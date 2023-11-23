using System.Text.Json;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.Models
{
    public class SettingsModel : IModel
    {
        public string ChannelId { get; } = string.Empty;
        public string TenantId { get; } = string.Empty;
        public string GroupId { get; } = string.Empty;
        public string GroupName { get; } = string.Empty;

        public SettingsModel(string channelId, string tenantId, string groupId, string groupName)
        {
            channelId.ThrowExceptionIfNullOrWhiteSpace(nameof(channelId));
            tenantId.ThrowExceptionIfNullOrWhiteSpace(nameof(channelId));
            groupId.ThrowExceptionIfNullOrWhiteSpace(nameof(groupId));
            groupName.ThrowExceptionIfNullOrWhiteSpace(nameof(groupName));

            ChannelId = channelId;
            TenantId = tenantId;
            GroupId = groupId;
            GroupName = groupName;

            VerifyProperties();
        }

        public SettingsModel(JsonElement data)
        {
            if (data.TryGetProperty("channelId", out var channelId))
            {
                ChannelId = channelId.ToString();
            }

            if (data.TryGetProperty("tenantId", out var tenantId))
            {
                TenantId = tenantId.ToString();
            }

            if (data.TryGetProperty("groupId", out var groupId))
            {
                GroupId = groupId.ToString();
            }

            if (data.TryGetProperty("groupName", out var groupName))
            {
                GroupName = groupName.ToString();
            }

            VerifyProperties();
        }

        private void VerifyProperties()
        {
            ChannelId.ThrowExceptionIfNullOrWhiteSpace(nameof(ChannelId));
            TenantId.ThrowExceptionIfNullOrWhiteSpace(nameof(TenantId));
            GroupId.ThrowExceptionIfNullOrWhiteSpace(nameof(GroupId));
            GroupName.ThrowExceptionIfNullOrWhiteSpace(nameof(GroupName));
        }
    }
}
