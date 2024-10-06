using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;
using WebApi8.CadastroAtletasBJJ.Services.Atleta;
using WebApi8.CadastroAtletasBJJ.Services.Equipe;

namespace WebApi8.CadastroAtletasBJJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {

        private readonly IAtletaService _atletaInterface;
        public AtletaController(IAtletaService atletaService)
        {
            _atletaInterface = atletaService;
        }

        [HttpGet("ListarAtletas")]
        public async Task<ActionResult<ResponseModel<List<AtletaModel>>>> ListarAtletas()
        {
            var equipes = await _atletaInterface.ListarAtletas();
            return Ok(equipes);
        }

        [HttpGet("BuscarAtletaPorId/{IdAtleta}")]
        public async Task<ActionResult<ResponseModel<AtletaModel>>> BuscarAtletaPorId(int IdAtleta)
        {
            var equipe = await _atletaInterface.BuscarAtletaPorId(IdAtleta);
            return Ok(equipe);
        }

        [HttpGet("BuscarAtletaPorIdEquipe/{IdEquipe}")]
        public async Task<ActionResult<ResponseModel<List<AtletaModel>>>> BuscarAtletaPorIdEquipe(int IdEquipe)
        {
            var equipe = await _atletaInterface.BuscarAtletaPorIdEquipe(IdEquipe);
            return Ok(equipe);
        }

        [HttpPost("CriarAtleta")]
        public async Task<ActionResult<ResponseModel<List<AtletaModel>>>> CriarAtleta(AtletaCriacaoDTO atletaCriacaoDTO)
        {
            var equipe = await _atletaInterface.CriarAtleta(atletaCriacaoDTO);
            return Ok(equipe);
        }

        [HttpPut("EditarAtleta")]
        public async Task<ActionResult<ResponseModel<List<AtletaModel>>>> EditarAtleta(AtletaEdicaoDTO atletaEdicaoDTO)
        {
            var equipe = await _atletaInterface.EditarAtleta(atletaEdicaoDTO);
            return Ok(equipe);
        }

        [HttpDelete("ExcluirAtleta")]
        public async Task<ActionResult<ResponseModel<List<AtletaModel>>>> ExcluirAtleta(int IdAtleta)
        {
            var equipe = await _atletaInterface.ExcluirAtleta(IdAtleta);
            return Ok(equipe);
        }
    }
}
