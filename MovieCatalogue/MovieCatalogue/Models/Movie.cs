using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
	

namespace MovieCatalogue.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime AirDate { get ; set; }
        public DateTime DateOfWatching { get; set; }
    }
    public class MovieDBContext: DbContext 
    {
        public DbSet<Movie> Movies { get; set; }
    }
}