using Microsoft.AspNetCore.Mvc;
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
    if (movies is null) return NotFound("Couldn't find movies.");
    return movies;
  }

  [HttpGet("{id:int}")]

  public ActionResult<Movie> Get(int id)
  {
    var movie = _context.Movies?.FirstOrDefault(p => p.MovieId == id);
    if (movie is null) return NotFound("Couldn't find refered movie.");
    return movie;
  }
}
