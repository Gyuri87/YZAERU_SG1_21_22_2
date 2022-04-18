using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.WpfClient.Models
{
    public class DirectorModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public DirectorModel()
        {
        }

        public DirectorModel(int id, string title)
        {
            this.id = id;
            this.name = title;
        }

        public DirectorModel(DirectorModel director)
        {
            this.id = director.id;
            this.name = director.name;
        }

        public override string ToString()
        {
            return $"id: {id}, title: {name}";
        }
    }
}
