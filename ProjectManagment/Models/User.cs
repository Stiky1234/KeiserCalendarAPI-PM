using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagment.Models;

public class User
{
    [Key] // Tells Entity Framework this is the Primary Key
    public int user_id { get; set; }

    public int company_id { get; set; }

    [Required]
    [MaxLength(100)]
    public string username { get; set; }

    [Required]
    [MaxLength(150)]
    public string email { get; set; }

    [Required]
    public string password_hash { get; set; }

    public string role { get; set; } = "Student";

    public DateTime created_at { get; set; } = DateTime.UtcNow;
}