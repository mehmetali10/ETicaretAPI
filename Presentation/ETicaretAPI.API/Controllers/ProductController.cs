﻿using ETicaretAPI.Application.Repositories;
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

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id= Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name="Product1", Price=100, Stock=10},
                new() {Id= Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name="Product2", Price=200, Stock=20},
                new() {Id= Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name="Product3", Price=300, Stock=30}
            });

            var count = await _productWriteRepository.SaveAsync();
        }
    }
}
