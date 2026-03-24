using Microsoft.EntityFrameworkCore;
using ProjectManagment.Models;

namespace ProjectManagment;

public class CalendarDbContext : DbContext
{
    public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventRegistration> EventRegistrations { get; set; }
    public DbSet<EventFavorite> EventFavorites { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}