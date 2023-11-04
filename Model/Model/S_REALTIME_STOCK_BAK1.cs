using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_REALTIME_STOCK_BAK1")]
	public class S_REALTIME_STOCK_BAK1
	{
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
		private int _LocationID;
		/// <summary>
		/// LocationID
		/// </summary>
		[Column(Name = "LocationID", DbType = "int", Storage = "_LocationID", UpdateCheck = UpdateCheck.Never)]
		public int LocationID
		{
			get { return _LocationID; }
			set { _LocationID = value; }
		}
		private int _GoodsID;
		/// <summary>
		/// GoodsID
		/// </summary>
		[Column(Name = "GoodsID", DbType = "int", Storage = "_GoodsID", UpdateCheck = UpdateCheck.Never)]
		public int GoodsID
		{
			get { return _GoodsID; }
			set { _GoodsID = value; }
		}
		private string _BatchNo;
		/// <summary>
		/// BatchNo
		/// </summary>
		[Column(Name = "BatchNo", DbType = "varchar(20)", Storage = "_BatchNo", UpdateCheck = UpdateCheck.Never)]
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
		private decimal _AveragePrice;
		/// <summary>
		/// AveragePrice
		/// </summary>
		[Column(Name = "AveragePrice", DbType = "money", Storage = "_AveragePrice", UpdateCheck = UpdateCheck.Never)]
		public decimal AveragePrice
		{
			get { return _AveragePrice; }
			set { _AveragePrice = value; }
		}
		private double _CurrentAmount;
		/// <summary>
		/// CurrentAmount
		/// </summary>
		[Column(Name = "CurrentAmount", DbType = "float", Storage = "_CurrentAmount", UpdateCheck = UpdateCheck.Never)]
		public double CurrentAmount
		{
			get { return _CurrentAmount; }
			set { _CurrentAmount = value; }
		}
		private double _BeginAmount;
		/// <summary>
		/// BeginAmount
		/// </summary>
		[Column(Name = "BeginAmount", DbType = "float", Storage = "_BeginAmount", UpdateCheck = UpdateCheck.Never)]
		public double BeginAmount
		{
			get { return _BeginAmount; }
			set { _BeginAmount = value; }
		}
		private double _OutAmount;
		/// <summary>
		/// OutAmount
		/// </summary>
		[Column(Name = "OutAmount", DbType = "float", Storage = "_OutAmount", UpdateCheck = UpdateCheck.Never)]
		public double OutAmount
		{
			get { return _OutAmount; }
			set { _OutAmount = value; }
		}
		private double _InAmount;
		/// <summary>
		/// InAmount
		/// </summary>
		[Column(Name = "InAmount", DbType = "float", Storage = "_InAmount", UpdateCheck = UpdateCheck.Never)]
		public double InAmount
		{
			get { return _InAmount; }
			set { _InAmount = value; }
		}
		private decimal _MoneyAmount;
		/// <summary>
		/// MoneyAmount
		/// </summary>
		[Column(Name = "MoneyAmount", DbType = "money", Storage = "_MoneyAmount", UpdateCheck = UpdateCheck.Never)]
		public decimal MoneyAmount
		{
			get { return _MoneyAmount; }
			set { _MoneyAmount = value; }
		}
		private string _InventoryBillNo;
		/// <summary>
		/// InventoryBillNo
		/// </summary>
		[Column(Name = "InventoryBillNo", DbType = "varchar(20)", Storage = "_InventoryBillNo", UpdateCheck = UpdateCheck.Never)]
		public string InventoryBillNo
		{
			get { return _InventoryBillNo; }
			set { _InventoryBillNo = value; }
		}
		private double _LockAmount;
		/// <summary>
		/// LockAmount
		/// </summary>
		[Column(Name = "LockAmount", DbType = "float", Storage = "_LockAmount", UpdateCheck = UpdateCheck.Never)]
		public double LockAmount
		{
			get { return _LockAmount; }
			set { _LockAmount = value; }
		}
		private decimal _BeginMoneyAmount;
		/// <summary>
		/// BeginMoneyAmount
		/// </summary>
		[Column(Name = "BeginMoneyAmount", DbType = "money", Storage = "_BeginMoneyAmount", UpdateCheck = UpdateCheck.Never)]
		public decimal BeginMoneyAmount
		{
			get { return _BeginMoneyAmount; }
			set { _BeginMoneyAmount = value; }
		}
		private DateTime _BackupTime;
		/// <summary>
		/// BackupTime
		/// </summary>
		[Column(Name = "BackupTime", DbType = "datetime", Storage = "_BackupTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime BackupTime
		{
			get { return _BackupTime; }
			set { _BackupTime = value; }
		}
	}
}