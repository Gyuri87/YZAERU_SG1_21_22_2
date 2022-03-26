using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class DirectorAndFilmCounter
    {
        
        public DirectorAndFilmCounter(string directorName)
        {
            this.DirectorName = directorName;
        }

        public DirectorAndFilmCounter()
        {
        }

        public string DirectorName { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"Driector name: {this.DirectorName} - Count of Film: {this.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj is DirectorAndFilm)
            {
                DirectorAndFilm another = obj as DirectorAndFilm;

                return this.DirectorName == another.DirectorName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Count;
        }
    }
}
