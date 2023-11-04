using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_10_SUB")]
	public class TB_10_SUB
	{
		private int _FlowNo;
		/// <summary>
		/// FlowNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "FlowNo", DbType = "int", Storage = "_FlowNo")]
		public int FlowNo
		{
			get { return _FlowNo; }
			set { _FlowNo = value; }
		}
		private int _ItemNo;
		/// <summary>
		/// ItemNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ItemNo", DbType = "int", Storage = "_ItemNo")]
		public int ItemNo
		{
			get { return _ItemNo; }
			set { _ItemNo = value; }
		}
		private string _GoodsName;
		/// <summary>
		/// GoodsName
		/// </summary>
		[Column(Name = "GoodsName", DbType = "nvarchar(100)", Storage = "_GoodsName", UpdateCheck = UpdateCheck.Never)]
		public string GoodsName
		{
			get { return _GoodsName; }
			set { _GoodsName = value; }
		}
		private int _Amount;
		/// <summary>
		/// Amount
		/// </summary>
		[Column(Name = "Amount", DbType = "int", Storage = "_Amount", UpdateCheck = UpdateCheck.Never)]
		public int Amount
		{
			get { return _Amount; }
			set { _Amount = value; }
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
	}
}