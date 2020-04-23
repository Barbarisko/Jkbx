using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Album> AlbumRepo { get; }
        IRepository<Machine> JukeboxRepo { get; }
        IRepository<Song> SongRepo { get; }
        void Save();
    }
}
