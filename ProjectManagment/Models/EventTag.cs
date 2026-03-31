using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class EventTag
{
    [Key]
    public int event_id { get; set; }

    [Key]
    public int tag_id { get; set; }

    [JsonIgnore]
    [ForeignKey("event_id")]
    public Event? Event { get; set; }

    [JsonIgnore]
    [ForeignKey("tag_id")]
    public Tag? Tag { get; set; }
}