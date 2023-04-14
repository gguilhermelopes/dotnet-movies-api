namespace MoviesApi.Models;

public class Movie
{
  public int MovieId { get; set; }
  public string? Name { get; set; }
  public int Year { get; set; }
  public string? Sinopsis { get; set; }
  public string? Genre { get; set; }
  public string? Director { get; set; }
  public string? ImageURI { get; private set; }
  public DateTime EntryDate { get; set; }
}