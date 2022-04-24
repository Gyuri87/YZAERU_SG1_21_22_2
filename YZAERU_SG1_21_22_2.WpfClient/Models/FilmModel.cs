using GalaSoft.MvvmLight;
using System;

namespace YZAERU_SG1_21_22_2.WpfClient.Models
{
    public class FilmModel : ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private DateTime relaseYear;

        public DateTime RelaseYear
        {
            get { return relaseYear; }
            set { relaseYear = value; }
        }

        private bool isTheBest;

        public bool IsTheBest
        {
            get { return isTheBest; }
            set { isTheBest = value; }
        }


        private int directorId;

        public int DirectorId
        {
            get { return directorId; }
            set { directorId = value; }
        }

        private string directorName;

        public string DirectorName
        {
            get { return directorName; }
            set { directorName = value; }
        }

        public FilmModel()
        {
        }

        public FilmModel(int id, string title, int lenght, int directorId, string directorName, string type, DateTime relaseYear, bool isTheBest )
        {
            this.id = id;
            this.title = title;
            this.length = lenght;
            this.directorId = directorId;
            this.directorName = directorName;
            this.type = type;
            this.relaseYear = relaseYear;
            this.isTheBest = isTheBest;
        }

        public FilmModel(FilmModel film)
        {
            this.id = film.id;
            this.title = film.title;
            this.length = film.length;
            this.directorId = film.directorId;
            this.type = film.type;
            this.relaseYear = film.relaseYear;
            this.isTheBest = film.isTheBest;
        }

        public override string ToString()
        {
            return $"id: {id}, title: {title}, lenght: {length}, directorId: {directorId}, type: {type}, relaseYear: {relaseYear}, isTheBest: {isTheBest}";
        }
    }
}
