using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventRegistrationsController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public EventRegistrationsController(CalendarDbContext context)
    {
        _context = context;
    }

    // 1. GET: api/EventRegistrations (See everyone who RSVP'd)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventRegistration>>> GetRegistrations()
    {
        return await _context.EventRegistrations.ToListAsync();
    }

    // 2. POST: api/EventRegistrations (A student clicks RSVP)
    [HttpPost]
    public async Task<ActionResult<EventRegistration>> PostRegistration(EventRegistration registration)
    {
        _context.EventRegistrations.Add(registration);
        await _context.SaveChangesAsync();

        return Ok(registration);
    }
}