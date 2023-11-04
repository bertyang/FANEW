using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_BILL_OUT_DETAIL")]
	public class S_BILL_OUT_DETAIL
	{
		private string _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BillNo", DbType = "varchar(20)", Storage = "_BillNo")]
		public string BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
		private int _GoodsID;
		/// <summary>
		/// GoodsID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GoodsID", DbType = "int", Storage = "_GoodsID")]
		public int GoodsID
		{
			get { return _GoodsID; }
			set { _GoodsID = value; }
		}
		private int _LocationID;
		/// <summary>
		/// LocationID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "LocationID", DbType = "int", Storage = "_LocationID")]
		public int LocationID
		{
			get { return _LocationID; }
			set { _LocationID = value; }
		}
		private string _BatchNo;
		/// <summary>
		/// BatchNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BatchNo", DbType = "varchar(10)", Storage = "_BatchNo")]
		public string BatchNo
		{
			get { return _BatchNo; }
			set { _BatchNo = value; }
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
		private decimal _Price;
		/// <summary>
		/// Price
		/// </summary>
		[Column(Name = "Price", DbType = "money", Storage = "_Price", UpdateCheck = UpdateCheck.Never)]
		public decimal Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		private double _Amount;
		/// <summary>
		/// Amount
		/// </summary>
		[Column(Name = "Amount", DbType = "float", Storage = "_Amount", UpdateCheck = UpdateCheck.Never)]
		public double Amount
		{
			get { return _Amount; }
			set { _Amount = value; }
		}
	}
}