using API_AlexandrePradoRomeu.InputModel;
using API_AlexandrePradoRomeu.Services;
using API_AlexandrePradoRomeu.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_AlexandrePradoRomeu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ICadastroServices _cadastroServices;

        public UsuarioController(ICadastroServices cadastroServices)
        {
            _cadastroServices = cadastroServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var registros = await _cadastroServices.Obter(pagina, quantidade);

            if (registros.Count() == 0)
                return NoContent();

            return Ok(registros);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioModel>> Obter([FromRoute] Guid id)
        {
            var usuario = await _cadastroServices.Obter(id);

            if (usuario == null)
                return NoContent();

            return Ok(usuario);
        }
       
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Inserir([FromBody] CadastroUserModel cadastro)
        {
            var user = await _cadastroServices.Inserir(cadastro);

            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar([FromRoute] Guid id, [FromBody] CadastroUserModel cadastro)
        {
            await _cadastroServices.Atualizar(id, cadastro);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Apagar([FromRoute] Guid id)
        {
            await _cadastroServices.Remover(id);

            return Ok();
        }

    }
}
