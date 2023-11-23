using TeamsTabsBCE.DatabaseAccess.Mappers.SettingsMapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    internal class SettingsRepositoryHandler : RepositoryHandlerBase, ISettingsRepositoryHandler
    {
        private readonly ISettingsMapper _settingsMapper;

        public SettingsRepositoryHandler(
            IServiceProvider serviceProvider,
            ISettingsMapper settingsMapper)
            : base(serviceProvider)
        {
            _settingsMapper = settingsMapper;
        }

        public async Task<SettingsModel> GetSettings()
        {
            var unitOfWork = GetUnitOfWork();
            var settings = await unitOfWork.SettingsRepository.GetSettings()
                ?? throw new Exception("Settings should already exist.");
            return _settingsMapper.ToModel(settings);
        }

        public async Task StoreSettings(SettingsModel settingsModel)
        {
            settingsModel.ThrowExceptionIfNull(nameof(settingsModel));

            var unitOfWork = GetUnitOfWork();
            var settings = _settingsMapper.FromModel(settingsModel);
            await unitOfWork.SettingsRepository.StoreSettings(settings);
            await unitOfWork.CompleteAsync();
        }
    }
}
