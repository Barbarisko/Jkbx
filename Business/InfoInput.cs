using System.Configuration;
using System.IO;

namespace Data
    {
    public static class InfoInput
    {
        public static string path = ConfigurationManager.AppSettings.Get("Path");
        public static string json = ConfigurationManager.AppSettings.Get("JsonPath");
        public static string original = ConfigurationManager.AppSettings.Get("PathToOriginal");


        //public static string path = @"info.txt";
        //public static string json = @"TestSong.json";
        //public static string original = @"StandartSaveFile.txt";

        public static string[] getAlbumsFromFile()
        {

            string text = File.ReadAllText(path);
            string[] alArr = text.Split(' ', '\n');
            return alArr;
        }

        public static string[] getSongsFromFile(string nameOfSong)
        {
            string pathToSongs = $"{nameOfSong}.txt";
            string text = File.ReadAllText(pathToSongs);
            string[]  songArr = text.Split(' ', '\n');
            return songArr;
        }
    }
}
