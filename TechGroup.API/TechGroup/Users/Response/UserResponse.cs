namespace TechGroup.API.TechGroup.Users.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public DateOnly CreatedAt { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

    }
}
