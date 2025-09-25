using CarrinhoApi.DTO;
using CarrinhoApi.RabbitMQSender;
using CarrinhoApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarrinhoApi.Controllers
{
    [Route("api/v1/controller")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private IProductRepository _repository;
        private ICarrinhoRepository _carrinhoRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        public CarrinhoController(IProductRepository repository,
            ICarrinhoRepository carrinhoRepository,
            IRabbitMQMessageSender rabbitMQMessageSender
            )
        {
            _repository = repository;
            _carrinhoRepository = carrinhoRepository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _repository.FindById(id));
        }
        [HttpPost("checkout")]
        [Authorize]
        public async Task<ProductDTO> Checkout(ProductDTO productdto)
        {
            _rabbitMQMessageSender.SendMessage(productdto, "checkoutqueue");
            return await _repository.FindById(productdto.Id);   
        }
    }
}
