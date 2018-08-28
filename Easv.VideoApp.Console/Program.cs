using System;
using System.Collections.Generic;
using Easv.VideoApp.Core.DomainService;
using Easv.VideoApp.Core.Entity;
using Easv.VideoApp.Infrastructure.Data.Repositories;

namespace Easv.VideoApp.ConsoleApp
{
    class Program
    {
        //Infrastructure.Data

        static IVideoRepository videoRepository;
        static void Main(string[] args)
        {
            videoRepository = new VideoRepository();
            //Infrastructure.Data
            //Initialise Data - Seed Database
            videos.Add(new Video
            {
                Id = id++,
                Genre = "Action",
                Name = "Hello Kitty"
            });
            videos.Add(new Video
            {
                Id = id++,
                Genre = "Romance",
                Name = "Die Hard"
            });
            videos.Add(new Video
            {
                Id = id++,
                Genre = "Comedy",
                Name = "Saw"
            });
            videos.Add(new Video
            {
                Id = id++,
                Genre = "Thriller",
                Name = "Peter Plys"
            });

            //UI
            string[] menuEnhender =
            {
                "List af alle film",
                "Tilføj film",
                "Fjern film",
                "Ændre filmg",
                "Exit"
            };

            var valg = VideoMenu(menuEnhender);

            while (valg != 5)
            {
                switch (valg)
                {
                    case 1:
                        VisFilm();
                        break;
                    case 2:
                        TilføjFilm();
                        break;
                    case 3:
                        SletFilm();
                        break;
                    case 4:
                        ÆndreFilm();
                        break;
                    default:
                        break;
                }
                valg = VideoMenu(menuEnhender);
            }
            Console.WriteLine("Farvel");


            Console.ReadLine();
        }

        private static Video FindVidMedID()
        {
            Console.WriteLine("Skriv id på filmen ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID er altid et tal");
            }

            Video videoFundet = null;

            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    videoFundet = video;
                }
            }
            Console.WriteLine($"Gammel Video Info = ID: {videoFundet.Id} | Navn: {videoFundet.Name} | Genre: {videoFundet.Genre} ");
            return videoFundet;
        }

        private static void ÆndreFilm()
        {
            var video = FindVidMedID();

            Console.WriteLine("Skrive filmens Navn");
            video.Name = Console.ReadLine();
            Console.WriteLine("Skrive filmens Genre");
            video.Genre = Console.ReadLine();

        }

        private static void SletFilm()
        {
            var videoFundet = FindVidMedID();

            if (videoFundet != null)
            {
                videos.Remove(videoFundet);
            }
        }

        private static void TilføjFilm()
        {
            //UI
            Console.WriteLine("Skrive filmens Navn");
            var navn = Console.ReadLine();
            Console.WriteLine("Skrive filmens Genre");
            var genre = Console.ReadLine();

            //CreateVideoService(navn, genre);

            videos.Add(new Video
            {
                Id = id++,
                Name = navn,
                Genre = genre
            });
        }

        //private static void CreateVideoService(string navn, string genre)
        //{
        //    videos.Add(new Video
        //    {
        //        Id = id++,
        //        Name = navn,
        //        Genre = genre
        //    });
        //}

        private static void VisFilm()
        {
            Console.WriteLine("\nListe af film");

            //GetVideos() from VideoService
            //VideoService needs a way to GetAll() from VideoRepository
            //List<Video> videoList = GetVideoService();
            foreach (var vid in videos)
            {
                Console.WriteLine($"Id: {vid.Id} | Navn: {vid.Name} | Genre: {vid.Genre}");

            }
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("\n");
        }

        //private static List<Video> GetVideoService()
        //{
        //    return GetAllRepository();
        //}

        //private static List<Video> GetAllRepository()
        //{
        //    return videos;
        //}


        //UI
        public static int VideoMenu(string[] menuEnhender)
        {
            //Console.Clear();
            Console.WriteLine("Skriv et tal for at vælge: \n");

            for (int i = 0; i < menuEnhender.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuEnhender[i]);
            }
            int valg;
            while (!int.TryParse(Console.ReadLine(), out valg) || valg < 1 || valg > 5)
            {
                Console.WriteLine("Det ikke et tal på listen");
            }
            Console.WriteLine("Valg: " + valg);
            return valg;

        }
    }
}
