using System.Text.Json.Serialization;

namespace WebApi8.CadastroAtletasBJJ.Models
{
    public class EquipeModel
    {

        public int Id { get; set; }
        public string NomeEquipe { get; set; }
        [JsonIgnore]
        public ICollection<AtletaModel> Atletas { get; set; }


    }
}
