using ApiExamenSeriesAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenSeriesAzure.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }

}
