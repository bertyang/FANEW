using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_StoreHouseType_Goods_UD")]
	public class S_StoreHouseType_Goods_UD
	{
		private int _StorehouseType;
		/// <summary>
		/// StorehouseType
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "StorehouseType", DbType = "int", Storage = "_StorehouseType")]
		public int StorehouseType
		{
			get { return _StorehouseType; }
			set { _StorehouseType = value; }
		}
		private int _GoodID;
		/// <summary>
		/// GoodID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GoodID", DbType = "int", Storage = "_GoodID")]
		public int GoodID
		{
			get { return _GoodID; }
			set { _GoodID = value; }
		}
		private double? _UpAmount;
		/// <summary>
		/// UpAmount
		/// </summary>
		[Column(Name = "UpAmount", DbType = "float", Storage = "_UpAmount", UpdateCheck = UpdateCheck.Never)]
		public double? UpAmount
		{
			get { return _UpAmount; }
			set { _UpAmount = value; }
		}
		private double? _DownAmount;
		/// <summary>
		/// DownAmount
		/// </summary>
		[Column(Name = "DownAmount", DbType = "float", Storage = "_DownAmount", UpdateCheck = UpdateCheck.Never)]
		public double? DownAmount
		{
			get { return _DownAmount; }
			set { _DownAmount = value; }
		}
	}
}