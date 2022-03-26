using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Models.Models
{
    public class DirectorAndActor
    {
        public string DirectorName { get; set; }

        public string ActorName { get; set; }

        public override string ToString()
        {
            return $"Actor name: {this.ActorName} - Director name: {this.DirectorName}";
        }

        public override bool Equals(object obj)
        {
            if (obj is DirectorAndActor)
            {
                DirectorAndActor another = obj as DirectorAndActor;

                return this.ActorName == another.ActorName && this.DirectorName == another.DirectorName;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"{this.ActorName}-{this.DirectorName}".Length;
        }
    }
}
