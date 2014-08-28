using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface ITelSaleLogRepository  : IRepository<TelSaleLog,int> {
    	IEnumerable<TelSaleLog> FindByCustomerId(int customerId);
    	IEnumerable<TelSaleLog> FindByContent(string content);
    	IEnumerable<TelSaleLog> FindByNextTelTime(Nullable<System.DateTime> nextTelTime);
    	IEnumerable<TelSaleLog> FindBySalesmanId(int salesmanId);
    	IEnumerable<TelSaleLog> FindByTelTime(System.DateTime telTime);
    	IEnumerable<TelSaleLog> FindByIsConvert(bool isConvert);
    	IEnumerable<TelSaleLog> FindByIsSignUp(bool isSignUp);
    	IEnumerable<TelSaleLog> FindByConsultType(string consultType);
    	IEnumerable<TelSaleLog> FindByCriteria(TelSaleLogCriteria c);
    }
}
