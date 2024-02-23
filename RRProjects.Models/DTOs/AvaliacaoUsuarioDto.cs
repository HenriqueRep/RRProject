namespace RRProject.Models.DTOs
{
    public class AvaliacaoUsuarioDto
    {
        public int Id { get; set; }
        public int CandidataIdenti { get; set; }
        public string? UsuarioIdenti { get; set; }
        public int NotaBeleza { get; set; }
        public int NotaFantasia { get; set; }
        public int NotaApresentacao { get; set; }
        public string? Comentario { get; set; }
        public int TotalVotos { get; set; }
    }
}
