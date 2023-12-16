using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Core.EntityConfigurations
{
    internal class TaskResultConfiguration : IEntityTypeConfiguration<TaskResult>
    {
        public void Configure(EntityTypeBuilder<TaskResult> builder)
        {
            builder.Property(tr => tr.UserEmail)
                .IsRequired();

            builder.HasIndex(tr => new { tr.UserEmail, tr.TaskIdentifierId })
               .IsUnique();

            builder.HasOne(tr => tr.TaskIdentifier)
                .WithMany(ti => ti.TaskResults)
                .HasForeignKey(tr => tr.TaskIdentifierId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
