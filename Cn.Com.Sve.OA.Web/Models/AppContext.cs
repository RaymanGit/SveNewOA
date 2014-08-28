using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cn.Com.Sve.OA.Web.Models {
	public class AppContext {
		private const string CurrentUserSessionKey = "CurrentUserSessionKey";
		public static Cn.Com.Sve.OA.Entities.User CurrentUser {
			get {
				return HttpContext.Current.Session[CurrentUserSessionKey] as Cn.Com.Sve.OA.Entities.User;
			}
			set {
				HttpContext.Current.Session[CurrentUserSessionKey] = value;
			}
		}
	}
}