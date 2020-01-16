using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.Data;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        public DataContext Context { get; }

        public EventosController(DataContext context)
        {
            this.Context = context;
        }

        [HttpGet]

        public IActionResult Get() 
        {
            try
            {
                 var results = Context.Eventos.ToList();
            return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
           
        }
        
    }
}