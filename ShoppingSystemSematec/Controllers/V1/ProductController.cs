using Microsoft.AspNetCore.Mvc;
using ShoppingSystemSematec.Business;
using ShoppingSystemSematec.Dtos;
using ShoppingSystemSematec.Models;
using System.Net.Mime;

namespace ShoppingSystemSematec.Controllers;

public class ProductController : BaseController
{
    public ProductController() {}

    [Route("{id}")]
    [HttpGet]

    public IActionResult Get([FromRoute]int id)
    {
        ProductBusiness productBusiness = new ProductBusiness();
        var product = productBusiness.GetProductById(id);

        if (product is null)
            return NotFound();

        ProductDto productDto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

        return Ok(productDto);
    }

    [Route("")]
    [HttpDelete]
    public bool Delete()
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Add([FromBody] AddProduct productDto)
    {
        if (string.IsNullOrEmpty(productDto.Name) || productDto.Price <= 0)
            return BadRequest();

        var product = new Product()
        {
            Price = productDto.Price,
            Name = productDto.Name,
            Id = 1,
            CreateAt = DateTime.Now,
        };

        ProductBusiness productBusiness = new ProductBusiness();
        productBusiness.AddProduct(product);

        return Created();
    }

    [Route("")]
    [HttpPut]
    public bool Update(Product product)
    {
        return true;
    }


}
