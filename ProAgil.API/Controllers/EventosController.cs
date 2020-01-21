using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domains;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IProAgilRepository Repo;

        public EventosController(IProAgilRepository repo)
        {
            Repo = repo;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await Repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("{EventoID}")]

        public async Task<IActionResult> Get(int EventoID)
        {
            try
            {
                var results = await Repo.GetEventosAsyncByID(EventoID, true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("getByTema/{tema}")]

        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await Repo.GetAllEventosAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

           [HttpPost]

        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                Repo.Add(model);

                if(await Repo.SaveChangesAsync()) {
                    return Created($"/api/evento/{model.ID}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest("Error! D:");

        }

         [HttpPut]

        public async Task<IActionResult> Put(int EventoID, Evento model)
        {
            try
            {
                var evento = await Repo.GetEventosAsyncByID(EventoID, false);

                if(evento == null) {
                    return NotFound();
                }
            
                Repo.Update(model);

                if(await Repo.SaveChangesAsync()) {
                    return Created($"/api/evento/{model.ID}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest("Error! D:");

        }

         [HttpDelete]

        public async Task<IActionResult> Delete(int EventoID)
        {
            try
            {
                var evento = await Repo.GetEventosAsyncByID(EventoID, false);

                if(evento == null) {
                    return NotFound();
                }
            
                Repo.Delete(evento);

                if(await Repo.SaveChangesAsync()) {
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest("Error! D:");

        }


        
    }
}