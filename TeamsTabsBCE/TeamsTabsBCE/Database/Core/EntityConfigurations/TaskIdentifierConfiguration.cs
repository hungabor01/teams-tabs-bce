using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Core.EntityConfigurations
{
    internal class TaskIdentifierConfiguration : IEntityTypeConfiguration<TaskIdentifier>
    {
        public void Configure(EntityTypeBuilder<TaskIdentifier> builder)
        {
            builder.HasIndex(ti => new { ti.Week, ti.List, ti.Step })
                .IsUnique();
        }
    }
}
