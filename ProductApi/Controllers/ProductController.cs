using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTO;
using ProductApi.Repository;

namespace ProductApi.Controllers
{
    [Route("api/v1/controller")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id) {
            return Ok(await _repository.FindById(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            return Ok(await _repository.FindAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            if (product == null) return BadRequest();
            return Ok(await _repository.Create(product));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDTO product)
        {
            if (product == null) return BadRequest();
            return Ok(await _repository.Update(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _repository.Delete(id);
            if (deleted) return Ok();
            return BadRequest("Something went wrong");
        }
    }
}
