using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAlbumRepo AlbumRepo { get; }
        IMachineRepo JukeboxRepo { get; }
        ISongRepo SongRepo { get; }
        void Save();
    }
}
