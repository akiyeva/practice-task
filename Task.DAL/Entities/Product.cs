using Task.Domain.Entities.Common;

namespace Task.Domain.Entities

{
    public class Product : Base
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public Category? Category { get; set; }
    }
}
