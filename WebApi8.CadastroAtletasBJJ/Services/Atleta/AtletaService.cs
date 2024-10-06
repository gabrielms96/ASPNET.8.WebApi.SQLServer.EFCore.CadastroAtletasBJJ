using Microsoft.EntityFrameworkCore;
using WebApi8.CadastroAtletasBJJ.Data;
using WebApi8.CadastroAtletasBJJ.Dto;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Services.Atleta
{
    public class AtletaService : IAtletaService
    {
        private readonly AppDbContext _context;

        public AtletaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AtletaModel>> BuscarAtletaPorId(int IdAtleta)
        {
            ResponseModel<AtletaModel> RespostaListaEquipe = new ResponseModel<AtletaModel>();
            try
            {
                var atleta = await _context.Atletas.Include(e => e.Equipe).FirstOrDefaultAsync(atletasBanco => atletasBanco.Id == IdAtleta);

                if (atleta == null)
                {
                    RespostaListaEquipe.Mensagem = $"Nenhum atleta com o ID {IdAtleta} foi encontrada.";
                    return RespostaListaEquipe;
                }

                RespostaListaEquipe.Dados = atleta;
                RespostaListaEquipe.Mensagem = "Atleta localizado.";
                return RespostaListaEquipe;

            }
            catch (Exception ex)
            {
                RespostaListaEquipe.Mensagem = ex.Message;
                RespostaListaEquipe.Status = false;
                return RespostaListaEquipe;
            }
        }


        public async Task<ResponseModel<List<AtletaModel>>> BuscarAtletaPorIdEquipe(int IdEquipe)
        {
            ResponseModel<List<AtletaModel>> RespostaListaEquipe = new ResponseModel<List<AtletaModel>>();
            try
            {
                var atleta = await _context.Atletas
                    .Include(e => e.Equipe)
                    .Where(atletaBanco => atletaBanco.Equipe.Id == IdEquipe)
                    .ToListAsync();

                if (atleta == null)
                {
                    RespostaListaEquipe.Mensagem = $"Não foi encontrado o Atleta com Id {IdEquipe}.";
                    return RespostaListaEquipe;
                }

                RespostaListaEquipe.Dados = atleta;
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

        public async Task<ResponseModel<List<AtletaModel>>> CriarAtleta(AtletaCriacaoDTO atletaCriacaoDTO)
        {
            ResponseModel<List<AtletaModel>> RespostaListaAtleta = new ResponseModel<List<AtletaModel>>();

            try
            {
                var equipe = await _context.Equipes.
                    FirstOrDefaultAsync(equipeBanco => equipeBanco.Id == atletaCriacaoDTO.Equipe.Id);

                if (equipe == null)
                {
                    RespostaListaAtleta.Mensagem = "Equipe não encontrada.";
                    return RespostaListaAtleta;
                }

                var atleta = new AtletaModel()
                {
                    Nome = atletaCriacaoDTO.Nome,
                    DataNascimento = atletaCriacaoDTO.DataNascimento,
                    Faixa = atletaCriacaoDTO.Faixa,
                    Peso = atletaCriacaoDTO.Peso,
                    Equipe = equipe
                };


                _context.Add(atleta);

                await _context.SaveChangesAsync();

                RespostaListaAtleta.Dados = await _context.Atletas.Include(e => e.Equipe).ToListAsync();

                return RespostaListaAtleta;

            }
            catch (Exception ex)
            {
                RespostaListaAtleta.Mensagem = ex.Message;
                RespostaListaAtleta.Status = false;
                return RespostaListaAtleta;
            }
        }

        public async Task<ResponseModel<List<AtletaModel>>> EditarAtleta(AtletaEdicaoDTO atletaEdicaoDTO)
        {
            ResponseModel<List<AtletaModel>> RespostaListaAtleta = new ResponseModel<List<AtletaModel>>();

            try
            {

                var atleta = await _context.Atletas
                    .Include(e => e.Equipe)
                    .FirstOrDefaultAsync(altetaBanco => altetaBanco.Id == atletaEdicaoDTO.Id);

                var equipe = await _context.Equipes
                    .FirstOrDefaultAsync(equipesBanco => equipesBanco.Id == atletaEdicaoDTO.Equipe.Id);

                if (atleta == null)
                {
                    RespostaListaAtleta.Mensagem = $"Nenhuma equipe foi encontrada.";
                    return RespostaListaAtleta;
                }

                if (equipe == null)
                {
                    RespostaListaAtleta.Mensagem = $"Nenhum atleta encontrada.";
                    return RespostaListaAtleta;
                }

                atleta.Nome = atletaEdicaoDTO.Nome;
                atleta.Peso = atletaEdicaoDTO.Peso;
                atleta.DataNascimento = atletaEdicaoDTO.DataNascimento;
                atleta.Faixa = atletaEdicaoDTO.Faixa;
                atleta.Equipe = equipe;

                _context.Update(atleta);
                await _context.SaveChangesAsync();

                RespostaListaAtleta.Dados = await _context.Atletas.ToListAsync();
                RespostaListaAtleta.Mensagem = $"Atleta editado com sucesso.";
                return RespostaListaAtleta;

            }
            catch (Exception ex)
            {
                RespostaListaAtleta.Mensagem = ex.Message;
                RespostaListaAtleta.Status = false;
                return RespostaListaAtleta;
            }
        }

        public async Task<ResponseModel<List<AtletaModel>>> ExcluirAtleta(int IdAtleta)
        {
            ResponseModel<List<AtletaModel>> RespostaListaAtleta = new ResponseModel<List<AtletaModel>>();

            try
            {
                var atleta = await _context.Atletas.FirstOrDefaultAsync(atletaBanco => atletaBanco.Id == IdAtleta);

                if (atleta == null)
                {
                    RespostaListaAtleta.Mensagem = $"Nenhum atleta com o ID {IdAtleta} foi encontrado.";
                    return RespostaListaAtleta;
                }

                _context.Atletas.Remove(atleta);
                await _context.SaveChangesAsync();

                RespostaListaAtleta.Dados = await _context.Atletas.ToListAsync();
                RespostaListaAtleta.Mensagem = "Atleta removido com sucesso.";

                return RespostaListaAtleta;

            }
            catch (Exception ex)
            {
                RespostaListaAtleta.Mensagem = ex.Message;
                RespostaListaAtleta.Status = false;
                return RespostaListaAtleta;
            }
        }

        public async Task<ResponseModel<List<AtletaModel>>> ListarAtletas()
        {
            ResponseModel<List<AtletaModel>> RespostaListaAtletas = new ResponseModel<List<AtletaModel>>();
            try
            {
                var atletas = await _context.Atletas.Include(e => e.Equipe).ToListAsync();

                RespostaListaAtletas.Dados = atletas;
                RespostaListaAtletas.Mensagem = "Todos as Atletas foram listados.";
                return RespostaListaAtletas;

            }
            catch (Exception ex)
            {
                RespostaListaAtletas.Mensagem = ex.Message;
                RespostaListaAtletas.Status = false;
                return RespostaListaAtletas;
            }
        }
    }
}

