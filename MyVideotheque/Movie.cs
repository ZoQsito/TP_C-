using System;
using System.Collections.Generic;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseDate { get; set; }
    public decimal Note { get; set; }
}

public class Videotheque
{
    public List<Movie> movies = new List<Movie>();

    public void AddMovie(string title, string director, int releaseDate, decimal note)
    {
        Movie movie = new Movie();
        movie.Title = title;
        movie.Director = director;
        movie.ReleaseDate = releaseDate;
        movie.Note = note;
        movies.Add(movie);
    }

    public Movie GetBestMovie()
    {
        Movie bestMovie = null;
        decimal bestNote = 0;

        foreach (Movie movie in movies)
        {
            if (movie.Note > bestNote)
            {
                bestNote = movie.Note;
                bestMovie = movie;
            }
        }

        return bestMovie;
    }

    public Movie[] GetMoviesByReleaseDate(int releaseDate)
    {
        List<Movie> moviesByReleaseDate = new List<Movie>();

        foreach (Movie movie in movies)
        {
            if (movie.ReleaseDate == releaseDate)
            {
                moviesByReleaseDate.Add(movie);
            }
        }

        return moviesByReleaseDate.ToArray();
    }

    public Movie[] GetMoviesByDirector(string director)
    {
        List<Movie> moviesByDirector = new List<Movie>();

        foreach (Movie movie in movies)
        {
            if (movie.Director.Equals(director))
            {
                moviesByDirector.Add(movie);
            }
        }

        return moviesByDirector.ToArray();
    }
}
