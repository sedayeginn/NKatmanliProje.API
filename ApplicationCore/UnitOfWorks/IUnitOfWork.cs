using ApplicationCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UnitOfWorks
{
   public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository categories { get; }
        Task CommitAsync();
        void Commit();
    }
}
