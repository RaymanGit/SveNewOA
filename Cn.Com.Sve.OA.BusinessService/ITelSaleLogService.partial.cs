using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface ITelSaleLogService {
    	IUnitOfWork Db { get; }
    
    	void Add(TelSaleLog entity);
    	void Update(TelSaleLog entity);
    	void Save(TelSaleLog entity);
    	void Delete(TelSaleLog entity);
    	void DeleteById(int id);
    	List<TelSaleLog> FindAll();
    	TelSaleLog FindById(int id);
    	List<TelSaleLog> FindByCustomerId(int customerId);
    	List<TelSaleLog> FindByContent(string content);
    	List<TelSaleLog> FindByNextTelTime(Nullable<System.DateTime> nextTelTime);
    	List<TelSaleLog> FindBySalesmanId(int salesmanId);
    	List<TelSaleLog> FindByTelTime(System.DateTime telTime);
    	List<TelSaleLog> FindByIsConvert(bool isConvert);
    	List<TelSaleLog> FindByIsSignUp(bool isSignUp);
    	List<TelSaleLog> FindByConsultType(string consultType);
    	PagedModel<TelSaleLog> FindByCriteria(TelSaleLogCriteria c);
    }
}
