namespace Task.Application.Dtos
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class ProductCreateDto : IDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductUpdateDto : IDto 
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductListDto : IDto
    {
        public List<ProductDto> Items { get; set; } = [];
    }
}
