using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Business.Services
{
    public class MachineService : IMachineService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public MachineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        List<SongModel> songs = new List<SongModel>();

        public List<SongModel> findSortedListOfSongs(MachineModel jukebox, 
                                                     string albumname, 
                                                     string singer, 
                                                     string genre,
                                                     int currentamount)
        {
            if (currentamount <= 0)
            {
                //MessageBox.Show("input money");
                return null;
            }

            if (singer == "" && genre == "" && albumname == "")
            {
                foreach (AlbumModel al in jukebox.albums)
                {
                    if (al.Price <= currentamount)
                    {
                        foreach (SongModel s in al.Songs) songs.Add(s);
                    }

                    else
                    {
                        if (currentamount <= 0)
                        {
                            MessageBox.Show("input money");
                        }
                    }
                }
                return songs;

            }

            foreach (AlbumModel al in jukebox.albums)
            {
                if (al.Price <= currentamount)
                {
                    if (albumname == "")
                    {
                        songs.AddRange(al.Songs);
                    }
                    else if (albumname == al.Name)
                    {
                        foreach (SongModel c in al.Songs)
                        {
                            songs.Add(c);
                        }
                    }


                    if (genre != "")
                    {
                        songs.RemoveAll(Song => Song.Genre != genre);
                    }
                    if (singer != "")
                    {
                        songs.RemoveAll(Song => Song.Singer != singer);
                    }

                }
                else
                {
                    if (currentamount <= 0)
                    {
                        MessageBox.Show("input money");
                    }
                }


            }

            return songs;
        }

        public List<AlbumModel> GetAlbums(MachineModel jukebox)
        {
            return jukebox.albums;
        }

        public MachineModel JukeboxFill()
        {
            //string text = File.ReadAllText(@"C:\info.txt");
            //string[] AlArr = text.Split(' ', '\n');

            //jukebox.albums = new List<AlbumModel>();
            MachineModel jukebox = new MachineModel();

            var jukeEntities = _unitOfWork.JukeboxRepo.GetAll();
            var jukeList = _mapper.Map<IEnumerable<MachineModel>>(jukeEntities);

            foreach (MachineModel a in jukeList)
            {
                jukebox = a;
            }

            return jukebox;

            //for (int i = 0; i <= AlArr.Length - 1; i = i + 6)
            //{
                
            //    jukebox.albums.Add(
            //     new AlbumModel()
            //     {
            //         Name = AlArr[i + 1],
            //         Songs = new List<SongModel>(),
            //         Price = Convert.ToInt32(AlArr[i + 3]),
            //         Releasedate = AlArr[i + 5]
            //     });

                //    for (int j = 0; j < jukebox.albums.Count; j++)
                //    {
                //        string pathToSongs = $"{jukebox.albums[j].Name}.txt";
                //        string text1 = File.ReadAllText(pathToSongs);
                //        string[] SongArr = text1.Split(' ', '\n');

                //        for (int k = 0; k <= SongArr.Length - 1; k = k + 8)
                //        {
                //            jukebox.albums[j].Songs.Add(
                //            new SongModel()
                //            {
                //                Name = SongArr[k + 1],
                //                Duration = Convert.ToDecimal(SongArr[k + 3]),
                //                Genre = SongArr[k + 5],
                //                Singer = SongArr[k + 7]
                //            });
                //        }

                //    }
                //}
            }

        public MachineModel loadFromFile(string path)
        {
            SerializeJson serializeJson = new SerializeJson(typeof(MachineModel));
            return (MachineModel)serializeJson.Deserialize(path);
        }

        public void saveToFile(string path)
        {
            SerializeJson serializeJson = new SerializeJson(typeof(MachineModel));
            serializeJson.Serialize(this, path);
        }
    }
}
