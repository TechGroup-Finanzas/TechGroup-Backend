namespace TechGroup.API.TechGroup.Questions.Request;

public class QuestionRequest
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}