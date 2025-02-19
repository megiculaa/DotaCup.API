using DotaCup.API.Data.Interfaces;
using DotaCup.API.Models.Entities;

namespace DotaCup.API.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    private IGenericRepository<Tournament> _tournamentRepository;
    private IGenericRepository<Clip> _clipRepository;

    public UnitOfWork(ApplicationContext context)
        => _context = context;

    public IGenericRepository<Tournament> TournamentRepository =>
        _tournamentRepository ??= new GenericRepository<Tournament>(_context);

    public IGenericRepository<Clip> ClipRepository =>
        _clipRepository ??= new GenericRepository<Clip>(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
