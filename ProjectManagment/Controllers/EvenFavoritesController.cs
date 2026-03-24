using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventFavoritesController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public EventFavoritesController(CalendarDbContext context)
    {
        _context = context;
    }

    // GET: api/EventFavorites (See all saved events)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventFavorite>>> GetFavorites()
    {
        return await _context.EventFavorites.ToListAsync();
    }

    // POST: api/EventFavorites (A student clicks the "Heart" or "Save" button)
    [HttpPost]
    public async Task<ActionResult<EventFavorite>> PostFavorite(EventFavorite favorite)
    {
        _context.EventFavorites.Add(favorite);
        await _context.SaveChangesAsync();

        return Ok(favorite);
    }
}