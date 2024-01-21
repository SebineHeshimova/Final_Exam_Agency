using Agency.Business.Services.Interfaces;
using Agency.Core.Entity;

namespace Agency.MVC.LayoutService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public  async Task<List<Setting>> GetSetting()
        {
            var setting =  await _settingService.GetAllAsync();
            return setting;
        }
    }
}
