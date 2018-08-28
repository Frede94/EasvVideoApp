using Easv.VideoApp.Core.DomainService;
using Easv.VideoApp.Core.Entity;
using Easv.VideoApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.VideoApp.ConsoleApp
{

    class Printer
    {
        private IVideoRepository videoRepository;

        public Printer()
        {
            videoRepository = new VideoRepository();
            //Infrastructure.Data
            //Initialise Data - Seed Database
            var vid1 = new Video()
            {
                Genre = "Action",
                Name = "Hello Kitty"
            };
            videoRepository.Create(vid1);
            var vid2 = new Video()
            {
                Genre = "Romance",
                Name = "Die Hard"
            };
            videoRepository.Create(vid2);
            var vid3 = new Video()
            {
                Genre = "Comedy",
                Name = "Saw"
            };
            videoRepository.Create(vid3);
            var vid4 = new Video()
            {
                Genre = "Thriller",
                Name = "Peter Plys"
            };
            videoRepository.Create(vid4);

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
        private Video FindVidMedID()
        {
            Console.WriteLine("Skriv id på filmen ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID er altid et tal");
            }

            return videoRepository.ReadById(id);
            //Console.WriteLine($"Gammel Video Info = ID: {videoFundet.Id} | Navn: {videoFundet.Name} | Genre: {videoFundet.Genre} ");

        }

        private void ÆndreFilm()
        {
            var video = FindVidMedID();

            Console.WriteLine("Skrive filmens Navn");
            video.Name = Console.ReadLine();
            Console.WriteLine("Skrive filmens Genre");
            video.Genre = Console.ReadLine();

        }

        private void SletFilm()
        {
            var videoFundet = FindVidMedID();

            if (videoFundet != null)
            {
                videoRepository.delete(videoFundet.Id);
            }
        }

        private void TilføjFilm()
        {
            //UI
            Console.WriteLine("Skrive filmens Navn");
            var navn = Console.ReadLine();
            Console.WriteLine("Skrive filmens Genre");
            var genre = Console.ReadLine();

            //CreateVideoService(navn, genre);

            var vid = new Video
            {
                Name = navn,
                Genre = genre
            };
            videoRepository.Create(vid);
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

        private void VisFilm()
        {
            Console.WriteLine("\nListe af film");

            //GetVideos() from VideoService
            //VideoService needs a way to GetAll() from VideoRepository
            //List<Video> videoList = GetVideoService();
            var vids = videoRepository.ReadAll();
            foreach (var vid in vids)
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
