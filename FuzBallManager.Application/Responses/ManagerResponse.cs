namespace Application.Responses
{
    public class ManagerResponse
    {
        public Guid ManagerID { get; set; }
        public string? Name { get; set; }
        //public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Score { get; set; }
        public int? Bank { get; set; }
        public Guid? ManagingTeamID { get; set; }
        public string? ManagingTeamName { get; set; }

        public override string? ToString() => ManagingTeamName;

    }
}
