namespace TechGroup.API.TechGroup.Users.Request
{
    public class UserRequest
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string dni { get; set; }
        public DateOnly birthday { get; set; }
        public string phone { get; set; }
        public string photo { get; set; }
        public double mora { get; set; }

    }
}
