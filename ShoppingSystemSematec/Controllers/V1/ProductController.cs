﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShoppingSystemSematec.Api.Shared.Configs;
using ShoppingSystemSematec.Application.Interfaces;
using ShoppingSystemSematec.Domain.Entities;
using ShoppingSystemSematec.Dtos;
using System.Net.Mime;

namespace ShoppingSystemSematec.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;
    public ProductController(IProductService productBusiness, IMapper mapper, IOptionsSnapshot<MySettings> mySettings)
    {
        _mySettings = mySettings.Value;
        _mapper = mapper;
        _productBusiness = productBusiness;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        List<Product> products = await _productBusiness.GetProducts();
        return Ok(products);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {

        Product product = await _productBusiness.GetProductById(id);

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
        _productBusiness.AddProduct(product);

        return Created();
    }

    [Route("")]
    [HttpPut]
    public bool Update(Product product)
    {
        return true;
    }


}
