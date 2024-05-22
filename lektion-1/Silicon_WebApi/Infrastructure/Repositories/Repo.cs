using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<TEntity>(ApiContext context) : IRepo<TEntity> where TEntity : class
{
    private readonly ApiContext _context = context;

    // EXISTS
    public virtual async Task<IRepositoryResult<TEntity>> ExistsAsync(Expression<Func<TEntity, bool>> deligate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(deligate);
            if (result)
                return RepositoryResultFactory<TEntity>.Found();

            return RepositoryResultFactory<TEntity>.NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<TEntity>.Error(ex);
        }

    }

    // CREATE
    public virtual async Task<IRepositoryResult<TEntity>> CreateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return RepositoryResultFactory<TEntity>.Created(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<TEntity>.Error(ex);
        }

    }

    // READ
    public virtual async Task<IRepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
                return RepositoryResultFactory<TEntity>.Ok(entity);

            return RepositoryResultFactory<TEntity>.NotFound();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<TEntity>.Error(ex);
        }

    }

    // READ - ALL
    public virtual async Task<IRepositoryResult<IEnumerable<TEntity>>> GetAsync()
    {
        try
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return RepositoryResultFactory<IEnumerable<TEntity>>.Ok(entities);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<IEnumerable<TEntity>>.Error(ex);
        }

    }

    // UPDATE
    public virtual async Task<IRepositoryResult<TEntity>> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return RepositoryResultFactory<TEntity>.Ok(entity);
            }

            return RepositoryResultFactory<TEntity>.NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<TEntity>.Error(ex);
        }

    }

    // DELETE
    public virtual async Task<IRepositoryResult<TEntity>> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return RepositoryResultFactory<TEntity>.Ok();
            }

            return RepositoryResultFactory<TEntity>.NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<TEntity>.Error(ex);
        }

    }

}
