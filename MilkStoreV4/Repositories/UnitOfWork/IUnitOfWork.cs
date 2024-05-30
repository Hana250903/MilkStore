using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();

        Task<UnitOfWork> SaveAsync();
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Product> ProductRepository { get; }


    }
}
