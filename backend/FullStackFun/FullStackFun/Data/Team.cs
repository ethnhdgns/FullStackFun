using System.ComponentModel.DataAnnotations;

namespace FullStackFun.Data;

public class Team
{
    [Key]
    public int TeamId { get; set; } // Primary Key

    [Required]
    public string? TeamName { get; set; }

}
