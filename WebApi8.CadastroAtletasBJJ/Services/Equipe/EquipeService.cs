using Microsoft.EntityFrameworkCore;
using WebApi8.CadastroAtletasBJJ.Data;
using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Services.Equipe
{
    public class EquipeService : IEquipeInterface
    {

        //Conectando ao banco
        private readonly AppDbContext _context;
        public EquipeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<EquipeModel>> BuscarEquipePorId(int IdEquipe)
        {
            ResponseModel<EquipeModel> RespostaListaEquipe = new ResponseModel<EquipeModel>();
            try
            {
                var equipe = await _context.Equipes.FirstOrDefaultAsync(equipeBanco => equipeBanco.Id == IdEquipe);

                if(equipe == null)
                {
                    RespostaListaEquipe.Mensagem = $"Nenhuma equipe com o ID {IdEquipe} foi encontrada.";
                    return RespostaListaEquipe;
                }

                RespostaListaEquipe.Dados = equipe;
                RespostaListaEquipe.Mensagem = "Equipe localizada.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }

        public async Task<ResponseModel<EquipeModel>> BuscarEquipePorIdAleta(int IdAtleta)
        {
            ResponseModel<EquipeModel> RespostaListaEquipe = new ResponseModel<EquipeModel>();
            try
            {
                var atleta = await _context.Atletas
                    .Include(e => e.Equipe)
                    .FirstOrDefaultAsync(atletaBanco => atletaBanco.Id == IdAtleta);

                if(atleta == null)
                {
                    RespostaListaEquipe.Mensagem = $"Não foi encontrado o Atleta com Id {IdAtleta}.";
                    return RespostaListaEquipe;
                }

                RespostaListaEquipe.Dados = atleta.Equipe;
                RespostaListaEquipe.Mensagem = "Equipe localizada.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }

        public async Task<ResponseModel<List<EquipeModel>>> CriarEquipe(EquipeCriacaoDTO equipeCriacaoDTO)
        {
            ResponseModel<List<EquipeModel>> RespostaListaEquipe = new ResponseModel<List<EquipeModel>>();

            try
            {
                var equipe = new EquipeModel()
                {
                    NomeEquipe = equipeCriacaoDTO.NomeEquipe
                };
                _context.Equipes.Add(equipe);
                await _context.SaveChangesAsync();

                RespostaListaEquipe.Dados = await _context.Equipes.ToListAsync();
                RespostaListaEquipe.Mensagem = "Equipe adicionada com sucesso.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }

        public async Task<ResponseModel<List<EquipeModel>>> EditarEquipe(EquipeEdicaoDTO equipeEdicaoDTO)
        {
            ResponseModel<List<EquipeModel>> RespostaListaEquipe = new ResponseModel<List<EquipeModel>>();

            try
            {

                var equipe = _context.Equipes.FirstOrDefault(equipeBanco => equipeBanco.Id == equipeEdicaoDTO.Id);


                if (equipe == null)
                {
                    RespostaListaEquipe.Mensagem = $"Nenhuma equipe com o ID {equipeEdicaoDTO.Id} foi encontrada.";
                    return RespostaListaEquipe;
                }

                equipe.NomeEquipe = equipeEdicaoDTO.NomeEquipe;

                _context.Update(equipe);
                await _context.SaveChangesAsync();

                RespostaListaEquipe.Dados = await _context.Equipes.ToListAsync();
                RespostaListaEquipe.Mensagem = $"Equipe editada com sucesso.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }

        public async Task<ResponseModel<List<EquipeModel>>> ExcluirEquipe(int IdEquipe)
        {
            ResponseModel<List<EquipeModel>> RespostaListaEquipe = new ResponseModel<List<EquipeModel>>();

            try
            {
                var equipe = await _context.Equipes.FirstOrDefaultAsync(equipeBanco => equipeBanco.Id == IdEquipe);

                if (equipe == null)
                {
                    RespostaListaEquipe.Mensagem = $"Nenhuma equipe com o ID {IdEquipe} foi encontrada.";
                    return RespostaListaEquipe;
                }

                _context.Equipes.Remove(equipe);
                await _context.SaveChangesAsync();

                RespostaListaEquipe.Dados = await _context.Equipes.ToListAsync();
                RespostaListaEquipe.Mensagem = "Equipe removida com sucesso.";

                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }

        public async Task<ResponseModel<List<EquipeModel>>> ListarEquipes()
        {
            ResponseModel<List<EquipeModel>> RespostaListaEquipe = new ResponseModel<List<EquipeModel>>();
            try
            {
                var equipes = await _context.Equipes.ToListAsync();

                RespostaListaEquipe.Dados = equipes;
                RespostaListaEquipe.Mensagem = "Todas as Equipes foram listadas.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }
    }
}
