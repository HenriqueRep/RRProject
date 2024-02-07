using System.ComponentModel.DataAnnotations;

namespace RRProject.API.Entities
{
    public class Candidata
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Clube { get; set; }
        [MaxLength(150)]
        public string Comentario { get; set; }
        public int Beleza { get; set; }
        public int Fantasia { get; set; }
        public int Apresentacao { get; set; }
        public int Total { get; set; }
        public string ImagemUrl { get; set; }
    }
}
