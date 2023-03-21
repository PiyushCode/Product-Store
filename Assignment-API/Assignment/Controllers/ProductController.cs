using Assignment.Services.Services.Contracts;
using Assignment.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
			this.productService = productService;
		}

		// GET: api/<ProductController>
		[Route("GetProducts")]
        [HttpGet]
		[Authorize]
		public async Task<IActionResult> Get()
		{
			//we can create global filters for exception handling as well
			try
			{
				var products = await productService.GetAllProductAsync();
				return Ok(products);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// GET api/<ProductController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ProductController>
		[Route("AddProduct")]
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Post([FromBody] AddProductRequestModel addProductRequest)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await productService.AddProduct(addProductRequest);

					return Created("Product/AddProduct", addProductRequest);
				}
				else
					return BadRequest(ModelState);

			}catch (Exception)
			{
				throw; 
			}
		}

		// PUT api/<ProductController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ProductController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
