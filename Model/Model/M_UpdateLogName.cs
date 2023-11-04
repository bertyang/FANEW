using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_UpdateLogName")]
	public class M_UpdateLogName
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
		private string _ModifyItem;
		/// <summary>
		/// ModifyItem
		/// </summary>
		[Column(Name = "ModifyItem", DbType = "varchar(50)", Storage = "_ModifyItem", UpdateCheck = UpdateCheck.Never)]
		public string ModifyItem
		{
			get { return _ModifyItem; }
			set { _ModifyItem = value; }
		}
		private string _ItemName;
		/// <summary>
		/// ItemName
		/// </summary>
		[Column(Name = "ItemName", DbType = "varchar(50)", Storage = "_ItemName", UpdateCheck = UpdateCheck.Never)]
		public string ItemName
		{
			get { return _ItemName; }
			set { _ItemName = value; }
		}
		private string _ParentName;
		/// <summary>
		/// ParentName
		/// </summary>
		[Column(Name = "ParentName", DbType = "varchar(50)", Storage = "_ParentName", UpdateCheck = UpdateCheck.Never)]
		public string ParentName
		{
			get { return _ParentName; }
			set { _ParentName = value; }
		}
	}
}