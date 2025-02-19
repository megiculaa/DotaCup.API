using DotaCup.API.Models.Entities;

namespace DotaCup.API.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Tournament> TournamentRepository { get; }
        public IGenericRepository<Clip> ClipRepository { get; }

        public Task Save();
        public void Dispose();
    }
}
