using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IModuleRepository  : IRepository<Module,int> {
    	IEnumerable<Module> FindByCode(string code);
    	IEnumerable<Module> FindByName(string name);
    	IEnumerable<Module> FindByIcon(string icon);
    	IEnumerable<Module> FindByCriteria(ModuleCriteria c);
    }
}
