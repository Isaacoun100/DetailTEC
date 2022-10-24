using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/")]
[ApiController]
public class InvoiceController: ControllerBase
{
    private static List<Invoice> invoices = new List<Invoice>();

    [HttpGet("getAllInvoices")]
    public async Task<ActionResult<List<Invoice>>> getAllInvoices()
    {
        if (invoices.Count == 0)
        {
            return BadRequest("No invoices found");
        }
        return Ok(invoices);
    }

    [HttpPost("addInvoice")]
    public async Task<ActionResult<List<Invoice>>> addInvoice(Invoice newInvoice)
    {
        invoices.Add(newInvoice);
        return Ok(invoices);
    }

    [HttpPost("getInvoice")]
    public async Task<ActionResult<Invoice>> getInvoice(InvoiceID invoiceToGet)
    {
        var invoice = invoices.Find(h => h.ID_Factura == invoiceToGet.ID_Factura);
        if (invoice == null)
        {
            return BadRequest("Invoice not found");
        }

        return Ok(invoice);
    }

    [HttpDelete("deleteInvoice")]
    public async Task<ActionResult<Invoice>> deleteInvoice(InvoiceID invoiceToDelete)
    {
        var invoice = invoices.Find(h => h.ID_Factura == invoiceToDelete.ID_Factura);
        if (invoice == null)
        {
            return BadRequest("Invoice not found");
        }

        invoices.Remove(invoice);
        return Ok(invoices);
    }

    [HttpPut("updateInvoice")]
    public async Task<ActionResult<Invoice>> updateInvoice(Invoice invoiceToUpdate)
    {
        var invoice = invoices.Find(h => h.ID_Factura == invoiceToUpdate.ID_Factura);
        if (invoice == null)
        {
            return BadRequest("Invoice not found");
        }

        invoice.monto = invoiceToUpdate.monto;
        invoice.productosConsumidos = invoiceToUpdate.productosConsumidos;
        invoice.iva = invoiceToUpdate.iva;
        invoice.servicios = invoiceToUpdate.servicios;
        invoice.ID_Factura = invoiceToUpdate.ID_Factura;

        return Ok(invoices);
        
    }

    [HttpPut("assignPoints")]
    public async Task<ActionResult<Invoice>> assignPoints(PointsManager pointsManager)
    {
        //Accesar a la base de datos de clientes y asignar o sustraer puntos
        return Ok("Client has been asigned points");
    }
    
    [HttpPut("pointsPayment")]
    public async Task<ActionResult<Invoice>> pointsPayment(PointsManager pointsManager)
    {
        //Accesar a la base de datos de clientes y asignar o sustraer puntos
        return Ok("Client has been sustracted points");
    }
    




















}