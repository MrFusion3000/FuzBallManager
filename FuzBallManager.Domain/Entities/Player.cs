using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PlayerID { get; set; }
    public string PlayerFirstName { get; set; } = "Anony";
    public string PlayerLastName { get; set; } = "Mouse";
    public DateTime DateOfBirth { get; set; }
    public int PlayerPosition { get; set; }
    public int PlayerStats { get; set; }
    public Guid TeamID { get; set; }
}
