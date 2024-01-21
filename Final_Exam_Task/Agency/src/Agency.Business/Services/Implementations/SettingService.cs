using Agency.Business.CustomExceptions.AgencyExceptions;
using Agency.Business.Services.Interfaces;
using Agency.Core.Entity;
using Agency.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repository;

        public SettingService(ISettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Setting>> GetAllAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _repository.GetAllWhere(expression, includes).ToListAsync();
        }

        public async Task<Setting> GetByIdAsync(Expression<Func<Setting, bool>>? expression = null, params string[]? includes)
        {
            return await _repository.SingleAsync(expression, includes);
        }

        public async Task UpdateAsync(Setting setting)
        {
            var existSetting = await _repository.SingleAsync(s => s.Id == setting.Id);
            if (existSetting == null) throw new EntityNullException("Entity can not null!");
            existSetting.UpdatedDate = DateTime.UtcNow.AddHours(4);
            existSetting.Value = setting.Value;
            await _repository.CommitAsync();
        }
    }
}
