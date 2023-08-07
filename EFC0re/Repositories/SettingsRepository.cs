using EFC0re.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFC0re.Repositories
{
    public class SettingsRepository:BaseRepository<Settings>, ISettingsRepository
    {
        public SettingsRepository(WebSiteContext context):base(context) { }
        public Settings GetSingle()
        {
            return _set.FirstOrDefault();
        }
    }
}