using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IFunctionRepository  : IRepository<Function,int> {
    	IEnumerable<Function> FindByModuleId(int moduleId);
    	IEnumerable<Function> FindByCode(string code);
    	IEnumerable<Function> FindByName(string name);
    	IEnumerable<Function> FindByIcon(string icon);
    	IEnumerable<Function> FindByUrl(string url);
    	IEnumerable<Function> FindByParentFunctionId(Nullable<int> parentFunctionId);
    	IEnumerable<Function> FindBySeq(Nullable<int> seq);
    	IEnumerable<Function> FindByCriteria(FunctionCriteria c);
    }
}
