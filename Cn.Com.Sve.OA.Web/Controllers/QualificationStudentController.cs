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
using Cn.Com.Sve.OA.Web.Models.ViewModels;

namespace Cn.Com.Sve.OA.Web.Controllers {
	public partial class QualificationStudentController : BaseController {
		private object ToJson(QualificationStudent e) {
			return new {
				Id = e.Id,
				Clazz=e.Clazz,
				TargetSchoolName=e.TargetSchoolName,
				SignUpTime=e.SignUpTime,
				SeqNo=e.SeqNo,
				TargetProfession=e.TargetProfession,
				StudentNo=e.StudentNo,
				Name = e.Name,
				Sex=e.Sex,
				Birthday = e.Birthday,
				JiGuang=e.JiGuang,
				IdCardNo=e.IdCardNo,
				MinZu=e.MinZu,
				ZhengZhiMianMao=e.ZhengZhiMianMao,
				IsMarried=e.IsMarried,
				HomeAddress=e.HomeAddress,
				HuKouAddress=e.HuKouAddress,
				CommAddress=e.CommAddress,
				Postcode=e.Postcode,
				HomeTelephone=e.HomeTelephone,
				Mobile = e.Mobile,
				QQ = e.QQ,
				Company=e.Company,
				Title=e.Title,
				CompanyTelephoneNo=e.CompanyTelephoneNo,
				BeginWorkTime=e.BeginWorkTime,
				WorkedYears=e.WorkedYears,
				HighestEduLevel=e.HighestEduLevel,
				HighestQualification=e.HighestQualification,
				GraduateDate = e.GraduateDate,
				GruduateSchool=e.GruduateSchool,
				HighestQualificationNo=e.HighestQualificationNo,
				StudyDuration1 = e.StudyDuration1,
				StudySchool1 = e.StudySchool1,
				StudyPosition1 = e.StudyPosition1,
				StudyDuration2 = e.StudyDuration2,
				StudySchool2 = e.StudySchool2,
				StudyPosition2 = e.StudyPosition2,
				StudyDuration3 = e.StudyDuration3,
				StudySchool3 = e.StudySchool3,
				StudyPosition3 = e.StudyPosition3,
				MemberRelType1 = e.MemberRelType1,
				MemberName1 = e.MemberName1,
				MemberCompany1 = e.MemberCompany1,
				MemberPosition1 = e.MemberPosition1,
				MemberMobile1 = e.MemberMobile1,
				MemberRelType2 = e.MemberRelType2,
				MemberName2 = e.MemberName2,
				MemberCompany2 = e.MemberCompany2,
				MemberPosition2 = e.MemberPosition2,
				MemberMobile2 = e.MemberMobile2,
				Remark = e.Remark,
				Status = e.Status,
				Consultant=e.Consultant,
				Referrer=e.Referrer,
				ReferrerMobile=e.ReferrerMobile,
				ReferrerQQ = e.ReferrerQQ,
				MatriculateTime = e.MatriculateTime,
				NetUserName=e.NetUserName,
				NetPassword=e.NetPassword,
				StudyType=e.StudyType,
				SubmitStatus=e.SubmitStatus,
				OfferStatus=e.OfferStatus,
				PayStatus=e.PayStatus,
				PaperStatus=e.PaperStatus,
				OldOAId=e.OldOAId
				
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, QualificationStudent e) {
			m.Rows.Add(this.ToJson(e));
		}

		partial void BeforeAddData(QualificationStudent e, ref ActionResult ar) {
			e.Photo1 = this.SaveFile("pf1");
			e.Photo2 = this.SaveFile("pf2");
			e.Photo3 = this.SaveFile("pf3");
		}
		partial void BeforeUpdateData(QualificationStudent e, ref ActionResult ar) {
			var fn = this.SaveFile("pf1");
			if (!String.IsNullOrEmpty(fn)) e.Photo1 = fn;
			fn = this.SaveFile("pf2");
			if (!String.IsNullOrEmpty(fn)) e.Photo2 = fn;
			fn = this.SaveFile("pf3");
			if (!String.IsNullOrEmpty(fn)) e.Photo3 = fn;
			
		}
		private string SaveFile(string key) {
			string fn = null;
			var f = this.Request.Files[key];
			if (!String.IsNullOrEmpty(f.FileName) && f.ContentLength > 0) {
				var ext = System.IO.Path.GetExtension(f.FileName);
				fn = "/Content/pic/" + Guid.NewGuid().ToString() + ext;
				f.SaveAs(this.Server.MapPath(fn));
			}
			return fn;
		}

