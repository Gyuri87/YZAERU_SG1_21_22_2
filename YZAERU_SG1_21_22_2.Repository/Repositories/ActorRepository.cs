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
    public class ActorRepository : MovieRepository<Actor, int>, IActorRepository
    {
        public ActorRepository(FilmDbContext context) : base(context)
        {
        }

        public override Actor GetById(int id)
        {
            return this.ReadAll().SingleOrDefault(actor => actor.Id == id);
        }
    }
}
