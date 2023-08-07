using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFC0re.Repositories.Interfaces
{
    public interface ISettingsRepository:IBaseRepository<Settings>
    {
        Settings GetSingle();
    }
}