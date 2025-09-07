using Microsoft.AspNetCore.Mvc;
using Senac.StockManagement.Application.Commands.CreateProduct;
using Senac.StockManagement.Application.Commands.UpdateProduct;
using Senac.StockManagement.Application.Queries.GetAllProducts;
using Senac.StockManagement.Application.Queries.GetProductById;

namespace Senac.StockManagement.API.Controllers.V1;

public class ProductController : BaseApiController
{
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">Command containing the necessary data to create the product.</param>
    /// <returns>
    /// Returns HTTP 201 (Created) status with the result of the product creation.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommandRequest command)
    {
        var result = await Mediator.Send(command);
        return Created(string.Empty, result);
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="command">Command containing the necessary data to update the product.</param>
    /// <returns>
    /// Returns HTTP 200 (OK) status with the result of the product update.
    /// </returns>
    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommandRequest command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 (OK) status with a list of all products.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        var query = new GetAllProductsQueryRequest();
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Gets a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>
    /// Returns HTTP 200 (OK) status with the product data.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var query = new GetProductByIdQueryRequest { Id = id };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}