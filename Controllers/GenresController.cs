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

  [HttpPost]
  public ActionResult Post(Genre genre)
  {
    if (genre is null)
      return BadRequest();
    _context.Genres?.Add(genre);
    _context.SaveChanges();

    return new CreatedAtRouteResult("GetGenre", new { id = genre.GenreId }, genre);
  }

  [HttpPut("{id:int}")]
  public ActionResult Put(int id, Genre genre)
  {
    if (id != genre.GenreId)
      return BadRequest();

    _context.Entry(genre).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(genre);
  }

  [HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
    var genre = _context.Genres?.FirstOrDefault(g => g.GenreId == id);
    if (genre is null)
      return NotFound("Couldn't find refered genre.");

    _context.Genres?.Remove(genre);
    _context.SaveChanges();

    return Ok($"Genre {genre.Name} deleted.");
  }
}
