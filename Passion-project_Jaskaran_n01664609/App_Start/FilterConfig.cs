using System.Web;
using System.Web.Mvc;

namespace Passion_project_Jaskaran_n01664609
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
