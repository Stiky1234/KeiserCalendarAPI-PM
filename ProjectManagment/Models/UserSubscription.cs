using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class UserSubscription
{
    [Key]
    public int user_id { get; set; }

    [Key]
    public int tag_id { get; set; }

    [JsonIgnore]
    [ForeignKey("user_id")]
    public User? User { get; set; }

    [JsonIgnore]
    [ForeignKey("tag_id")]
    public Tag? Tag { get; set; }
}