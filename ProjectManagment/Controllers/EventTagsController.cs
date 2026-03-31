using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventTagsController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public EventTagsController(CalendarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventTag>>> GetEventTags()
    {
        return await _context.EventTags.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<EventTag>> PostEventTag(EventTag eventTag)
    {
        _context.EventTags.Add(eventTag);
        await _context.SaveChangesAsync();
        return Ok(eventTag);
    }
}