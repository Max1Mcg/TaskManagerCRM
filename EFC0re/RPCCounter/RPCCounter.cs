using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFC0re.RPCCounter
{
    public class RPCCpunter : FilterAttribute, IActionFilter
    {
        public static int count { get; set; } = 0;
        public static PerformanceCounter cpuCounter { get; set; } = new PerformanceCounter();
        public RPCCpunter()
        {
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();
            //count++;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            count++;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}