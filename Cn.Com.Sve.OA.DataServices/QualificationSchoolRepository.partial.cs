using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class QualificationSchoolRepository : IQualificationSchoolRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public QualificationSchoolRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(QualificationSchool entity) {
    		this.DbContext.QualificationSchools.AddObject(entity);
    	}
    
    	public void Update(QualificationSchool entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Name = entity.Name;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.QualificationSchools.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(QualificationSchool entity) {
    		this.DbContext.QualificationSchools.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.QualificationSchools.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<QualificationSchool> FindAll() {
    		return this.DbContext.QualificationSchools;
    	}
    	public IEnumerable<QualificationSchool> FindAll2() {
    		return this.DbContext.QualificationSchools;
    	}
    
    	public QualificationSchool FindById(int id) {
    		return this.DbContext.QualificationSchools.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<QualificationSchool> FindByName(string name){
    				return this.DbContext.QualificationSchools.Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<QualificationSchool> FindByCriteria(QualificationSchoolCriteria c) {
    		return this.DbContext.QualificationSchools.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    
    		);
    	}
    
    }
}
