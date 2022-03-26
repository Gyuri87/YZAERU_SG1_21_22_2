using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.Entities;

namespace YZAERU_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmController : Controller
    {
        readonly IFilmLogic filmLogic;

        public FilmController(IFilmLogic filmLogic)
        {
            this.filmLogic = filmLogic;
        }

        // /api/Film/List
        [HttpGet]
        [ActionName("List")]
        public IList<Film> GetFilms()
        {
            return filmLogic.GetAllFilms();
        }

        // /api/Film/List
        //[HttpGet]
        //[ActionName("List")]
        //public IList<Film> GetFilms()
        //{
        //    return filmLogic.GetAllFilms();
        //}
    }
}
