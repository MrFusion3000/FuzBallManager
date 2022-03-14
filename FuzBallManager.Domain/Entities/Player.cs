using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PlayerID { get; set; }
    public string PlayerFirstName { get; set; }
    public string PlayerLastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string PlayerPosition { get; set; }
    public int? PlayerStats { get; set; }
    public Guid? TeamID { get; set; }
    public string TeamName { get; set; }
    public bool? InManagedTeam { get; set; }
    public bool? Injured { get; set; }
}
