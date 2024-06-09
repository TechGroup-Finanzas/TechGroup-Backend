using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.Infrastructure.TechGroup.Questions.Interfaces;

public interface IQuestionInfrastructure
{
    public Task<List<Question>> GetAllAsync();
    public Task<Question> GetByIdAsync(int id);
    public Task<bool> CreateAsync(Question question);
    public Task<bool> UpdateAsync(int id, Question question);
    public Task<bool> DeleteAsync(int id);
}