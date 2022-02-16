using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Team
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TeamID { get; set; }
    public string TeamName { get; set; } = "Team Null FC";
    public int? Points { get; set; }
    public int? Wins { get; set; }
    public int? Draws { get; set; }
    public int? Lost { get; set; }
    public int? GoalsForward { get; set; }
    public int? GoalsAgainst { get; set; }
    public string Stadium { get; set; }


    public ICollection<Player> Players { get; set; }
}
