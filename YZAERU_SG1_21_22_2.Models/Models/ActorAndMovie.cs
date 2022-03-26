using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class ActorAndMovie
    {
        
        public string MovieName { get; set; }

        public string ActorName { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"Actor name: {this.ActorName} - Movie title: {this.MovieName} - Movie count: {this.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ActorAndMovie)
            {
                ActorAndMovie another = obj as ActorAndMovie;

                return this.ActorName == another.ActorName && this.MovieName == another.MovieName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Count;
        }
    }
}
