using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Services.Equipe
{
    public interface IEquipeInterface
    {
        //task por ser um método assíncrono
        Task<ResponseModel<List<EquipeModel>>> ListarEquipes();
        Task<ResponseModel<EquipeModel>> BuscarEquipePorId(int IdEquipe);
        Task<ResponseModel<EquipeModel>> BuscarEquipePorIdAleta(int IdAtleta);
        Task<ResponseModel<List<EquipeModel>>> CriarEquipe(EquipeCriacaoDTO equipeCriacaoDTO);
        Task<ResponseModel<List<EquipeModel>>> EditarEquipe(EquipeEdicaoDTO equipeCriacaoDTO);
        Task<ResponseModel<List<EquipeModel>>> ExcluirEquipe(int IdEquipe);

    }
}
