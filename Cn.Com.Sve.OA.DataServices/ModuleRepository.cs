using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Cn.RaymanLee.Data;
using Cn.RaymanLee.Utils;

namespace Cn.Com.Sve.OA.DataServices {
	public partial interface IModuleRepository : IRepository<Module, int> {
		List<Module> FindByUserId(int userId);
	}
	public partial class ModuleRepository : IModuleRepository {
		public List<Module> FindByUserId(int userId) {
			List<Module> modules = new List<Module>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" SELECT DISTINCT M.* ");
			sb.Append(" FROM Sys_UserGroupModulePermission GMP ");
			sb.Append(" INNER JOIN Sys_Module M ON GMP.ModuleId = M.Id  ");
			sb.Append(" INNER JOIN Sys_UserInGroup UIP ON GMP.UserGroupId = UIP.UserGroupId ");
			sb.Append(" WHERE UIP.UserId = ").Append(userId);
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					modules.Add(new Module {
						Id = ir["Id"].ToInt(),
						Code = ir["Code"].ToStr(),
						Name = ir["Name"].ToStr(),
						Icon = ir["Icon"].ToStr()
					});
				}
			}
			db = null;
			return modules;
		}

	}
}
