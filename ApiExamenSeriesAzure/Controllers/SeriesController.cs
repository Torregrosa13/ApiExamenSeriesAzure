using ApiExamenSeriesAzure.Models;
using ApiExamenSeriesAzure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenSeriesAzure.Controllers
{
    [Route("api/series/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }

        [HttpGet("/PersonajesSerie/{id}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSerie(int id)
        {
            return await this.repo.GetPersonajesSerieAsync(id);
        }

        [HttpGet("MultiplesPersonajesSerie")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSeries([FromQuery] List<int> idsSeries)
        {
            return await this.repo.GetPersonajesVariasSeries(idsSeries);
        }

    }
}
