using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly PublisherContext _context;
    private readonly IMapper _mapper;

    public PublisherRepository(PublisherContext publisherContext, IMapper mapper)
    {
        _context = publisherContext;
        _mapper = mapper;
    }

    public void AddPublisher(Publisher publisher)
    {
        _context.Add(publisher);
    }

    public async Task<Publisher?> GetPublisherByIdAsync(int publisherId)
    {
        return await _context.Publishers.FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }

    public async Task<bool> SaveChangesAsync() {
        return await _context.SaveChangesAsync() > 0;
    }

    
}