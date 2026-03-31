using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProjectManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly CalendarDbContext _context;
    private readonly IConfiguration _configuration;

    // We inject the Database AND the Configuration (appsettings.json) here
    public AuthController(CalendarDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // 1. Check if the user exists in MySQL
        var user = await _context.Users.FirstOrDefaultAsync(u => u.email == request.Email);

        if (user == null)
        {
            return Unauthorized("Invalid email. The Bouncer says no!");
        }

        // 2. Assign Roles (For testing, User #1 gets to be the Admin)
        string userRole = user.user_id == 1 ? "Admin" : "Student";

        // 3. Create the VIP Wristband (The Token)
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.user_id.ToString()),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, userRole) // <-- The Bouncer looks at this!
            }),
            Expires = DateTime.UtcNow.AddHours(2), // Wristband expires in 2 hours
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtString = tokenHandler.WriteToken(token);

        // 4. Hand the token back to the user
        return Ok(new { Token = jwtString });
    }
}

// A tiny helper class to catch the email from Swagger
public class LoginRequest
{
    public string Email { get; set; }
}