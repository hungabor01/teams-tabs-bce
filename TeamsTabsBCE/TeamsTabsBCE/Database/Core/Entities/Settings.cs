using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Database.Core.Entities
{
    public class Settings : IEntity
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string TenantId { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }

        public Settings(string channelId, string tenantId, string groupId, string groupName)
        {
            channelId.ThrowExceptionIfNullOrWhiteSpace(nameof(channelId));
            tenantId.ThrowExceptionIfNullOrWhiteSpace(nameof(channelId));
            groupId.ThrowExceptionIfNullOrWhiteSpace(nameof(groupId));
            groupName.ThrowExceptionIfNullOrWhiteSpace(nameof(groupName));

            ChannelId = channelId;
            TenantId = tenantId;
            GroupId = groupId;
            GroupName = groupName;
        }
    }
}
