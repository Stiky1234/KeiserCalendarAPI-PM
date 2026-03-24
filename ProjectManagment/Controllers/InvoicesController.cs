using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public InvoicesController(CalendarDbContext context)
    {
        _context = context;
    }

    // GET: api/Invoices (View billing history)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
    {
        return await _context.Invoices.ToListAsync();
    }

    // POST: api/Invoices (Generate a new bill)
    [HttpPost]
    public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return Ok(invoice);
    }
}