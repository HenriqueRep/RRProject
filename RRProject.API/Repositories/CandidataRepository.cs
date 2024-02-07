using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RRProject.API.Context;
using RRProject.API.Entities;
using RRProject.API.Interfaces;

namespace RRProject.API.Repositories
{
    public class CandidataRepository : ICandidataRepository
    {
        private readonly AppDbContext _context;
        public CandidataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Candidata> ListbyId(int id)
        {
            var candidata = await _context.Candidatas.SingleOrDefaultAsync(c => c.Id == id);
            return candidata;
        }

        public async Task<IEnumerable<Candidata>> GetList()
        {
            var candidatas = await _context.Candidatas.ToListAsync();
            return candidatas;
        }
    }
}
