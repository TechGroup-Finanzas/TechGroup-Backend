using TechGroup.Domain.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Models;

namespace TechGroup.Domain.TechGroup.Answers.Services;

public class AnswerDomain: IAnswerDomain
{
    private readonly IAnswerInfrastructure _answerInfrastructure;
    public AnswerDomain(IAnswerInfrastructure answerInfrastructure)
    {
        _answerInfrastructure = answerInfrastructure;
    }
    public async Task<bool> SaveAsync(Answer answer)
    {
        return await _answerInfrastructure.CreateAsync(answer);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _answerInfrastructure.DeleteAsync(id);
    }
    public async Task<bool> UpdateAsync(int id, Answer answer)
    {
        return await _answerInfrastructure.UpdateAsync(id, answer);
    }
}