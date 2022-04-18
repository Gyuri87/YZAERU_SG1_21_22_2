using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class DirectorAndFilm
    {
        public DirectorAndFilm(int directorId, string directorName, int filmId, string filmTitle, int filmLength)
        {
            this.FilmId = filmId;
            this.DirectorId = directorId;
            this.DirectorName = directorName;
            this.FilmTitle = filmTitle;
            this.FilmLength = filmLength;
        }

        public DirectorAndFilm()
        {
        }

        public int FilmId { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        public string FilmTitle { get; set; }

        public int FilmLength { get; set; }

        public override string ToString()
        {
            return $"Driector name: {this.DirectorName} - DirectorId: {this.DirectorId} - FilmId: {this.FilmId} - Movie title: {this.FilmTitle} - Length: {this.FilmLength}";
        }

        public override bool Equals(object obj)
        {
            if (obj is DirectorAndFilm)
            {
                DirectorAndFilm another = obj as DirectorAndFilm;

                return this.DirectorName == another.DirectorName && this.FilmTitle == another.FilmTitle;
            }

            return false;
        }
    }
}
