using WebApi8.CadastroAtletasBJJ.Dto.Vinculo;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Dto
{
    public class AtletaCriacaoDTO
    {
        public string Nome { get; set; }
        public double Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Faixa { get; set; }
        public AtletaVinculoDTO Equipe { get; set; }

    }
}
