using System.Web;
using System.Web.Mvc;

namespace Cn.Com.Sve.OA.Web {
	public class FilterConfig {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}
	}
}