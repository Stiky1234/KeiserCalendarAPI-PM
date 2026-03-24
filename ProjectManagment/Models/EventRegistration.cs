using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class EventRegistration
{
    [Key]
    public int registration_id { get; set; }

    [Required]
    public int event_id { get; set; }

    [Required]
    public int user_id { get; set; }

    public DateTime registered_at { get; set; } = DateTime.UtcNow;

    public string status { get; set; } = "Registered"; 

    [JsonIgnore]
    [ForeignKey("event_id")]
    public Event? Event { get; set; }

    [JsonIgnore]
    [ForeignKey("user_id")]
    public User? User { get; set; }
}