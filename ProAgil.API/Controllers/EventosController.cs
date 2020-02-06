using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.DTOs;
using ProAgil.Domains;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IProAgilRepository Repo;
        private readonly IMapper Mapper;

        public EventosController(IProAgilRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {

                var eventos = await Repo.GetAllEventosAsync(true);

                var results = Mapper.Map<IEnumerable<EventoDTO>>(eventos);

                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou, {ex.Message} ");
            }

        }

        [HttpPost("upload")]

        public async Task<IActionResult> Upload()
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create)) {
                        file.CopyTo(stream);
                    }
                }


                return Ok();
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou, {ex.Message} ");
            }

            return BadRequest("Erro ao realizar o upload!");

        }

        [HttpGet("{EventoID}")]

        public async Task<IActionResult> Get(int EventoID)
        {
            try
            {
                var evento = await Repo.GetEventosAsyncByID(EventoID, true);
                var results = Mapper.Map<EventoDTO>(evento);
                return Ok(results);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }

        }

        [HttpGet("getByTema/{tema}")]

        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var eventos = await Repo.GetAllEventosAsyncByTema(tema, true);

                var results = Mapper.Map<EventoDTO[]>(eventos);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost]

        public async Task<IActionResult> Post(EventoDTO model)
        {
            try
            {
                var evento = Mapper.Map<Evento>(model);

                Repo.Add(evento);

                if (await Repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.ID}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest("Error! D:");

        }

        [HttpPut("{EventoID}")]

        public async Task<IActionResult> Put(int EventoID, EventoDTO model)
        {
            try
            {
                var evento = await Repo.GetEventosAsyncByID(EventoID, false);

                if (evento == null)
                {
                    return NotFound();
                }

                Mapper.Map(model, evento);

                Repo.Update(evento);

                if (await Repo.SaveChangesAsync())
                {
                    return Created($"/api/eventos/{model.ID}", Mapper.Map<EventoDTO>(evento));
                }
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou" + ex.Message);
            }

            return BadRequest("Error! D:");

        }

        [HttpDelete("{EventoID}")]

        public async Task<IActionResult> Delete(int EventoID)
        {
            try
            {
                var evento = await Repo.GetEventosAsyncByID(EventoID, false);

                if (evento == null)
                {
                    return NotFound();
                }

                Repo.Delete(evento);

                if (await Repo.SaveChangesAsync())
                {
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