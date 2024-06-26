﻿using RRProject.API.Entities;

namespace RRProject.API.Interfaces
{
    public interface ICandidataRepository
    {
        Task<IEnumerable<Candidata>> GetList();
        Task<Candidata> ListbyId(int id);
    }
}
