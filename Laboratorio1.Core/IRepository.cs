using System;
using System.Linq;
using System.Net;

namespace Laboratorio1.Core
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        IQueryable<TEntity> All();

        TEntity GetById(long id);

        TEntity Update(TEntity entity);

        int SaveChanges();
    }
}
