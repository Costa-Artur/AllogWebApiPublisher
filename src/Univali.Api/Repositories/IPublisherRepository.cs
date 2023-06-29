using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public interface IPublisherRepository
{
    // CONTEXT COMMIT
    Task<bool> SaveChangesAsync();
    //PUBLISHER
    void AddPublisher (Publisher publisher);

    Task<Publisher?> GetPublisherByIdAsync (int publisherId);
}