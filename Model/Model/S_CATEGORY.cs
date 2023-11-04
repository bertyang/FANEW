using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_CATEGORY")]
	public class S_CATEGORY
	{
		private int _ID;
		/// <summary>
		/// ID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ID", DbType = "int", Storage = "_ID")]
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "nvarchar(200)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private int _ParentID;
		/// <summary>
		/// ParentID
		/// </summary>
		[Column(Name = "ParentID", DbType = "int", Storage = "_ParentID", UpdateCheck = UpdateCheck.Never)]
		public int ParentID
		{
			get { return _ParentID; }
			set { _ParentID = value; }
		}
		private double _ProfitRatio;
		/// <summary>
		/// ProfitRatio
		/// </summary>
		[Column(Name = "ProfitRatio", DbType = "float", Storage = "_ProfitRatio", UpdateCheck = UpdateCheck.Never)]
		public double ProfitRatio
		{
			get { return _ProfitRatio; }
			set { _ProfitRatio = value; }
		}
	}
}