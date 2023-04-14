using System.Collections.ObjectModel;

namespace MoviesApi.Models;

public class Genre
{
  public Genre()
  {
    Movies = new Collection<Movie>();
  }
  public int GenreId { get; set; }
  public string? Name { get; set; }
  public string? ImageURI { get; set; }
  public ICollection<Movie>? Movies { get; set; }
}