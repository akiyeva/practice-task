using Core.Persistence.Repositories;

namespace Task.Domain.Entities
{
    public class Category : Entity  
    {
        public string? Name { get; set; }
    }
}
