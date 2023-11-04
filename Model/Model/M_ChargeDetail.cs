using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_ChargeDetail")]
	public class M_ChargeDetail
	{
		private Int64 _ChargeID;
		/// <summary>
		/// ChargeID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ChargeID", DbType = "bigint", Storage = "_ChargeID")]
		public Int64 ChargeID
		{
			get { return _ChargeID; }
			set { _ChargeID = value; }
		}
		private int _ChargeItemID;
		/// <summary>
		/// ChargeItemID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ChargeItemID", DbType = "int", Storage = "_ChargeItemID")]
		public int ChargeItemID
		{
			get { return _ChargeItemID; }
			set { _ChargeItemID = value; }
		}
		private double? _Number;
		/// <summary>
		/// Number
		/// </summary>
		[Column(Name = "Number", DbType = "float", Storage = "_Number", UpdateCheck = UpdateCheck.Never)]
		public double? Number
		{
			get { return _Number; }
			set { _Number = value; }
		}
		private double? _Price;
		/// <summary>
		/// Price
		/// </summary>
		[Column(Name = "Price", DbType = "float", Storage = "_Price", UpdateCheck = UpdateCheck.Never)]
		public double? Price
		{
			get { return _Price; }
			set { _Price = value; }
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
		private string _ChargeStyle;
		/// <summary>
		/// ChargeStyle
		/// </summary>
		[Column(Name = "ChargeStyle", DbType = "char(10)", Storage = "_ChargeStyle", UpdateCheck = UpdateCheck.Never)]
		public string ChargeStyle
		{
			get { return _ChargeStyle; }
			set { _ChargeStyle = value; }
		}
	}
}