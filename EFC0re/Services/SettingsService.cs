using EFC0re.Repositories.Interfaces;
using EFC0re.Services.Interfaces;
using Npgsql.TypeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EFC0re.Services
{
    public class SettingsService:ISettingsService
    {
        ISettingsRepository _settingsRepository;
        public SettingsService(ISettingsRepository settingsRepository) {
            _settingsRepository= settingsRepository;
        }
        public async Task ChangePeriod(int? period)
        {
            if (_settingsRepository.GetSingle() != default)
                await _settingsRepository.Update(new Settings {Idperiod = _settingsRepository.GetSingle().Idperiod, Period = period});
            else await _settingsRepository.Create(new Settings { Idperiod = new Guid(), Period = period});
        }
        public int GetPeriod()
        {
            return _settingsRepository.GetSingle().Period.Value;
        }
    }
}