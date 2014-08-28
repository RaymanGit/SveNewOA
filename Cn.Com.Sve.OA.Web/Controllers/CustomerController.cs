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
	public partial class CustomerController : BaseController {
		//public IBigInfoSourceService BigInfoSourceService { get; set; }
		//public ISmallInfoSourceService SmallInfoSourceService { get; set; }
		//public IImportCustomerService ImportCustomerService { get; set; }
		#region 分部方法
		private object ToJson(Customer e) {
			return new {
				Id = e.Id,
				Name = e.Name,
				SchoolId = e.SchoolId,
				MarketYear = e.MarketYear,
				Telephone = e.Telephone,
				Mobile = e.Mobile,
				Clazz = e.Clazz,
				Gender = e.Gender,
				QQ = e.QQ,
				Email = e.Email,
				EduLevel = e.EduLevel,
				IsGaoKao = e.IsGaoKao,
				GaoKaoScore = e.GaoKaoScore,
				GaoKaoBatch = e.GaoKaoBatch,
				DistrictId = e.DistrictId,
				Address = e.Address,
				Postcode = e.Postcode,
				SmallInfoSourceId = e.SmallInfoSourceId,
				ConsultType = e.ConsultType,
				Remark = e.Remark,
				ConsultantId1 = e.ConsultantId1,
				ConsultantId2 = e.ConsultantId2,
				NetConsultantId = e.NetConsultantId,
				CreateTeacherId = e.CreateTeacherId,
				ConsultTime = e.ConsultTime,
				SalesTeamId = e.SalesTeamId,
				SalesmanId = e.SalesmanId,
				IsImport = e.IsImport,
				TeleSalesTimes = e.TeleSalesTimes,
				NextTeleSalesTime = e.NextTeleSalesTime.HasValue ? String.Format("{0:yyyy-MM-dd HH:mm}",e.NextTeleSalesTime.Value) : "",
				AppointmentTime = e.AppointmentTime,
				DropInTime = e.DropInTime,
				DinWeiTime = e.DinWeiTime,
				SignUpTime = e.SignUpTime,
				IsDinWei = e.IsDinWei,
				IsClosed = e.IsClosed,
				Important = e.Important,
				ConsultantRemark = e.ConsultantRemark,
				Keywords = e.Keywords,
				IsLeaderFollow = e.IsLeaderFollow,
				Status = e.Status,
				LastSalesTime = e.LastSalesTime,
				LastSaleLog = e.LastSaleLog,
				InClazzId = e.InClazzId,
				InClazzName = e.InClazzName,
				ConsultantName1 = e.ConsultantName1,
				ConsultantName2 = e.ConsultantName2,
				ProvinceName = e.ProvinceName,
				CityName = e.CityName,
				DistrictName = e.DistrictName,
				SchoolName = e.SchoolName,
				SalesTeamName = e.SalesTeamName,
				SalesmanName = e.SalesmanName,
				IsDorm = e.IsDorm
			};
			#region OLD
			//return new {
			//    Id = e.Id,
			//    Name = e.Name,
			//    SchoolId = e.SchoolId,
			//    MarketYear = e.MarketYear,
			//    Telephone = e.Telephone,
			//    Mobile = e.Mobile,
			//    Clazz = e.Clazz,
			//    Gender = e.Gender,
			//    QQ = e.QQ,
			//    Email = e.Email,
			//    EduLevel = e.EduLevel,
			//    IsGaoKao = e.IsGaoKao,
			//    GaoKaoScore = e.GaoKaoScore,
			//    GaoKaoBatch = e.GaoKaoBatch,
			//    DistrictId = e.DistrictId,
			//    Address = e.Address,
			//    Postcode = e.Postcode,
			//    SmallInfoSourceId = e.SmallInfoSourceId,
			//    ConsultType = e.ConsultType,
			//    Remark = e.Remark,
			//    ConsultantId1 = e.ConsultantId1,
			//    ConsultantId2 = e.ConsultantId2,
			//    NetConsultantId = e.NetConsultantId,
			//    CreateTeacherId = e.CreateTeacherId,
			//    ConsultTime = e.ConsultTime,
			//    SalesTeamId = e.SalesTeamId,
			//    SalesmanId = e.SalesmanId,
			//    IsImport = e.IsImport,
			//    TeleSalesTimes = e.TeleSalesTimes,
			//    NextTeleSalesTime = e.NextTeleSalesTime,
			//    AppointmentTime = e.AppointmentTime,
			//    DropInTime = e.DropInTime,
			//    DinWeiTime = e.DinWeiTime,
			//    SignUpTime = e.SignUpTime,
			//    IsDinWei = e.IsDinWei,
			//    IsClosed = e.IsClosed,
			//    Important = e.Important,
			//    ConsultantRemark = e.ConsultantRemark,
			//    Keywords = e.Keywords,
			//    IsLeaderFollow = e.IsLeaderFollow,
			//    Status = e.Status,
			//    LastSalesTime = e.LastSalesTime,
			//    LastSaleLog = e.LastSaleLog,
			//    InClazzId = e.InClazzId,
			//    InClazzName = (e.InClazz == null) ? "" : e.InClazz.Name,
			//    ConsultantName1 = (e.Consultant1 == null) ? "" : e.Consultant1.Name,
			//    ConsultantName2 = (e.Consultant2 == null) ? "" : e.Consultant2.Name,
			//    ProvinceName = (e.District == null || e.District.City == null || e.District.City.Province == null) ? "" : e.District.City.Province.Name,
			//    CityName = (e.District == null || e.District.City == null) ? "" : e.District.City.Name,
			//    DistrictName = (e.District == null) ? "" : e.District.Name,
			//    SchoolName = e.School.Name,
			//    SalesTeamName = (e.SalesTeam == null) ? "" : e.SalesTeam.Name,
			//    SalesmanName = (e.Salesman == null) ? "" : e.Salesman.Name,
			//    IsDorm = e.IsDorm
			//};
			#endregion
		}

		partial void AddRowToGridModel(LigerGridModel m, Customer e) {
			m.Rows.Add(this.ToJson(e));
		}
		partial void AfterAddData(Customer e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		partial void AfterUpdateData(Customer e, ref ActionResult ar) {
			ar = this.Json(new AjaxOperationResult {
				Data = this.ToJson(e),
				Successful = true
			});
		}
		#endregion
		
		public ActionResult GetInitData() {
			#region 省市区数据
			IProvinceService provService = new ProvinceService(new SysContext { CurrentUser = AppContext.CurrentUser });
			ICityService cityService = new CityService(new SysContext { CurrentUser = AppContext.CurrentUser });
			IDistrictService districtService = new DistrictService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var provinces = provService.FindAll();
			var cities = cityService.FindAll();
			var districts = districtService.FindAll();

			List<object> provs = new List<object>();

			provinces.ForEach(o => {
				var p = new { Id = o.Id, Name = o.Name, Cities = new List<object>() };
				cities.Where(c => c.ProvinceId.Equals(o.Id)).ToList().ForEach(c => {
					var city = new { Id = c.Id, Name = c.Name, Districts = new List<object>() };
					districts.Where(d => d.CityId.Equals(c.Id)).ToList().ForEach(d => {
						city.Districts.Add(new { Id = d.Id, Name = d.Name });
					});
					p.Cities.Add(city);
				});
				provs.Add(p);
			});
			#endregion

			#region 招生小组
			ISalesTeamService teamService = new SalesTeamService(new SysContext { CurrentUser = AppContext.CurrentUser });
			ISalesTeamMemberService memberService = new SalesTeamMemberService(new SysContext { CurrentUser = AppContext.CurrentUser });
			var ts = teamService.FindAll();
			var ms = memberService.FindAll();
			var teams = new List<object>();

			ts.ForEach(o => {
				var t = new { Id = o.Id, Name = o.Name, Members = new List<object>() };
				ms.Where(m => m.SalesTeamId.Equals(o.Id)).ToList().ForEach(m => {
					t.Members.Add(new { Id = m.Id, Name = m.User.Name, UserId = m.UserId, IsLeader = m.IsLeader });
				});
				teams.Add(t);
			});
			#endregion

			return this.Json(new { Provinces = provs, Teams = teams }, JsonRequestBehavior.AllowGet);
		}

		#region 导入数据

		[HttpGet]
		public ActionResult Import() {
			// 默认招生年份，9月份以前默认为本年，9月份开始默认为下一年
			if (DateTime.Today.Month < 9) {
				this.ViewBag.MarketingYear = DateTime.Today.Year;
			} else {
				this.ViewBag.MarketingYear = DateTime.Today.Year + 1;
			}
			return this.View();
		}
		[HttpPost]
		public ActionResult ImportBySchool(int? SchoolId, string Level, int? MarketingYear, int? BigSourceId, int? SmallSourceId, bool? chkDelOld) {
			if (!SchoolId.HasValue) { 
				return this.Content("找不到相应的学校！");
			}
			if (!MarketingYear.HasValue) {
				return this.Content("请填写正确的招生年份！");
			}
			if (!BigSourceId.HasValue || !SmallSourceId.HasValue) {
				return this.Content("请选择正确的信息来源！");
			}
			if (this.Request.Files["File"] == null) {
				return this.Content("请选择正确的数据文件！");
			}
			var key = Guid.NewGuid().ToString();
			var filename = @"d:\tempdata\" + key + ".xls";
			try {
				this.Request.Files["File"].SaveAs(filename);
			} catch (Exception ex) {
				return this.Content(String.Format("保存上传文件时发生错误，内部错误为{0}。", ex.Message));
			}
			//var filename = @"d:\tempdata\91b630c2-bf32-410b-b0a4-3b7e69891c23.xls";
			var r = this.Service.ImportBySchool(key, SchoolId.Value, Level, MarketingYear.Value, SmallSourceId.Value, filename, chkDelOld.GetValueOrDefault());
			if (r.Successful) {
				int rn1 = 0, rn2=0;
				if (r.DuplicateQty > 0) {
					rn1 = 1;
				}
				if (r.ErrorQty > 0) {
					rn2 = 1;
				}
				return this.Content(String.Format(
					"OK-{6}-{7}-{0}-总记录数：{1}，添加数量：{2}，更新数量：{3}，重复数量：{4}，错误数量：{5}。"
					,key,r.TotalQty,r.AddedQty,r.UpdatedQty,r.DuplicateQty,r.ErrorQty,rn1,rn2
				));
			} else {
				return this.Content(r.ErrorMessage);
			}
			//return this.Content("msg");
			//return this.Json(new AjaxOperationResult { Successful = true });
			//this.ViewBag.MarketingYear = MarketingYear;
			//return this.View("Import");			
		}
		[HttpPost]
		public ActionResult ImportByChannel(string Level, int? MarketingYear, int? BigSourceId2, int? SmallSourceId2) {
			if (!MarketingYear.HasValue) {
				return this.Content("请填写正确的招生年份！");
			}
			if (!BigSourceId2.HasValue || !SmallSourceId2.HasValue) {
				return this.Content("请选择正确的信息来源！");
			}
			if (this.Request.Files["File"] == null) {
				return this.Content("请选择正确的数据文件！");
			}
			var key = Guid.NewGuid().ToString();
			var filename = @"d:\tempdata\" + key + ".xls";
			try {
				this.Request.Files["File"].SaveAs(filename);
			} catch (Exception ex) {
				return this.Content(String.Format("保存上传文件时发生错误，内部错误为{0}。", ex.Message));
			}
			//var filename = @"d:\tempdata\91b630c2-bf32-410b-b0a4-3b7e69891c23.xls";
			try {
				var r = this.Service.ImportByChannel(key, Level, MarketingYear.Value, SmallSourceId2.Value, filename);
				if (r.Successful) {
					int rn1 = 0, rn2 = 0;
					if (r.DuplicateQty > 0) {
						rn1 = 1;
					}
					if (r.ErrorQty > 0) {
						rn2 = 1;
					}
					return this.Content(String.Format(
						"OK-{6}-{7}-{0}-总记录数：{1}，添加数量：{2}，更新数量：{3}，重复数量：{4}，错误数量：{5}。"
						, key, r.TotalQty, r.AddedQty, r.UpdatedQty, r.DuplicateQty, r.ErrorQty, rn1, rn2
					));
				} else {
					return this.Content(r.ErrorMessage);
				}
			} catch (Exception ex) {
				return this.Content(ex.Message);
			}
			//return this.Content("msg");
			//return this.Json(new AjaxOperationResult { Successful = true });
			//this.ViewBag.MarketingYear = MarketingYear;
			//return this.View("Import");			
		}
		
		public ActionResult ShowImportDuplicate(string importKey) {
			this.ViewBag.Key = importKey;
			return this.View();
		}
		public ActionResult ShowImportError(string importKey) {
			this.ViewBag.Key = importKey;
			return this.View();
		}
		public ActionResult GetImportDuplicate(ImportDupliateCriteria c) {
			var m = new LigerGridModel();
			var r = this.Service.GetImportDuplicate(c);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				m.Rows.Add(new {
					Id = o.Id,
					CustomerId = o.CustomerId,
					ImportId = o.ImportId,
					SchoolName = o.SchoolName,
					Name = o.Name,
					Tel = o.Tel,
					Mobile = o.Mobile,
					Score = o.Score,
					ErrorMsg = o.ErrorMsg,
					Flag = o.CustomerId.HasValue ? "已有记录" : "新记录"
				});
			});
			var ar = this.Json(m, JsonRequestBehavior.AllowGet);
			return ar;
			/*
                    { display: 'Id', name: 'Id', width: 100, align: 'left' },
					{ display: 'ImportKey', name: 'ImportKey', width: 100, align: 'left' },
					{ display: 'CustomerId', name: 'CustomerId', width: 100, align: 'left' },
					{ display: 'ImportId', name: 'ImportId', width: 100, align: 'left' },
					{ display: 'SchoolName', name: 'SchoolName', width: 100, align: 'left' },
					{ display: 'Name', name: 'Name', width: 100, align: 'left' },
					{ display: 'Tel', name: 'Tel', width: 100, align: 'left' },
					{ display: 'Mobile', name: 'Mobile', width: 100, align: 'left' },
					{ display: 'Score', name: 'Score', width: 100, align: 'left' }
			 */
		}
		public ActionResult GetImportError(ImportCustomerCriteria c) {
			/*
					{ display: 'ProvinceName', name: 'ProvinceName', width: 100, align: 'left' },
					{ display: 'CityName', name: 'CityName', width: 100, align: 'left' },
					{ display: 'DistrictName', name: 'DistrictName', width: 100, align: 'left' },
					{ display: 'SchoolName', name: 'SchoolName', width: 100, align: 'left' },
					{ display: 'Name', name: 'Name', width: 100, align: 'left' },
					{ display: 'Gender', name: 'Gender', width: 100, align: 'left' },
					{ display: 'Tel', name: 'Tel', width: 100, align: 'left' },
					{ display: 'Mobile', name: 'Mobile', width: 100, align: 'left' },
					{ display: 'Score', name: 'Score', width: 100, align: 'left' },
					{ display: 'ErrorMsg', name: 'ErrorMsg', width: 100, align: 'left' }

			 */
			var m = new LigerGridModel();
			var r = this.Service.GetImportError(c);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				m.Rows.Add(new {
					Id = o.Id,
					ProvinceName = o.ProvinceName,
					CityName = o.CityName,
					DistrictName = o.DistrictName,
					SchoolName = o.SchoolName,
					Name = o.Name,
					Gender = o.Gender,
					Tel = o.Tel,
					Mobile = o.Mobile,
					Score = o.Score,
					ErrorMsg = o.ErrorMsg
				});
			});
			var ar = this.Json(m, JsonRequestBehavior.AllowGet);
			return ar;
		}
		#endregion

		#region 资料分配

		/// <summary>
		/// 生源分配到组
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult AssignToTeam() {
			return this.View();
		}
		[HttpPost]
		public ActionResult AssignToTeamBySchool(int? teamId, string schoolIds) {
			AjaxOperationResult r = new AjaxOperationResult { Successful = true, Message = "" };
			try {
				if (!teamId.HasValue) {
					r.Successful = false;
					r.Message = "未指定招生小组";
				} else if (String.IsNullOrEmpty(schoolIds)) {
					r.Successful = false;
					r.Message = "未指定学校";
				} else {
					string[] ids = schoolIds.Split(',');
					var sids = new List<int>();
					foreach (var id in ids) {
						if (!String.IsNullOrEmpty(id.Trim())) {
							try {
								sids.Add(Int32.Parse(id));
							} catch { }
						}
					}
					this.Service.AssignToTeam(teamId.Value, sids);
				}
			} catch (Exception ex) {
				r.Successful = false;
				r.Message = ex.Message;
			}
			return this.Json(r);
		}
		[HttpPost]
		public ActionResult ChangeSalesman(int oldId, int newId) {
			AjaxOperationResult r = new AjaxOperationResult { Successful = true, Message = "" };
			try {
				this.Service.ChangeSalesman(oldId, newId);
			} catch (Exception ex) {
				r.Successful = false;
				r.Message = ex.Message;
			}
			return this.Json(r);
		}
		[HttpGet]
		public ActionResult AssignToSales() {
			return this.View();
		}
		[HttpPost]
		public ActionResult AssignToSales(int salesman, int schoolId, int qty) {
			AjaxOperationResult r = new AjaxOperationResult { Successful = true, Message = "" };
			try {
				this.Service.AssignToSalesman(schoolId, salesman, qty);
			} catch (Exception ex) {
				r.Successful = false;
				r.Message = ex.Message;
			}
			return this.Json(r);
		}
		[HttpPost]
		public ActionResult AssignToSales2(int? teamId, int? memberId, string customerIds) {
			AjaxOperationResult r = new AjaxOperationResult { Successful = true, Message = "" };
			try {
				if (!teamId.HasValue) {
					r.Successful = false;
					r.Message = "未指定招生小组";
				} else if (!memberId.HasValue) {
					r.Successful = false;
					r.Message = "未指定招生人员";
				} else if (String.IsNullOrEmpty(customerIds)) {
					r.Successful = false;
					r.Message = "未指定生源资料";
				} else {
					string[] ids = customerIds.Split(',');
					var sids = new List<int>();
					foreach (var id in ids) {
						if (!String.IsNullOrEmpty(id.Trim())) {
							try {
								sids.Add(Int32.Parse(id));
							} catch { }
						}
					}
					this.Service.AssignToSales(teamId.Value, memberId.Value, sids);
				}
			} catch (Exception ex) {
				r.Successful = false;
				r.Message = ex.Message;
			}
			return this.Json(r);
		}
				
		public ActionResult CountBySchool(int schoolId, int teamId) {
			var r = this.Service.CountBySchool(schoolId, teamId);
			return this.Json(r, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Search(CustomerCriteria c) {
			var m = new LigerGridModel();
			var r = this.Service.Search(c);
			this.AfterGetData(m, c, r);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				this.AddRowToGridModel(m, o);
			});
			this.AfterBuildGridModel(m, c, r);
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region 电访
		/// <summary>
		/// 组长跟进
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult LeaderFollow() {
			ISalesTeamMemberService tms = new SalesTeamMemberService(new SysContext { CurrentUser = AppContext.CurrentUser },this.Service.Db);
			var user = AppContext.CurrentUser;
			int? teamId = null;
			if (user != null) {
				var members = tms.FindByUserId(user.Id);
				if (members.Count(o => o.IsLeader) > 0) {
					// 组长
					teamId = members.First(o => o.IsLeader).SalesTeam.Id;
				} else {
					// 当前用户非组长
				}
			}

			ViewBag.TeamId = teamId;
			return this.View();
		}
		/// <summary>
		/// 负责学校列表
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult MySchools() {
			var model = new Models.ViewModels.Customer_MySchools_ViewModel();
			model.Teams = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>();

			var schools = this.Service.FindSchoolAssignState();


			ISupervisorService saService = new SupervisorService(new SysContext { CurrentUser = AppContext.CurrentUser }, this.Service.Db);
			ISalesTeamService sts = new SalesTeamService(new SysContext { CurrentUser = AppContext.CurrentUser }, this.Service.Db);
			var teams = sts.FindAll();
			ISalesTeamMemberService tms = new SalesTeamMemberService(new SysContext { CurrentUser = AppContext.CurrentUser }, this.Service.Db);
			var tMembers = tms.FindAll();
			var user = AppContext.CurrentUser;
			if (user != null) {
				bool isSa = saService.FindByUserId(user.Id).Count(o => o.Type.Equals("查看所有生源")) > 0;
				if (isSa) {
					teams.ForEach(t => {
						model.Teams.Add(this.BuildSalesTeamSchoolData(t, schools, tMembers));
					});
				} else {
					var members = tMembers.Where(o => o.UserId.Equals(user.Id)).ToList();
					if (members.Count(o => o.IsLeader) > 0) {
						// 组长
						members.Where(o => o.IsLeader).ToList().ForEach(t => { 
							model.Teams.Add(this.BuildSalesTeamSchoolData(t.SalesTeam, schools, tMembers));
						});
					} else {
						// 当前用户非组长
						members.ForEach(m => {
							var team = new Models.ViewModels.Customer_MySchools_ViewModel.Item {
								Id = m.SalesTeam.Id,
								Name = m.SalesTeam.Name,
								Children = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>(),
								Schools = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>()
							};
							team.Children.Add(this.BuildSalesmanSchoolData(m, schools));
							model.Teams.Add(team);
						});
					}
				}
			}

			return this.View(model);
		}

		private Customer_MySchools_ViewModel.Item BuildSalesmanSchoolData(SalesTeamMember m, List<SchoolAssignState> schools) {
			var member = new Models.ViewModels.Customer_MySchools_ViewModel.Item {
				Id = m.UserId,
				Name = m.User.Name,
				Schools = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>()
			};
			schools.Where(o => o.SalesmanId.HasValue && o.SalesmanId.Equals(m.UserId)).ToList().ForEach(o => { 
				member.Schools.Add(new Models.ViewModels.Customer_MySchools_ViewModel.Item { Id = o.SchoolId, Name = o.SchoolName });
			});
			return member;
		}
		private Customer_MySchools_ViewModel.Item BuildSalesTeamSchoolData(SalesTeam t, List<SchoolAssignState> schools, List<SalesTeamMember> members) {
			//ISalesTeamMemberService tms = new SalesTeamMemberService(new SysContext { CurrentUser = AppContext.CurrentUser }, this.Service.Db);
			var team = new Models.ViewModels.Customer_MySchools_ViewModel.Item {
				Id = t.Id,
				Name = t.Name,
				Children = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>(),
				Schools = new List<Models.ViewModels.Customer_MySchools_ViewModel.Item>()
			};
			schools.Where(o => o.SalesTeamId.HasValue && o.SalesTeamId.Equals(t.Id)).ToList().ForEach(o => {
				team.Schools.Add(new Models.ViewModels.Customer_MySchools_ViewModel.Item { Id = o.SchoolId, Name = o.SchoolName });
			});
			members.Where(o => o.SalesTeamId.Equals(t.Id)).ToList().ForEach(m => {
				team.Children.Add(this.BuildSalesmanSchoolData(m, schools));
			});
			return team;
		}
		/// <summary>
		/// 显示我的回访资料查询列表界面
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult MyTeleCustomers() {
			return this.RedirectToAction("MySchools");
			//return this.View();
		}
		/// <summary>
		/// 显示某学校的生源
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult MyTeleCustomersBySchool(int schoolId) {
			this.ViewBag.SchoolId = schoolId;
			return this.View();
		}
		[HttpGet]
		public ActionResult SearchTeleCustomers() {
			return this.View();
		}


		/// <summary>
		/// 显示录入电访记录界面
		/// </summary>
		/// <param name="customerId">生源ID</param>
		/// <returns></returns>
		public ActionResult TeleSale(int customerId) {
			var m = new Models.ViewModels.TeleSaleViewModel();
			m.Customer = this.Service.FindById(customerId);

			return this.View(m);
		}

		/// <summary>
		/// 在电访过程中修改生源资料
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult UpdateInTelSale(Customer e) {
			ActionResult ar = null;
			try {
				var c = this.Service.FindById(e.Id);
				c.Name = e.Name;
				c.Gender = e.Gender;
				c.EduLevel = e.EduLevel;
				c.Telephone = e.Telephone;
				c.Mobile = e.Mobile;
				c.QQ = e.QQ;
				c.DistrictId = e.DistrictId;
				c.Address = e.Address;
				c.Postcode = e.Postcode;
				c.SchoolId = e.SchoolId;
				c.Clazz = e.Clazz;
				this.Service.Save(c);
				this.AfterUpdateData(c, ref ar);
			} catch (Exception ex) {
				ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
			return ar;
		}
		/// <summary>
		/// 显示回访记录
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		public ActionResult DisplayTeleSaleLogs(int customerId) {
			var m = new Models.ViewModels.TeleSaleViewModel();
			m.Customer = this.Service.FindById(customerId);

			return this.View(m);
		}

		[HttpGet]
		public ActionResult ChangeStatus() {
			return this.View();
		}
		/// <summary>
		/// 上门
		/// </summary>
		/// <param name="id"></param>
		/// <param name="consultant"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult DropIn(int id, int? consultant) {
			try {
				var c = this.Service.DropIn(id, consultant);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}
		/// <summary>
		/// 撤消上门状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="consultant"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult CancelDropIn(int id) {
			try {
				var c = this.Service.CancelDropIn(id);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult DinWei(int id, int? consultant, int? clazzId, bool? isDorm) {
			try {
				var c = this.Service.DinWei(id, consultant, clazzId, isDorm);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}
		[HttpPost]
		public ActionResult CancelDinWei(int id) {
			try {
				var c = this.Service.CancelDinWei(id);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult SignUp(int id, int? consultant, int? clazzId, bool? isDorm) {
			try {
				var c = this.Service.SignUp(id, consultant, clazzId, isDorm);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}
		[HttpPost]
		public ActionResult CancelSignUp(int id) {
			try {
				var c = this.Service.CancelSignUp(id);
				return this.Json(new AjaxOperationResult { Data = this.ToJson(c), Successful = true });
			} catch (Exception ex) {
				return this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
			}
		}
	
		#endregion

		#region 查询
		/// <summary>
		/// 查询咨询状态
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult SearchStatus() {
			return this.View();
		}
		[HttpPost]
		public ActionResult SearchStatus(CustomerCriteria c) {
			string status = c.StatusSrh;
			switch (c.StatusSrh) { 
				case "已上门":
					c.IsDropInSrh = true;
					c.DropInTimeFromSrh = c.ChangeStatusTimeStartSrh;
					c.DropInTimeToSrh = c.ChangeStatusTimeEndSrh;
					break;
				case "已定位":
					c.IsDinWeiSrh = true;
					c.DinWeiTimeFromSrh = c.ChangeStatusTimeStartSrh;
					c.DinWeiTimeToSrh = c.ChangeStatusTimeEndSrh;
					break;
				case "已报名":
					c.IsSignUpSrh = true;
					c.SignUpTimeFromSrh = c.ChangeStatusTimeStartSrh;
					c.SignUpTimeToSrh = c.ChangeStatusTimeEndSrh;
					break;
				case "已缴费":
					c.StatusSrh = String.Empty;
					c.IsPaySrh = true;
					c.PayTimeFromSrh = c.ChangeStatusTimeStartSrh;
					c.PayTimeToSrh = c.ChangeStatusTimeEndSrh;
					break;
				case "已退费":
					c.StatusSrh = String.Empty;
					c.IsRefundSrh = true;
					c.RefundTimeFromSrh = c.ChangeStatusTimeStartSrh;
					c.RefundTimeToSrh = c.ChangeStatusTimeEndSrh;
					break;
				default:
					break;
			}

			var m = new LigerGridModel();
			var r = this.Service.Search(c);
			this.AfterGetData(m, c, r);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				String time1 = String.Empty, time2=String.Empty, c1=String.Empty,c2=String.Empty, payStatus = "否";
				payStatus = (o.IsPay) ? "是" : "否";
				switch (status) {
					case "已上门":
						time1 = String.Format("{0:d}", o.DropInTime.GetValueOrDefault());
						c1 = o.ConsultantName1;
						break;
					case "已定位":
						time1 = String.Format("{0:d}", o.DropInTime.GetValueOrDefault());
						c1 = o.ConsultantName1;
						time2 = String.Format("{0:d}", o.DinWeiTime.GetValueOrDefault());
						c2 = o.ConsultantName2;
						break;
					case "已报名":
						time1 = String.Format("{0:d}", o.DropInTime.GetValueOrDefault());
						c1 = o.ConsultantName1;
						time2 = String.Format("{0:d}", o.SignUpTime.GetValueOrDefault());
						c2 = o.ConsultantName2;
						break;
					case "已缴费":
						time1 = String.Format("{0:d}", o.DropInTime.GetValueOrDefault());
						c1 = o.ConsultantName1;
						time2 = String.Format("{0:d}", o.SignUpTime.GetValueOrDefault());
						//time2 = String.Format("{0:d}", o.PayTime.GetValueOrDefault());
						c2 = o.ConsultantName2;
						break;
					case "已退费":
						time1 = String.Format("{0:d}", o.DropInTime.GetValueOrDefault());
						c1 = o.ConsultantName1;
						time2 = String.Format("{0:d}", o.SignUpTime.GetValueOrDefault());
						//time = String.Format("{0:d}", o.RefundTime.GetValueOrDefault());
						c2 = o.ConsultantName2;
						break;
					default:
						break;
				}
				m.Rows.Add(
					new {
						Id = o.Id,
						Name = o.Name,
						SchoolName = o.SchoolName,
						SalesTeamName = o.SalesmanName,
						SalesmanName = o.SalesmanName,
						ConsultantName1 = c1,
						ConsultantName2 = c2,
						Status = o.Status,
						InClazzName = o.InClazzName,
						// TODO: ClazzMasterName = (o.InClazz == null) ? "" : o.InClazzMaster,
						Time1 = time1,
						Time2 = time2,
						PayStatus = payStatus
					}
				);
			});
			this.AfterBuildGridModel(m, c, r);
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		#endregion

		
		[HttpPost]
		public ActionResult InputSave(Customer e) {
    		ActionResult ar = null;
    		try {
				if (e.Id == 0) {
					e.ConsultType = "未电访";
					e.CreateTeacherId = AppContext.CurrentUser.Id;
					e.IsImport = false;
					e.TeleSalesTimes = 0;
					e.IsDinWei = false;
					e.IsClosed = false;
					e.Important = false;
					e.IsLeaderFollow = false;
					e.Status = "未上门";
					e.IsPay = false;
					e.IsRefund = false;
					e.IsDropIn = false;
					e.IsSignUp = false;
					this.Service.Add(e);
				} else {
					var c = this.Service.FindById(e.Id);
					c.Name = e.Name;
					c.SchoolId = e.SchoolId;
					c.MarketYear = e.MarketYear;
					c.Telephone = e.Telephone;
					c.Mobile = e.Mobile;
					c.Clazz = e.Clazz;
					c.Gender = e.Gender;
					c.QQ = e.QQ;
					c.Email = e.Email;
					c.EduLevel = e.EduLevel;
					c.IsGaoKao = e.IsGaoKao;
					c.GaoKaoScore = e.GaoKaoScore;
					c.GaoKaoBatch = e.GaoKaoBatch;
					c.DistrictId = e.DistrictId;
					c.Address = e.Address;
					c.Postcode = e.Postcode;
					c.SmallInfoSourceId = e.SmallInfoSourceId;
					c.Remark = e.Remark;
					c.ConsultantId1 = e.ConsultantId1;
					c.ConsultantId2 = e.ConsultantId2;
					c.NetConsultantId = e.NetConsultantId;
					c.SalesTeamId = e.SalesTeamId;
					c.SalesmanId = e.SalesmanId;
					this.Service.Update(c);
				}
    			ar = this.Json(new AjaxOperationResult { Successful = true });
				
    		} catch (Exception ex) {
    			ar = this.Json(new AjaxOperationResult { Successful = false, Message = ex.Message });
    		}
    		return ar;
    	}

		public ActionResult FindDuplicate(CustomerCriteria c) {
			var m = new LigerGridModel();
			var r = this.Service.Search(c);
			this.AfterGetData(m, c, r);
			m.Total = r.RecordCount;
			r.Data.ForEach(o => {
				this.AddRowToGridModel(m, o);
			});
			this.AfterBuildGridModel(m, c, r);
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public ActionResult AssignReport() {
			return this.View();
		}

		public ActionResult GetAssignReport(string SalesTeamName, string SalesmanName) {
			var m = new { Rows = this.Service.GetAssignReport(SalesTeamName, SalesmanName) };

			return this.Json(m, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult GetSalesTeamSummaryReport() {
			return this.View();
		}
		public ActionResult GetSalesTeamSummaryReport(DateTime startDate, DateTime endDate) {
			var m = new { Rows = this.Service.GetSalesTeamSummaryReport(startDate, endDate) };
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
		// 按区域学校统计招生量
		[HttpGet]
		public ActionResult GetSalesTeamSummaryReportBySchool() {
			return this.View();
		}
		public ActionResult GetSalesTeamSummaryReportBySchool(DateTime startDate, DateTime endDate) {
			var m = new { Rows = this.Service.GetSalesTeamSummaryReportBySchool(startDate, endDate) };
			return this.Json(m, JsonRequestBehavior.AllowGet);
		}
		public ActionResult GetCustomerAssignSummaryByTeam(string teamName) {
			var m = this.Service.GetCustomerAssignSummaryByTeam(teamName);
			var s = String.Format("{0}组总资料量{1}份，未分配资料量{2}份。", m.SalesTeamName, m.TotalQty, m.UnassignQty);
			return this.Content(s);
		}
	}
}
