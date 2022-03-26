using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Services;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;
using YZAERU_SG1_21_22_2.Repository.Repositories;

namespace YZAERU_SG1_21_22_2.Program
{
    public class DependencyFactory : IDependencyFactory
    {
        /// <summary>
        /// Dbcontext property.
        /// </summary>
        private FilmDbContext ctx;

        /// <summary>
        /// Create FilmLogic.
        /// </summary>
        /// <returns>FilmLogic instance.</returns>
        public FilmLogic GetFilmLogic()
        {
            if (this.ctx == null)
            {
                this.ctx = new FilmDbContext();
            }

            var filmRepository = new FilmRepository(this.ctx);
            var directorRepository = new DirectorRepository(this.ctx);

            return new FilmLogic(filmRepository, directorRepository);
        }

        /// <summary>
        /// Create DirectorLogic.
        /// </summary>
        /// <returns>DirectorLogic instance.</returns>
        public DirectorLogic GetDirectorLogic()
        {
            if (this.ctx == null)
            {
                this.ctx = new FilmDbContext();
            }

            IDirectorRepository directoryRepository = new DirectorRepository(this.ctx);
            IFilmRepository filmRepository = new FilmRepository(this.ctx);

            return new DirectorLogic(directoryRepository, filmRepository);
        }

        /// <summary>
        /// Create ActorLogic.
        /// </summary>
        /// <returns>ActorLogic instance.</returns>
        public ActorLogic GetActorLogic()
        {
            if (this.ctx == null)
            {
                this.ctx = new FilmDbContext();
            }

            var actorRepository = new ActorRepository(this.ctx);

            return new ActorLogic(actorRepository);
        }

        /// <summary>
        /// GetActorFilmLogic.
        /// </summary>
        /// <returns>ActorFilmLogic instacne.</returns>
        public ActorFilmLogic GetActorFilmLogic()
        {
            if (this.ctx == null)
            {
                this.ctx = new FilmDbContext();
            }

            var actorFilmRepository = new ActorFilmRepository(this.ctx);
            var filmRepository = new FilmRepository(this.ctx);
            var directorRepository = new DirectorRepository(this.ctx);
            var actorRepository = new ActorRepository(this.ctx);

            return new ActorFilmLogic(actorFilmRepository, directorRepository, filmRepository, actorRepository);
        }
    }
}
