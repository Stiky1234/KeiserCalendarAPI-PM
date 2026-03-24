using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.Models;

public class Plan
{
    [Key]
    public int plan_id { get; set; }

    [Required]
    [MaxLength(100)]
    public string plan_name { get; set; }

    public string description { get; set; }
    public decimal monthly_price { get; set; }
    public int event_limit { get; set; }
    public int active_users_limit { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;
}