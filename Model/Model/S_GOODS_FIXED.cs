using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_GOODS_FIXED")]
	public class S_GOODS_FIXED
	{
		private int _ID;
		/// <summary>
		/// ID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ID", DbType = "int", Storage = "_ID")]
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "nvarchar(200)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Spec;
		/// <summary>
		/// Spec
		/// </summary>
		[Column(Name = "Spec", DbType = "nvarchar(100)", Storage = "_Spec", UpdateCheck = UpdateCheck.Never)]
		public string Spec
		{
			get { return _Spec; }
			set { _Spec = value; }
		}
		private string _Type;
		/// <summary>
		/// Type
		/// </summary>
		[Column(Name = "Type", DbType = "nvarchar(100)", Storage = "_Type", UpdateCheck = UpdateCheck.Never)]
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		private string _Unit;
		/// <summary>
		/// Unit
		/// </summary>
		[Column(Name = "Unit", DbType = "nvarchar(20)", Storage = "_Unit", UpdateCheck = UpdateCheck.Never)]
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
		}
		private string _AssetCode;
		/// <summary>
		/// AssetCode
		/// </summary>
		[Column(Name = "AssetCode", DbType = "nvarchar(40)", Storage = "_AssetCode", UpdateCheck = UpdateCheck.Never)]
		public string AssetCode
		{
			get { return _AssetCode; }
			set { _AssetCode = value; }
		}
		private string _EquipmentNo;
		/// <summary>
		/// EquipmentNo
		/// </summary>
		[Column(Name = "EquipmentNo", DbType = "nvarchar(200)", Storage = "_EquipmentNo", UpdateCheck = UpdateCheck.Never)]
		public string EquipmentNo
		{
			get { return _EquipmentNo; }
			set { _EquipmentNo = value; }
		}
		private int? _ManufacturerID;
		/// <summary>
		/// ManufacturerID
		/// </summary>
		[Column(Name = "ManufacturerID", DbType = "int", Storage = "_ManufacturerID", UpdateCheck = UpdateCheck.Never)]
		public int? ManufacturerID
		{
			get { return _ManufacturerID; }
			set { _ManufacturerID = value; }
		}
		private int? _SupplierID;
		/// <summary>
		/// SupplierID
		/// </summary>
		[Column(Name = "SupplierID", DbType = "int", Storage = "_SupplierID", UpdateCheck = UpdateCheck.Never)]
		public int? SupplierID
		{
			get { return _SupplierID; }
			set { _SupplierID = value; }
		}
		private string _Abbreviation;
		/// <summary>
		/// Abbreviation
		/// </summary>
		[Column(Name = "Abbreviation", DbType = "varchar(20)", Storage = "_Abbreviation", UpdateCheck = UpdateCheck.Never)]
		public string Abbreviation
		{
			get { return _Abbreviation; }
			set { _Abbreviation = value; }
		}
		private string _Pic;
		/// <summary>
		/// Pic
		/// </summary>
		[Column(Name = "Pic", DbType = "varchar(200)", Storage = "_Pic", UpdateCheck = UpdateCheck.Never)]
		public string Pic
		{
			get { return _Pic; }
			set { _Pic = value; }
		}
		private int? _UseOrgID;
		/// <summary>
		/// UseOrgID
		/// </summary>
		[Column(Name = "UseOrgID", DbType = "int", Storage = "_UseOrgID", UpdateCheck = UpdateCheck.Never)]
		public int? UseOrgID
		{
			get { return _UseOrgID; }
			set { _UseOrgID = value; }
		}
		private int? _ManagerID;
		/// <summary>
		/// ManagerID
		/// </summary>
		[Column(Name = "ManagerID", DbType = "int", Storage = "_ManagerID", UpdateCheck = UpdateCheck.Never)]
		public int? ManagerID
		{
			get { return _ManagerID; }
			set { _ManagerID = value; }
		}
		private int? _UserID;
		/// <summary>
		/// UserID
		/// </summary>
		[Column(Name = "UserID", DbType = "int", Storage = "_UserID", UpdateCheck = UpdateCheck.Never)]
		public int? UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}
		private string _Status;
		/// <summary>
		/// Status
		/// </summary>
		[Column(Name = "Status", DbType = "nvarchar(100)", Storage = "_Status", UpdateCheck = UpdateCheck.Never)]
		public string Status
		{
			get { return _Status; }
			set { _Status = value; }
		}
		private string _Purpose;
		/// <summary>
		/// Purpose
		/// </summary>
		[Column(Name = "Purpose", DbType = "nvarchar(100)", Storage = "_Purpose", UpdateCheck = UpdateCheck.Never)]
		public string Purpose
		{
			get { return _Purpose; }
			set { _Purpose = value; }
		}
		private string _Location;
		/// <summary>
		/// Location
		/// </summary>
		[Column(Name = "Location", DbType = "nvarchar(200)", Storage = "_Location", UpdateCheck = UpdateCheck.Never)]
		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}
		private string _AddMode;
		/// <summary>
		/// AddMode
		/// </summary>
		[Column(Name = "AddMode", DbType = "nvarchar(100)", Storage = "_AddMode", UpdateCheck = UpdateCheck.Never)]
		public string AddMode
		{
			get { return _AddMode; }
			set { _AddMode = value; }
		}
		private string _Remark;
		/// <summary>
		/// Remark
		/// </summary>
		[Column(Name = "Remark", DbType = "nvarchar(510)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private double? _OriginalValue;
		/// <summary>
		/// OriginalValue
		/// </summary>
		[Column(Name = "OriginalValue", DbType = "float", Storage = "_OriginalValue", UpdateCheck = UpdateCheck.Never)]
		public double? OriginalValue
		{
			get { return _OriginalValue; }
			set { _OriginalValue = value; }
		}
		private double? _ResidualValue;
		/// <summary>
		/// ResidualValue
		/// </summary>
		[Column(Name = "ResidualValue", DbType = "float", Storage = "_ResidualValue", UpdateCheck = UpdateCheck.Never)]
		public double? ResidualValue
		{
			get { return _ResidualValue; }
			set { _ResidualValue = value; }
		}
		private double? _ResidualValueRate;
		/// <summary>
		/// ResidualValueRate
		/// </summary>
		[Column(Name = "ResidualValueRate", DbType = "float", Storage = "_ResidualValueRate", UpdateCheck = UpdateCheck.Never)]
		public double? ResidualValueRate
		{
			get { return _ResidualValueRate; }
			set { _ResidualValueRate = value; }
		}
		private int? _DepreciationYear;
		/// <summary>
		/// DepreciationYear
		/// </summary>
		[Column(Name = "DepreciationYear", DbType = "int", Storage = "_DepreciationYear", UpdateCheck = UpdateCheck.Never)]
		public int? DepreciationYear
		{
			get { return _DepreciationYear; }
			set { _DepreciationYear = value; }
		}
		private int? _DepreciationMonth;
		/// <summary>
		/// DepreciationMonth
		/// </summary>
		[Column(Name = "DepreciationMonth", DbType = "int", Storage = "_DepreciationMonth", UpdateCheck = UpdateCheck.Never)]
		public int? DepreciationMonth
		{
			get { return _DepreciationMonth; }
			set { _DepreciationMonth = value; }
		}
		private string _DepreciationMethod;
		/// <summary>
		/// DepreciationMethod
		/// </summary>
		[Column(Name = "DepreciationMethod", DbType = "nvarchar(100)", Storage = "_DepreciationMethod", UpdateCheck = UpdateCheck.Never)]
		public string DepreciationMethod
		{
			get { return _DepreciationMethod; }
			set { _DepreciationMethod = value; }
		}
		private DateTime? _CreateTime;
		/// <summary>
		/// CreateTime
		/// </summary>
		[Column(Name = "CreateTime", DbType = "datetime", Storage = "_CreateTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? CreateTime
		{
			get { return _CreateTime; }
			set { _CreateTime = value; }
		}
		private int _Serial;
		/// <summary>
		/// Serial
		/// </summary>
		[Column(Name = "Serial", DbType = "int", Storage = "_Serial", UpdateCheck = UpdateCheck.Never)]
		public int Serial
		{
			get { return _Serial; }
			set { _Serial = value; }
		}
		private string _Active;
		/// <summary>
		/// Active
		/// </summary>
		[Column(Name = "Active", DbType = "char(1)", Storage = "_Active", UpdateCheck = UpdateCheck.Never)]
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}
		private DateTime? _EnableTime;
		/// <summary>
		/// EnableTime
		/// </summary>
		[Column(Name = "EnableTime", DbType = "datetime", Storage = "_EnableTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? EnableTime
		{
			get { return _EnableTime; }
			set { _EnableTime = value; }
		}
	}
}