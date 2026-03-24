using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class AuditLog
{
    [Key]
    public int log_id { get; set; }

    public int? user_id { get; set; } // Nullable because the system itself might do an action

    public string action { get; set; } // e.g., "Created Event", "Deleted User"

    public string table_name { get; set; } // e.g., "events", "users"

    public DateTime timestamp { get; set; } = DateTime.UtcNow;

    // Relationships
    [JsonIgnore]
    [ForeignKey("user_id")]
    public User? User { get; set; }
}