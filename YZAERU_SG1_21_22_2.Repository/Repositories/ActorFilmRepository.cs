using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Repository.Repositories
{
    public class ActorFilmRepository : MovieRepository<ActorFilm, int>, IActorFilmRepository
    {

        public ActorFilmRepository(FilmDbContext context) : base(context)
        {
        }


        public ActorFilm GetByFilmIdAndActorId(int filmId, int actorId)
        {
            return this.ReadAll().Where(actorFilm => actorFilm.FilmId == filmId && actorFilm.ActorId == actorId).SingleOrDefault();
        }


        public override ActorFilm GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
