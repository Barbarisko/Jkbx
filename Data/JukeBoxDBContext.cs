using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class JukeBoxDBContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Song> Songs { get; set; }

        public JukeBoxDBContext(DbContextOptions<JukeBoxDBContext> options) : base(options)
        {
            Initializer.Init(this);
        }
    }
}
