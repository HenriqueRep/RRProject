using Microsoft.EntityFrameworkCore;
using RRProject.API.Context;
using RRProject.API.Entities;
using RRProject.API.Interfaces;

namespace RRProject.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            var users = await _context.Usuarios.ToListAsync();
            return users;
        }

        public async Task<Usuario> GetUser(int id)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync(c => c.Id == id);
            return user;
        }
    }
}
