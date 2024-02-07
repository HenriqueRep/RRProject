using System.ComponentModel.DataAnnotations;

namespace RRProject.API.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nome { get; set; }
        [MaxLength(30)]
        public string Senha { get; set; }
    }
}
