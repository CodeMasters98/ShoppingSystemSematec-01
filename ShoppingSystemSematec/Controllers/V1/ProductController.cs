using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingSystemSematec.Api.Shared.Configs;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Dtos;
using ShoppingSystemSematec.Application.Usecases.Product.Commands;
using ShoppingSystemSematec.Application.Wrappers;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Domain.ValueObjects;
using ShoppingSystemSematec.Infrastructure.Persistence.Repositories;
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
    public async Task<IActionResult> GetAll([FromBody] QueryCriteria queryCriteria = null, CancellationToken ct = default)
    {
        var products = await _productService.FindByQueryCriteria(queryCriteria);
        return Ok(products);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken ct)
    {
        var product = await _productService.FindByCondition(x => x.Id == id, ct);
        if (product is null)
            return NotFound();
        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [Route("")]
    [HttpDelete]
    public async Task<bool> Delete(CancellationToken ct)
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken ct)
        => await SendAsync(command, ct);

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
        //var isActivate = _productService.Activate(productId);
        return true;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using (var memoryStream = new MemoryStream())
        {
            //Businness
            await file.CopyToAsync(memoryStream);
            //imageEntity.Data = memoryStream.ToArray();
        }

        return Ok();
    }

}
