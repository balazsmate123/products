using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Product.DTO;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDTO> products = new()
        {
            new ProductDTO (Guid.NewGuid(),"Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDTO (Guid.NewGuid(),"Termék2", 3500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new ProductDTO (Guid.NewGuid(),"Termék3", 4500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            return products;
        }
        [HttpGet("{id}")]
        public ProductDTO GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        [HttpPut]
        public ProductDTO PullProduct(Guid id, UpdateProductDTO UpdateProduct)
        {
            var exisitingProduct = products.Where(x => x.Id == id).FirstOrDefault();

            var product = exisitingProduct with
            {
                productName = UpdateProduct.productName,
                ProductPrice = UpdateProduct.ProductPrice,
                ModifiedTime = DateTimeOffset.UtcNow
            };

            var index = products.FindIndex(x => x.Id == id);

            products[index] = product;
            return product;
        }

        [HttpDelete]
        public string DeleteById(Guid id) 
        {
            var index = products.FindIndex(x => x.Id == id);
            products.RemoveAt(index);
            return "Termék törölve";
        }

        [HttpPost]
        public ProductDTO PostProduct(CreateProductDTO createProduct)
        {
            var product = new ProductDTO(Guid.NewGuid(), createProduct.productName, createProduct.ProductPrice, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            products.Add(product);
            return product;
        }
    }
}
