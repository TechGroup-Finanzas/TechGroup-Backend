using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Answers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Answers.Models;

namespace TechGroup.Infrastructure.TechGroup.Answers.Services;

public class AnswerInfrastructure: IAnswerInfrastructure
{
    public readonly TechGroupDbContext techGroupDbContext;
    
    public AnswerInfrastructure(TechGroupDbContext techGroupDbContext)
    {
        this.techGroupDbContext = techGroupDbContext;
    }
    
    public async Task<bool> CreateAsync(Answer answer)
    {
        await techGroupDbContext.AddAsync(answer);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var answerToDelete = await techGroupDbContext.Answer.FirstOrDefaultAsync(x => x.Id == id);
        if (answerToDelete == null)
        {
            throw new Exception("Answer not found");
        }
        techGroupDbContext.Answer.Remove(answerToDelete);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Answer>> GetAllAsync()
    {
        var answers = await techGroupDbContext.Answer.ToListAsync();
        return answers;
    }
    
    public async Task<Answer> GetByIdAsync(int id)
    {
        var answer = await techGroupDbContext.Answer.FirstOrDefaultAsync(x => x.Id == id);
        return answer;
    }
    
    public async Task<bool> UpdateAsync(int id, Answer answer)
    {
        var answerToUpdate = await techGroupDbContext.Answer.FirstOrDefaultAsync(x => x.Id == id);
        if (answerToUpdate == null)
        {
            throw new Exception("Answer not found");
        }
        answerToUpdate.Description = answer.Description;
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
}