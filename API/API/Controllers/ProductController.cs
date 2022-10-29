using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.RequestFromDatabase;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class ProductController: ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpPost("getProduct")]
    public async Task<ActionResult<Product>> getProduct(Product productToFind)
    {
        ManageProduct manageProduct = new ManageProduct();
        Product product = manageProduct.getProduct(productToFind.nombre);
        StatusJSON result;
        if (product.nombre.Equals(""))
        {
            result = new StatusJSON("Error", null);
            return BadRequest(result);
        }
        result = new StatusJSON("ok", product);
        return Ok(result);
    }
    
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<List<Product>>> getAllProducts()
    {
        List<Product> allProducts = new List<Product>();
        ManageProduct manageProduct = new ManageProduct();
        allProducts = manageProduct.getAllProducts();
        StatusJSON json;
        if (allProducts.Count == 0)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }

        json = new StatusJSON("ok", allProducts);
        return Ok(json);

    }

    [HttpPost("addProduct")]
    public async Task<ActionResult<Product>> addProduct(Product newProduct)
    {
        ManageProduct manageProduct = new ManageProduct();
        var addedProduct = manageProduct.addProduct(newProduct);
        StatusJSON json;
        if (!addedProduct)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
            
        }

        json = new StatusJSON("oK", "Product added succesfully");
        return Ok(json);
    }

    [HttpDelete("deleteProduct")]
    public async Task<ActionResult<Product>> deleteProduct(ProductName productToDelete)
    {
        ManageProduct manageProduct = new ManageProduct();
        var deletedProduct = manageProduct.deletePrduct(productToDelete.nombre);
        StatusJSON json;
        if (!deletedProduct)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }
        json = new StatusJSON("ok", "product deleted succesfully");
        return Ok(json);
    }

    [HttpPut("updateProduct")]
    public async Task<ActionResult<Product>> updateProduct(Product productToUpdate)
    {
        ManageProduct manageProduct = new ManageProduct();
        StatusJSON json;
        var updatedProduct = manageProduct.updateProduct(productToUpdate);
        if (!updatedProduct)
        {
            json = new StatusJSON("Error", null);
            return BadRequest(json);
        }
        json = new StatusJSON("ok", "Product updated succesfully");
        return Ok(json);

    }





}