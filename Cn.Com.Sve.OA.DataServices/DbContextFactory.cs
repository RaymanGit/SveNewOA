using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.Com.Sve.OA.Entities;
namespace Cn.Com.Sve.OA.DataServices {
	public class DbContextFactory {
		public static OaDbContext Create() {
			return new OaDbContext();
		}
	}
}
