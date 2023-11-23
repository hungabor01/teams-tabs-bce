using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.DatabaseAccess.Mappers.Mapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.SettingsMapper
{
    internal class SettingsMapper : Mapper<Settings, SettingsModel>, ISettingsMapper
    {
        public override Settings FromModel(SettingsModel model)
        {
            model.ThrowExceptionIfNull(nameof(model));

            return new Settings(model.ChannelId, model.TenantId, model.GroupId, model.GroupName);
        }

        public override SettingsModel ToModel(Settings entity)
        {
            entity.ThrowExceptionIfNull(nameof(entity));

            return new SettingsModel(entity.ChannelId, entity.TenantId, entity.GroupId, entity.GroupName);
        }
    }
}
