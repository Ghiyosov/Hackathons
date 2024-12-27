using System.Net;
using Domein.DTOs;
using Domein.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackatonService(DataContext _data) : IHackathonService
{
    public async Task<Response<List<HackatonDTO>>> GetHackathons()
    {
        var resHackatons = await _data.Hackathons.ToListAsync();
        var resDTO = resHackatons.Select(x => new HackatonDTO()
        {
            Id = x.Id,
            Name = x.Name,
            Date = x.Date,
            Theme = x.Theme
        });
        return new Response<List<HackatonDTO>>(resDTO.ToList());
    }

    public async Task<Response<string>> AddHackathon(HackatonDTO hackaton)
    {
        var hac = new Hackathon()
        {
            Name = hackaton.Name,
            Date = hackaton.Date,
            Theme = hackaton.Theme
        };
        await _data.Hackathons.AddAsync(hac);
        var resHackatons = await _data.SaveChangesAsync();
        return resHackatons == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Hackathon not created")
            : new Response<string>("Hackathon created successfully");
    }

    public async Task<Response<string>> UpdateHackathon(HackatonDTO hackaton)
    {
        var resHackaton = await _data.Hackathons.FirstOrDefaultAsync(x=>x.Id == hackaton.Id);
        if (resHackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Hackathon not found");
        }
        resHackaton.Name = hackaton.Name;
        resHackaton.Date = hackaton.Date;
        resHackaton.Theme = hackaton.Theme;
        var res = await _data.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Hackathon not updated")
            : new Response<string>("Hackathon updated successfully");
    }

    public async Task<Response<string>> DeleteHackathon(int id)
    {
        var resHackaton = await _data.Hackathons.FirstOrDefaultAsync(x=>x.Id == id);
        if (resHackaton == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Hackathon not found");
        }
        _data.Hackathons.Remove(resHackaton);
        var res = await _data.SaveChangesAsync();
        return res == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Hackathon not deleted")
            : new Response<string>("Hackathon deleted successfully");
    }

    public async Task<Response<Hackathon>> GetHackathonTeamsById(int id)
    {
        var resHack = await _data.Hackathons
            .Include(x=>x.Teams)
            .FirstOrDefaultAsync(x=>x.Id == id);
        if (resHack == null)
        {
            return new Response<Hackathon>(HttpStatusCode.NotFound,"Hackathon not found");
        }
        return new Response<Hackathon>(resHack);
        
    }
}