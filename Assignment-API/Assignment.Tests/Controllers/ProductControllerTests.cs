using Assignment.Api.Controllers;
using Assignment.Services.Services.Contracts;
using Assignment.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Assignment.Tests.Controllers
{
	public class ProductControllerTests
	{
		private readonly Mock<IProductService> mockProductService;
		private readonly ProductController productController;

        public ProductControllerTests()
        {
			mockProductService = new Mock<IProductService>();
			productController = new ProductController(mockProductService.Object);
		}

		[Fact]
		public async Task AddProduct_WithValidRequest_CreatedResponse()
		{
			//Arrange
			var dummyAddProductRequest = DummyAddProductRequest();
			mockProductService.Setup(x => x.AddProduct(dummyAddProductRequest));

			//Act
			var response = await productController.Post(dummyAddProductRequest) as CreatedResult;
			mockProductService.Verify(x=>x.AddProduct(dummyAddProductRequest), Times.Once);

			//Assert
			Assert.Equal((int)HttpStatusCode.Created, response.StatusCode.Value);

		}

		[Fact]
		public async Task AddProduct_WithInVaildRequest_BadRquest()
		{
			//Arrange
			var dummyAddProductRequest = DummyAddProductRequest();
			dummyAddProductRequest.ProductName = null;
			productController.ModelState.AddModelError("ProductName", "Required");

			//Act
			var response = await productController.Post(dummyAddProductRequest) as BadRequestObjectResult;

			//Assert
			Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode.Value);

		}


		#region private methods for dummy data

		private AddProductRequestModel DummyAddProductRequest()
		{
			return new AddProductRequestModel
			{
				CategoryId = Guid.Parse("42b2abcb-90d2-4f85-9ceb-75569c814f7d"),
				Price = 5.5,
				ProductName = "test"
			};
		}

		#endregion

	}
}
