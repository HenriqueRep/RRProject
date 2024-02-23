namespace RRProject.API.Entities
{
    public class UsuarioLogoutResponse
    {
        public bool Sucesso { get; }

        public UsuarioLogoutResponse(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}
