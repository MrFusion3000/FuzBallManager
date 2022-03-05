using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Fixture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FixtureID { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; } = 0;
        public int AwayTeamScore { get; set; } = 0;
        public int Attendance { get; set; } = 0;
        public DateTime FixtureDate { get; set; }
        public bool Played { get; set; }
    }
}
