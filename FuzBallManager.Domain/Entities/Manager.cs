using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Manager
    {
        public Guid ManagerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ManagingTeam { get; set; }
        public int Score { get; set; }
        public int Bank { get; set; }
    }
}
