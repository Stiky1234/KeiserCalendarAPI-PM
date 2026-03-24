using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagment.Models;

public class Company
{
    [Key]
    public int company_id { get; set; }

    public int? plan_id { get; set; }

    [Required]
    [MaxLength(150)]
    public string name { get; set; }

    [MaxLength(255)]
    public string logo_url { get; set; }

    [MaxLength(10)]
    public string primary_color { get; set; }

    [MaxLength(10)]
    public string secondary_color { get; set; }

    public string current_subscription_status { get; set; } = "Trial";
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    // This tells Entity Framework about the relationship
    [ForeignKey("plan_id")]
    public Plan Plan { get; set; }
}