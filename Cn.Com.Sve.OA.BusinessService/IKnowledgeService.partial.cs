using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.RaymanLee.Data;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.BusinessService {
    public partial interface IKnowledgeService {
    	IUnitOfWork Db { get; }
    
    	void Add(Knowledge entity);
    	void Update(Knowledge entity);
    	void Save(Knowledge entity);
    	void Delete(Knowledge entity);
    	void DeleteById(int id);
    	List<Knowledge> FindAll();
    	Knowledge FindById(int id);
    	List<Knowledge> FindBySubject(string subject);
    	List<Knowledge> FindByContent(string content);
    	List<Knowledge> FindByKnowledgeType(string knowledgeType);
    	PagedModel<Knowledge> FindByCriteria(KnowledgeCriteria c);
    }
}
