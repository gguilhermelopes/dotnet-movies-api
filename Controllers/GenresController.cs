using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[Route("[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
  private readonly AppDbContext _context;

  public GenresController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Genre>> Get()
  {
    try
    {
      var genres = _context.Genres?.AsNoTracking().ToList();
      if (genres is null)
        return NotFound("Couldn't find any genres.");
      return genres;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpGet("{id:int}", Name = "GetGenre")]
  public ActionResult<Genre> Get(int id)
  {
    try
    {
      var genre = _context.Genres?.AsNoTracking().FirstOrDefault(g => g.GenreId == id);
      if (genre is null)
        return NotFound("Couldn't find refered genre.");
      return genre;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpGet("movies")]
  public ActionResult<IEnumerable<Genre>> GetGenresMovies()
  {
    try
    {

      return _context.Genres?.AsNoTracking().Include(g => g.Movies).ToList();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpPost]
  public ActionResult Post(Genre genre)
  {
    try
    {
      if (genre is null)
        return BadRequest();

      _context.Genres?.Add(genre);
      _context.SaveChanges();

      return new CreatedAtRouteResult("GetGenre", new { id = genre.GenreId }, genre);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }

  [HttpPut("{id:int}")]
  public ActionResult Put(int id, Genre genre)
  {
    try
    {
      if (id != genre.GenreId)
        return BadRequest();

      _context.Entry(genre).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(genre);
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
      var genre = _context.Genres?.FirstOrDefault(g => g.GenreId == id);
      if (genre is null)
        return NotFound("Couldn't find refered genre.");

      _context.Genres?.Remove(genre);
      _context.SaveChanges();

      return Ok($"Genre {genre.Name} deleted.");
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Oops! It looks like something went wrong on our end. Our team has been notified and we are working to resolve the issue as soon as possible. Please try again later.");
    }
  }
}
