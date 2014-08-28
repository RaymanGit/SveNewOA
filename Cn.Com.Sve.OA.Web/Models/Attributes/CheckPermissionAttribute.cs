using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cn.Com.Sve.OA.Web.Models.Attributes {
	public class CheckPermissionAttribute : ActionFilterAttribute {
		public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext) {
			base.OnActionExecuting(filterContext);
		}
	}
}