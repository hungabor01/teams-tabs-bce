using Microsoft.EntityFrameworkCore;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Core.EntityConfigurations;

namespace TeamsTabsBCE.Database.Core
{
    public class BceDbContext : DbContext
    {
        public BceDbContext(DbContextOptions<BceDbContext> options) : base(options)
        {
        }

        public DbSet<TaskIdentifier> TaskIdentifiers { get; set; }
        public DbSet<TaskResult> TaskResult { get; set; }
        public DbSet<TeamsConversation> TeamsConversation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database\\BceDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskIdentifierConfiguration());
            modelBuilder.ApplyConfiguration(new TaskResultConfiguration());
            modelBuilder.ApplyConfiguration(new TeamsConversationConfiguration());
        }
    }
}
