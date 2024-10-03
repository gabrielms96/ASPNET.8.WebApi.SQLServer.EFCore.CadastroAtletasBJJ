using WebApi8.CadastroAtletasBJJ.Migrations;

namespace WebApi8.CadastroAtletasBJJ.Models
{
    //T para aceitar tanto equipe quanto atleta
    public class ResponseModel<T>
    {
        //dados pode vir nulo
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
