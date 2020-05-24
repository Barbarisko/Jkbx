using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class SongRepository : Repository<Song>, ISongRepo
    {
        private JukeBoxDBContext context;

        public SongRepository (JukeBoxDBContext _context):base(_context)
        {
            context = _context;
        }
        public void Add(Song entity)
        {
            context.Songs.Add(entity);
        }

        public IEnumerable<Song> GetAll()
        {
            return context.Songs.ToList();
        }
    }
}
