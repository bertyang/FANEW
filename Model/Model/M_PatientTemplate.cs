using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientTemplate")]
	public class M_PatientTemplate
	{
		private string _ProjectID;
		/// <summary>
		/// ProjectID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ProjectID", DbType = "varchar(10)", Storage = "_ProjectID")]
		public string ProjectID
		{
			get { return _ProjectID; }
			set { _ProjectID = value; }
		}
		private int _TemplateID;
		/// <summary>
		/// TemplateID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TemplateID", DbType = "int", Storage = "_TemplateID")]
		public int TemplateID
		{
			get { return _TemplateID; }
			set { _TemplateID = value; }
		}
	}
}