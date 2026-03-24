using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models; 
namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public UsersController(CalendarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {   
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }
}