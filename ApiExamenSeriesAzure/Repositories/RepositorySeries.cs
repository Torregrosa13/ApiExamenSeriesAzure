using System.Reflection.Metadata.Ecma335;
using ApiExamenSeriesAzure.Data;
using ApiExamenSeriesAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenSeriesAzure.Repositories
{

//    PERSONAJES
//•	Todos Personaje
//•	Cambiar personaje de serie con PUT

//SERIES

//•	Todas las series
//•	Buscar serie
//•	Buscar Personajes por Serie
//•	Múltiples personajes de una serie: Enviaremos varios Ids de serie y nos devolverá los personajes de dichas series


    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(int idSerie)
        {
            var consulta = from datos in this.context.Personajes
                           where idSerie == datos.IdSerie
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesVariasSeries(List<int> idsSeries)
        {
            var consulta = from datos in this.context.Personajes
                           where idsSeries.Contains(datos.IdSerie)
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task CambiarPersonajeSerie(int idSerie, int idPersonaje)
        {
            Personaje p = await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
            p.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }
    }
}
