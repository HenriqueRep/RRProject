using AutoMapper;
using RRProject.API.Context;
using RRProject.API.Entities;
using RRProject.API.Interfaces;

namespace RRProject.API.Repositories
{
    public class VotoUsuarioRepository : IVotoUsuarioRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VotoUsuarioRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Candidata> AdicionarCandidata(Candidata candidata)
        {
            throw new NotImplementedException();
        }

        public Task<Candidata> AtualizarCandidata(Candidata candidata)
        {
            throw new NotImplementedException();
        }

        public Task<Candidata> ListarporID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Candidata> ProcurarCandidata()
        {
            throw new NotImplementedException();
        }

        public Task<Candidata> RemoverCandidata(Candidata candidata)
        {
            throw new NotImplementedException();
        }
    }
}
