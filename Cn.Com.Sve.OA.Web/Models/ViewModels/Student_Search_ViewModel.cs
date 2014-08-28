using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities.Criteria;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class Student_Search_ViewModel {
		public StudentCriteria Criteria { get; set; }
		public List<Class> Clazz { get; set; }
		public Student_Search_ViewModel() {
			this.Criteria = new StudentCriteria();
			this.Clazz = new List<Class>();
		}
		public class Class {
			public string ClazzName { get; set; }
			public List<Student> Students { get; set; }
			public Class() { 
				this.Students = new List<Student>();
			}
		}
		public class Student {
			public int Id { get; set; }
			public string Name { get; set; }
			public string StudentNo { get; set; }
		}
	}
}