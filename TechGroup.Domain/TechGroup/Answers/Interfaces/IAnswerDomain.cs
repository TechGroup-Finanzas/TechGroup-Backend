using TechGroup.Infrastructure.TechGroup.Answers.Models;

namespace TechGroup.Domain.TechGroup.Answers.Interfaces;

public interface IAnswerDomain
{
    public Task<bool> SaveAsync(Answer answer);
    public Task<bool> DeleteAsync(int id);
    public Task<bool> UpdateAsync(int id, Answer answer);
}