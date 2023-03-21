using Assignment.DataLayer.Entities;
using Assignment.DataLayer.Repositories.Contracts;
using Assignment.Services.Services.Implementations;
using Moq;

namespace Assignment.Tests.Services
{
	public class ProductServiceTests
	{
        private readonly Mock<IProductRepository> mockProductRepository;
		private readonly ProductService productService;
		public ProductServiceTests()
        {
			mockProductRepository = new Mock<IProductRepository>();
			productService = new ProductService(mockProductRepository.Object);
		}


		[Fact]
		public async Task GetAllProducts_ValidRequest_ReturnsNonEmptyListofProduct()
		{
			//Arrange
			var dummyProducts = DummyProductList();
			mockProductRepository.Setup(x => x.GetAllProductAsync()).ReturnsAsync(dummyProducts);

			//Act
			var response = await productService.GetAllProductAsync();
			mockProductRepository.Verify(x => x.GetAllProductAsync(), Times.Once);

			//Assert
			Assert.NotNull(response);
			Assert.NotEmpty(response);
		}


		private List<Product> DummyProductList()
		{
			var products = new List<Product>
			{
				new Product { Id = Guid.NewGuid(), Category = new Category() { Id = Guid.NewGuid(), Name = "C1" }, Name = "P1", Price = 1, Rating = 2 }
			};

			return products;
		}
    }
}
