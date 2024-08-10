using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController :ControllerBase
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IOrderWriteRepository _orderWriteRepository;
    private readonly ICustomerWriteRepository _customerWriteRepository;
    private readonly IOrderReadRepository _orderReadRepository;



    public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,
        IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
    {
        _productWriteRepository=productWriteRepository;
        _productReadRepository = productReadRepository;
        _orderWriteRepository=orderWriteRepository;
        _customerWriteRepository = customerWriteRepository;
        _orderReadRepository = orderReadRepository;
    }


    [HttpGet]
    public async Task Get()
    {
        Order order = await _orderReadRepository.GetByIdAsync("8ae54b10-0877-48a7-a23c-a87dbba08812");
        order.Address = "New York";
        
        await _orderWriteRepository.SaveAsync(); 

    }
}

