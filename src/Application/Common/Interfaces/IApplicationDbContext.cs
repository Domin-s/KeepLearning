namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Enteties.Continent> Continentes { get; }
    DbSet<Domain.Enteties.Country> Countries { get; }
    DbSet<Domain.Enteties.Question> Questions { get; }
    DbSet<Domain.Enteties.Exam> Exams { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
