using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cn.Com.Sve.OA.Entities.Criteria;
namespace Cn.Com.Sve.OA.Web.Models.ViewModels {
	public class Student_Search_ViewModel {
		public StudentCriteria Criteria { get; set; }
		public List<Class> Clazz { get; set; }
		//报读学校统计
		public List<KeyValuePair<string, int>> SchoolSummary { get; set; }
		//户口类型统计
		public List<KeyValuePair<string, int>> HuKouSummary { get; set; }
		//居住区域统计
		public List<KeyValuePair<string, int>> DistrictSummary { get; set; }


		public Student_Search_ViewModel() {
			this.Criteria = new StudentCriteria();
			this.Clazz = new List<Class>();
			this.SchoolSummary = new List<KeyValuePair<string, int>>();
			this.HuKouSummary = new List<KeyValuePair<string, int>>();
			this.DistrictSummary = new List<KeyValuePair<string, int>>();
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