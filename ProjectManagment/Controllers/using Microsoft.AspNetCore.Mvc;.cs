using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserSubscriptionsController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public UserSubscriptionsController(CalendarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserSubscription>>> GetSubscriptions()
    {
        return await _context.UserSubscriptions.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<UserSubscription>> PostSubscription(UserSubscription sub)
    {
        _context.UserSubscriptions.Add(sub);
        await _context.SaveChangesAsync();
        return Ok(sub);
    }
}