using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly JukeBoxDBContext _context;
        public IAlbumRepo AlbumRepo { get; }
        public IMachineRepo JukeboxRepo { get; }
        public ISongRepo SongRepo { get; }

        public UnitOfWork(JukeBoxDBContext context, ISongRepo songs,
            IMachineRepo jukeboxes, IAlbumRepo albums)
        {
            _context = context;
            AlbumRepo = albums;
            JukeboxRepo = jukeboxes;
            SongRepo = songs;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
