using EFC0re.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EFC0re.Controllers
{
    //[Route("api/[controller]")]
    public class SettingsController : Controller
    {
        ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        [System.Web.Http.HttpPatch]
        //[System.Web.Http.Route("")]
        public async Task ChangePeriod(int? period)
        {
            await _settingsService.ChangePeriod(period);
            //return View();
        }
        [System.Web.Http.HttpGet]
        public ContentResult CurrentPeriod()
        {
            return Content(JsonConvert.SerializeObject(_settingsService.GetPeriod(), _jsonSetting), "application/json");
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    }
}