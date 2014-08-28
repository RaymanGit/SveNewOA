using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;

namespace Cn.Com.Sve.OA.Entities {
	public partial class OaDbContext : IUnitOfWork {
		public void Save() {
			this.SaveChanges();
		}
	}
}
