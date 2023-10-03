using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeepLearning.Infrastructure.Persistence
{
    public class KeepLearningDbContext : IdentityDbContext
    {
        public KeepLearningDbContext(DbContextOptions<KeepLearningDbContext> options) : base(options)
        {

        }
    }
}
