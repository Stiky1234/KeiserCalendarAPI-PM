using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class Event
{
    [Key]
    public int event_id { get; set; }

    public int company_id { get; set; }
    public int created_by_user_id { get; set; }

    [Required]
    [MaxLength(200)]
    public string title { get; set; }

    public string description { get; set; }
    public DateTime event_date { get; set; }
    public TimeSpan start_time { get; set; }
    public TimeSpan end_time { get; set; }

    [MaxLength(255)]
    public string location { get; set; }

    [MaxLength(100)]
    public string category { get; set; }

    public int? registration_limit { get; set; }
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    [ForeignKey("company_id")]
    public Company? Company { get; set; }

    [JsonIgnore]
    [ForeignKey("created_by_user_id")]
    public User? Creator { get; set; }
}