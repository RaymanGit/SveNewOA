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
	public partial interface IModuleService {
		List<Module> FindByUserId(int userId);
	}
	public partial class ModuleService : IModuleService {
		public List<Module> FindByUserId(int userId) {
			return this.Repository.FindByUserId(userId);
		}
	}
}
