using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.API.Entities;
using AgendaTelefonica.API.Models;
using AgendaTelefonica.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.API.Controllers
{
    [ApiController]
    [Route("api/contato")]
    public class AgendaController : ControllerBase
    {
        private readonly IContatoRepository _repository;

        public AgendaController(IContatoRepository repository) => _repository = repository;


        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _repository.Obter();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contato = _repository.ObterPorId(id);
            if (contato is null)
                return NotFound();
            return Ok(contato);
        }

        [HttpPost]
        public IActionResult Post(AddContatoModel model)
        {
            Contato contato = new Contato(model.Nome, model.Idade);

            _repository.Adicionar(contato);

            return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateContatoModel model)
        {
            var contato = _repository.ObterPorId(id);
            if (contato is null)
                return NotFound();

            contato.Atualizar(model.Nome, model.Idade);

            _repository.Alterar(contato);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _repository.ObterPorId(id);

            if (contato is null)
                return NotFound();

            _repository.Deletar(contato);

            return NoContent();
        }
    }
}