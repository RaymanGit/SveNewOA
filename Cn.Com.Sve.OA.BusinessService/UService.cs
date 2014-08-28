using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.DataServices;

namespace Cn.Com.Sve.OA.BusinessService {
	public class UService {
		protected IUnitOfWork Db { get; private set; }
		protected IUserRepository Repository { get; private set; }
		public UService() {
			this.Db = DbContextFactory.Create();
			this.Repository = new UserRepository(this.Db);
		}


	}
}
