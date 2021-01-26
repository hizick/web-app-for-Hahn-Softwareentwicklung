using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
