using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;
using WebApi8.CadastroAtletasBJJ.Services.Equipe;

namespace WebApi8.CadastroAtletasBJJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {

        private readonly IEquipeInterface _equipeInterface;

        public EquipeController(IEquipeInterface equipeInterface)
        {
            _equipeInterface = equipeInterface;
        }

        //Endpoint para buscar e listar
        [HttpGet("ListarEquipes")]
        public async Task<ActionResult<ResponseModel<List<EquipeModel>>>> ListarEquipes()
        {
            var equipes = await _equipeInterface.ListarEquipes();
            return Ok(equipes);
        }

        [HttpGet("BuscarEquipePorId/{IdEquipe}")]
        public async Task<ActionResult<ResponseModel<EquipeModel>>> BuscarEquipePorId(int IdEquipe)
        {
            var equipe = await _equipeInterface.BuscarEquipePorId(IdEquipe);
            return Ok(equipe);
        }

        [HttpGet("BuscarEquipePorIdAleta/{IdAtleta}")]
        public async Task<ActionResult<ResponseModel<EquipeModel>>> BuscarEquipePorIdAleta(int IdAtleta)
        {
            var equipe = await _equipeInterface.BuscarEquipePorIdAleta(IdAtleta);
            return Ok(equipe);
        }


        [HttpPost("CriarEquipe")]
        public async Task<ActionResult<ResponseModel<List<EquipeModel>>>> CriarEquipe(EquipeCriacaoDTO equipeCriacaoDTO)
        {
            var equipe = await _equipeInterface.CriarEquipe(equipeCriacaoDTO);
            return Ok(equipe);
        }

        [HttpPut("EditarEquipe")]
        public async Task<ActionResult<ResponseModel<List<EquipeModel>>>> EditarEquipe(EquipeEdicaoDTO equipeCriacaoDTO)
        {
            var equipe = await _equipeInterface.EditarEquipe(equipeCriacaoDTO);
            return Ok(equipe);
        }

        [HttpDelete("ExcluirEquipe")]
        public async Task<ActionResult<ResponseModel<List<EquipeModel>>>> ExcluirEquipe(int IdEquipe)
        {
            var equipe = await _equipeInterface.ExcluirEquipe(IdEquipe);
            return Ok(equipe);
        }
    }
}
