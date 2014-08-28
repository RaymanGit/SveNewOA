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
	public partial interface IFunctionRepository : IRepository<Function, int> {
		List<Function> FindByUserId(int userId, int moduleId);
	}
	public partial class FunctionRepository : IFunctionRepository {
		public List<Function> FindByUserId(int userId, int moduleId) {
			List<Function> functions = new List<Function>();
			StringBuilder sb = new StringBuilder();
			var db = DatabaseFactory.CreateDatabase();
			sb.Append(" SELECT DISTINCT F.* ");
			sb.Append(" FROM Sys_UserGroupFunctionPermission GFP ");
			sb.Append(" INNER JOIN Sys_Function F ON GFP.FunctionId=F.Id ");
			sb.Append(" INNER JOIN Sys_UserInGroup UIG ON GFP.UserGroupId = UIG.UserGroupId ");
			sb.Append(" WHERE UIG.UserId = ").Append(userId).Append(" AND ModuleId = ").Append(moduleId);
			sb.Append(" ORDER BY Seq ");
			var sql = sb.ToString();
			using (var ir = db.ExecuteReader(CommandType.Text, sql)) {
				while (ir.Read()) {
					functions.Add(new Function {
						Id = ir["Id"].ToInt(),
						Code = ir["Code"].ToStr(),
						Name = ir["Name"].ToStr(),
						Icon = ir["Icon"].ToStr(),
						ModuleId = ir["ModuleId"].ToInt(),
						ParentFunctionId = ir["ParentFunctionId"].ToNullableInt(),
						Seq = ir["Seq"].ToNullableInt(),
						Url = ir["Url"].ToStr()
					});
				}
			}
			db = null;
			return functions;
		}
	}
}
