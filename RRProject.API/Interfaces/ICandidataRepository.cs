using RRProject.API.Entities;
using RRProject.Models.DTOs;

namespace RRProject.API.Interfaces
{
    public interface ICandidataRepository
    {
        Task<IEnumerable<Candidata>> GetList();
        Task<Candidata> ListbyId(int id);
    }
}
