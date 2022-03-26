using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Models.Entities;

namespace YZAERU_SG1_21_22_2.Logic.Interfaces
{
    
    public interface IDirectorLogic
    {
       
        Director GetOneDirector(int id);

        IList<Director> GetAllDirectors();

        bool DeletDirector(int directorId);

        Director UpdateDirector(Director director);

        Director InsertDirector(Director director);
    }
}
