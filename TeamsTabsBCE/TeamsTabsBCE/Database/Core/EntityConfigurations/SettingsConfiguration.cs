using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Core.EntityConfigurations
{
    internal class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property(s => s.ChannelId)
                .IsRequired();

            builder.Property(s => s.TenantId)
                .IsRequired();

            builder.Property(s => s.GroupId)
                .IsRequired();

            builder.Property(s => s.GroupName)
                .IsRequired();
        }
    }
}
