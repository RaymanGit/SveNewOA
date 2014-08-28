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
	public partial class KnowledgeController : BaseController {
		private object ToJson(Knowledge e) {
			return new {
				Id = e.Id,
				Subject = e.Subject,
				Content = e.Content,
				KnowledgeType = e.KnowledgeType
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, Knowledge e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(Knowledge e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(Knowledge e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Search(KnowledgeCriteria c) {
			var m = new LigerGridModel();
			this.BeforeGetData(c);
			var r = this.Service.Search(c);
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
