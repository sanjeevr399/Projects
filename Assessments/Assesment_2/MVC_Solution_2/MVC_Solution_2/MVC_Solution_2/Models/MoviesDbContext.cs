using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Solution_2.Models
{
    public class MoviesDbContext
    {
        public DbSet<Movie> Movies { get; set; }

        internal object Entry(Movie movie)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}