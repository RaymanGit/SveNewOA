using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ISmallInfoSourceRepository  : IRepository<SmallInfoSource,int> {
    	IEnumerable<SmallInfoSource> FindByName(string name);
    	IEnumerable<SmallInfoSource> FindByInfoSourceBigId(int infoSourceBigId);
    	IEnumerable<SmallInfoSource> FindByCriteria(SmallInfoSourceCriteria c);
    }
}
