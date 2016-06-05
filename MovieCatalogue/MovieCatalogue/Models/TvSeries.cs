using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieCatalogue.Models
{
    public class TvSeries
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
    }
    public class TvSeriesDBContext : DbContext
    {
        public DbSet<TvSeries> Series { get; set; }
    }
}