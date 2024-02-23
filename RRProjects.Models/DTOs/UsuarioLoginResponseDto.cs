namespace RRProject.Models.DTOs
{
    public class UsuarioLoginResponseDto
    {
        public string ID { get; set; }
        public string Usuario { get; set; }
        public bool Sucesso { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
