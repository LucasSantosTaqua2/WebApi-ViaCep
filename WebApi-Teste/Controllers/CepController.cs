using Microsoft.AspNetCore.Mvc;
using WebApi_Teste.Integracao.Interfaces;
using WebApi_Teste.Integracao.Response;

namespace WebApi_Teste.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;

        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
            var responseData = await _viaCepIntegracao.ObterDadosViaCep(cep);

            if(responseData == null)
            {
                return BadRequest("CEP não encontrado!");
            }

            return Ok(responseData);
        }
    }
}
