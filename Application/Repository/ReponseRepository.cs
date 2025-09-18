using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Application.Repository;

public class ReponseRepository
{
    private readonly QuizDbContext _context;

    public ReponseRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reponse>> GetAllReponsesAsync() => await _context.Reponses.ToListAsync();

    public async Task UpdateReponseAsync(Reponse reponse)
    {
        _context.Reponses.Update(reponse);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReponseAsync(int id)
    {
        var reponse = await _context.Reponses.FindAsync(id);
        if (reponse != null)
        {
            _context.Reponses.Remove(reponse);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<Reponse?> GetReponseByIdAsync(int id) =>
         await _context.Reponses
            .Include(r => r.Question)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task AddReponseAsync(Reponse reponse)
    {
        await _context.Reponses.AddAsync(reponse);
        await _context.SaveChangesAsync();
    }





}
