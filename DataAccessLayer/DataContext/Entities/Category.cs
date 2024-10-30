using core.Persistence.Repositories;

namespace DataAccessLayer.DataContext.Entities
{
    public class Category : Entity
    {
        public required string Name { get; set; }
    }
}
