using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Models.DTOs;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

namespace YZAERU_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmController : Controller
    {
        readonly IFilmLogic filmLogic;
        readonly IDirectorLogic directorLogic;

        public FilmController(IFilmLogic filmLogic, IDirectorLogic directorLogic)
        {
            this.filmLogic = filmLogic;
            this.directorLogic = directorLogic;
        }

        // /api/Film/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IList<Film> GetFilms()
        {
            return filmLogic.GetAllFilms();
        }

        // /api/Film/GetAllDirectors
        [HttpGet]
        [ActionName("GetAllDirectors")]
        public IList<Director> GetAllDirectors()
        {
            return directorLogic.GetAllDirectors();
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
        public ApiResult Post(FilmDTO film)
        {
            var result = new ApiResult(true);

            try
            {
                filmLogic.InsertFilm(new Film()
                {
                    Id = film.Id,
                    Title = film.Title,
                    Length = film.Length,
                    DirectorId = film.DirectorId
                });
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
        public ApiResult Put(FilmDTO film)
        {
            var result = new ApiResult(true);

            try
            {
                filmLogic.UpdateFilm(new Film() { 
                    Id = film.Id,
                    Title = film.Title,
                    Length = film.Length,
                    DirectorId = film.DirectorId
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }

            return result;
        }
    }
}
