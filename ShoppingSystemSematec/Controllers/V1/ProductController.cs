using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingSystemSematec.Api.Shared.Configs;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Dtos;
using ShoppingSystemSematec.Domain.Entities;
using System.Net.Mime;

namespace ShoppingSystemSematec.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;

    public ProductController(IProductService productService, IMapper mapper, IOptionsSnapshot<MySettings> mySettings)
    {
        _mySettings = mySettings.Value;
        _mapper = mapper;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Product> products = await _productService.GetProducts();
        return Ok(products);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {

        Product product = await _productService.GetProductById(id);

        if (product is null)
            return NotFound();

        product.Name = $" {_mySettings.StringSetting}  {product.Name}";
        var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [Route("")]
    [HttpDelete]
    public async Task<bool> Delete()
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productService.AddProduct(product);

        return Created();
    }

    [Route("")]
    [HttpPut]
    public bool Update(Product product)
    {
        return true;
    }

    [Route("")]
    [HttpPut]
    public bool Activate([FromRoute] int productId)
    {
        var isActivate = _productService.Activate(productId);
        return true;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            //imageEntity.Data = memoryStream.ToArray();
        }

        return Ok();
    }

}
