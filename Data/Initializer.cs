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
                Singer = "Singer1",
                Duration = 22
            };

            Song Song2 = new Song()
            {
                Name = "Song2",
                Genre = "pop",
                Singer = "Singer1",
                Duration = 32
            };

            Song Song3 = new Song()
            {
                Name = "Song3",
                Genre = "rock",
                Singer = "Singer2",
                Duration = 55
            };

            Song Song4 = new Song()
            {
                Name = "Song4",
                Genre = "rock",
                Singer = "Singer2",
                Duration = 22
            };

            Song Song5 = new Song()
            {
                Name = "Song5",
                Genre = "hiphop",
                Singer = "Singer3",
                Duration = 22
            };

            Song Song6 = new Song()
            {
                Name = "Song6",
                Genre = "hiphop",
                Singer = "Singer3",
                Duration = 22
            };
            Song Song7 = new Song()
            {
                Name = "Song7",
                Genre = "hiphop",
                Singer = "Singer3",
                Duration = 22
            };


            Album a = new Album()
            {
                Name = "a",
                Price = 44, 
                Songs = new List<Song>() { Song1, Song2 }
            };

            Album b = new Album()
            {
                Name = "b",
                Price = 32, 
                Songs = new List<Song>() { Song3, Song4 }
            };

            Album c = new Album()
            {
                Name = "c",
                Price = 12,
                Songs = new List<Song>() { Song5, Song6, Song7 }
            };

           
            Machine Jukebox = new Machine()
            {
               
                albums = new List<Album>() { a, b, c }
            };

            context.Machines.Add(Jukebox);

            context.SaveChanges();

            initialized = true;
        }


}
}
