using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.API.TechGroup.Questions.Response;

public class QuestionResponse
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}