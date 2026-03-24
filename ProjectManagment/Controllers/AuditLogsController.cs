using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuditLogsController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public AuditLogsController(CalendarDbContext context)
    {
        _context = context;
    }

    // GET: api/AuditLogs (Admin dashboard to view all system actions)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuditLog>>> GetAuditLogs()
    {
        return await _context.AuditLogs.ToListAsync();
    }

    // POST: api/AuditLogs (Log a new action securely)
    [HttpPost]
    public async Task<ActionResult<AuditLog>> PostAuditLog(AuditLog log)
    {
        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();

        return Ok(log);
    }
}