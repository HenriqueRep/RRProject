using RRProject.Models.DTOs;

namespace RRProject.Web.Interfaces
{
    public interface ICandidataService
    {
        Task<IEnumerable<CandidataDto>> GetCandidates();
        Task<CandidataDto> GetCandidatebyID(int id);
    }
}
