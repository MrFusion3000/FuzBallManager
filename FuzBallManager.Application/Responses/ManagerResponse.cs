using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class ManagerResponse
    {
        public Guid ManagerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Score { get; set; }
        public int? Bank { get; set; }
        public Guid? ManagingTeamID { get; set; }
        public string? ManagingTeamName { get; set; }
    }
}
