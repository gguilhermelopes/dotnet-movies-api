using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Genre
{
  public Genre()
  {
    Movies = new Collection<Movie>();
  }
  public int GenreId { get; set; }
  [Required]
  [StringLength(80)]
  public string? Name { get; set; }
  [Required]
  [StringLength(300)]
  public string? ImageURI { get; set; }
  public ICollection<Movie>? Movies { get; set; }
}