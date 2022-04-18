using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces
{
    public interface IFilmDisplayService
    {
        void Display(FilmModel film);
    }
}
