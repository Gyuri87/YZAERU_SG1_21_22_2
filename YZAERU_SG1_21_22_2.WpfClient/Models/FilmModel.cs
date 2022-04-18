using GalaSoft.MvvmLight;

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

        private int lenght;

        public int Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        private int directorId;

        public int DirectorId
        {
            get { return directorId; }
            set { directorId = value; }
        }

        public FilmModel()
        {
        }

        public FilmModel(int id, string title, int lenght, int directorId)
        {
            this.id = id;
            this.title = title;
            this.lenght = lenght;
            this.directorId = directorId;
        }

        public FilmModel(FilmModel film)
        {
            this.id = film.id;
            this.title = film.title;
            this.lenght = film.lenght;
            this.directorId = film.directorId;
        }

        public override string ToString()
        {
            return $"id: {id}, title: {title}, lenght: {lenght}, directorId: {directorId}";
        }
    }
}
