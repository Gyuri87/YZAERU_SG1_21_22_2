using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Models.Entities;

namespace YZAERU_SG1_21_22_2.Logic.Interfaces
{
    public interface IActorLogic
    {
        
        Actor GetOneActor(int id);

        IList<Actor> GetAllActors();

        Actor InsertActor(Actor actor);

        Actor UpdatActor(Actor actor);

        bool DeletActor(int actorId);

        IList<Actor> GetAllActress();
    }
}
