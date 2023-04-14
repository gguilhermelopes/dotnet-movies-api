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
    var movies = _context.Movies?.ToList();
    if (movies is null)
      return NotFound("Couldn't find movies.");
    return movies;
  }

  [HttpGet("{id:int}", Name = "GetMovie")]

  public ActionResult<Movie> Get(int id)
  {
    var movie = _context.Movies?.FirstOrDefault(p => p.MovieId == id);
    if (movie is null)
      return NotFound("Couldn't find refered movie.");
    return movie;
  }

  [HttpPost]
  public ActionResult Post(Movie movie)
  {
    if (movie is null)
      return BadRequest();
    _context.Movies?.Add(movie);
    _context.SaveChanges();

    return new CreatedAtRouteResult("GetMovie", new { id = movie.MovieId }, movie);
  }

  [HttpPut("{id:int}")]

  public ActionResult Put(int id, Movie movie)
  {
    if (id != movie.MovieId)
      return BadRequest();

    _context.Entry(movie).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(movie);
  }
}
