using ConsoleTools;
using System;
using YZAERU_SG1_21_22_2.Logic.Services;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Program.Extensions;

namespace YZAERU_SG1_21_22_2.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new DependencyFactory();

            FilmLogic filmLogic = factory.GetFilmLogic();
            DirectorLogic directorLogic = factory.GetDirectorLogic();
            ActorLogic actorLogic = factory.GetActorLogic();
            ActorFilmLogic actorFilmLogic = factory.GetActorFilmLogic();

            var menu = new ConsoleMenu(args, 0)
                                    .Add("List of actors and actress", () => ShowActors(actorLogic))
                                    .Add("List of Movies", () => ShowFilms(filmLogic))
                                    .Add("List of directors", () => ShowDirectors(directorLogic))
                                    .Add("Movies and directors", () => ShowFilmsAndDirector(filmLogic))
                                    .Add("Movies and actors", () => ShowFilmsAndActor(actorFilmLogic))
                                    .Add("Insert film", () => InsertFilm(filmLogic))
                                    .Add("Delet movie", () => DeletFilm(filmLogic))
                                    .Add("Modified the movie titile by id.", () => UpdateFilm(filmLogic))
                                    .Add("Insert director", () => InsertDirector(directorLogic))
                                    .Add("Update director", () => UpdateDirector(directorLogic))
                                    .Add("Delet director", () => DeletDirector(directorLogic))
                                    .Add("Insert actor", () => InsertActor(actorLogic))
                                    .Add("Update actor", () => UpdateActor(actorLogic))
                                    .Add("Delet actor", () => DeletActor(actorLogic))
                                    .Add("Connect actor and movie", () => ConnectActorAndMovie(actorFilmLogic))
                                    .Add("Disconnect actor and movie", () => DisconnectActorAndMovie(actorFilmLogic))
                                    .Add("List of director and actor", () => GetDirectorAndActor(actorFilmLogic))
                                    .Add("Get favorite actor", () => GetFavoriteActor(actorFilmLogic))
                                    .Add("List of actors in which film she/he starred.", () => CountActorsMovies(actorFilmLogic))
                                    .Add("List of actor how many movie starred in.", () => CountDirectorMovies(directorLogic))
                                    .Add("Which  actor who has the acted in most films", () => GetTheActorWhoHasTheActedInMostFilms(actorFilmLogic))
                                    .Add("Which  actor who has the acted in least films.", () => GetTheActorWhoHasPlayedTheLeastNumberOfFilms(actorFilmLogic))
                                    .Add("All Actress", () => GetAllActress(actorLogic))
                                    .Add("All Actors", () => GetAllActors(actorLogic))
                                    .Add("Longest movie", () => GetMostLongestMovie(filmLogic))
                                    .Add("Get most longest movie async", () => GetMostLongestMovieAsync(filmLogic))
                                    .Add("Count movies of director async", () => CountMoviesOfDirectorAsync(directorLogic))
                                    .Add("Get director and actors async", () => GetDirectorAndActorsAsync(actorFilmLogic))
                                    .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

        /// <summary>
        /// Show List of movies.
        /// </summary>
        /// <param name="filmLogic">FilmLogic instance.</param>
        public static void ShowFilms(FilmLogic filmLogic)
        {
            filmLogic.GetAllFilms().DisplayListToConsol();

            Console.ReadKey();
        }

        /// <summary>
        /// Show all directors.
        /// </summary>
        /// <param name="directorLogic">DirectorLogic inctance.</param>
        public static void ShowDirectors(DirectorLogic directorLogic)
        {
            directorLogic.GetAllDirectors().DisplayListToConsol();

            Console.ReadKey();
        }

        /// <summary>
        /// Show all actors.
        /// </summary>
        /// <param name="actorLogic">ActorLogic inctance.</param>
        public static void ShowActors(ActorLogic actorLogic)
        {
            actorLogic.GetAllActors().DisplayListToConsol();

            Console.ReadKey();
        }

        /// <summary>
        /// Show all films and actors.
        /// </summary>
        /// <param name="filmLogic">FilmLogic.</param>
        public static void ShowFilmsAndDirector(FilmLogic filmLogic)
        {
            filmLogic.GetMoviesWithDirector().DisplayListToConsol();

            Console.ReadKey();
        }

        /// <summary>
        /// Delet film.
        /// </summary>
        /// <param name="filmLogic">FilmLogic instance.</param>
        public static void DeletFilm(FilmLogic filmLogic)
        {
            Console.WriteLine("Please enter the film id.");
            var filmId = Console.ReadLine();

            if (filmLogic.DeletFilm(Int32.Parse(filmId)))
            {
                Console.WriteLine("Delete successfully!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Delete failed!");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Show actors and films.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void ShowFilmsAndActor(ActorFilmLogic actorFilmLogic)
        {
            actorFilmLogic.GetAllActorsFilms().DisplayListToConsol();

            Console.ReadKey();
        }

        /// <summary>
        /// InsertFilm.
        /// </summary>
        /// <param name="filmLogic">FilmLogic instance.</param>
        public static void InsertFilm(FilmLogic filmLogic)
        {
            Console.Write("Please enter the new movie title: ");
            var title = Console.ReadLine();
            Console.WriteLine();
            Console.Write("How long the movie: ");
            var length = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter the director id: ");
            var directorId = Console.ReadLine();
            Console.WriteLine();

            var insetrtedFilm = filmLogic.InsertFilm(new Film() { Title = title, DirectorId = Int32.Parse(directorId), Length = Int32.Parse(length) });

            Console.WriteLine(insetrtedFilm);
            Console.ReadLine();
        }

        /// <summary>
        /// UpdateFilm.
        /// </summary>
        /// <param name="filmLogic">FilmLogic instance.</param>
        public static void UpdateFilm(FilmLogic filmLogic)
        {
            Console.Write("Please enter movie id what do you want modify: ");
            var filmId = Console.ReadLine();
            Console.Write("Please enter the film title: ");
            var filmTitle = Console.ReadLine();
            var film = filmLogic.GetOneFilm(Int32.Parse(filmId));
            film.Title = filmTitle;
            var updatedFilm = filmLogic.UpdateFilm(film);

            Console.WriteLine(updatedFilm);
            Console.ReadLine();
        }

        /// <summary>
        /// InsertDirector.
        /// </summary>
        /// <param name="directorLogic">DirectorLogic instance.</param>
        public static void InsertDirector(DirectorLogic directorLogic)
        {
            Console.Write("Please enter the director name: ");
            var directorName = Console.ReadLine();

            var insertedDirector = directorLogic.InsertDirector(new Director() { Name = directorName });

            Console.WriteLine(insertedDirector);
        }

        /// <summary>
        /// UpdateDirector.
        /// </summary>
        /// <param name="directorLogic">DirectorLogic instance.</param>
        public static void UpdateDirector(DirectorLogic directorLogic)
        {
            Console.Write("Please enter the director id: ");
            var directorId = Console.ReadLine();
            Console.Write("Please enter the new name of director: ");
            var directorName = Console.ReadLine();

            var director = directorLogic.GetOneDirector(Int32.Parse(directorId));
            director.Name = directorName;
            var updatedDirector = directorLogic.UpdateDirector(director);

            Console.WriteLine(updatedDirector);
        }

        /// <summary>
        /// DeletDirector.
        /// </summary>
        /// <param name="directorLogic">DirectorLogic instance.</param>
        public static void DeletDirector(DirectorLogic directorLogic)
        {
            Console.Write("Please enter the director id: ");
            var directorId = Int32.Parse(Console.ReadLine());

            if (directorLogic.DeletDirector(directorId))
            {
                Console.WriteLine("Delete successfully!");
            }
            else
            {
                Console.WriteLine("Delete failed!");
            }
        }

        /// <summary>
        /// InsertActor.
        /// </summary>
        /// <param name="actorLogic">ActorLogic instance.</param>
        public static void InsertActor(ActorLogic actorLogic)
        {
            Console.Write("Please enter the actors name: ");
            var actorName = Console.ReadLine();
            Console.Write("Actor new gender: ");
            var actorGender = Console.ReadLine();

            var actor = actorLogic.InsertActor(new Actor() { Name = actorName, Gender = actorGender });

            Console.WriteLine($"Created actor: {actor}");
        }

        /// <summary>
        /// UpdateActor.
        /// </summary>
        /// <param name="actorLogic">ActorLogic instance.</param>
        public static void UpdateActor(ActorLogic actorLogic)
        {
            Console.Write("Please enter the actor id what do you want modify: ");
            var actorId = Int32.Parse(Console.ReadLine());
            var actor = actorLogic.GetOneActor(actorId);

            Console.Write("Enter new name of actor: ");
            var actorName = Console.ReadLine();
            actor.Name = actorName;

            actorLogic.UpdatActor(actor);
        }

        /// <summary>
        /// DeletActor.
        /// </summary>
        /// <param name="actorLogic">ActorLogic instance.</param>
        public static void DeletActor(ActorLogic actorLogic)
        {
            Console.Write("Please enter the actor id what do you want delete: ");
            var actorId = Int32.Parse(Console.ReadLine());

            if (actorLogic.DeletActor(actorId))
            {
                Console.WriteLine("Delete successfully!");
            }
            else
            {
                Console.WriteLine("Delete failed!");
            }
        }

        /// <summary>
        /// ConnectActorAndMovie.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void ConnectActorAndMovie(ActorFilmLogic actorFilmLogic)
        {
            Console.Write("Please enter the movie id: ");
            var filmId = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter the id of actor: ");
            var actorId = Int32.Parse(Console.ReadLine());

            var actorFilm = actorFilmLogic.InsertActorFilm(new ActorFilm() { ActorId = actorId, FilmId = filmId });
            Console.WriteLine($"Inserted row: {actorFilm}");
        }

        /// <summary>
        /// DisconnectActorAndMovie.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void DisconnectActorAndMovie(ActorFilmLogic actorFilmLogic)
        {
            Console.Write("Please enter id of movie: ");
            var filmId = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter id of actor: ");
            var actorId = Int32.Parse(Console.ReadLine());

            if (actorFilmLogic.DeletActorFilm(filmId, actorId))
            {
                Console.WriteLine("Delete successfully!");
            }
            else
            {
                Console.WriteLine("Delete failed!");
            }
        }

        /// <summary>
        /// GetDirectorAndActor.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void GetDirectorAndActor(ActorFilmLogic actorFilmLogic)
        {
            actorFilmLogic.GetDirectorAndActors().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// CountActorsMovies.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void CountActorsMovies(ActorFilmLogic actorFilmLogic)
        {
            foreach (var item in actorFilmLogic.CountFilmsOfActor())
            {
                Console.WriteLine($"{item.ActorName} - {item.Count} play in movies.");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// CountDirectorMovies.
        /// </summary>
        /// <param name="directorLogic">DirectorLogic instance.</param>
        public static void CountDirectorMovies(DirectorLogic directorLogic)
        {
            foreach (var item in directorLogic.CountMoviesOfDirector())
            {
                Console.WriteLine($"{item.DirectorName} - {item.Count} directed.");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// GetTheActorWhoHasTheActedInMostFilms.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void GetTheActorWhoHasTheActedInMostFilms(ActorFilmLogic actorFilmLogic)
        {
            actorFilmLogic.GetTheActorWhoHasTheActedInMostFilms().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// GetTheActorWhoHasPlayedTheLeastNumberOfFilms.
        /// </summary>
        /// <param name="actorFilmLogic">ActorFilmLogic instance.</param>
        public static void GetTheActorWhoHasPlayedTheLeastNumberOfFilms(ActorFilmLogic actorFilmLogic)
        {
            actorFilmLogic.GetTheActorWhoHasPlayedTheLeastNumberOfFilms().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// GetAllActress.
        /// </summary>
        /// <param name="actorLogic">ActorLogic inistance.</param>
        public static void GetAllActress(ActorLogic actorLogic)
        {
            actorLogic.GetAllActress().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// GetAllActors.
        /// </summary>
        /// <param name="actorLogic">ActorLogic inistance.</param>
        public static void GetAllActors(ActorLogic actorLogic)
        {
            actorLogic.GetActors().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// GetMostLongestMovie.
        /// </summary>
        /// <param name="filmLogic">FilmLogic instance.</param>
        public static void GetMostLongestMovie(FilmLogic filmLogic)
        {
            filmLogic.GetMostLongestMovie().DisplayListToConsol();

            Console.ReadLine();
        }

        /// <summary>
        /// GetMostLongestMovieAsync.
        /// </summary>
        /// <param name="filmLogic">Instance of FilmLocig.</param>
        public static void GetMostLongestMovieAsync(FilmLogic filmLogic)
        {
            var task = filmLogic.GetMostLongestMovieAsync();
            task.RunSynchronously();
            task.Wait();
            if (task.IsCompletedSuccessfully)
            {
                task.Result.DisplayListToConsol();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// CountMoviesOfDirectorAsync.
        /// </summary>
        /// <param name="directorLogic">Instance of DirectorLogic.</param>
        public static void CountMoviesOfDirectorAsync(DirectorLogic directorLogic)
        {
            var task = directorLogic.CountMoviesOfDirectorAsync();
            task.RunSynchronously();
            task.Wait();
            if (task.IsCompletedSuccessfully)
            {
                task.Result.DisplayListToConsol();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// CountMoviesOfDirectorAsync.
        /// </summary>
        /// <param name="actorFilmLogic">Instance of ActorFilmLogic.</param>
        public static void GetDirectorAndActorsAsync(ActorFilmLogic actorFilmLogic)
        {
            var task = actorFilmLogic.GetDirectorAndActorsAsync();
            task.RunSynchronously();
            task.Wait();
            if (task.IsCompletedSuccessfully)
            {
                task.Result.DisplayListToConsol();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Show Favoorite actor.
        /// </summary>
        /// <param name="actorFilmLogic">Instance of ActorFilmLogic.</param>
        public static void GetFavoriteActor(ActorFilmLogic actorFilmLogic)
        {
            var result = actorFilmLogic.GetFavotritActor();

            Console.WriteLine(result.ToString());

            Console.ReadLine();
        }
    }
}
