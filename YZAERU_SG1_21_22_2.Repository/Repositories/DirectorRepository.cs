using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Repository.Context;
using YZAERU_SG1_21_22_2.Repository.Interfaces;

namespace YZAERU_SG1_21_22_2.Repository.Repositories
{
    public class DirectorRepository : MovieRepository<Director, int>, IDirectorRepository
    {
        
        public DirectorRepository(FilmDbContext context) : base(context)
        {
        }

        public override Director GetById(int id)
        {
            return this.ReadAll().SingleOrDefault(directory => directory.Id == id);
        }
    }
}
