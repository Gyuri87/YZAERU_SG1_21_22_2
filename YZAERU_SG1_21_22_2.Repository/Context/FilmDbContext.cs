using Microsoft.EntityFrameworkCore;
using YZAERU_SG1_21_22_2.Models.Entities;

namespace YZAERU_SG1_21_22_2.Repository.Context
{
    public class FilmDbContext : DbContext
    {

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<ActorFilm> ActorFilms { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Director> Directors { get; set; }

        public FilmDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\film.mdf;Integrated Security=True;Connection Timeout=30;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                        .HasOne(f => f.Director)
                        .WithMany(d => d.Films)
                        .HasForeignKey(f => f.DirectorId);

            modelBuilder.Entity<ActorFilm>()
                        .HasOne(af => af.Actor)
                        .WithMany(a => a.ActorFilms)
                        .HasForeignKey(af => af.ActorId);

            modelBuilder.Entity<ActorFilm>()
                        .HasOne(af => af.Film)
                        .WithMany(f => f.ActorFilms)
                        .HasForeignKey(af => af.FilmId);

            var director1 = new Director() { Id = 1, Name = "George Lucas" };
            var director2 = new Director() { Id = 2, Name = "Steven Spielberg" };
            var director3 = new Director() { Id = 3, Name = "Anthony Russo" };

            var film1 = new Film() { Id = 1, DirectorId = 1, Title = "Csillagok háborúja", Length = 121, IsTheBest=true, RelaseYear=1977, Type="scifi" };
            var film2 = new Film() { Id = 2, DirectorId = 1, Title = "A Jedi visszatér", Length = 131, IsTheBest = true, RelaseYear = 1987, Type = "scifi" };
            var film3 = new Film() { Id = 3, DirectorId = 3, Title = "Bosszúállók: Végjáték", Length = 181, IsTheBest = false, RelaseYear = 2019, Type = "akció" };
            var film4 = new Film() { Id = 4, DirectorId = 3, Title = "Bosszúállók: Végtelen háború", Length = 149, IsTheBest = false, RelaseYear = 2020, Type = "akció" };
            var film5 = new Film() { Id = 5, DirectorId = 2, Title = "Az elveszett frigyláda fosztogatói", Length = 115, IsTheBest = false, RelaseYear = 1986, Type = "történelmi" };
            var film6 = new Film() { Id = 6, DirectorId = 2, Title = "Jurassic Park", Length = 127, IsTheBest = false, RelaseYear = 1995, Type = "fantasy" };
            var film7 = new Film() { Id = 7, DirectorId = 1, Title = "Birodalom visszavág", Length = 121, IsTheBest = true, RelaseYear = 1980, Type = "scifi" };

            var actor1 = new Actor() { Id = 1, Name = "Harrison Ford", Gender = "man" };
            var actor2 = new Actor() { Id = 2, Name = "Mark Hamill", Gender = "man" };
            var actor3 = new Actor() { Id = 3, Name = "Carrie Fisher", Gender = "woman" };

            var actor4 = new Actor() { Id = 4, Name = "Robert Downey Jr.", Gender = "man" };
            var actor5 = new Actor() { Id = 5, Name = "Chris Evans", Gender = "man" };
            var actor6 = new Actor() { Id = 6, Name = "Mark Ruffalo'", Gender = "man" };

            var actor7 = new Actor() { Id = 7, Name = "Karen Allen", Gender = "woman" };
            var actor8 = new Actor() { Id = 8, Name = "John Rhys-Davies", Gender = "man" };

            var actor9 = new Actor() { Id = 9, Name = "Sam Neill", Gender = "man" };
            var actor10 = new Actor() { Id = 10, Name = "Richard Attenborough", Gender = "man" };
            var actor11 = new Actor() { Id = 11, Name = "Jeff Goldblum", Gender = "man" };

            var actorFilm1 = new ActorFilm() { Id = 1, ActorId = 1, FilmId = 1 };
            var actorFilm2 = new ActorFilm() { Id = 2, ActorId = 2, FilmId = 1 };
            var actorFilm3 = new ActorFilm() { Id = 3, ActorId = 3, FilmId = 1 };

            var actorFilm4 = new ActorFilm() { Id = 4, ActorId = 1, FilmId = 2 };
            var actorFilm5 = new ActorFilm() { Id = 5, ActorId = 2, FilmId = 2 };
            var actorFilm6 = new ActorFilm() { Id = 6, ActorId = 3, FilmId = 2 };

            var actorFilm7 = new ActorFilm() { Id = 7, ActorId = 4, FilmId = 3 };
            var actorFilm8 = new ActorFilm() { Id = 8, ActorId = 5, FilmId = 3 };
            var actorFilm9 = new ActorFilm() { Id = 9, ActorId = 6, FilmId = 3 };

            var actorFilm10 = new ActorFilm() { Id = 10, ActorId = 4, FilmId = 4 };
            var actorFilm11 = new ActorFilm() { Id = 11, ActorId = 5, FilmId = 4 };
            var actorFilm12 = new ActorFilm() { Id = 12, ActorId = 6, FilmId = 4 };

            var actorFilm13 = new ActorFilm() { Id = 13, ActorId = 1, FilmId = 5 };
            var actorFilm14 = new ActorFilm() { Id = 14, ActorId = 7, FilmId = 5 };
            var actorFilm15 = new ActorFilm() { Id = 15, ActorId = 8, FilmId = 5 };

            var actorFilm16 = new ActorFilm() { Id = 16, ActorId = 9, FilmId = 6 };
            var actorFilm17 = new ActorFilm() { Id = 17, ActorId = 10, FilmId = 6 };
            var actorFilm18 = new ActorFilm() { Id = 18, ActorId = 11, FilmId = 6 };

            var actorFilm19 = new ActorFilm() { Id = 19, ActorId = 1, FilmId = 7 };

            modelBuilder.Entity<Director>().HasData(director1, director2, director3);

            modelBuilder.Entity<Film>().HasData(film1, film2, film3, film4, film5, film6, film7);

            modelBuilder.Entity<Actor>().HasData(actor1, actor2, actor3, actor4, actor5, actor6, actor7, actor8, actor9, actor10, actor11);

            modelBuilder.Entity<ActorFilm>().HasData(actorFilm1, actorFilm2, actorFilm3, actorFilm4, actorFilm5, actorFilm6, actorFilm7, actorFilm8, actorFilm9, actorFilm10, actorFilm11, actorFilm12, actorFilm13, actorFilm14, actorFilm15, actorFilm16, actorFilm17, actorFilm18, actorFilm19);
        }
    }
}
