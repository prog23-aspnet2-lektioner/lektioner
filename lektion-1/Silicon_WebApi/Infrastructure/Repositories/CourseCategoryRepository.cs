using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories;

public class CourseCategoryRepository(ApiContext context) : Repo<CourseCategoryEntity>(context) , ICourseCategoryRepository
{
    private readonly ApiContext _context = context;
}
