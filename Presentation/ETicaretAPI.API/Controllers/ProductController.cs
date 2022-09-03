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


        //[HttpGet]
        //public async Task Get()
        //{
        //    var customerId = Guid.NewGuid();

        //    await _customerWriteRepository.AddAsync( new() { Id = customerId, Name = "Abuzittin" });

        //    await _orderWriteRepository.AddAsync(new() { Description = "do not ring the bell", Addres = "Istanbul, Sancaktepe", CustomerId = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "Seffaf kargoss", Addres = "Istanbul, Uskudar", CustomerId = customerId });

        //    await _orderWriteRepository.SaveAsync(); //scopedaki bütün değişiklikleri kaydeder, customer içinde geçerli !!
        //}

        [HttpGet]
        public async Task Get()
        {
            // 4e09c081-e68e-41c9-be0e-4abc3526a708
            var order = await _orderReadRepository.GetByIdAsync("4e09c081-e68e-41c9-be0e-4abc3526a708");
            order.Addres = "Ankara, Çankaya";

            await _orderWriteRepository.SaveAsync();

        }

        //[HttpGet]
        //public async Task Get()
        //{
        //    var product = await _productReadRepository.GetByIdAsync("56cecdb7-13ab-42d5-90bb-579f23858055", false);
        //    product.Name = "HeadPhones";
        //    var count = await _productWriteRepository.SaveAsync();
        //}
    }
}
