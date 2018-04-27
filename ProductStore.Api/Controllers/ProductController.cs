using Microsoft.AspNetCore.Mvc;
using ProductStore.Api.Models;
using ProductStore.Api.Repositories;
using ProductStore.Api.ViewModels;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductStore.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// ctor
        /// </summary>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return ModelBadRequest();
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await _productRepository.CreateAsync(product);

            return CreatedAtRoute("Get", new { Controller = "Product", id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return ModelBadRequest();
            }

            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };

            return Ok(model);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductListViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            var items = products.Select(product => new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            });

            var model = new ProductListViewModel(items);

            return Ok(model);
        }

        private IActionResult ModelBadRequest()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(x => new
            {
                message = (x.Exception == null) ? x.ErrorMessage : x.Exception.Message
            });

            return BadRequest(errors);
        }
    }
}