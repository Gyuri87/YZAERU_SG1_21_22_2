using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Logic.Services
{
    public class ActorLogic : IActorLogic
    {
        private IActorRepository actorRepository;

        public ActorLogic(IActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public IList<Actor> GetAllActors()
        {
            return this.actorRepository.ReadAll().ToList();
        }

        public Actor GetOneActor(int id)
        {
            return this.actorRepository.GetById(id);
        }

        public Actor InsertActor(Actor actor)
        {
            return this.actorRepository.Insert(actor);
        }

        public Actor UpdatActor(Actor actor)
        {
            return this.actorRepository.Update(actor);
        }

        public bool DeletActor(int actorId)
        {
            var actor = this.actorRepository.GetById(actorId);

            if (actor != null)
            {
                this.actorRepository.Delete(actor);

                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<Actor> GetAllActress()
        {
            var list = from actress in this.actorRepository.ReadAll()
                       where actress.Gender == "woman"
                       select new Actor() { Gender = actress.Gender, Id = actress.Id, Name = actress.Name };

            return list.ToList();
        }

        public IList<Actor> GetActors()
        {
            var list = from actress in this.actorRepository.ReadAll()
                       where actress.Gender == "man"
                       select new Actor() { Gender = actress.Gender, Id = actress.Id, Name = actress.Name };

            return list.ToList();
        }
    }
}
