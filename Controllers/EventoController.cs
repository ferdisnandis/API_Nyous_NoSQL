using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyous_API_NoSQL.Domain;
using Nyous_API_NoSQL.Interfaces;

namespace Nyous_API_NoSQL.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpPost]
        public ActionResult<EventoDomain> Create(EventoDomain evento)
        {
            try
            {
                _eventoRepository.Adicionar(evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            try
            {
                return _eventoRepository.Listar();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            try
            {
                var evento = _eventoRepository.BuscarPorId(id);
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _eventoRepository.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento)
        {
            try
            {
                evento.Id = id;
                _eventoRepository.Atualizar(id, evento);

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
