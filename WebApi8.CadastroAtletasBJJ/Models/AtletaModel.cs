namespace WebApi8.CadastroAtletasBJJ.Models
{
    public class AtletaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Peso{ get; set; }
        public DateTime DataNascimento { get; set; }
        public string Faixa { get; set; }
        public EquipeModel Equipe{ get; set; }

    }
}
