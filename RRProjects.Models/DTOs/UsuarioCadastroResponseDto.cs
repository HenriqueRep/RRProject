using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRProject.Models.DTOs
{
    public class UsuarioCadastroResponseDto
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioCadastroResponseDto() => Erros = new List<string>();

        public UsuarioCadastroResponseDto(bool sucesso = true) : this() => Sucesso = sucesso;

        public void AdicionarErros(IEnumerable<string> erros) => Erros.AddRange(erros);
    }
}
