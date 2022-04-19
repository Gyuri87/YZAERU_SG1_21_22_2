using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Linq;
using YZAERU_SG1_21_22_2.Models.DTOs;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.WpfClient.BL.Interfaces;
using YZAERU_SG1_21_22_2.WpfClient.Infrastructure;
using YZAERU_SG1_21_22_2.WpfClient.Models;

namespace YZAERU_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class DirectorHandlerService : IFilmHandlerService
    {
        readonly IMessenger messenger;
        readonly IFilmEditorService editorService;
        readonly IFilmDisplayService displayService;
        HttpService httpService;

        public DirectorHandlerService(IMessenger messenger, IFilmEditorService editorService, IFilmDisplayService displayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.displayService = displayService;
            this.httpService = new HttpService("Film", "http://localhost:24577/api/");
        }

        public void AddFilm(IList<FilmModel> collection)
        {
            FilmModel filmToEdit = null;
            bool operationFinished = false;

            do
            {
                var newFilm = editorService.EditFilm(filmToEdit);

                if (newFilm != null)
                {
                    var operationResult = httpService.Create(new FilmDTO()
                    {
                        Id = newFilm.Id,
                        DirectorId = newFilm.DirectorId,
                        Length = newFilm.Length,
                        Title = newFilm.Title
                    });

                    filmToEdit = newFilm;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);

                        SendMessage("Film sikeresen hozzá lett adva!");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("A film hozzáadása nem sikerült");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }

        private void RefreshCollectionFromServer(IList<FilmModel> collection)
        {
            collection.Clear();
            var newFilms = GetAll();

            foreach (var film in newFilms)
            {
                collection.Add(film);
            }
        }

        public void DeleteFilm(IList<FilmModel> collection, FilmModel film)
        {
            if (film != null)
            {
                var operationResult = httpService.Delete(film.Id);

                if (operationResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Film sikeresen törölve lett!");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Nem sikerült törölni a filmet!");
            }
        }

        public IList<FilmModel> GetAll()
        {
            var films = httpService.GetAll<Film>();

            return films.Select(x => new FilmModel(x.Id, x.Title , x.Length, x.DirectorId, x.DirectorName)).ToList();
        }


        public void ModifyFilm(IList<FilmModel> collection, FilmModel film)
        {
            FilmModel filmToEdit = film;
            bool operationFinished = false;

            do
            {
                var editedFilm = editorService.EditFilm(filmToEdit);

                if (editedFilm != null)
                {
                    var operationResult = httpService.Update(new FilmDTO()
                    {
                        Id = editedFilm.Id, // This prop cannot be changed
                        Title = editedFilm.Title,
                        Length = editedFilm.Length,
                        DirectorId = editedFilm.DirectorId
                    });

                    filmToEdit = editedFilm;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);
                        SendMessage("Film modification was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Film modification has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        public void ViewFilm(FilmModel film)
        {
            displayService.Display(film);
        }

        public IList<DirectorModel> GetAllDirectors()
        {
            var directors = httpService.GetAllDirectors<Director>();

            return directors.Select(x => new DirectorModel(x.Id, x.Name)).ToList();
        }
    }
}
