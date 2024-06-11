using TechGroup.Infrastructure.TechGroup.Answers.Models;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.TechGroup.Questions.Models;

public class Question
{
    public int Id { get; set; } 

    public required int UserId { get; set; }
    
    public required string Title { get; set; }

    public required string Description { get; set; }
    
    public User User { get; set; } 
    
    public ICollection<Answer> Answers { get; set; }
    
    public DateOnly CreatedAt { get; set; }
}