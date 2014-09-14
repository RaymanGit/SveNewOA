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
	public partial class StudentController : BaseController {
		private object ToJson(Student e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				PinYin = e.PinYin,
				Gender = e.Gender,
				Birthday = e.Birthday,
				EduLevel = e.EduLevel,
				GraduateDate = e.GraduateDate,
				Score = e.Score,
				GruduateSchoolId = e.GruduateSchoolId,
				Profession = e.Profession,
				IdCardNo = e.IdCardNo,
				HuKouType = e.HuKouType,
				Address = e.Address,
				Postcode = e.Postcode,
				FeeSource = e.FeeSource,
				SmallInfoSourceId = e.SmallInfoSourceId,
				QQ = e.QQ,
				Email = e.Email,
				Mobile = e.Mobile,
				HomeTelephone = e.HomeTelephone,
				OfficeTelephone = e.OfficeTelephone,
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
				MemberRelType3 = e.MemberRelType3,
				MemberName3 = e.MemberName3,
				MemberCompany3 = e.MemberCompany3,
				MemberPosition3 = e.MemberPosition3,
				MemberMobile3 = e.MemberMobile3,
				MemberRelType4 = e.MemberRelType4,
				MemberName4 = e.MemberName4,
				MemberCompany4 = e.MemberCompany4,
				MemberPosition4 = e.MemberPosition4,
				MemberMobile4 = e.MemberMobile4,
				WorkState = e.WorkState,
				StudyDuration1 = e.StudyDuration1,
				StudySchool1 = e.StudySchool1,
				StudyPosition1 = e.StudyPosition1,
				StudyDuration2 = e.StudyDuration2,
				StudySchool2 = e.StudySchool2,
				StudyPosition2 = e.StudyPosition2,
				StudyDuration3 = e.StudyDuration3,
				StudySchool3 = e.StudySchool3,
				StudyPosition3 = e.StudyPosition3,
				SoftwareExp = e.SoftwareExp,
				ProgramExp = e.ProgramExp,
				NetworkExp = e.NetworkExp,
				RelCourse = e.RelCourse,
				DistrictId = e.DistrictId,
				IntentCity = e.IntentCity,
				ClazzId = e.ClazzId,
				StudentNo = e.StudentNo,
				InSchoolDate = e.InSchoolDate,
				IsDorm = e.IsDorm,
				DormNo = e.DormNo,
				GiveCourseware = e.GiveCourseware,
				Consultants = e.Consultants,
				Remark = e.Remark,
				CreateTime = e.CreateTime,
				LastUpdateTime = e.LastUpdateTime,
				IsGetQualification = e.IsGetQualification,
				Status = e.Status,
				TechnicalWay = e.TechnicalWay,
				NeedObtainWork = e.NeedObtainWork,
				IntentPosition = e.IntentPosition,
				TargetSalary = e.TargetSalary,
				InsuranceStartDate = e.InsuranceStartDate,
				InsuranceEndDate = e.InsuranceEndDate,
				GaoKaoBatch = e.GaoKaoBatch,
				GiveNotebook = e.GiveNotebook,
				MaxSalary = e.MaxSalary,
				CurrentSalary = e.CurrentSalary,
				FirstSalary = e.FirstSalary,
				BeginSchoolTime = e.BeginSchoolTime,
				MasterName1 = e.MasterName1,
				MasterName2 = e.MasterName2,
				MasterName3 = e.MasterName3,
				TeacherName1 = e.TeacherName1,
				TeacherName2 = e.TeacherName2,
				TeacherName3 = e.TeacherName3,
				MasterId1 = e.MasterId1,
				MasterId2 = e.MasterId2,
				MasterId3 = e.MasterId3,
				TeacherId1 = e.TeacherId1,
				TeacherId2 = e.TeacherId2,
				TeacherId3 = e.TeacherId3,
				QualificationSchool = e.QualificationSchool,
				InsuranceStatus = e.InsuranceStatus,
				OldOaId = e.OldOaId,
				OldOaInfoSourceSubTypeName = e.OldOaInfoSourceSubTypeName,
				OldOaClass = e.OldOaClass,
				HasRelTeacher = e.HasRelTeacher,
				RelTeacher = e.RelTeacher,
				HomeIntro = e.HomeIntro,
				Give1 = e.Give1,
				Give2 = e.Give2,
				Give3 = e.Give3,
				Receive1 = e.Receive1,
				Receive2 = e.Receive2,
				Receive3 = e.Receive3,
				Receive4 = e.Receive4,
				Receive5 = e.Receive5,
				Receive6 = e.Receive6,
				Pic1 = e.Pic1,
				Pic2 = e.Pic2,
				Pic3 = e.Pic3,
				Pic4 = e.Pic4,
				Pic5 = e.Pic5,
				Pic6 = e.Pic6
			};
		}

		partial void AddRowToGridModel(LigerGridModel m, Student e) {
			m.Rows.Add(this.ToJson(e));
		}

		partial void BeforeAddData(Student e, ref ActionResult ar) {
			e.Pic1 = this.SaveFile("pf1");
			e.Pic2 = this.SaveFile("pf2");
			e.Pic3 = this.SaveFile("pf3");
			e.Pic4 = this.SaveFile("pf4");
			e.Pic5 = this.SaveFile("pf5");
			e.Pic6 = this.SaveFile("pf6");
			if (String.IsNullOrEmpty(e.DormNo)) {
				e.IsDorm = "否";
			} else {
				e.IsDorm = "是";
			}
			e.CreateTime = DateTime.Now;
			e.LastUpdateTime = DateTime.Now;
			e.NeedObtainWork = "是";

		}
		partial void BeforeUpdateData(Student e, ref ActionResult ar) {
			var p = this.SaveFile("pf1");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic1 = p;
			}
			p = this.SaveFile("pf2");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic2 = p;
			}
			p = this.SaveFile("pf3");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic3 = p;
			}
			p = this.SaveFile("pf4");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic4 = p;
			}
			p = this.SaveFile("pf5");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic5 = p;
			}
			p = this.SaveFile("pf6");
			if (!String.IsNullOrEmpty(p)) {
				e.Pic6 = p;
			}
			if (String.IsNullOrEmpty(e.DormNo)) {
				e.IsDorm = "否";
			} else {
				e.IsDorm = "是";
			}
			e.LastUpdateTime = DateTime.Now;
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

		partial void AfterAddData(Student e, ref ActionResult ar) {
			if (e.ClazzId.HasValue) {
				var s = new StudentChangeClazzLogService(new SysContext { CurrentUser = AppContext.CurrentUser });
				s.Add(new StudentChangeClazzLog { 
					ChangeTime = DateTime.Now, 
					NewClazzId = e.ClazzId.Value, 
					OperatorName = AppContext.CurrentUser.Name, 
					StudentId = e.Id 
				});
			}
			ar = this.RedirectToAction("Add");
		}
		partial void AfterUpdateData(Student e, ref ActionResult ar) {
			if (e.ClazzId.HasValue) {
				var s = new StudentChangeClazzLogService(new SysContext { CurrentUser = AppContext.CurrentUser });
				var list = s.FindByStudentId(e.Id).OrderByDescending(o => o.ChangeTime).ToList();
				if (list.Count > 0) {
					StudentChangeClazzLog log = list[list.Count - 1];
					if (!log.NewClazzId.Equals(e.ClazzId.Value)) {
						s.Add(new StudentChangeClazzLog {
							ChangeTime = DateTime.Now,
							OldClazzId=log.NewClazzId,
							NewClazzId = e.ClazzId.Value,
							OperatorName = AppContext.CurrentUser.Name,
							StudentId = e.Id
						});
					}
				} else {
					s.Add(new StudentChangeClazzLog {
						ChangeTime = DateTime.Now,
						NewClazzId = e.ClazzId.Value,
						OperatorName = AppContext.CurrentUser.Name,
						StudentId = e.Id
					});
				}
			}
			ar = this.RedirectToAction("Edit", new { id = e.Id });
		}

		public ActionResult GetInitData() {
			return this.Json(new { }, JsonRequestBehavior.AllowGet);
		}


		/// <summary>
		/// 提供给电访的同校学生查询
		/// </summary>
		/// <param name="schoolId"></param>
		/// <returns></returns>
		public ActionResult GetStudentsForTeleSale(StudentCriteria c) {
			var m = new LigerGridModel();
			var r = this.Service.FindByCriteria(c);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				m.Rows.Add(new {
					Id = o.Id,
					Name = o.Name,
					FullDistrictName = o.FullDistrictName,
					Address = o.Address,
					Mobile = o.Mobile,
					ClazzName = (o.Clazz == null ? "" : o.Clazz.Name),
					MaxSalary = o.MaxSalary
				});
			});
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult Search() {
			return this.View(new Student_Search_ViewModel());
		}
		private Student_Search_ViewModel DoSearch(StudentCriteria c) {
			c.sortname = "Clazz-Name";
			c.pagesize = null;
			var m = new Student_Search_ViewModel();
			m.Criteria = c;
			var r = this.Service.Search(c);
			r.Data.Where(o=>o.ClazzId.HasValue).Select(o => o.Clazz.Name).Distinct().ToList().ForEach(o => {
				var clazz = new Student_Search_ViewModel.Class();
				clazz.ClazzName = o;
				r.Data.Where(s => s.ClazzId.HasValue  &&  s.Clazz.Name.Equals(o)).ToList().ForEach(s => {
					var student = new Student_Search_ViewModel.Student();
					student.Id = s.Id;
					student.Name = s.Name;
					student.StudentNo = s.StudentNo;
					clazz.Students.Add(student);
				});
				m.Clazz.Add(clazz);
			});

			r.Data.Where(o=>!String.IsNullOrEmpty(o.QualificationSchool)).GroupBy(o => o.QualificationSchool).Select(g => new { Name = g.Key, Qty = g.Count() }).ToList().ForEach(o => {
				m.SchoolSummary.Add(new KeyValuePair<string, int>(o.Name, o.Qty));
			});
			r.Data.Where(o=>!String.IsNullOrEmpty(o.HuKouType)).GroupBy(o => o.HuKouType).Select(g => new { Name = g.Key, Qty = g.Count() }).ToList().ForEach(o => {
				m.HuKouSummary.Add(new KeyValuePair<string, int>(o.Name, o.Qty));
			});
			r.Data.Where(o=>o.District!=null).GroupBy(o => o.District.FullName).Select(g => new { Name = g.Key, Qty = g.Count() }).ToList().ForEach(o => {
				m.DistrictSummary.Add(new KeyValuePair<string, int>(o.Name, o.Qty));
			});



			return m;
		}
		[HttpPost]
		public ActionResult Search(StudentCriteria c) {
			if (c.Export) {
				var sb = new System.Text.StringBuilder();
				sb.AppendLine("姓名\t地址\t毕业学校");
				var r = this.Service.Search(c);
				r.Data.ForEach(o => {
					sb.AppendLine(String.Format("{0}\t{1}\t{2}", 
						o.Name, o.Address, o.GruduateSchool != null ? o.GruduateSchool.Name : ""));
				});

				return File(System.Text.Encoding.Default.GetBytes(sb.ToString()), "application/ms-excel", "fileStream.xls");

			} else {
				return this.View(this.DoSearch(c));
			}
			//r.Data.ForEach(o => {
			//    //this.AddRowToGridModel(m, o);
			//    m.Rows.Add(new { 
			//        Id=o.Id,
			//        ClazzName=o.Clazz.Name,
			//        Name=o.Name,
			//        StudentNo=o.StudentNo
			//    });
			//});
			
			//return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult Display(int id) {
			var s = new StudentChangeClazzLogService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var m = this.Service.FindById(id);
			/*
			if (m != null) {
				m.ChangeClazzLogs = s.FindByStudentId(m.Id).OrderBy(o => o.ChangeTime).ToList();
			}
			 * */
			return this.View(m);
		}

		[HttpGet]
		public ActionResult SearchForTele() {
			return this.View(new Student_Search_ViewModel());
		}
		[HttpPost]
		public ActionResult SearchForTele(StudentCriteria c) {
			return this.View(this.DoSearch(c));
		}

		[HttpGet]
		public ActionResult SearchForVisit() {
			return this.View(new Student_Search_ViewModel());
		}
		[HttpPost]
		public ActionResult SearchForVisit(StudentCriteria c) {
			return this.View(this.DoSearch(c));
		}
		[HttpGet]
		public ActionResult SearchForHomeVisit() {
			return this.View(new Student_Search_ViewModel());
		}
		[HttpPost]
		public ActionResult SearchForHomeVisit(StudentCriteria c) {
			return this.View(this.DoSearch(c));
		}

		public ActionResult DisplayPic(string file) {
			return this.View((object)file);
		}

		#region 保险相关

		[HttpGet]
		public ActionResult SearchForInsurance() {
			return this.View(new InsuranceSearchViewModel { Criteria = new StudentCriteria(), Data = new PagedModel<Student>() });
		}
		[HttpPost]
		public ActionResult SearchForInsurance(StudentCriteria c) {
			var m = new InsuranceSearchViewModel();
			m.Criteria = c;
			m.Data = this.Service.Search(c);
			return this.View(m);
		}
		[HttpPost]
		public ActionResult BuyInsurance(String ClazzNameSrh, String NameSrh, DateTime? BuyStartDate, DateTime? BuyEndDate, List<int> chkSelect) {
			this.Service.BuyInsurance(BuyStartDate.Value, BuyEndDate.Value, chkSelect);

			var m = new InsuranceSearchViewModel();
			m.Criteria = new StudentCriteria { ClazzNameSrh = ClazzNameSrh, NameSrh = NameSrh };
			m.Data = this.Service.Search(m.Criteria);
			return this.View("SearchForInsurance", m);
		}

		[HttpGet]
		public ActionResult SearchInsuranceStatus() {
			var m = new InsuranceSearchViewModel { Criteria = new StudentCriteria(), Data = new PagedModel<Student>() };
			m.Criteria.InsuranceStatusSrh = "全部";
			return this.View(m);
		}
		[HttpPost]
		public ActionResult SearchInsuranceStatus(StudentCriteria c) {
			var m = new InsuranceSearchViewModel();
			m.Criteria = c;
			if (m.Criteria.InsuranceEndDateToSrh.HasValue) {
				if (!m.Criteria.InsuranceStatusSrh.Equals("一个月内到期")) {
					m.Criteria.InsuranceStatusSrh = "全部";
				} else {
					m.Criteria.InsuranceEndDateToSrh = DateTime.Today.AddMonths(1);
				}
			}

			m.Data = this.Service.Search(c);
			return this.View(m);
		}

		#endregion
	}
}
