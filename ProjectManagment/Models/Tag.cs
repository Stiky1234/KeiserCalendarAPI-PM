using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.Models;

public class Tag
{
    [Key]
    public int tag_id { get; set; }

    [Required]
    public string name { get; set; }
}