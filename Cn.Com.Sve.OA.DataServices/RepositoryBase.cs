using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cn.RaymanLee.Patterns;
using Cn.Com.Sve.OA.Entities;

namespace Cn.Com.Sve.OA.DataServices {
	public abstract class RepositoryBase<T,TKey> : IRepository<T,TKey> where T : class{
		protected OaDbContext DbContext { get; private set; }
		protected RepositoryBase(IUnitOfWork unitOfWork){
			if (unitOfWork == null) {
				throw new ArgumentNullException("unitOfWork");
			}
			if (!(unitOfWork is OaDbContext)) {
				throw new ArgumentException("unitOfWork 不是 OaDbContext 的实例！");
			}
			this.DbContext = unitOfWork as OaDbContext;
		}


		public abstract void Add(T entity);

		public abstract void Update(T entity);

		public abstract void Delete(T entity);

		public abstract void DeleteById(TKey id);

		public abstract IEnumerable<T> FindAll();
		public abstract IEnumerable<T> FindAll2();

		public abstract T FindById(TKey id);
	}
}
