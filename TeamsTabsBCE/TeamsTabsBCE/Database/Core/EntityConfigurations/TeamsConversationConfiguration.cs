using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Core.EntityConfigurations
{
    internal class TeamsConversationConfiguration : IEntityTypeConfiguration<TeamsConversation>
    {
        public void Configure(EntityTypeBuilder<TeamsConversation> builder)
        {
            builder.Property(tc => tc.ConversationId)
                .IsRequired();

            builder.HasOne(tc => tc.TaskIdentifier)
                .WithOne(ti => ti.TeamsConversation)
                .HasForeignKey<TeamsConversation>(tc => tc.TaskIdentifierId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
