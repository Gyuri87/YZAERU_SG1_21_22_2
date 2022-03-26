using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Services;

namespace YZAERU_SG1_21_22_2.Program
{
    public interface IDependencyFactory
    {
        
        ActorLogic GetActorLogic();

        DirectorLogic GetDirectorLogic();

        FilmLogic GetFilmLogic();

        ActorFilmLogic GetActorFilmLogic();
    }
}
