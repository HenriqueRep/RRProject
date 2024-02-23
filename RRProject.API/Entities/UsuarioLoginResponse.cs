using RRProject.API.Services;
using System.Text.Json.Serialization;

namespace RRProject.API.Entities
{
    public class UsuarioLoginResponse
    {
        public string ID { get; set; }
        public string Usuario { get; set; }
        public bool Sucesso { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DataExpiracao { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioLoginResponse() => Erros = new List<string>();

        public UsuarioLoginResponse(bool sucesso = true) : this() => Sucesso = sucesso;
        public UsuarioLoginResponse(string userid,
                                    string usuario,
                                    bool sucesso,
                                    string token,
                                    DateTime dataExpiracao) : this(sucesso)
        {
            ID = userid;
            Usuario = usuario;
            Token = token;
            DataExpiracao = dataExpiracao;
        }
        public void AdicionarErro(string erro) => Erros.Add(erro);
        public void AdicionarErros(IEnumerable<string> erros) => Erros.AddRange(erros);
    }
}
