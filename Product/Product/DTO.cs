namespace Product
{
    public class DTO
    {
        public record ProductDTO(Guid Id, string productName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);

        public record CreateProductDTO(string productName, int ProductPrice);

        public record UpdateProductDTO(string productName, int ProductPrice);
    }
}
