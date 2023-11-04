using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_ChargeItem")]
	public class M_ChargeItem
	{
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
		private string _ItemName;
		/// <summary>
		/// ItemName
		/// </summary>
		[Column(Name = "ItemName", DbType = "varchar(20)", Storage = "_ItemName", UpdateCheck = UpdateCheck.Never)]
		public string ItemName
		{
			get { return _ItemName; }
			set { _ItemName = value; }
		}
		private string _Unit;
		/// <summary>
		/// Unit
		/// </summary>
		[Column(Name = "Unit", DbType = "varchar(20)", Storage = "_Unit", UpdateCheck = UpdateCheck.Never)]
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
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
		private string _Belong;
		/// <summary>
		/// Belong
		/// </summary>
		[Column(Name = "Belong", DbType = "varchar(50)", Storage = "_Belong", UpdateCheck = UpdateCheck.Never)]
		public string Belong
		{
			get { return _Belong; }
			set { _Belong = value; }
		}
		private int? _TROrder;
		/// <summary>
		/// TROrder
		/// </summary>
		[Column(Name = "TROrder", DbType = "int", Storage = "_TROrder", UpdateCheck = UpdateCheck.Never)]
		public int? TROrder
		{
			get { return _TROrder; }
			set { _TROrder = value; }
		}
		private int? _ParentItemID;
		/// <summary>
		/// ParentItemID
		/// </summary>
		[Column(Name = "ParentItemID", DbType = "int", Storage = "_ParentItemID", UpdateCheck = UpdateCheck.Never)]
		public int? ParentItemID
		{
			get { return _ParentItemID; }
			set { _ParentItemID = value; }
		}
		private string _ChargeType;
		/// <summary>
		/// ChargeType
		/// </summary>
		[Column(Name = "ChargeType", DbType = "char(2)", Storage = "_ChargeType", UpdateCheck = UpdateCheck.Never)]
		public string ChargeType
		{
			get { return _ChargeType; }
			set { _ChargeType = value; }
		}
		private string _InterfaceName;
		/// <summary>
		/// InterfaceName
		/// </summary>
		[Column(Name = "InterfaceName", DbType = "varchar(20)", Storage = "_InterfaceName", UpdateCheck = UpdateCheck.Never)]
		public string InterfaceName
		{
			get { return _InterfaceName; }
			set { _InterfaceName = value; }
		}
	}
}