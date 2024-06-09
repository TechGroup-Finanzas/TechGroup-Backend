using TechGroup.Domain.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.Domain.TechGroup.Questions.Services;

public class QuestionDomain: IQuestionDomain
{
    private readonly IQuestionInfrastructure _questionInfrastructure;
    public QuestionDomain(IQuestionInfrastructure questionInfrastructure)
    {
        _questionInfrastructure = questionInfrastructure;
    }
    public async Task<bool> SaveAsync(Question question)
    {
        return await _questionInfrastructure.CreateAsync(question);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _questionInfrastructure.DeleteAsync(id);
    }
    public async Task<bool> UpdateAsync(int id, Question question)
    {
        return await _questionInfrastructure.UpdateAsync(id, question);
    }
}