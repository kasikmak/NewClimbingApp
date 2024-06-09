using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    protected readonly NewClimbingAppContext? context;
    private DbSet<T> entities;

    public Repository(NewClimbingAppContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }
   
    public Task<List<T>> GetAll()
    {
        return entities.ToListAsync();
    }
    public Task<T> GetById(int id)
    {
        return entities.SingleOrDefaultAsync(s => s.Id == id);
    }
    public Task Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        entities.Add(entity);
        return context.SaveChangesAsync();
    }
    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        return context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
        entities.Remove(entity);
        await context.SaveChangesAsync();
    }
}
