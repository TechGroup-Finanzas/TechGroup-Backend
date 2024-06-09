using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Questions.Interfaces;
using TechGroup.Infrastructure.TechGroup.Questions.Models;

namespace TechGroup.Infrastructure.TechGroup.Questions.Services;

public class QuestionInfrastructure : IQuestionInfrastructure
{
    public readonly TechGroupDbContext techGroupDbContext;
    
    public QuestionInfrastructure(TechGroupDbContext techGroupDbContext)
    {
        this.techGroupDbContext = techGroupDbContext;
    }
    
    public async Task<bool> CreateAsync(Question question)
    {
        await techGroupDbContext.AddAsync(question);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var questionToDelete = await techGroupDbContext.Question.FirstOrDefaultAsync(x => x.Id == id);
        if (questionToDelete == null)
        {
            throw new Exception("Question not found");
        }
        techGroupDbContext.Question.Remove(questionToDelete);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Question>> GetAllAsync()
    {
        var questions = await techGroupDbContext.Question.ToListAsync();
        return questions;
    }
    
    public async Task<Question> GetByIdAsync(int id)
    {
        var question = await techGroupDbContext.Question.FirstOrDefaultAsync(x => x.Id == id);
        return question;
    }
    
    public async Task<bool> UpdateAsync(int id, Question question)
    {
        var questionToUpdate = await techGroupDbContext.Question.FirstOrDefaultAsync(x => x.Id == id);
        if (questionToUpdate == null)
        {
            throw new Exception("Question not found");
        }
        questionToUpdate.Title = question.Title;
        questionToUpdate.Description = question.Description;
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
}