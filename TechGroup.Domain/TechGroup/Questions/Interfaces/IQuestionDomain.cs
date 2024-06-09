using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.Domain.TechGroup.Questions.Interfaces;

public interface IQuestionDomain
{
    public Task<bool> SaveAsync(Question question);
    public Task<bool> DeleteAsync(int id);
    public Task<bool> UpdateAsync(int id, Question question);
}