using classroomTask.Contexts;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;
using Task.Persistence.Repositories.Abstraction;

namespace Task.Persistence.Repositories.Implementations
{
    public class ProductRepository : EfRepositoryBase<Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
