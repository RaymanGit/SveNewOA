using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ICityRepository  : IRepository<City,int> {
    	IEnumerable<City> FindByName(string name);
    	IEnumerable<City> FindByProvinceId(int provinceId);
    	IEnumerable<City> FindByCriteria(CityCriteria c);
    }
}
