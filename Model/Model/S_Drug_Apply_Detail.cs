using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Drug_Apply_Detail")]
	public class S_Drug_Apply_Detail
	{
		private int _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BillNo", DbType = "int", Storage = "_BillNo")]
		public int BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
		private int _GOODSID;
		/// <summary>
		/// GOODSID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GOODSID", DbType = "int", Storage = "_GOODSID")]
		public int GOODSID
		{
			get { return _GOODSID; }
			set { _GOODSID = value; }
		}
		private double? _Amount;
		/// <summary>
		/// Amount
		/// </summary>
		[Column(Name = "Amount", DbType = "float", Storage = "_Amount", UpdateCheck = UpdateCheck.Never)]
		public double? Amount
		{
			get { return _Amount; }
			set { _Amount = value; }
		}
	}
}