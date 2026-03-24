using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagment.Models;

public class Invoice
{
    [Key]
    public int invoice_id { get; set; }

    [Required]
    public int company_id { get; set; }

    public decimal amount { get; set; }

    public DateTime issue_date { get; set; } = DateTime.UtcNow;

    public DateTime due_date { get; set; }

    public string status { get; set; } = "Pending"; // e.g., "Pending", "Paid", "Overdue"

    // Relationships
    [JsonIgnore]
    [ForeignKey("company_id")]
    public Company? Company { get; set; }
}