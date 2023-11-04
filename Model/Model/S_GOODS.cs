using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_GOODS")]
	public class S_GOODS
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
		private int _CategoryID;
		/// <summary>
		/// CategoryID
		/// </summary>
		[Column(Name = "CategoryID", DbType = "int", Storage = "_CategoryID", UpdateCheck = UpdateCheck.Never)]
		public int CategoryID
		{
			get { return _CategoryID; }
			set { _CategoryID = value; }
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
		private string _Form;
		/// <summary>
		/// Form
		/// </summary>
		[Column(Name = "Form", DbType = "nvarchar(20)", Storage = "_Form", UpdateCheck = UpdateCheck.Never)]
		public string Form
		{
			get { return _Form; }
			set { _Form = value; }
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
		private int? _EarlyWarningExpireDays;
		/// <summary>
		/// EarlyWarningExpireDays
		/// </summary>
		[Column(Name = "EarlyWarningExpireDays", DbType = "int", Storage = "_EarlyWarningExpireDays", UpdateCheck = UpdateCheck.Never)]
		public int? EarlyWarningExpireDays
		{
			get { return _EarlyWarningExpireDays; }
			set { _EarlyWarningExpireDays = value; }
		}
		private string _MinSpec;
		/// <summary>
		/// MinSpec
		/// </summary>
		[Column(Name = "MinSpec", DbType = "varchar(50)", Storage = "_MinSpec", UpdateCheck = UpdateCheck.Never)]
		public string MinSpec
		{
			get { return _MinSpec; }
			set { _MinSpec = value; }
		}
		private string _MinNum;
		/// <summary>
		/// MinNum
		/// </summary>
		[Column(Name = "MinNum", DbType = "varchar(50)", Storage = "_MinNum", UpdateCheck = UpdateCheck.Never)]
		public string MinNum
		{
			get { return _MinNum; }
			set { _MinNum = value; }
		}
	}
}