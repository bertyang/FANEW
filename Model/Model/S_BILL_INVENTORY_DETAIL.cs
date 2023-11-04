using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_BILL_INVENTORY_DETAIL")]
	public class S_BILL_INVENTORY_DETAIL
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
		private string _BatchNo;
		/// <summary>
		/// BatchNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BatchNo", DbType = "varchar(20)", Storage = "_BatchNo")]
		public string BatchNo
		{
			get { return _BatchNo; }
			set { _BatchNo = value; }
		}
		private int _StoreHouseID;
		/// <summary>
		/// StoreHouseID
		/// </summary>
		[Column(Name = "StoreHouseID", DbType = "int", Storage = "_StoreHouseID", UpdateCheck = UpdateCheck.Never)]
		public int StoreHouseID
		{
			get { return _StoreHouseID; }
			set { _StoreHouseID = value; }
		}
		private double _BookAmount;
		/// <summary>
		/// BookAmount
		/// </summary>
		[Column(Name = "BookAmount", DbType = "float", Storage = "_BookAmount", UpdateCheck = UpdateCheck.Never)]
		public double BookAmount
		{
			get { return _BookAmount; }
			set { _BookAmount = value; }
		}
		private double _RealAmount;
		/// <summary>
		/// RealAmount
		/// </summary>
		[Column(Name = "RealAmount", DbType = "float", Storage = "_RealAmount", UpdateCheck = UpdateCheck.Never)]
		public double RealAmount
		{
			get { return _RealAmount; }
			set { _RealAmount = value; }
		}
		private double _ProfitLossAmount;
		/// <summary>
		/// ProfitLossAmount
		/// </summary>
		[Column(Name = "ProfitLossAmount", DbType = "float", Storage = "_ProfitLossAmount", UpdateCheck = UpdateCheck.Never)]
		public double ProfitLossAmount
		{
			get { return _ProfitLossAmount; }
			set { _ProfitLossAmount = value; }
		}
		private decimal? _Price;
		/// <summary>
		/// Price
		/// </summary>
		[Column(Name = "Price", DbType = "money", Storage = "_Price", UpdateCheck = UpdateCheck.Never)]
		public decimal? Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
	}
}