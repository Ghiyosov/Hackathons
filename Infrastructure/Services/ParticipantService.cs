using System.Net;
using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(DataContext _data) : IParticiantService
{
    public async Task<Response<List<ParticiantDTO>>> GetParticiants()
    {
        var resPar = await _data.Participants.ToListAsync();
        var resDTO = resPar.Select(x => new ParticiantDTO()
        {
            Id = x.Id,
            Name = x.Name,
            Role = x.Role,
            JoinedDate = x.JoinedDate
        });
        return new Response<List<ParticiantDTO>>(resDTO.ToList());
    }

    public async Task<Response<string>> AddParticiant(ParticiantDTO particiant)
    {
        var par = new Participant()
        {
            Name = particiant.Name,
            Email = particiant.Email,
            TeamId = particiant.TeamId,
            Role = particiant.Role,
            JoinedDate = particiant.JoinedDate
        };
        var resPar = _data.Participants.Add(par);
        var res = _data.SaveChanges();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Team not created")
            : new Response<string>("Team created successfully");
    }

    public async Task<Response<string>> UpdateParticant(ParticiantDTO particiant)
    {
        var par = await _data.Participants.FirstOrDefaultAsync(x => x.Id == particiant.Id);
        if (par == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }
        par.Name =particiant.Name;
        par.Email = particiant.Email;
        par.TeamId = particiant.TeamId;
        par.Role = particiant.Role;
        par.JoinedDate = particiant.JoinedDate;
        
        var resPar = await _data.SaveChangesAsync();
        return resPar == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Participant not updated")
            : new Response<string>("Participant updated successfully");

    }

    public async Task<Response<string>> DeleteParticiant(int id)
    {
        var resPar = await _data.Participants.FirstOrDefaultAsync(x => x.Id == id);
        if (resPar == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        }
        _data.Participants.Remove(resPar);
        var res = await _data.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Participant not deleted")
            : new Response<string>("Participant deleted successfully");

    }
}