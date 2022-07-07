using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Abstraction;
using Infrastructure.Data;

namespace Infrastructure.Implementation
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly StoreContext _context;
        private Hashtable? _repositories;
        public UnityOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repositoryy<TEntity>() where TEntity : BaseEntity
        {
           if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>) _repositories[type];
        }
    }
}