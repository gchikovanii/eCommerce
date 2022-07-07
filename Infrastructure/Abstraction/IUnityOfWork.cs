using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Abstraction
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<TEntity> Repositoryy<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();

    }
}