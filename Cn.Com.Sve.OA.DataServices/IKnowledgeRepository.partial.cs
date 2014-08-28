using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;

namespace Cn.Com.Sve.OA.DataServices {
    public partial interface IKnowledgeRepository  : IRepository<Knowledge,int> {
    	IEnumerable<Knowledge> FindBySubject(string subject);
    	IEnumerable<Knowledge> FindByContent(string content);
    	IEnumerable<Knowledge> FindByKnowledgeType(string knowledgeType);
    	IEnumerable<Knowledge> FindByCriteria(KnowledgeCriteria c);
    }
}
