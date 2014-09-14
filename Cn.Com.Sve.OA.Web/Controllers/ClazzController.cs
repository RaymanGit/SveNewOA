using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cn.Com.Sve.OA.BusinessService;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;
using Cn.Com.Sve.OA.Web.Models;
using Cn.RaymanLee.Web.UI.ViewModels.LigerUI;
using Cn.RaymanLee.Data;


namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class ClazzController : BaseController {
		private object ToJson(Clazz e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				Semester = e.Semester,
				StudentQty = e.StudentQty,
				LimitedQty = e.LimitedQty,
				TeacherA = e.TeacherA,
				TeacherB = e.TeacherB,
				Master = e.Master,
				Governor = e.Governor,
				OpenDate = e.OpenDate,
				ClosedDate = e.ClosedDate,
				FinishedDate = e.FinishedDate,
				IsOpen = e.IsOpen,
				IsClosed = e.IsClosed,
				IsFinished = e.IsFinished,
				CreateTime = e.CreateTime,
				UpdateTime = e.UpdateTime,
				KickOffDate = e.KickOffDate
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, Clazz e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(Clazz e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(Clazz e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Suggest(string prefix, int qty) {
			List<object> m = new List<object>();
			var r = this.Service.FindByCriteria2(new ClazzCriteria { NameSrh = prefix, pagesize = qty, sortname = "name", sortorder = "asc" });
			r.Data.ForEach(o => {
				m.Add(new { Id = o.Id, Name = o.Name });
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetData2(ClazzCriteria c) {
			var m = new LigerGridModel();
			this.BeforeGetData(c);
			var r = this.Service.FindByCriteria2(c);
			this.AfterGetData(m, c, r);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				this.AddRowToGridModel(m, o);
			});
			this.AfterBuildGridModel(m, c, r);
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}


	}
}
