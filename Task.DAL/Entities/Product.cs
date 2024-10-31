using Core.Persistence.Repositories;

namespace Task.Domain.Entities

{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public Category? Category { get; set; }
        public int ? CategoryId { get; set; }
    }
}
