using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        public ProductController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderWriteRepository orderWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }



        [HttpGet]
        public async Task<OkObjectResult> Get()
        {
            var list = _orderReadRepository.GetAll();
            return Ok(list);

        }

    }
}
