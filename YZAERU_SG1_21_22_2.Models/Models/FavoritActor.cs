using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class FavoritActor
    {
       
        public string ActorName { get; set; }

        public int MovieNumber { get; set; }

        public override string ToString()
        {
            return $"Actor name: {this.ActorName} - Number of film: {this.MovieNumber}";
        }
    }
}
