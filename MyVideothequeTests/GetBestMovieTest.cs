
namespace MyvideothequeTests;

[TestClass]
public class Videotheque_GetBestMovieShould
{
    [TestMethod]
    public void ReturnNull_WhenNoMoviesAdded()
    {
        // Arrange
        Videotheque videotheque = new Videotheque();

        // Act
        Movie bestMovie = videotheque.GetBestMovie();

        // Assert
        Assert.IsNull(bestMovie);
    }

    [TestMethod]
    public void ReturnBestMovie_WhenMoviesAdded()
    {
        // Arrange
        Videotheque videotheque = new Videotheque();
        videotheque.AddMovie("One Piece Red", "Goro Taniguchi", 2022, 6.2m);
        videotheque.AddMovie("Avengers: Endgame", "Anthony Russo", 2019, 8.9m);

        // Act
        Movie bestMovie = videotheque.GetBestMovie();

        // Assert
        Assert.AreEqual("Avengers: Endgame", bestMovie.Title);
        Assert.AreEqual("Anthony Russo", bestMovie.Director);
        Assert.AreEqual(2019, bestMovie.ReleaseDate);
        Assert.AreEqual(8.9m, bestMovie.Note);
    }
}

