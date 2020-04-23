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
        public IRepository<Song> SongRepo { get; }
        public IRepository<Machine> JukeboxRepo { get; }
        public IRepository<Album> AlbumRepo { get; }

        public UnitOfWork(JukeBoxDBContext context, IRepository<Album> albums,
            IRepository<Machine> jukeboxes, IRepository<Song> songs)
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
