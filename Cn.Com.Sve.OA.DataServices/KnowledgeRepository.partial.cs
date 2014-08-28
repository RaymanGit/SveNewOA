using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class KnowledgeRepository : IKnowledgeRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public KnowledgeRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Knowledge entity) {
    		this.DbContext.Knowledges.AddObject(entity);
    	}
    
    	public void Update(Knowledge entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.Subject = entity.Subject;
    			e.Content = entity.Content;
    			e.KnowledgeType = entity.KnowledgeType;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Knowledges.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Knowledge entity) {
    		this.DbContext.Knowledges.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Knowledges.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Knowledge> FindAll() {
    		return this.DbContext.Knowledges;
    	}
    	public IEnumerable<Knowledge> FindAll2() {
    		return this.DbContext.Knowledges;
    	}
    
    	public Knowledge FindById(int id) {
    		return this.DbContext.Knowledges.FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Knowledge> FindBySubject(string subject){
    				return this.DbContext.Knowledges.Where(o => o.Subject.Equals(subject));
    			}
    	public IEnumerable<Knowledge> FindByContent(string content){
    				return this.DbContext.Knowledges.Where(o => o.Content.Equals(content));
    			}
    	public IEnumerable<Knowledge> FindByKnowledgeType(string knowledgeType){
    				return this.DbContext.Knowledges.Where(o => o.KnowledgeType.Equals(knowledgeType));
    			}
    	public IEnumerable<Knowledge> FindByCriteria(KnowledgeCriteria c) {
    		return this.DbContext.Knowledges.Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.SubjectSrh) || o.Subject.Contains(c.SubjectSrh))
    			&& (String.IsNullOrEmpty(c.ContentSrh) || o.Content.Contains(c.ContentSrh))
    			&& (String.IsNullOrEmpty(c.KnowledgeTypeSrh) || o.KnowledgeType.Contains(c.KnowledgeTypeSrh))
    
    		);
    	}
    
    }
}
