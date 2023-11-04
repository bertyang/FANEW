using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_MeasureGroup")]
	public class M_MeasureGroup
	{
		private string _GroupID;
		/// <summary>
		/// GroupID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GroupID", DbType = "varchar(10)", Storage = "_GroupID")]
		public string GroupID
		{
			get { return _GroupID; }
			set { _GroupID = value; }
		}
		private string _ParentID;
		/// <summary>
		/// ParentID
		/// </summary>
		[Column(Name = "ParentID", DbType = "varchar(10)", Storage = "_ParentID", UpdateCheck = UpdateCheck.Never)]
		public string ParentID
		{
			get { return _ParentID; }
			set { _ParentID = value; }
		}
		private string _GroupLable;
		/// <summary>
		/// GroupLable
		/// </summary>
		[Column(Name = "GroupLable", DbType = "varchar(20)", Storage = "_GroupLable", UpdateCheck = UpdateCheck.Never)]
		public string GroupLable
		{
			get { return _GroupLable; }
			set { _GroupLable = value; }
		}
		private bool? _IsTrue;
		/// <summary>
		/// IsTrue
		/// </summary>
		[Column(Name = "IsTrue", DbType = "bit", Storage = "_IsTrue", UpdateCheck = UpdateCheck.Never)]
		public bool? IsTrue
		{
			get { return _IsTrue; }
			set { _IsTrue = value; }
		}
	}
}