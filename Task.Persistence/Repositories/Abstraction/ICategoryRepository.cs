using Core.Persistence.Repositories;
using Task.Domain.Entities;

namespace Task.Persistence.Repositories.Abstraction
{
    public interface ICategoryRepository : IRepositoryAsync<Category>
    {
    }
}
