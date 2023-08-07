using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace EFC0re.Controllers
{
    //DataContract for Serializing Data - required to serve in JSON format
    public class DataContract
    {
        public DataContract(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        public Nullable<double> x = null;

        //Explicitly setting the name to be used while serializing to JSON.
        public Nullable<double> y = null;
    }
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult JSON(int xStart = 0, double yStart = 0, int length = 1)
        {
            List<DataContract> dataPoints = new List<DataContract>();
            Random random = new Random();
            double y = yStart;

            for (int i = 0; i < length; i++)
            {
                y = y + random.Next(-1, 2);
                dataPoints.Add(new DataContract(xStart + i, y));
            }

            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

    }
}