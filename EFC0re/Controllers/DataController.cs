using EFC0re.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EFC0re.Controllers
{
    public class My
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public class DataController : Controller
    {
        IDataService _dataService;
        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }
        [System.Web.Http.HttpGet]
        public ContentResult GetOne(Guid id)
        {
            return Content(JsonConvert.SerializeObject(_dataService.GetOneData(id), _jsonSetting), "application/json");
            //return JsonConvert.SerializeObject(_dataService.GetOneData(id), JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpGet]
        public ContentResult GetLasts(int count)
        {
            return Content(JsonConvert.SerializeObject(_dataService.GetLasts(count).Select(i => new { CpuLoading = i.CpuLoading,RamLoading = i.RamLoading, Year = i.CreatedAt.Value.Year, Month = i.CreatedAt.Value.Month, Day = i.CreatedAt.Value.Day, Hour = i.CreatedAt.Value.Hour, Minute = i.CreatedAt.Value.Minute, Second = i.CreatedAt.Value.Second }), _jsonSetting), "application/json");
            //return Json(_dataService.GetLasts(count), JsonRequestBehavior.AllowGet);
            //return Json(new List<My> { new My { x = 1, y = 2}, new My { x = 3, y = 5 }, new My { x = 50, y = 23 }, new My { x = 1, y = 100 }, new My { x = 6, y = 5 }, new My { x = 23, y = 98 }, new My { x = 32, y = 12 }, new My { x = 1, y = 2 } }, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpGet]
        //IEnumerable<Data>
        public ActionResult GetRange(DateTime start, DateTime end)
        {
            return Json(_dataService.GetRange(start, end), JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpPost]
        public ContentResult Create()
        {
            bool auto = true;
            return Content(JsonConvert.SerializeObject(_dataService.CreateInstanceAuto(auto), _jsonSetting), "application/json");
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    }
}