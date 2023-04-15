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
    var genres = _context.Genres?.ToList();
    if (genres is null)
      return NotFound("Couldn't find any genres.");
    return genres;
  }

  [HttpGet("{id:int}", Name = "GetGenre")]
  public ActionResult<Genre> Get(int id)
  {
    var genre = _context.Genres?.FirstOrDefault(g => g.GenreId == id);
    if (genre is null)
      return NotFound("Couldn't find refered genre.");
    return genre;
  }

}
