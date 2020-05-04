using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Initializer
    {
        private static bool initialized = false;
        public static void Init(JukeBoxDBContext context)
        {
            if (initialized)
             {
                 return;
             }


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            Song Song1 = new Song()
            {
                Name = "Song1",
                Genre = "pop",
                Singer = "Dua Lipa",
                Duration = 22
            };

            Song Song2 = new Song()
            {
                Name = "Song2",
                Genre = "pop",
                Singer = "Dua Lipa",
                Duration = 32
            };

            Song Song3 = new Song()
            {
                Name = "Song3",
                Genre = "hiphop",
                Singer = "Lana Del Rey",
                Duration = 55
            };

            Song Song4 = new Song()
            {
                Name = "Song4",
                Genre = "hiphop",
                Singer = "Lana Del Rey",
                Duration = 22
            };

            Song Song5 = new Song()
            {
                Name = "Song5",
                Genre = "rock",
                Singer = "Queen",
                Duration = 22
            };

            Song Song6 = new Song()
            {
                Name = "Song6",
                Genre = "rock",
                Singer = "Queen",
                Duration = 22
            };
            Song Song7 = new Song()
            {
                Name = "Song7",
                Genre = "rock",
                Singer = "Queen",
                Duration = 22
            };


            Album a = new Album()
            {
                Name = "a",
                Price = 44, 
                Songs = new List<Song>() { Song1, Song2 }
            };

            Album Young = new Album()
            {
                Name = "Young and beautiful",
                Price = 32, 
                Songs = new List<Song>() { Song3, Song4 }
            };

            Album Night = new Album()
            {
                Name = "Night In The Opera",
                Price = 12,
                Songs = new List<Song>() { Song5, Song6, Song7 }
            };

           
            Machine Jukebox = new Machine()
            {
               
                albums = new List<Album>() { a, Young, Night }
            };

            context.Machines.Add(Jukebox);

            context.SaveChanges();

            initialized = true;
        }


}
}
