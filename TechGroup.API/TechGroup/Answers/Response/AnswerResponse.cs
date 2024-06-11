using TechGroup.API.TechGroup.Questions.Response;
using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.API.TechGroup.Answers.Response;

public class AnswerResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public QuestionResponse Question { get; set; }
}