		partial void AfterAddData(QualificationStudent e, ref ActionResult ar) {
			//ar = this.RedirectToAction("AddNew");
			ar = this.RedirectToAction("EditStudent", new { id = e.Id });

		}
		partial void AfterUpdateData(QualificationStudent e, ref ActionResult ar) {
			ar = this.RedirectToAction("EditStudent", new { id = e.Id });
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult AddNew() {
			var ss = new QualificationSchoolService(new SysContext{ CurrentUser = AppContext.CurrentUser });
			
			var m = new QualificationStudentViewModel();
			m.Schools = ss.FindAll();
			m.Student = new QualificationStudent();
			return this.View(m);
		}
		[HttpPost]
		public ActionResult AddNew(QualificationStudent e) {
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
		public ActionResult Search() {
			var ss = new QualificationSchoolService(new SysContext{ CurrentUser = AppContext.CurrentUser });

			var m = new QualificationStudentSearchViewModel {
				Criteria = new QualificationStudentCriteria(),
				Schools = ss.FindAll(),
				Students = new List<QualificationStudent>()
			};
			return this.View(m);
		}
		[HttpPost]
		public ActionResult Search(QualificationStudentCriteria c) {
			var ss = new QualificationSchoolService(new SysContext{ CurrentUser = AppContext.CurrentUser });
			c.CurrentUserName = AppContext.CurrentUser.Name;
			var m = new QualificationStudentSearchViewModel {
				Criteria = c,
				Schools = ss.FindAll(),
				Students = this.Service.Search(c)
			};
			return this.View(m);
		}

		[HttpGet]
		public ActionResult EditStudent(int id) {
			var ss = new QualificationSchoolService(new SysContext{ CurrentUser = AppContext.CurrentUser });

			var m = new QualificationStudentViewModel { Schools = ss.FindAll(), Student = this.Service.FindById(id) };
			if (m.Student != null) {
				return this.View(m);
			} else {
				return this.Content("找不到数据！");
			}
		}
		[HttpPost]
		public ActionResult UpdateStudent(QualificationStudent e) {
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

		[HttpGet]
		public ActionResult Display(int id) {
			QualificationUnrestrictedUserService us = new QualificationUnrestrictedUserService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var list = us.FindByUserName(AppContext.CurrentUser.Name);
			this.ViewBag.CanEdit = (list.Count > 0);
			

			var m = this.Service.FindById(id);
			return this.View(m);
		}

		[HttpGet]
		public ActionResult SummaryReport() {
			var list = this.Service.GetSummaryReport();
			return this.View(list);
		}
		[HttpGet]
		public ActionResult SumBySchool(int year) {
			this.ViewBag.Year = year;
			var list = this.Service.SumBySchool(year);
			return this.View(list);
		}
		[HttpGet]
		public ActionResult SumByConsultant(int year) {
			this.ViewBag.Year = year;
			var list = this.Service.SumByConsultant(year);
			return this.View(list);
		}
		[HttpGet]
		public ActionResult SumByReferer(int year, string consultant) {
			this.ViewBag.Year = year;
			var list = this.Service.SumByReferer(year,consultant);
			return this.View(list);
		}
		[HttpGet]
		public ActionResult SumByStatus() {
			var list = this.Service.SumByStatus();
			return this.View(list);
		}


		[HttpGet]
		public ActionResult ListStudents(int? year, string school, string consultant, string referrer, string submitStatus, string offerStatus, string payStatus, string paperStatus) {
			var c = new QualificationStudentCriteria {
				Year = year,
				TargetSchoolNameSrh = school,
				ConsultantSrh = consultant,
				ReferrerSrh = referrer,
				CurrentUserName = AppContext.CurrentUser.Name,
				SubmitStatusSrh = submitStatus,
				OfferStatusSrh = offerStatus,
				PayStatusSrh = payStatus,
				PaperStatusSrh = paperStatus
			};
			var list = this.Service.Search(c);
			return this.View(list);
		}

	}
}
