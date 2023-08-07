using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EFC0re.Services.Interfaces
{
    public interface ISettingsService
    {
        Task ChangePeriod(int? period);
        int GetPeriod();
    }
}