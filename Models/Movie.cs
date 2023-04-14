namespace MoviesApi.Models;

public class Movie
{
  public int MovieId { get; set; }
  public string? Name { get; set; }
  public int Year { get; set; }
  public string? Sinopsis { get; set; }
  public string? Director { get; set; }
  public string? ImageURI { get; set; }
  public DateTime EntryDate { get; set; }
  public int GenreId { get; set; }
  public Genre? Genre { get; set; }
}