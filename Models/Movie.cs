using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesApi.Models;


public class Movie
{
  public int MovieId { get; set; }
  [Required]
  [StringLength(80)]
  public string? Name { get; set; }
  public int Year { get; set; }
  [Required]
  [StringLength(1000)]
  public string? Sinopsis { get; set; }
  [Required]
  [StringLength(80)]
  public string? Director { get; set; }
  [Required]
  [StringLength(300)]
  public string? ImageURI { get; set; }
  public DateTime EntryDate { get; set; }
  public int GenreId { get; set; }

  [JsonIgnore]
  public Genre? Genre { get; set; }
}