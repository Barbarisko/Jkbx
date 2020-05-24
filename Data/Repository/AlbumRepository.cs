using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
   public  class AlbumRepository : Repository<Album>, IAlbumRepo
    {
        private JukeBoxDBContext context;

        public AlbumRepository(JukeBoxDBContext _context):base(_context)
        {
            context = _context;
        }
        //public void Add(Album entity)
        //{
        //    context.Albums.Add(entity);
        //}

        //public IEnumerable<Album> GetAll()
        //{
        //    return context.Albums.ToList();
        //}
    }
}
