using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;
using Cn.Com.Sve.OA.Entities.Criteria;


namespace Cn.Com.Sve.OA.DataServices {
    public partial class FunctionRepository : IFunctionRepository {
    	protected OaDbContext DbContext { get; private set; }
    	public FunctionRepository(IUnitOfWork unitOfWork){
    		if (unitOfWork == null) {
    			throw new ArgumentNullException("unitOfWork");
    		}
    		if (!(unitOfWork is OaDbContext)) {
    			throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
    		}
    		this.DbContext = unitOfWork as OaDbContext;
    	}
    
    	public void Add(Function entity) {
    		this.DbContext.Functions.AddObject(entity);
    	}
    
    	public void Update(Function entity) {
    		var e = this.FindById(entity.Id);
    		if (e != null) {
    			e.ModuleId = entity.ModuleId;
    			e.Code = entity.Code;
    			e.Name = entity.Name;
    			e.Icon = entity.Icon;
    			e.Url = entity.Url;
    			e.ParentFunctionId = entity.ParentFunctionId;
    			e.Seq = entity.Seq;
    		}
    		//if (this.FindById(entity.Id) != null) {
    		//	this.DbContext.Functions.Attach(entity);
    		//	this.DbContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
    		//}
    	}
    
    	public void Delete(Function entity) {
    		this.DbContext.Functions.DeleteObject(entity);
    	}
    
    	public void DeleteById(int id) {
    		var obj = this.FindById(id);
    		if (obj != null) {
    			this.DbContext.Functions.DeleteObject(obj);
    		}
    	}
    
    	public IEnumerable<Function> FindAll() {
    		return this.DbContext.Functions.Include("ParentFunction").Include("Module");
    	}
    	public IEnumerable<Function> FindAll2() {
    		return this.DbContext.Functions;
    	}
    
    	public Function FindById(int id) {
    		return this.DbContext.Functions.Include("ParentFunction").Include("Module").FirstOrDefault(o => o.Id.Equals(id));
    	}
    	public IEnumerable<Function> FindByModuleId(int moduleId){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.ModuleId.Equals(moduleId));
    			}
    	public IEnumerable<Function> FindByCode(string code){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.Code.Equals(code));
    			}
    	public IEnumerable<Function> FindByName(string name){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.Name.Equals(name));
    			}
    	public IEnumerable<Function> FindByIcon(string icon){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.Icon.Equals(icon));
    			}
    	public IEnumerable<Function> FindByUrl(string url){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.Url.Equals(url));
    			}
    	public IEnumerable<Function> FindByParentFunctionId(Nullable<int> parentFunctionId){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.ParentFunctionId.Value.Equals(parentFunctionId.Value));
    			}
    	public IEnumerable<Function> FindBySeq(Nullable<int> seq){
    				return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => o.Seq.Value.Equals(seq.Value));
    			}
    	public IEnumerable<Function> FindByCriteria(FunctionCriteria c) {
    		return this.DbContext.Functions.Include("ParentFunction").Include("Module").Where(o => 
    			(!c.IdSrh.HasValue || o.Id.Equals(c.IdSrh.Value))
    			&& (!c.IdFromSrh.HasValue || o.Id >= c.IdFromSrh.Value)
    			&& (!c.IdToSrh.HasValue || o.Id <= c.IdToSrh.Value)
    			&& (!c.ModuleIdSrh.HasValue || o.ModuleId.Equals(c.ModuleIdSrh.Value))
    			&& (!c.ModuleIdFromSrh.HasValue || o.ModuleId >= c.ModuleIdFromSrh.Value)
    			&& (!c.ModuleIdToSrh.HasValue || o.ModuleId <= c.ModuleIdToSrh.Value)
    			&& (String.IsNullOrEmpty(c.CodeSrh) || o.Code.Contains(c.CodeSrh))
    			&& (String.IsNullOrEmpty(c.NameSrh) || o.Name.Contains(c.NameSrh))
    			&& (String.IsNullOrEmpty(c.IconSrh) || o.Icon.Contains(c.IconSrh))
    			&& (String.IsNullOrEmpty(c.UrlSrh) || o.Url.Contains(c.UrlSrh))
    			&& (!c.ParentFunctionIdSrh.HasValue || (o.ParentFunctionId.HasValue 			&& o.ParentFunctionId.Value.Equals(c.ParentFunctionIdSrh.Value)))
    			&& (!c.ParentFunctionIdFromSrh.HasValue || (o.ParentFunctionId.HasValue 			&& o.ParentFunctionId.Value >= c.ParentFunctionIdFromSrh.Value))
    			&& (!c.ParentFunctionIdToSrh.HasValue || (o.ParentFunctionId.HasValue 			&& o.ParentFunctionId.Value <= c.ParentFunctionIdToSrh.Value))
    			&& (!c.SeqSrh.HasValue || (o.Seq.HasValue 			&& o.Seq.Value.Equals(c.SeqSrh.Value)))
    			&& (!c.SeqFromSrh.HasValue || (o.Seq.HasValue 			&& o.Seq.Value >= c.SeqFromSrh.Value))
    			&& (!c.SeqToSrh.HasValue || (o.Seq.HasValue 			&& o.Seq.Value <= c.SeqToSrh.Value))
    
    		);
    	}
    
    }
}
