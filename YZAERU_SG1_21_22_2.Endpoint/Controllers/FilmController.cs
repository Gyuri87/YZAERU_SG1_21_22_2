using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

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
        [ActionName("GetAll")]
        public IList<Film> GetFilms()
        {
            return filmLogic.GetAllFilms();
        }

        // /api/Film/Get/5
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            return filmLogic.GetOneFilm(id);
        }

        // /api/Film/MoviesDirector
        [HttpGet]
        [ActionName("MoviesDirector")]
        public IList<DirectorAndFilm> MoviesDirector()
        {
            return filmLogic.GetMoviesWithDirector();
        }
        // /api/Film/LongestMovie
        [HttpGet]
        [ActionName("LongestMovie")]
        public IList<Film> GetLongestMovie()
        {
            return filmLogic.GetMostLongestMovie();
        }

        // /api/Film/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                filmLogic.DeletFilm(id);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // /api/Film/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Film film)
        {
            var result = new ApiResult(true);

            try
            {
                filmLogic.InsertFilm(film);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }

        // /api/Film/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Film film)
        {
            var result = new ApiResult(true);

            try
            {
                filmLogic.UpdateFilm(film);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }
    }
}
