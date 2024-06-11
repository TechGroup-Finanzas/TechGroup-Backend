using TechGroup.Infrastructure.TechGroup.Answers.Models;

namespace TechGroup.Infrastructure.TechGroup.Answers.Interfaces;

public interface IAnswerInfrastructure
{
    public Task<List<Answer>> GetAllAsync();
    public Task<Answer> GetByIdAsync(int id);
    public Task<bool> CreateAsync(Answer answer);
    public Task<bool> UpdateAsync(int id, Answer answer);
    public Task<bool> DeleteAsync(int id);
}