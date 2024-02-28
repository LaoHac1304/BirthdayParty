using BirthdayParty.Domain.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();

        IGenericRepository<TEntity> GetRepository<TEntity>()
           where TEntity : class;

        /*TEntityRepository? Resolve<TEntity, TEntityRepository>()
            where TEntity : class
            where TEntityRepository : IGenericRepository<TEntity>;*/

    }
}
