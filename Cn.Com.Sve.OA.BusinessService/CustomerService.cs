using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;

using FileHelpers;
using FileHelpers.DataLink;

namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface ICustomerService {
		ImportResult ImportBySchool(string key, int schoolId, string level, int marketingYear, int infoSourceId, string filename, bool isDelOldData);
		ImportResult ImportByChannel(string key, string level, int marketingYear, int infoSourceId, string filename);
		PagedModel<ImportCustomer> GetImportError(ImportCustomerCriteria c);
		PagedModel<ImportDupliate> GetImportDuplicate(ImportDupliateCriteria c);

		void AssignToTeam(int teamId, List<int> schools);
		void ChangeSalesman(int oldSalesman, int newSalesman);
		CountCustomerBySchoolResult CountBySchool(int schoolId, int teamId);
		void AssignToSalesman(int schoolId, int salesmanId, int qty);
		void AssignToSales(int teamId, int memberId, List<int> customers);
		PagedModel<Customer> Search(CustomerCriteria c);
		Customer DropIn(int id, int? consultant);
		Customer CancelDropIn(int id);
		Customer DinWei(int id, int? consultant, int? clazzId, bool? isDorm);
		Customer CancelDinWei(int id);
		Customer SignUp(int id, int? consultant, int? clazzId, bool? isDorm);
		Customer CancelSignUp(int id);

		List<School> FindSchoolsBySalesTeam(int teamId);
		List<School> FindSchoolsBySalesman(int userId);
		List<SchoolAssignState> FindSchoolAssignState();
		PagedModel<Customer> FindDuplicate(CustomerCriteria c);
		List<SchoolAssignState> GetAssignReport(string teamName, string salesmanName);
		List<SalesTeamSummaryReport> GetSalesTeamSummaryReport(DateTime startDate, DateTime endDate);
		List<SalesTeamSummaryReportBySchool> GetSalesTeamSummaryReportBySchool(DateTime startDate, DateTime endDate);
		CustomerAssignSummary GetCustomerAssignSummaryByTeam(string teamName);
		void DeleteBySchoolId(int schoolId);
	}
	public partial class CustomerService : ICustomerService {
		public IProvinceRepository ProvRepository { get; set; }
		public ICityRepository CityRepository { get; set; }
		public IDistrictRepository DistrictRepository { get; set; }
		public ISchoolRepository SchoolRepository { get; set; }
		public IImportCustomerRepository ImportCustomerRepository { get; set; }
		public IImportDupliateRepository ImportDupliateRepository { get; set; }
		public void DeleteBySchoolId(int schoolId) {
			this.Repository.DeleteBySchoolId(schoolId);
		}
		#region 导入资料
		public ImportResult ImportBySchool(string key, int schoolId, string level, int marketingYear, int infoSourceId, string filename, bool isDelOldData) {
			ImportResult r = new ImportResult();
			if (isDelOldData) {
				this.DeleteBySchoolId(schoolId);
			}
			#region 初始化 Repository
			this.ProvRepository = new ProvinceRepository(this.Db);
			this.CityRepository = new CityRepository(this.Db);
			this.DistrictRepository = new DistrictRepository(this.Db);
			this.SchoolRepository = new SchoolRepository(this.Db);
			this.ImportCustomerRepository = new ImportCustomerRepository(this.Db);
			this.ImportDupliateRepository = new ImportDupliateRepository(this.Db);
			#endregion
			#region 读取初始数据
			var provinces = this.ProvRepository.FindAll();
			var cities = this.CityRepository.FindAll();
			var districts = this.DistrictRepository.FindAll();
			var schools = this.SchoolRepository.FindAll();
			#endregion
			
			ExcelStorage provider = new ExcelStorage(typeof(QuestionaryData), filename, 3, 1);
			var data = provider.ExtractRecords() as QuestionaryData[];
			var toImportList = new List<ImportCustomer>();
			var toUpdateCustomers = new List<Customer>();
			var toAddCustomers = new List<Customer>();
			var duplicates = new List<ImportDupliate>();
			var currentCustomers = this.FindBySchoolId(schoolId);
			r.TotalQty = data.Length;
			foreach (var d in data) {
				#region 构建对象
				var ic = new ImportCustomer {
					Address = d.Address,
					CityName = d.CityName,
					Clazz = d.Clazz,
					DistrictName = d.DistrictName,
					Gender = d.Gender,
					ImportKey = key,
					ImportType = "按学校导入",
					InfoSource = infoSourceId,
					IsProcessed = false,
					Level = level,
					MarketYear = marketingYear,
					Mobile = d.Mobile,
					ProvinceName = d.ProvinceName,
					QQ = d.QQ,
					SchoolId = schoolId,
					SchoolName = "",
					Tel = d.TelPrefix + "-" + d.Telephone,
					Name = d.Name
				};
				if (String.IsNullOrEmpty(d.TelPrefix) && String.IsNullOrEmpty(d.Telephone)) {
					ic.Tel = null;
				}
				#endregion
				toImportList.Add(ic);
				#region 读取省、市、区和学校的信息
				var prov = provinces.FirstOrDefault(o => o.Name.Equals(ic.ProvinceName));
				if (prov == null) {
					ic.ErrorMsg = "找不到省份：" + ic.ProvinceName;
					r.ErrorQty++;
					continue;
				}
				ic.ProvinceId = prov.Id;
				var city = cities.FirstOrDefault(o => o.ProvinceId.Equals(ic.ProvinceId) && o.Name.Equals(ic.CityName));
				if (city == null) { 
					ic.ErrorMsg = "在"+ic.ProvinceName+"里找不到"+ic.CityName;
					r.ErrorQty++;
					continue;
				}
				ic.CityId = city.Id;
				var district = districts.FirstOrDefault(o => o.CityId.Equals(ic.CityId) && o.Name.Equals(ic.DistrictName));
				if (district == null) { 
					ic.ErrorMsg = "在" + ic.CityName + "里找不到"+ic.DistrictName;
					r.ErrorQty++;
					continue;
				}
				ic.DistrictId = district.Id;
				ic.SchoolName = schools.First(o => o.Id.Equals(ic.SchoolId)).Name;
				#endregion

				#region 同校有同名且同电话（或手机）的，补全数据
				var customer = currentCustomers.FirstOrDefault(o => o.Name.Equals(ic.Name) && 
					((o.Telephone != null && o.Telephone.Equals(ic.Tel)) || (o.Mobile != null && o.Mobile.Equals(ic.Mobile))));
				if (customer != null) {
					if (String.IsNullOrEmpty(customer.Address)) {
						customer.Address = ic.Address;
					}
					if (String.IsNullOrEmpty(customer.Telephone)) {
						customer.Telephone = ic.Tel;
					}
					if (String.IsNullOrEmpty(customer.Mobile)) {
						customer.Mobile = ic.Mobile;
					}
					if (String.IsNullOrEmpty(customer.QQ)) {
						customer.QQ = ic.QQ;
					}
					toUpdateCustomers.Add(customer);
					ic.IsProcessed = true;
					r.UpdatedQty++;
					continue;
				}
				#endregion
				#region 同样有同名或同电话或同手机的，认定为重复数据
				var dCustomers = currentCustomers.Where(o => o.Name.Equals(ic.Name) 
					//|| (o.Telephone !=null && o.Telephone.Length>0 && ic.Tel!=null && ic.Tel.Length>0 && o.Telephone.Equals(ic.Tel)) 
					//|| (o.Mobile != null && o.Mobile.Length>0 && ic.Mobile !=null && ic.Mobile.Length>0 && o.Mobile.Equals(ic.Mobile))
					).ToList();
				if (dCustomers.Count == 0) {
					#region 无重复
					customer = new Customer {
						Address = ic.Address,
						QQ = ic.QQ,
						Mobile = ic.Mobile,
						Telephone = ic.Tel,
						Name = ic.Name,
						Clazz = ic.Clazz,
						DistrictId = ic.DistrictId,
						EduLevel = level,
						Gender = ic.Gender,
						SmallInfoSourceId = infoSourceId,
						IsImport = true,
						MarketYear = marketingYear,
						SchoolId = schoolId,
						TeleSalesTimes = 0,
						Important = false,
						IsClosed = false,
						IsDinWei = false,
						IsGaoKao = false,
						ConsultType = "未电访",
						IsLeaderFollow = false,
						IsPay=false,
						IsRefund=false,
						IsDropIn=false,
						IsSignUp=false,
						Status = "未上门"
					};
					toAddCustomers.Add(customer);
					ic.IsProcessed = true;
					r.AddedQty++;
					#endregion
					continue;
				} else {
					r.DuplicateQty++;
					#region 有重复
					// 处理重复的数据
					var duplicate = new ImportDupliate {
						ImportCustomer = ic,
						ImportKey = key,
						Mobile = ic.Mobile,
						Name = ic.Name,
						SchoolName = ic.SchoolName,
						Tel = ic.Tel
					};
					duplicates.Add(duplicate);
					dCustomers.ForEach(o => {
						duplicate = new ImportDupliate {
							CustomerId=o.Id,
							ImportKey = key,
							Mobile = o.Mobile,
							Name = o.Name,
							SchoolName = o.School.Name,
							Tel = o.Telephone,
							Score=o.GaoKaoScore
						};
						duplicates.Add(duplicate);
					});
					#endregion
				}
				#endregion
			}

			toImportList.ForEach(o => { this.ImportCustomerRepository.Add(o); });
			toUpdateCustomers.ForEach(o => { this.Repository.Update(o); });
			toAddCustomers.ForEach(o => { this.Repository.Add(o); });
			duplicates.ForEach(o => { this.ImportDupliateRepository.Add(o); });
			this.Db.Save();
			r.Successful = true;
			return r;
		}
		public ImportResult ImportByChannel(string key, string level, int marketingYear, int infoSourceId, string filename) {
			ImportResult r = new ImportResult();

			#region 初始化 Repository
			this.ProvRepository = new ProvinceRepository(this.Db);
			this.CityRepository = new CityRepository(this.Db);
			this.DistrictRepository = new DistrictRepository(this.Db);
			this.SchoolRepository = new SchoolRepository(this.Db);
			this.ImportCustomerRepository = new ImportCustomerRepository(this.Db);
			this.ImportDupliateRepository = new ImportDupliateRepository(this.Db);
			#endregion
			#region 读取初始数据
			var provinces = this.ProvRepository.FindAll();
			var cities = this.CityRepository.FindAll();
			var districts = this.DistrictRepository.FindAll();
			var schools = this.SchoolRepository.FindAll();
			#endregion
			
			ExcelStorage provider = new ExcelStorage(typeof(ChannelData), filename, 2, 1);
			var data = provider.ExtractRecords() as ChannelData[];

			var toImportList = new List<ImportCustomer>();
			var toUpdateCustomers = new List<Customer>();
			var toAddCustomers = new List<Customer>();
			var duplicates = new List<ImportDupliate>();
			//var currentCustomers = this.FindBySchoolId(schoolId);
			r.TotalQty = data.Length;
			foreach (var d in data) {
				#region 构建对象
				var ic = new ImportCustomer {
					ProvinceName = d.ProvinceName,
					CityName = d.CityName,
					DistrictName = d.DistrictName,
					SchoolName = d.SchoolName,
					Name = d.Name,
					Gender = d.Gender,
					Score = String.IsNullOrEmpty(d.Score) ? null : (int?)Int32.Parse(d.Score.Trim()),
					Address = d.Address,
					Postcode = d.Postcode,
					Contact = d.Contact,
					Tel = d.Telephone,
					Mobile = d.Mobile,
					ImportKey = key,
					ImportType = "按渠道导入",
					InfoSource = infoSourceId,
					IsProcessed = false,
					Level = level,
					MarketYear = marketingYear,
					QQ = d.QQ,
					Clazz = d.Clazz
				};
				#endregion
				toImportList.Add(ic);
				#region 读取省、市、区和学校的信息
				var prov = provinces.FirstOrDefault(o => o.Name.Equals(ic.ProvinceName));
				if (prov == null) {
					ic.ErrorMsg = "找不到省份：" + ic.ProvinceName;
					r.ErrorQty++;
					continue;
				}
				ic.ProvinceId = prov.Id;
				var city = cities.FirstOrDefault(o => o.ProvinceId.Equals(ic.ProvinceId) && o.Name.Equals(ic.CityName));
				if (city == null) { 
					ic.ErrorMsg = "在"+ic.ProvinceName+"里找不到"+ic.CityName;
					r.ErrorQty++;
					continue;
				}
				ic.CityId = city.Id;
				var district = districts.FirstOrDefault(o => o.CityId.Equals(ic.CityId) && o.Name.Equals(ic.DistrictName));
				if (district == null) { 
					ic.ErrorMsg = "在" + ic.CityName + "里找不到"+ic.DistrictName;
					r.ErrorQty++;
					continue;
				}
				ic.DistrictId = district.Id;
				var school = schools.FirstOrDefault(o => o.DistrictId.Equals(ic.DistrictId) && o.Name.Equals(d.SchoolName));
				if (school == null) {
					ic.ErrorMsg = "在" + ic.DistrictName + "里找不到" + ic.SchoolName;
					r.ErrorQty++;
					continue;
				}
				ic.SchoolId = school.Id;
				#endregion

				#region 同校有同名且同电话（或手机）的，补全数据
				var customer = this.Repository.FindByName(ic.Name).FirstOrDefault(o => 
					(o.SchoolId.HasValue && o.SchoolId.Value.Equals(ic.SchoolId.Value) ) && 
					((o.Telephone != null && o.Telephone.Equals(ic.Tel)) || (o.Mobile != null && o.Mobile.Equals(ic.Mobile))));
				if (customer != null) {
					if (String.IsNullOrEmpty(customer.Address)) {
						customer.Address = ic.Address;
					}
					if (String.IsNullOrEmpty(customer.Telephone)) {
						customer.Telephone = ic.Tel;
					}
					if (String.IsNullOrEmpty(customer.Mobile)) {
						customer.Mobile = ic.Mobile;
					}
					if (!customer.GaoKaoScore.HasValue) {
						customer.GaoKaoScore = ic.Score;
					}
					toUpdateCustomers.Add(customer);
					ic.IsProcessed = true;
					r.UpdatedQty++;
					continue;
				}
				#endregion
				#region 同样有同名或同电话或同手机的，认定为重复数据
				var dCustomers = this.FindBySchoolId(ic.SchoolId).Where(o => o.Name.Equals(ic.Name) 
					|| (o.Telephone != null && o.Telephone.Length>0 && ic.Tel!=null && ic.Tel.Length>0 && o.Telephone.Equals(ic.Tel)) 
					|| (o.Mobile != null && o.Mobile.Length>0 && ic.Mobile!=null && ic.Mobile.Length>0 && o.Mobile.Equals(ic.Mobile))
					).ToList();
				if (dCustomers.Count == 0) {
					#region 无重复
					customer = new Customer {
						DistrictId = ic.DistrictId,
						SchoolId = ic.SchoolId,
						Name = ic.Name,
						Gender = ic.Gender,
						GaoKaoScore = ic.Score,
						Address = ic.Address,
						Postcode = ic.Postcode,
						Telephone = ic.Tel,
						Mobile = ic.Mobile,
						EduLevel = level,
						SmallInfoSourceId = infoSourceId,
						IsImport = true,
						MarketYear = marketingYear,
						TeleSalesTimes = 0,
						Important = false,
						IsClosed = false,
						IsDinWei = false,
						IsGaoKao = false,
						IsLeaderFollow = false,
						IsPay = false,
						IsRefund = false,
						IsDropIn = false,
						IsSignUp = false,
						Status = "未上门",
						QQ = ic.QQ,
						Clazz = ic.Clazz
					};
					toAddCustomers.Add(customer);
					ic.IsProcessed = true;
					r.AddedQty++;
					#endregion
					continue;
				} else {
				//省	市	区	学校	姓名	性别	总分	地址	邮编	联系人	固定电话	移动电话
					r.DuplicateQty++;
					#region 有重复
					//var dCustomers = this.FindBySchoolId(ic.SchoolId).Where(o => o.Name.Equals(ic.Name) ||
					//(o.Telephone != null && o.Telephone.Equals(ic.Tel)) || (o.Mobile != null && o.Mobile.Equals(ic.Mobile))).ToList();
					// 处理重复的数据
					var duplicate = new ImportDupliate {
						ImportCustomer = ic,
						ImportKey = key,
						Mobile = ic.Mobile,
						Name = ic.Name,
						SchoolName = ic.SchoolName,
						Tel = ic.Tel,
						Score =ic.Score,
						ErrorMsg = String.Empty
					};

					dCustomers.ForEach(o => {
						var em = String.Empty;
						if (duplicate.Name.Equals(o.Name)) {
							em += "姓名重复,";
						}
						if (duplicate.Tel != null && o.Telephone != null && duplicate.Tel.Equals(o.Telephone)) {
							em += "家庭电话重复,";
						}
						if (duplicate.Mobile != null && o.Mobile != null && duplicate.Mobile.Equals(o.Mobile)) {
							em += "手机号码重复,";
						}
						duplicate.ErrorMsg += em;

						var dup = new ImportDupliate {
							CustomerId=o.Id,
							ImportKey = key,
							Mobile = o.Mobile,
							Name = o.Name,
							SchoolName = o.School.Name,
							Tel = o.Telephone,
							Score=o.GaoKaoScore,
							ErrorMsg = em
						};
						duplicates.Add(dup);
					});
					duplicates.Add(duplicate);
					#endregion
				}
				#endregion
			}

			toImportList.ForEach(o => { this.ImportCustomerRepository.Add(o); });
			toUpdateCustomers.ForEach(o => { this.Repository.Update(o); });
			toAddCustomers.ForEach(o => { this.Repository.Add(o); });
			duplicates.ForEach(o => { this.ImportDupliateRepository.Add(o); });
			this.Db.Save();
			r.Successful = true;
			return r;
		}
		public PagedModel<ImportCustomer> GetImportError(ImportCustomerCriteria c) {
			this.ImportCustomerRepository = new ImportCustomerRepository(this.Db);
			PagedModel<ImportCustomer> m = new PagedModel<ImportCustomer>();
			var r = this.ImportCustomerRepository.FindByCriteria(c)
				.Where(o => !o.IsProcessed && !String.IsNullOrEmpty(o.ErrorMsg) && o.ImportKey.Equals(c.ImportKeySrh ));
			r = r.OrderBy(o => o.Id);
			m.RecordCount = r.Count();
			if (c.pagesize.HasValue) {
				int page = c.page ?? 1;
				int pageCount = m.RecordCount / c.pagesize.Value;
				if (m.RecordCount % c.pagesize.Value > 0) {
					pageCount++;
				}
				int skip = (page - 1) * c.pagesize.Value;
				if (skip > 0) {
					r = r.Skip(skip);
				}
				r = r.Take(c.pagesize.Value);
			}

			m.Data = r.ToList();
			return m;
		}
		public PagedModel<ImportDupliate> GetImportDuplicate(ImportDupliateCriteria c) {
			this.ImportDupliateRepository = new ImportDupliateRepository(this.Db);
			PagedModel<ImportDupliate> m = new PagedModel<ImportDupliate>();
			var r = this.ImportDupliateRepository.FindByCriteria(c);
			r = r.OrderBy(o => o.Id);
			m.RecordCount = r.Count();
			if (c.pagesize.HasValue) {
				int page = c.page ?? 1;
				int pageCount = m.RecordCount / c.pagesize.Value;
				if (m.RecordCount % c.pagesize.Value > 0) {
					pageCount++;
				}
				int skip = (page - 1) * c.pagesize.Value;
				if (skip > 0) {
					r = r.Skip(skip);
				}
				r = r.Take(c.pagesize.Value);
			}

			m.Data = r.ToList();
			return m;
		}
		public void ExportDuplicateData(string key) {
			this.ImportDupliateRepository = new ImportDupliateRepository(this.Db);
			var r = this.ImportDupliateRepository.FindByImportKey(key);
			r.ToList();
			var ids = r.Select(o => o.ImportId).ToList();
			var list = this.ImportCustomerRepository.FindByImportKey(key).Where(o => ids.Contains(o.Id)).ToList();
			var dupList = new List<QuestionaryData>();
			//list.ForEach(o => { 
			//    dupList.Add(new QuestionaryData{ Address=o.Address, CityName=o.CityName, Clazz=o.Clazz,
			//         DistrictName=o.DistrictName
			//});
		}
		#endregion

		#region 分配
		public void AssignToTeam(int teamId, List<int> schools) {
			schools.ForEach(s => {
				this.Repository.FindBySchoolId(s).Where(o=>!o.SalesTeamId.HasValue || !o.SalesTeamId.Equals(teamId)).ToList().ForEach(c => {
					c.SalesTeamId = teamId;
					c.SalesmanId = null;
					this.Repository.Update(c);
				});
			});
			this.Db.Save();
		}
		public void ChangeSalesman(int oldSalesman, int newSalesman) {
			ISalesTeamMemberRepository SalesTeamMemberRepository = new SalesTeamMemberRepository(this.Db);
			var salesman = SalesTeamMemberRepository.FindByUserId(newSalesman).FirstOrDefault();
			if (salesman != null) {
				this.Repository.FindBySalesmanId(oldSalesman).ToList().ForEach(c => {
					c.SalesTeamId = salesman.SalesTeamId;
					c.SalesmanId = salesman.UserId;
					this.Repository.Update(c);
				});
				this.Db.Save();
			} else {
				throw new ApplicationException("未找到指定的电访人员！[Id="+newSalesman+"]");
			}
		}
		public CountCustomerBySchoolResult CountBySchool(int schoolId, int teamId) {
			var r = new CountCustomerBySchoolResult();
			r.UnAssignedToMemberQty = this.Repository.FindBySchoolId(schoolId)
				.Where(o => o.SalesTeamId.HasValue && o.SalesTeamId.Equals(teamId) && !o.SalesmanId.HasValue).Count();
			return r;
		}
		public void AssignToSalesman(int schoolId, int salesmanId, int qty) {
			ISalesTeamMemberRepository SalesTeamMemberRepository = new SalesTeamMemberRepository(this.Db);
			var salesman = SalesTeamMemberRepository.FindByUserId(salesmanId).FirstOrDefault();
			if (salesman == null) {
				throw new ApplicationException("未找到指定的电访人员！[Id=" + salesmanId + "]");
			}
			this.Repository.FindBySchoolId(schoolId)
				.Where(o => !o.SalesmanId.HasValue && o.SalesTeamId.HasValue && o.SalesTeamId.Value.Equals(salesman.SalesTeamId))
				.Take(qty).ToList().ForEach(c => {
					c.SalesTeamId = salesman.SalesTeamId;
					c.SalesmanId = salesman.UserId;
					this.Repository.Update(c);
				});
			this.Db.Save();
		}
		public void AssignToSales(int teamId, int memberId, List<int> customers) {
			customers.ForEach(s => {
				var c = this.Repository.FindById(s);
				if (c != null) {
					c.SalesTeamId = teamId;
					c.SalesmanId = memberId;
					this.Repository.Update(c);
				}
			});
			this.Db.Save();
		}

		#endregion

		public PagedModel<Customer> Search(CustomerCriteria c) {
			return this.Repository.Search(c, this.SysContext.CurrentUser.Id);
			#region Old
			//PagedModel<Customer> m = new PagedModel<Customer>();
			////var r = this.Repository.FindAll();
			//var r = this.Repository.FindAll2();

			//#region 权限控制
			//var supervisorService = new SupervisorService(this.SysContext, this.Db);
			//// 首先检查当前用户是否具有“查看所有生源”的特权
			//var isSa = (supervisorService.FindByUserId(this.SysContext.CurrentUser.Id).Count(o => o.Type.Equals("查看所有生源")) > 0);
			//if (!isSa) {
			//    // 没有特权，则读取当前用户担任组长和组员的的招生小组的ID
			//    var teamMemberService = new SalesTeamMemberService(this.SysContext, this.Db);
			//    var leaders = teamMemberService.FindByUserId(this.SysContext.CurrentUser.Id).Where(o => o.IsLeader).Select(o=>o.SalesTeamId).ToList();
			//    var members = teamMemberService.FindByUserId(this.SysContext.CurrentUser.Id).Where(o => !o.IsLeader).Select(o => o.SalesTeamId).ToList();
			//    if (leaders.Count > 0 || members.Count > 0) {
			//        // 过滤掉未分配生源以及其它招生小组的资料
			//        r = r.Where(o => o.SalesTeamId.HasValue 
			//            && (leaders.Contains(o.SalesTeamId.Value)
			//                || (o.SalesmanId.HasValue && o.SalesmanId.Equals(this.SysContext.CurrentUser.Id))
			//            )
			//        );
			//        //u = u.Where(o => o.SalesTeamId.HasValue 
			//        //    && (leaders.Contains(o.SalesTeamId.Value)
			//        //        || (o.SalesmanId.HasValue && o.SalesmanId.Equals(this.SysContext.CurrentUser.Id))
			//        //    )
			//        //);

			//    }
			//}
			//#endregion

			//if (c.SchoolIdSrh.HasValue) { 
			//    r = r.Where(o=>o.SchoolId.HasValue && o.SchoolId.Value.Equals(c.SchoolIdSrh.Value));
			//    //u = u.Where(o=>o.SchoolId.HasValue && o.SchoolId.Value.Equals(c.SchoolIdSrh.Value));
			//}
			//if (!String.IsNullOrEmpty(c.SchoolNameSrh)) {
			//    r = r.Where(o => o.School != null && o.School.Name.Contains(c.SchoolNameSrh));
			//    //u = u.Where(o => o.School != null && o.School.Name.Contains(c.SchoolNameSrh));
			//}
			//if (!String.IsNullOrEmpty(c.ClazzSrh)) {
			//    r = r.Where(o => !String.IsNullOrEmpty(o.Clazz) && o.Clazz.Contains(c.ClazzSrh));
			//}
			//if (!String.IsNullOrEmpty(c.ConsultTypeSrh)) {
			//    r = r.Where(o => !String.IsNullOrEmpty(o.ConsultType) && o.ConsultType.Equals(c.ConsultTypeSrh));
			//}
			//if (c.SalesTeamIdSrh.HasValue) {
			//    r = r.Where(o => o.SalesTeamId.HasValue && o.SalesTeamId.Value.Equals(c.SalesTeamIdSrh.Value));
			//}
			//if (c.SalesmanIdSrh.HasValue) {
			//    r = r.Where(o => o.SalesmanId.HasValue && o.SalesmanId.Value.Equals(c.SalesmanIdSrh.Value));
			//}
			//if (!String.IsNullOrEmpty(c.EduLevelSrh)) {
			//    r = r.Where(o => !String.IsNullOrEmpty(o.EduLevel) && o.EduLevel.Contains(c.EduLevelSrh));
			//}
			//if (!String.IsNullOrEmpty(c.NameSrh)) {
			//    r = r.Where(o => !String.IsNullOrEmpty(o.Name) && o.Name.Contains(c.NameSrh));
			//    //u = u.Where(o => !String.IsNullOrEmpty(o.Name) && o.Name.Contains(c.NameSrh));
			//}
			//if (!String.IsNullOrEmpty(c.TelephoneSrh)) {
			//    r = r.Where(o =>
			//        (!String.IsNullOrEmpty(o.Telephone) && o.Telephone.Contains(c.TelephoneSrh)) ||
			//        (!String.IsNullOrEmpty(o.Mobile) && o.Mobile.Contains(c.TelephoneSrh)) ||
			//        (!String.IsNullOrEmpty(o.Address) && o.Address.Contains(c.TelephoneSrh)) 
			//    );
			//}
			//if (c.ImportantSrh.HasValue && c.ImportantSrh.Value) {
			//    r = r.Where(o => o.Important);
			//}
			//if (!String.IsNullOrEmpty(c.KeywordsSrh)) {
			//    r = r.Where(o => !String.IsNullOrEmpty(o.Keywords) && o.Keywords.Contains(c.KeywordsSrh));
			//}
			//if (c.IsTodaySrh.HasValue && c.IsTodaySrh.Value) {
			//    r = r.Where(o => o.NextTeleSalesTime.HasValue && o.NextTeleSalesTime.Value.Date.Equals(DateTime.Today));
			//}

			//#region 以下条件用于查询咨询状态
			//if (c.IsDropInSrh.HasValue && c.IsDropInSrh.Value) {
			//    r = r.Where(o => o.IsDropIn);
			//    if (c.DropInTimeFromSrh.HasValue) {
			//        r = r.Where(o => o.DropInTime.HasValue && o.DropInTime.Value >= c.DropInTimeFromSrh.Value);
			//    }
			//    if (c.DropInTimeToSrh.HasValue) {
			//        r = r.Where(o => o.DropInTime.HasValue && o.DropInTime.Value <= c.DropInTimeToSrh.Value);
			//    }
			//}
			//if (c.IsDinWeiSrh.HasValue && c.IsDinWeiSrh.Value) {
			//    r = r.Where(o => o.IsDinWei);
			//    if (c.DinWeiTimeFromSrh.HasValue) {
			//        r = r.Where(o => o.DinWeiTime.HasValue && o.DinWeiTime.Value >= c.DinWeiTimeFromSrh.Value);
			//    }
			//    if (c.DinWeiTimeToSrh.HasValue) {
			//        r = r.Where(o => o.DinWeiTime.HasValue && o.DinWeiTime.Value <= c.DinWeiTimeToSrh.Value);
			//    }
			//}
			//if (c.IsSignUpSrh.HasValue && c.IsSignUpSrh.Value) {
			//    r = r.Where(o => o.IsSignUp);
			//    if (c.SignUpTimeFromSrh.HasValue) {
			//        r = r.Where(o => o.SignUpTime.HasValue && o.SignUpTime.Value >= c.SignUpTimeFromSrh.Value);
			//    }
			//    if (c.SignUpTimeToSrh.HasValue) {
			//        r = r.Where(o => o.SignUpTime.HasValue && o.SignUpTime.Value <= c.SignUpTimeToSrh.Value);
			//    }
			//}
			//if (c.IsPaySrh.HasValue && c.IsPaySrh.Value) {
			//    r = r.Where(o => o.IsPay);
			//    if (c.PayTimeFromSrh.HasValue) {
			//        r = r.Where(o => o.PayTime.HasValue && o.PayTime.Value >= c.PayTimeFromSrh.Value);
			//    }
			//    if (c.SignUpTimeToSrh.HasValue) {
			//        r = r.Where(o => o.PayTime.HasValue && o.PayTime.Value <= c.PayTimeToSrh.Value);
			//    }
			//}
			//if (c.IsRefundSrh.HasValue && c.IsRefundSrh.Value) {
			//    r = r.Where(o => o.IsRefund);
			//    if (c.RefundTimeFromSrh.HasValue) {
			//        r = r.Where(o => o.RefundTime.HasValue && o.RefundTime.Value >= c.RefundTimeFromSrh.Value);
			//    }
			//    if (c.SignUpTimeToSrh.HasValue) {
			//        r = r.Where(o => o.RefundTime.HasValue && o.RefundTime.Value <= c.RefundTimeToSrh.Value);
			//    }
			//}

			//#endregion

			//#region 以下条件用于组长跟进
			//if (!String.IsNullOrEmpty(c.SalesmanNameSrh)) {
			//    r = r.Where(o => o.Salesman != null && o.Salesman.Name.Contains(c.SalesmanNameSrh));
			//    //u = u.Where(o => o.Salesman != null && o.Salesman.Name.Contains(c.SalesmanNameSrh));
			//}
			//if (c.IsLeaderFollowSrh.HasValue && c.IsLeaderFollowSrh.Value) {
			//    r = r.Where(o => o.IsLeaderFollow);
			//    //u = u.Where(o => o.IsLeaderFollow);
			//}
			//#endregion

			

			//#region 排序
			//if (String.IsNullOrEmpty(c.sortname)) {
			//    c.sortname = "name";
			//}
			//if (String.IsNullOrEmpty(c.sortorder)) {
			//    c.sortorder = "adc";
			//}
			//if (!String.IsNullOrEmpty(c.sortname)) {
			//    if (c.sortname.ToLower().Equals("id")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Id);
			//        } else {
			//            r = r.OrderByDescending(o => o.Id);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("name")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Name);
			//        } else {
			//            r = r.OrderByDescending(o => o.Name);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("schoolid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.SchoolId);
			//        } else {
			//            r = r.OrderByDescending(o => o.SchoolId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("marketyear")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.MarketYear);
			//        } else {
			//            r = r.OrderByDescending(o => o.MarketYear);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("telephone")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Telephone);
			//        } else {
			//            r = r.OrderByDescending(o => o.Telephone);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("mobile")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Mobile);
			//        } else {
			//            r = r.OrderByDescending(o => o.Mobile);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("gender")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Gender);
			//        } else {
			//            r = r.OrderByDescending(o => o.Gender);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("qq")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.QQ);
			//        } else {
			//            r = r.OrderByDescending(o => o.QQ);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("email")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Email);
			//        } else {
			//            r = r.OrderByDescending(o => o.Email);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("edulevel")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.EduLevel);
			//        } else {
			//            r = r.OrderByDescending(o => o.EduLevel);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("isgaokao")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.IsGaoKao);
			//        } else {
			//            r = r.OrderByDescending(o => o.IsGaoKao);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("gaokaoscore")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.GaoKaoScore);
			//        } else {
			//            r = r.OrderByDescending(o => o.GaoKaoScore);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("gaokaobatch")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.GaoKaoBatch);
			//        } else {
			//            r = r.OrderByDescending(o => o.GaoKaoBatch);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("districtid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.DistrictId);
			//        } else {
			//            r = r.OrderByDescending(o => o.DistrictId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("address")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Address);
			//        } else {
			//            r = r.OrderByDescending(o => o.Address);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("postcode")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Postcode);
			//        } else {
			//            r = r.OrderByDescending(o => o.Postcode);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("smallinfosourceid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.SmallInfoSourceId);
			//        } else {
			//            r = r.OrderByDescending(o => o.SmallInfoSourceId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("consulttype")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.ConsultType);
			//        } else {
			//            r = r.OrderByDescending(o => o.ConsultType);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("remark")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Remark);
			//        } else {
			//            r = r.OrderByDescending(o => o.Remark);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("consultantid1")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.ConsultantId1);
			//        } else {
			//            r = r.OrderByDescending(o => o.ConsultantId1);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("consultantid2")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.ConsultantId2);
			//        } else {
			//            r = r.OrderByDescending(o => o.ConsultantId2);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("netconsultantid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.NetConsultantId);
			//        } else {
			//            r = r.OrderByDescending(o => o.NetConsultantId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("createteacherid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.CreateTeacherId);
			//        } else {
			//            r = r.OrderByDescending(o => o.CreateTeacherId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("consulttime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.ConsultTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.ConsultTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("salesteamid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.SalesTeamId);
			//        } else {
			//            r = r.OrderByDescending(o => o.SalesTeamId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("salesmanid")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.SalesmanId);
			//        } else {
			//            r = r.OrderByDescending(o => o.SalesmanId);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("isimport")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.IsImport);
			//        } else {
			//            r = r.OrderByDescending(o => o.IsImport);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("telesalestimes")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.TeleSalesTimes);
			//        } else {
			//            r = r.OrderByDescending(o => o.TeleSalesTimes);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("nexttelesalestime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.NextTeleSalesTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.NextTeleSalesTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("appointmenttime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.AppointmentTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.AppointmentTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("dropintime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.DropInTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.DropInTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("dinweitime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.DinWeiTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.DinWeiTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("signuptime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.SignUpTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.SignUpTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("isdinwei")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.IsDinWei);
			//        } else {
			//            r = r.OrderByDescending(o => o.IsDinWei);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("isclosed")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.IsClosed);
			//        } else {
			//            r = r.OrderByDescending(o => o.IsClosed);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("lastsalestime")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.LastSalesTime);
			//        } else {
			//            r = r.OrderByDescending(o => o.LastSalesTime);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("important")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Important);
			//        } else {
			//            r = r.OrderByDescending(o => o.Important);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("consultantremark")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.ConsultantRemark);
			//        } else {
			//            r = r.OrderByDescending(o => o.ConsultantRemark);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("keywords")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Keywords);
			//        } else {
			//            r = r.OrderByDescending(o => o.Keywords);
			//        }
			//    }
			//    if (c.sortname.ToLower().Equals("clazz")) {
			//        if (c.sortorder.ToLower().Equals("asc")) {
			//            r = r.OrderBy(o => o.Clazz);
			//        } else {
			//            r = r.OrderByDescending(o => o.Clazz);
			//        }
			//    }

			//}
			//#endregion

			//m.RecordCount = r.OrderBy(o=>o.Name).Count();
			//if (!c.pagesize.HasValue) {
			//    c.pagesize = 20;
			//}
			//if (c.pagesize.HasValue) {
			//    int page = c.page ?? 1;
			//    int pageCount = m.RecordCount / c.pagesize.Value;
			//    if (m.RecordCount % c.pagesize.Value > 0) {
			//        pageCount++;
			//    }
			//    int skip = (page - 1) * c.pagesize.Value;
			//    if (skip > 0) {
			//        r = r.Skip(skip);
			//        //u = u.Skip(skip);
			//    }
			//    r = r.Take(c.pagesize.Value);
			//    //u = u.Take(c.pagesize.Value);
			//}

			//m.Data = r.ToList();
			////m.Data = u.ToList();
			//return m;
			#endregion
		}

		/// <summary>
		/// 上门
		/// </summary>
		/// <param name="id"></param>
		/// <param name="consultant"></param>
		/// <returns></returns>
		public Customer DropIn(int id, int? consultant) {
			var c = this.FindById(id);
			if (consultant.HasValue) {
				c.ConsultantId1 = consultant;
			}
			c.DropInTime = DateTime.Now;
			c.IsDropIn = true;
			c.Status = "已上门";
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}
		/// <summary>
		/// 撤消上门状态
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Customer CancelDropIn(int id) {
			var c = this.FindById(id);
			c.Status = "未上门";
			c.IsDropIn = false;
			c.DropInTime = null;
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}
		public Customer DinWei(int id, int? consultant, int? clazzId, bool? isDorm) {
			var c = this.FindById(id);
			if (consultant.HasValue) {
				c.ConsultantId2 = consultant;
			}
			if (clazzId.HasValue) {
				c.InClazzId = clazzId;
			}
			c.DinWeiTime = DateTime.Now;
			c.IsDinWei = true;
			c.IsDorm = isDorm;
			c.Status = "已定位";
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}
		public Customer CancelDinWei(int id) {
			var c = this.FindById(id);
			c.DinWeiTime = null;
			c.IsDinWei = false;
			c.IsDorm = null;
			c.InClazzId = null;
			if (c.IsDropIn) {
				c.Status = "已上门";
			} else {
				c.Status = "未上门";
			}
			c.ConsultantId2 = null;
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}
		public Customer SignUp(int id, int? consultant, int? clazzId, bool? isDorm) {
			var c = this.FindById(id);
			if (consultant.HasValue) {
				c.ConsultantId2 = consultant;
			}
			if (clazzId.HasValue) {
				c.InClazzId = clazzId;
			}
			c.SignUpTime = DateTime.Now;
			c.IsDorm = isDorm;
			c.IsSignUp = true;
			c.Status = "已报名";
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}
		public Customer CancelSignUp(int id) {
			var c = this.FindById(id);
			c.SignUpTime = null;
			c.IsDorm = null;
			c.InClazzId = null;
			if (c.IsDinWei) {
				c.Status = "已定位";
			}else if (c.IsDropIn) {
				c.Status = "已上门";
			} else {
				c.Status = "未上门";
			}
			c.ConsultantId2 = null;
			this.Update(c);
			return this.FindById(id);
			//var m = this.Repository.Search(new CustomerCriteria { IdSrh = id }, this.SysContext.CurrentUser.Id);
			//return m.Data[0];
		}

		public List<School> FindSchoolsBySalesTeam(int teamId) {
			return this.Repository.FindSchoolsBySalesTeam(teamId).ToList();
		}
		public List<School> FindSchoolsBySalesman(int userId) {
			return this.Repository.FindSchoolsBySalesman(userId).ToList();
		}
		public List<SchoolAssignState> FindSchoolAssignState() {
			return this.Repository.FindSchoolAssignState();
		}

		public PagedModel<Customer> FindDuplicate(CustomerCriteria c) {
			return this.Repository.FindDuplicate(c);
		}

		public List<SchoolAssignState> GetAssignReport(string teamName, string salesmanName) {
			//this.SysContext.CurrentUser
			return this.Repository.GetAssignReport(teamName, salesmanName);
		}

		public List<SalesTeamSummaryReport> GetSalesTeamSummaryReport(DateTime startDate, DateTime endDate) {
			return this.Repository.GetSalesTeamSummaryReport(startDate, endDate);
		}
		public List<SalesTeamSummaryReportBySchool> GetSalesTeamSummaryReportBySchool(DateTime startDate, DateTime endDate) {
			return this.Repository.GetSalesTeamSummaryReportBySchool(startDate, endDate);
		}

		public CustomerAssignSummary GetCustomerAssignSummaryByTeam(string teamName) {
			return this.Repository.GetCustomerAssignSummaryByTeam(teamName);
		}
	}
	
	
	[DelimitedRecord(",")]
	class QuestionaryData {
		//姓名	性别	区号	家庭电话	省	市	区	详细家庭住址	手机号码	QQ	班级
		[FieldTrim(TrimMode.Both)]
		public string Name;
		[FieldTrim(TrimMode.Both)]
		public string Gender;
		[FieldTrim(TrimMode.Both)]
		public string TelPrefix;
		[FieldTrim(TrimMode.Both)]
		public string Telephone;
		[FieldTrim(TrimMode.Both)]
		public string ProvinceName;
		[FieldTrim(TrimMode.Both)]
		public string CityName;
		[FieldTrim(TrimMode.Both)]
		public string DistrictName;
		[FieldTrim(TrimMode.Both)]
		public string Address;
		[FieldTrim(TrimMode.Both)]
		public string Mobile;
		[FieldTrim(TrimMode.Both)]
		public string QQ;
		[FieldTrim(TrimMode.Both)]
		public string Clazz;
		[FieldTrim(TrimMode.Both)]
		public string ErrorMsg;
	}
	[DelimitedRecord(",")]
	class ChannelData {
		//省	市	区	学校	姓名	性别	总分	地址	邮编	联系人	固定电话	移动电话
		[FieldTrim(TrimMode.Both)]
		public string ProvinceName;
		[FieldTrim(TrimMode.Both)]
		public string CityName;
		[FieldTrim(TrimMode.Both)]
		public string DistrictName;
		[FieldTrim(TrimMode.Both)]
		public string SchoolName;
		[FieldTrim(TrimMode.Both)]
		public string Name;
		[FieldTrim(TrimMode.Both)]
		public string Gender;
		[FieldTrim(TrimMode.Both)]
		public string Score;
		[FieldTrim(TrimMode.Both)]
		public string Address;
		[FieldTrim(TrimMode.Both)]
		public string Postcode;
		[FieldTrim(TrimMode.Both)]
		public string Contact;
		[FieldTrim(TrimMode.Both)]
		public string Telephone;
		[FieldTrim(TrimMode.Both)]
		public string Mobile;
		[FieldTrim(TrimMode.Both)]
		public string QQ;
		[FieldTrim(TrimMode.Both)]
		public string Clazz;
	}

	public class ImportResult {
		public bool Successful { get; set; }
		public string ErrorMessage { get; set; }
		public int TotalQty { get; set; }
		public int ErrorQty { get; set; }
		public int AddedQty { get; set; }
		public int UpdatedQty { get; set; }
		public int DuplicateQty { get; set; }
	}

	public class CountCustomerBySchoolResult {
		public int TotalQty { get; set; }
		public int AssignedToTeamQty { get; set; }
		public int AssignedToMemberQty { get; set; }
		public int UnAssignedToTeamQty { get; set; }
		public int UnAssignedToMemberQty { get; set; }
	}
}
