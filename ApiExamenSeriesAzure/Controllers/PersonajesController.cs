using ApiExamenSeriesAzure.Models;
using ApiExamenSeriesAzure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenSeriesAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;
        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpPut("/CambiarPersonajeSerie/{ids}/{idp}")]
        public async Task<ActionResult> CambiarPersonajesSerie(int ids, int idp)
        {
            await this.repo.CambiarPersonajeSerie(ids, idp);
            return Ok();
        }
    }
}
