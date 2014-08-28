using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cn.Com.Sve.OA.BusinessService;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Web.Models;
using Cn.RaymanLee.Web.UI.ViewModels.LigerUI;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public class SystemController : BaseController {
		public IUserService UserService { get; set; }
		public IModuleService ModuleService { get; set; }
		public IFunctionService FunctionService { get; set; }
		public SystemController() {
			this.UserService = new UserService(new SysContext { CurrentUser = AppContext.CurrentUser });
			this.ModuleService = new ModuleService(new SysContext { CurrentUser = AppContext.CurrentUser });
			this.FunctionService = new FunctionService(new SysContext { CurrentUser = AppContext.CurrentUser });
		}

		public ActionResult Index() {
			return View();
		}

		[HttpGet]
		public ActionResult Login() {
			//var c = this.Request.Cookies["username"];
			//if (c != null) {
			//    this.ViewBag.UserName = c.Value;
			//} else {
			//    this.ViewBag.UserName = String.Empty;
			//}
			return this.View();
		}
		[HttpPost]
		public ActionResult Login(string UserName, string Password) {
			var user = this.UserService.FindByName(UserName).FirstOrDefault();
			if (user != null && user.Password.Equals(Password)) {
				//var c = new HttpCookie("username", user.Name);
				//c.Expires = DateTime.MaxValue;
				//this.Response.Cookies.Add(c);
				AppContext.CurrentUser = user;
				return this.Content("true");
			} else {
				return this.Content("false");
			}

		}
		[HttpPost]
		public ActionResult ChangePassword(string OldPassword, string Password) {
			var user = this.UserService.FindById(AppContext.CurrentUser.Id);
			user.Password = Password;
			this.UserService.Update(user);
			return this.Content("true");
		}

		public ActionResult Logout() {
			this.Session.Abandon();
			return this.RedirectToAction("Login");
		}

		public ActionResult Home() {
			if (AppContext.CurrentUser == null) {
				return this.RedirectToAction("Login");
			}
			return this.View();
		}

		[HttpGet]
		public ActionResult GetModules() {
			List<Object> list = new List<object>();
			this.ModuleService.FindByUserId(AppContext.CurrentUser.Id).ForEach(m => {
				list.Add(new { 
					icon=m.Icon,
					id=m.Id,
					MenuName=m.Name,
					MenuId=m.Id,
					text=m.Name,
					MenuUrl="null",
					MenuIcon=UrlHelper.GenerateContentUrl(m.Icon, this.HttpContext),
					MenuNo=m.Code,
					MenuParentNo="null"
				});
			});

			return this.Json(list, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult GetFunctionTree(int moduleId) {
			List<LigerTreeModel> list = new List<LigerTreeModel>();
			var functions = this.FunctionService.FindByUserId(AppContext.CurrentUser.Id, moduleId);
			this.LoadTreeData(functions, functions.Where(o => !o.ParentFunctionId.HasValue).ToList(), list, null);
			return this.Json(list, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public ActionResult UserDefault() {
			var user = AppContext.CurrentUser;
			if (String.IsNullOrEmpty(user.DefaultUrl)) { 
				return this.View();
			}
			if (user.DefaultUrl.Equals("组长跟进")) {
				return this.RedirectToAction("LeaderFollow", "Customer");
			}
			if (user.DefaultUrl.Equals("学校列表")) {
				return this.RedirectToAction("MySchools", "Customer");
			}
			return this.View();
		}

		private void LoadTreeData(List<Function> allfunctions, List<Function> functions, List<LigerTreeModel> list, LigerTreeModel m) {
			if (functions.Count > 0 && m!=null) m.isleaf = 0;
			functions.ForEach(o => {
				LigerTreeModel s = new LigerTreeModel {
					icon = UrlHelper.GenerateContentUrl(o.Icon, this.HttpContext),
					id = o.Id.ToString(),
					isleaf = 1,
					pid = (m == null ? "0" : m.id.ToString()),
					text = o.Name,
					treelevel = (m == null ? 1 : m.treelevel + 1),
					url = o.Url == null ? o.Url : UrlHelper.GenerateContentUrl(o.Url, this.HttpContext)
				};
				list.Add(s);
				this.LoadTreeData(allfunctions, 
					allfunctions.Where(f => f.ParentFunctionId.HasValue && f.ParentFunctionId.Value.ToString().Equals(s.id)).ToList(),
					list, s);

			});
		}
	}
}
