using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Migrations
{
  /// <inheritdoc />
  public partial class PopulaMovies : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder mb)
    {
      mb.Sql("Insert into Movies(Name,Year,Sinopsis,Director,ImageURI,EntryDate,GenreId) Values('The Thing', 1982, 'In remote Antarctica, a group of American research scientists are disturbed at their base camp by a helicopter shooting at a sled dog. When they take in the dog, it brutally attacks both human beings and canines in the camp and they discover that the beast can assume the shape of its victims. A resourceful helicopter pilot and the camp doctor lead the camp crew in a desperate, gory battle against the vicious creature before it picks them all off, one by one.', 'John Carpenter', 'https://xl.movieposterdb.com/22_03/1982/84787/xl_84787_039cdfd6.jpg?v=2023-02-24%2001:10:35', now(), 1)");

      mb.Sql("Insert into Movies(Name,Year,Sinopsis,Director,ImageURI,EntryDate,GenreId) Values('The Rocky Horror Picture Show',1975,'Sweethearts Brad and Janet, stuck with a flat tire during a storm, discover the eerie mansion of Dr. Frank-N-Furter, a transvestite scientist. As their innocence is lost, Brad and Janet meet a houseful of wild characters, including a rocking biker and a creepy butler. Through elaborate dances and rock songs, Frank-N-Furter unveils his latest creation: a muscular man named Rocky.','Jim Sharman','https://xl.movieposterdb.com/09_04/1975/73629/xl_73629_d6f3eac8.jpg?v=2023-03-12%2004:53:39',now(),2)");

      mb.Sql("Insert into Movies(Name,Year,Sinopsis,Director,ImageURI,EntryDate,GenreId) Values('Arrival',2016,'Taking place after alien crafts land around the world, an expert linguist is recruited by the military to determine whether they come in peace or are a threat.','Denis Villeneuve','https://xl.movieposterdb.com/22_10/2016/2543164/xl_arrival-movie-poster_a18b5408.jpg?v=2023-02-19%2019:20:31',now(),3)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder mb)
    {
      mb.Sql("Delete from Movies");
    }
  }
}
