using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.Infrastructure.TechGroup.Answers.Models;

public class Answer
{
    public int Id { get; set; }
    
    public required string Description { get; set; }
    
    public required int QuestionId { get; set; }
    
    public Question Question { get; set; } 
    
    public DateOnly CreatedAt { get; set; }
}