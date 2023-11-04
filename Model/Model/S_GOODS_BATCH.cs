using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_GOODS_BATCH")]
	public class S_GOODS_BATCH
	{
		private int _GOODID;
		/// <summary>
		/// GOODID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GOODID", DbType = "int", Storage = "_GOODID")]
		public int GOODID
		{
			get { return _GOODID; }
			set { _GOODID = value; }
		}
		private string _BATCHNO;
		/// <summary>
		/// BATCHNO
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BATCHNO", DbType = "varchar(20)", Storage = "_BATCHNO")]
		public string BATCHNO
		{
			get { return _BATCHNO; }
			set { _BATCHNO = value; }
		}
		private DateTime _ManufactureDate;
		/// <summary>
		/// ManufactureDate
		/// </summary>
		[Column(Name = "ManufactureDate", DbType = "datetime", Storage = "_ManufactureDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime ManufactureDate
		{
			get { return _ManufactureDate; }
			set { _ManufactureDate = value; }
		}
		private DateTime _ValidityPeriod;
		/// <summary>
		/// ValidityPeriod
		/// </summary>
		[Column(Name = "ValidityPeriod", DbType = "datetime", Storage = "_ValidityPeriod", UpdateCheck = UpdateCheck.Never)]
		public DateTime ValidityPeriod
		{
			get { return _ValidityPeriod; }
			set { _ValidityPeriod = value; }
		}
		private double _InPrice;
		/// <summary>
		/// InPrice
		/// </summary>
		[Column(Name = "InPrice", DbType = "float", Storage = "_InPrice", UpdateCheck = UpdateCheck.Never)]
		public double InPrice
		{
			get { return _InPrice; }
			set { _InPrice = value; }
		}
		private double _OutPrice;
		/// <summary>
		/// OutPrice
		/// </summary>
		[Column(Name = "OutPrice", DbType = "float", Storage = "_OutPrice", UpdateCheck = UpdateCheck.Never)]
		public double OutPrice
		{
			get { return _OutPrice; }
			set { _OutPrice = value; }
		}
	}
}