using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class EventFavorite
{
    [Key]
    public int favorite_id { get; set; }

    [Required]
    public int user_id { get; set; }

    [Required]
    public int event_id { get; set; }

    public DateTime created_at { get; set; } = DateTime.UtcNow;

    // Relationships
    [JsonIgnore]
    [ForeignKey("user_id")]
    public User? User { get; set; }

    [JsonIgnore]
    [ForeignKey("event_id")]
    public Event? Event { get; set; }
}