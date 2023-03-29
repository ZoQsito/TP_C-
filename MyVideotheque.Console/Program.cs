using System;
using System.Collections.Generic;
using System.IO;
namespace MyVideotheque;
public class Program
{
    private static Videotheque videotheque;

    public static void Main(string[] args)
    {
        InitializeVideotheque();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nQue voulez-vous faire ?");
            Console.WriteLine("1. Lister la vidéothèque");
            Console.WriteLine("2. Afficher le titre du film le mieux noté");
            Console.WriteLine("3. Ajouter un nouveau film");
            Console.WriteLine("0. Quitter");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListVideotheque();
                    break;
                case "2":
                    DisplayBestMovie();
                    break;
                case "3":
                    AddNewMovie();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Commande inconnue !");
                    break;
            }
        }
    }

    private static void InitializeVideotheque()
    {
        videotheque = new Videotheque();
        videotheque.AddMovie("Pulp Fiction", "Quentin Tarantino", 1994, 8.9m);
        videotheque.AddMovie("Fight Club", "David Fincher", 1999, 8.8m);
        videotheque.AddMovie("Matrix", "Sœurs Wachowski", 1999, 8.7m);
        videotheque.AddMovie("Django Unchained", "Quentin Tarantino", 2012, 8.4m);
        videotheque.AddMovie("American Beauty", "Sam Mendes", 1999, 8.4m);
        videotheque.AddMovie("Le roi du curling", "Ole Endresen", 2011, 6.1m);
    }

    private static void ListVideotheque()
    {
        Console.WriteLine("\nVidéothèque :");
        foreach (Movie movie in videotheque.movies)
        {
            Console.WriteLine("- " + movie.Title + " (" + movie.ReleaseDate + ") : " + movie.Note + "/10");
        }
    }

    private static void DisplayBestMovie()
    {
        Movie bestMovie = videotheque.GetBestMovie();
        if (bestMovie != null)
        {
            Console.WriteLine("\nLe film le mieux noté est : " + bestMovie.Title);
        }
        else
        {
            Console.WriteLine("\nAucun film dans la vidéothèque !");
        }
    }

    static void AddNewMovie()
    {
        Console.WriteLine("Ajout d'un nouveau film :");

        Console.Write("Titre : ");
        string titre = Console.ReadLine();

        Console.Write("Réalisateur : ");
        string realisateur = Console.ReadLine();

        Console.Write("Année de sortie : ");
        int anneeSortie;
        while (!int.TryParse(Console.ReadLine(), out anneeSortie))
        {
            Console.WriteLine("Année de sortie invalide. Veuillez entrer un nombre.");
        }

        Console.Write("Note (sur 10) : ");
        decimal note;
        while (!decimal.TryParse(Console.ReadLine(), out note))
        {
            Console.WriteLine("Note invalide. Veuillez entrer un nombre décimal.");
        }

        videotheque.AddMovie(titre, realisateur, anneeSortie, note);
        Console.WriteLine("Le film a été ajouté à la vidéothèque.");
    }
}