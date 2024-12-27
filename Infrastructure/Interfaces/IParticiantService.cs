using Domein.DTOs;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IParticiantService
{
    public Task<Response<List<ParticiantDTO>>> GetParticiants();
    public Task<Response<string>> AddParticiant(ParticiantDTO particiant);
    public Task<Response<string>> UpdateParticant(ParticiantDTO particiant);
    public Task<Response<string>> DeleteParticiant(int id);
}