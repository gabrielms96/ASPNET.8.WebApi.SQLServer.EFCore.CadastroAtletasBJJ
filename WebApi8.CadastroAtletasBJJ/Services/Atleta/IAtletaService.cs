using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Services.Atleta
{
    public interface IAtletaService
    {
        Task<ResponseModel<List<AtletaModel>>> ListarAtletas();
        Task<ResponseModel<AtletaModel>> BuscarAtletaPorId(int IdAtleta);
        Task<ResponseModel<List<AtletaModel>>> BuscarAtletaPorIdEquipe(int IdEquipe);
        Task<ResponseModel<List<AtletaModel>>> CriarAtleta(AtletaCriacaoDTO atletaCriacaoDTO);
        Task<ResponseModel<List<AtletaModel>>> EditarAtleta(AtletaEdicaoDTO atletaEdicaoDTO);
        Task<ResponseModel<List<AtletaModel>>> ExcluirAtleta(int IdAtleta);

    }
}
