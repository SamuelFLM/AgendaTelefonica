using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;
using AgendaTelefonica.API.Entities;
using AgendaTelefonica.API.Models;
using AgendaTelefonica.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.API.Controllers
{
    [ApiController]
    [Route("api/contato/{id}/telefone")]
    public class TelefoneController : ControllerBase
    {
        private readonly IContatoRepository _repository;

        public TelefoneController(IContatoRepository repository) => _repository = repository;

        [HttpPost]
        public IActionResult Post(int id, AddTelefoneModel model){
            var contato = _repository.ObterPorId(id);

            if (contato is null)
                return NotFound();

            var telefone = new Telefone(model.Numero, id);

            if (telefone.Numero.Length > 16)
                return BadRequest();

            _repository.AdicionarTelefone(telefone);

            return NoContent();
        }

    }
}