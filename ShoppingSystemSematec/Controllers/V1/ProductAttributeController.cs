using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Dtos;
using ShoppingSystemSematec.Controllers;
using ShoppingSystemSematec.Domain.Entities;
using System.Net.Mime;

namespace ShoppingSystemSematec.Api.Controllers.V1;

public class ProductAttributeController : BaseController
{
    private readonly IProductAttributeService _productAttributeService;
    private readonly IMapper _mapper;

    public ProductAttributeController(IProductAttributeService productAttributeService, IMapper mapper)
    {
        _mapper = mapper;
        _productAttributeService = productAttributeService;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductAttributeDto dto)
    {
        var productAttibute = _mapper.Map<ProductAttribute>(dto);
        _productAttributeService.AddProductAttribute(productAttibute);

        return Created();
    }

}
