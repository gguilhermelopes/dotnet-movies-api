using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[Route("[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
  private readonly AppDbContext _context;

  public MoviesController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Movie>> Get()
  {
    try
    {
      var movies = _context.Movies?.AsNoTracking().ToList();
      if (movies is null)
        return NotFound("Couldn't find movies.");
      return movies;
    }
    catch (System.Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpGet("{id:int}", Name = "GetMovie")]
  public ActionResult<Movie> Get(int id)
  {
    try
    {
      var movie = _context.Movies?.AsNoTracking().FirstOrDefault(m => m.MovieId == id);
      if (movie is null)
        return NotFound("Couldn't find refered movie.");
      return movie;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpPost]
  public ActionResult Post(Movie movie)
  {
    try
    {
      if (movie is null)
        return BadRequest();
      _context.Movies?.Add(movie);
      _context.SaveChanges();

      return new CreatedAtRouteResult("GetMovie", new { id = movie.MovieId }, movie);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpPut("{id:int}")]

  public ActionResult Put(int id, Movie movie)
  {
    try
    {
      if (id != movie.MovieId)
        return BadRequest();

      _context.Entry(movie).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(movie);

    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
    try
    {
      var movie = _context.Movies?.FirstOrDefault(m => m.MovieId == id);

      if (movie is null)
        return NotFound("Couldn't find refered movie.");

      _context.Movies?.Remove(movie);
      _context.SaveChanges();

      return Ok($"{movie.Name} deleted.");
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }
}
