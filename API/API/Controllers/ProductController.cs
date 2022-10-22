using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class ProductController: ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpPost("getProduct")]
    public async Task<ActionResult<Product>> getProduct(string productToFind)
    {
        var product = products.Find(h => h.nombre == productToFind);
        if (product == null)
        {
            return BadRequest("Product not found");
        }

        return Ok(product);
    }

    [HttpPost("addProduct")]
    public async Task<ActionResult<Product>> addProduct(Product newProduct)
    {
        products.Add(newProduct);
        return Ok(products);
    }

    [HttpDelete("deleteProduct")]
    public async Task<ActionResult<Product>> deleteProduct(string productToDelete)
    {
        var product = products.Find(h => h.nombre == productToDelete);
        if (product == null)
        {
            return BadRequest("Product not found");
        }

        products.Remove(product);
        return Ok(products);
    }

    [HttpPut("updateProduct")]
    public async Task<ActionResult<Product>> updateProduct(Product productToUpdate)
    {
        var product = products.Find(h => h.nombre == productToUpdate.nombre);
        if (product == null)
        {
            return BadRequest("Product not found");
        }

        product.nombre = productToUpdate.nombre;
        product.marca = productToUpdate.marca;
        product.costo = productToUpdate.costo;
        product.proveedores = productToUpdate.proveedores;

        return Ok(products);

    }





}