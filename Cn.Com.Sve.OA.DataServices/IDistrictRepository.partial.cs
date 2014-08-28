using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IDistrictRepository  : IRepository<District,int> {
    	IEnumerable<District> FindByName(string name);
    	IEnumerable<District> FindByCityId(int cityId);
    	IEnumerable<District> FindByPhonePrefix(string phonePrefix);
    	IEnumerable<District> FindByPostcode(string postcode);
    	IEnumerable<District> FindByCriteria(DistrictCriteria c);
    }
}
