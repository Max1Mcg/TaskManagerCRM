using EFC0re.RPCCounter;
using System.Web;
using System.Web.Mvc;

namespace EFC0re
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RPCCpunter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
