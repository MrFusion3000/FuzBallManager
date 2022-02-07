using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Team
{
    [Key]
    public Guid TeamID { get; set; }
    public string TeamName { get; set; } = "Team Null FC";
    public int Points { get; set; }

    public ICollection<Player> Players { get; set; }
}
