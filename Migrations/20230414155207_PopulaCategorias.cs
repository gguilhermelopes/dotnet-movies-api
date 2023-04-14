using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
  /// <inheritdoc />
  public partial class PopulaCategorias : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {
      mb.Sql("Insert into Genres(Name,ImageURI) Values('Horror', 'https://img.icons8.com/ios/100/null/horror.png')");
      mb.Sql("Insert into Genres(Name,ImageURI) Values('Fantasy', 'https://img.icons8.com/ios/100/null/fantasy.png')");
      mb.Sql("Insert into Genres(Name,ImageURI) Values('Sci-Fi', 'https://img.icons8.com/ios/100/null/sci-fi.png')");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
      mb.Sql("Delete from Genres");
    }
  }
}
