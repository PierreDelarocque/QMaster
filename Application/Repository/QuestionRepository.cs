using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Application.Repository;

public class QuestionRepository
{
    private readonly QuizDbContext _context;
    public QuestionRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetAllQuestionsAsync() => await _context.Questions
        .Include(q => q.Reponses)
        .ToListAsync();

    public async Task UpdateQuestionAsync(Question question)
    {
        _context.Questions.Update(question);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteQuestionAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question != null)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<Question?> GetQuestionByIdAsync(int id) =>

         await _context.Questions
            .Include(q => q.Reponses)
            .FirstOrDefaultAsync(q => q.Id == id);

    public async Task AddQuestionAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();
    }





}
