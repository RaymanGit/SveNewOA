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
    public partial class SalesTeamMemberController : BaseController {
    	partial void BeforeGetData(SalesTeamMemberCriteria c);
    	partial void AddRowToGridModel(LigerGridModel m, SalesTeamMember e);
    	partial void AfterGetData(LigerGridModel gm, SalesTeamMemberCriteria c, PagedModel<SalesTeamMember> pm);
    	partial void AfterBuildGridModel(LigerGridModel gm, SalesTeamMemberCriteria c, PagedModel<SalesTeamMember> pm);
    	partial void BeforeShowAddView();
    	partial void BeforeAddData(SalesTeamMember e, ref ActionResult ar);
    	partial void AfterAddData(SalesTeamMember e, ref ActionResult ar);
    	partial void BeforeShowEditView(SalesTeamMember e);
    	partial void BeforeUpdateData(SalesTeamMember e, ref ActionResult ar);
    	partial void AfterUpdateData(SalesTeamMember e, ref ActionResult ar);
    	partial void BeforeDeleteData(int id, ref ActionResult ar);
    	partial void AfterDeleteData(int id, ref ActionResult ar);
    
    	public ISalesTeamMemberService Service { get; set; }
    	public SalesTeamMemberController() {
    		this.Service = new SalesTeamMemberService(new SysContext{ CurrentUser = AppContext.CurrentUser });
    	}
    	public ActionResult Index() {
    		return View();
    	}
    	
    
    	public ActionResult GetData(SalesTeamMemberCriteria c) {
    		var m = new LigerGridModel();
    		this.BeforeGetData(c);
    		var r = this.Service.FindByCriteria(c);
    		this.AfterGetData(m, c, r);
    		m.Total = r.RecordCount;
    		r.Data.ForEach(o => {
    			this.AddRowToGridModel(m, o);
    		});
    		this.AfterBuildGridModel(m, c, r);
    		return this.Json(m, JsonRequestBehavior.AllowGet);
    	}
    	[HttpGet]
    	public ActionResult Add() {
    		this.BeforeShowAddView();
    		return this.View();
    	}
    	[HttpPost]
    	public ActionResult Add(SalesTeamMember e) {
    		ActionResult ar = null;
    		try {
    			this.BeforeAddData(e, ref ar);
    			if (ar == null) {
    				this.Service.Add(e);
    				e = this.Service.FindById(e.Id);
    				//ar = this.Json(new AjaxOperationResult { Data = e, Successful = true });
    				this.AfterAddData(e, ref ar);
    			}
    		} catch (Exception ex) {
    			ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
    		}
    		return ar;
    	}
    	[HttpGet]
    	public ActionResult Edit(int id) {
    		var e = this.Service.FindById(id);
    			if (e != null) {
    			this.BeforeShowEditView(e);
    			return this.View(e);
    		} else {
    			return this.Content("找不到数据！");
    		}
    	}
    	[HttpPost]
    	public ActionResult Update(SalesTeamMember e) {
    		ActionResult ar = null;
    		try {
    			this.BeforeUpdateData(e, ref ar);
    			if (ar == null) {
    				this.Service.Update(e);
    				e = this.Service.FindById(e.Id);
    				//ar = this.Json(new AjaxOperationResult { Data = e, Successful = true });
    				this.AfterUpdateData(e, ref ar);
    			}
    		} catch (Exception ex) {
    			ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
    		}
    		return ar;
    	}
    	[HttpPost]
    	public ActionResult Delete(int id) {
    		ActionResult ar = null;
    		try {
    			this.BeforeDeleteData(id, ref ar);
    			if (ar == null) {
    				this.Service.DeleteById(id);
    				ar = this.Json(new AjaxOperationResult { Successful = true });
    				this.AfterDeleteData(id, ref ar);
    			}
    		} catch (Exception ex) {
    			ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
    		}
    		return ar;
    	}
    
    }
}
