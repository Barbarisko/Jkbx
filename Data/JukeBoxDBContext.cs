using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

    public class EFDBContextFactory : IDesignTimeDbContextFactory<JukeBoxDBContext>
    {
        public JukeBoxDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JukeBoxDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JukeboxDB;Trusted_Connection=True;", b=>b.MigrationsAssembly("Data"));

            return new JukeBoxDBContext(optionsBuilder.Options);
        }
    }
}
