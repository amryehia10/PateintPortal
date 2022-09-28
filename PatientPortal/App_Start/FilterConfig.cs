using PatientPortal.App_Start;
using System.Web;
using System.Web.Mvc;

namespace PatientPortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new Auth());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
