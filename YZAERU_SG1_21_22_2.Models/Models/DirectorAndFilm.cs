using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class DirectorAndFilm
    {
        public DirectorAndFilm(string directorName, string filmTitle)
        {
            this.DirectorName = directorName;
            this.FilmTitle = filmTitle;
        }

        public DirectorAndFilm()
        {
        }

        public string DirectorName { get; set; }

        public string FilmTitle { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"Driector name: {this.DirectorName} - Movie title: {this.FilmTitle} - Count of Film: {this.Count}";
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

        public override int GetHashCode()
        {
            return this.Count;
        }
    }
}
