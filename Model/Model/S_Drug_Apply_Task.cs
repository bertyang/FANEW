using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Drug_Apply_Task")]
	public class S_Drug_Apply_Task
	{
		private string _TaskCode;
		/// <summary>
		/// TaskCode
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TaskCode", DbType = "char(20)", Storage = "_TaskCode")]
		public string TaskCode
		{
			get { return _TaskCode; }
			set { _TaskCode = value; }
		}
		private int _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(Name = "BillNo", DbType = "int", Storage = "_BillNo", UpdateCheck = UpdateCheck.Never)]
		public int BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
	}
}