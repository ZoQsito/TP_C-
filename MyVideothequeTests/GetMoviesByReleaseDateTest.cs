namespace MyvideothequeTests;

[TestClass]
public class Videotheque_GetMoviesByReleaseDateShould
{
    [TestMethod]
    public void ReturnEmptyArray_WhenNoMoviesAdded()
    {
        // Arrange
        Videotheque videotheque = new Videotheque();
        int releaseDate = 2022;

        // Act
        Movie[] moviesByReleaseDate = videotheque.GetMoviesByReleaseDate(releaseDate);

        // Assert
        Assert.AreEqual(0, moviesByReleaseDate.Length);
    }

    [TestMethod]
    public void ReturnMovies_WhenMoviesAdded()
    {
        // Arrange
        Videotheque videotheque = new Videotheque();
        videotheque.AddMovie("One Piece Red", "Goro Taniguchi", 2022, 6.2m);
        videotheque.AddMovie("Avengers: Endgame", "Anthony Russo", 2019, 8.9m);
        videotheque.AddMovie("Justice League", "Zack Snyder", 2021, 7.6m);
        int releaseDate = 2022;

        // Act
        Movie[] moviesByReleaseDate = videotheque.GetMoviesByReleaseDate(releaseDate);

        // Assert
        Assert.AreEqual(1, moviesByReleaseDate.Length);
        Assert.AreEqual("One Piece Red", moviesByReleaseDate[0].Title);
        Assert.AreEqual("Goro Taniguchi", moviesByReleaseDate[0].Director);
        Assert.AreEqual(2022, moviesByReleaseDate[0].ReleaseDate);
        Assert.AreEqual(6.2m, moviesByReleaseDate[0].Note);
    }
}