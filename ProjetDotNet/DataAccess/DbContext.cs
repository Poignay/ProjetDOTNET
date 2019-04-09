using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace ProjetDotNet.DataAccess
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        private static DbContext _context = null;
        public static async Task<DbContext> GetCurrent()
        {
            if (_context == null)
            {
                _context = new DbContext(
                    Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }

        internal DbContext(DbContextOptions options) : base(options) { }
        private DbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public string DatabasePath { get; }

        public DbSet<Class.Film> Films { get; set; }
        public DbSet<Class.Personne> Personnes { get; set; }
        public DbSet<Class.Serie> Series { get; set; }
        public DbSet<Class.Pret> Prets { get; set; }
        public DbSet<Class.Media_Personne> Media_Personnes { get; set; }
        public DbSet<Class.Media_Genre> Media_Genres { get; set; }
        public DbSet<Class.Genre> Genres { get; set; }
        public DbSet<Class.Episode> Episodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class.Media_Personne>()
                                .HasKey(ab => new { ab.id_Media, ab.id_Personne });

            modelBuilder.Entity<Class.Media_Genre>()
                                .HasKey(ab => new { ab.Id_genre, ab.Id_media });

            modelBuilder.Entity<Class.Pret>()
                                .HasKey(ab => new { ab.Id_media, ab.Id_personne });

            //modelBuilder.Entity<Model.AuthorBook>().HasOne(ab => ab.Book)
            //                                       .WithMany(b => b.Authors)
            //                                       .HasForeignKey(ab => ab.BookId);
        }

    }
}
