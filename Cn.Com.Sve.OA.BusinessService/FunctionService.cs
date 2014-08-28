using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;
using Cn.Com.Sve.OA.Entities.Criteria;
namespace Cn.Com.Sve.OA.BusinessService {
	public partial interface IFunctionService {
		List<Function> FindByUserId(int userId, int moduleId);
	}
	public partial class FunctionService : IFunctionService {
		public List<Function> FindByUserId(int userId, int moduleId) {
			return this.Repository.FindByUserId(userId, moduleId);
		}
	}
}
