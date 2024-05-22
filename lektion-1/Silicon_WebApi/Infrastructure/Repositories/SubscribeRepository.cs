using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories;


public class SubscribeRepository(ApiContext context) : Repo<SubscribeEntity>(context), ISubscribeRepository
{
    private readonly ApiContext _context = context;
}
