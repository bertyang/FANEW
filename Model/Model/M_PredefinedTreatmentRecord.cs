using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PredefinedTreatmentRecord")]
	public class M_PredefinedTreatmentRecord
	{
		private string _ProjectID;
		/// <summary>
		/// ProjectID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ProjectID", DbType = "varchar(10)", Storage = "_ProjectID")]
		public string ProjectID
		{
			get { return _ProjectID; }
			set { _ProjectID = value; }
		}
		private string _GroupID;
		/// <summary>
		/// GroupID
		/// </summary>
		[Column(Name = "GroupID", DbType = "varchar(10)", Storage = "_GroupID", UpdateCheck = UpdateCheck.Never)]
		public string GroupID
		{
			get { return _GroupID; }
			set { _GroupID = value; }
		}
		private string _UpperID;
		/// <summary>
		/// UpperID
		/// </summary>
		[Column(Name = "UpperID", DbType = "varchar(10)", Storage = "_UpperID", UpdateCheck = UpdateCheck.Never)]
		public string UpperID
		{
			get { return _UpperID; }
			set { _UpperID = value; }
		}
		private string _AssociateID;
		/// <summary>
		/// AssociateID
		/// </summary>
		[Column(Name = "AssociateID", DbType = "varchar(10)", Storage = "_AssociateID", UpdateCheck = UpdateCheck.Never)]
		public string AssociateID
		{
			get { return _AssociateID; }
			set { _AssociateID = value; }
		}
		private string _Prefixes;
		/// <summary>
		/// Prefixes
		/// </summary>
		[Column(Name = "Prefixes", DbType = "varchar(50)", Storage = "_Prefixes", UpdateCheck = UpdateCheck.Never)]
		public string Prefixes
		{
			get { return _Prefixes; }
			set { _Prefixes = value; }
		}
		private string _Suffixes;
		/// <summary>
		/// Suffixes
		/// </summary>
		[Column(Name = "Suffixes", DbType = "varchar(20)", Storage = "_Suffixes", UpdateCheck = UpdateCheck.Never)]
		public string Suffixes
		{
			get { return _Suffixes; }
			set { _Suffixes = value; }
		}
		private string _LableStyle;
		/// <summary>
		/// LableStyle
		/// </summary>
		[Column(Name = "LableStyle", DbType = "varchar(50)", Storage = "_LableStyle", UpdateCheck = UpdateCheck.Never)]
		public string LableStyle
		{
			get { return _LableStyle; }
			set { _LableStyle = value; }
		}
		private string _InputStyle;
		/// <summary>
		/// InputStyle
		/// </summary>
		[Column(Name = "InputStyle", DbType = "varchar(50)", Storage = "_InputStyle", UpdateCheck = UpdateCheck.Never)]
		public string InputStyle
		{
			get { return _InputStyle; }
			set { _InputStyle = value; }
		}
		private string _ProjectName;
		/// <summary>
		/// ProjectName
		/// </summary>
		[Column(Name = "ProjectName", DbType = "varchar(20)", Storage = "_ProjectName", UpdateCheck = UpdateCheck.Never)]
		public string ProjectName
		{
			get { return _ProjectName; }
			set { _ProjectName = value; }
		}
		private bool? _IsDoctorAdvice;
		/// <summary>
		/// IsDoctorAdvice
		/// </summary>
		[Column(Name = "IsDoctorAdvice", DbType = "bit", Storage = "_IsDoctorAdvice", UpdateCheck = UpdateCheck.Never)]
		public bool? IsDoctorAdvice
		{
			get { return _IsDoctorAdvice; }
			set { _IsDoctorAdvice = value; }
		}
		private string _DefaultSign;
		/// <summary>
		/// DefaultSign
		/// </summary>
		[Column(Name = "DefaultSign", DbType = "varchar(10)", Storage = "_DefaultSign", UpdateCheck = UpdateCheck.Never)]
		public string DefaultSign
		{
			get { return _DefaultSign; }
			set { _DefaultSign = value; }
		}
		private string _ResponsClassify;
		/// <summary>
		/// ResponsClassify
		/// </summary>
		[Column(Name = "ResponsClassify", DbType = "varchar(10)", Storage = "_ResponsClassify", UpdateCheck = UpdateCheck.Never)]
		public string ResponsClassify
		{
			get { return _ResponsClassify; }
			set { _ResponsClassify = value; }
		}
		private int? _ChargeProject;
		/// <summary>
		/// ChargeProject
		/// </summary>
		[Column(Name = "ChargeProject", DbType = "int", Storage = "_ChargeProject", UpdateCheck = UpdateCheck.Never)]
		public int? ChargeProject
		{
			get { return _ChargeProject; }
			set { _ChargeProject = value; }
		}
		private double? _Valuation;
		/// <summary>
		/// Valuation
		/// </summary>
		[Column(Name = "Valuation", DbType = "float", Storage = "_Valuation", UpdateCheck = UpdateCheck.Never)]
		public double? Valuation
		{
			get { return _Valuation; }
			set { _Valuation = value; }
		}
		private string _Units;
		/// <summary>
		/// Units
		/// </summary>
		[Column(Name = "Units", DbType = "varchar(10)", Storage = "_Units", UpdateCheck = UpdateCheck.Never)]
		public string Units
		{
			get { return _Units; }
			set { _Units = value; }
		}
		private string _InputType;
		/// <summary>
		/// InputType
		/// </summary>
		[Column(Name = "InputType", DbType = "varchar(10)", Storage = "_InputType", UpdateCheck = UpdateCheck.Never)]
		public string InputType
		{
			get { return _InputType; }
			set { _InputType = value; }
		}
		private string _FormatMask;
		/// <summary>
		/// FormatMask
		/// </summary>
		[Column(Name = "FormatMask", DbType = "varchar(50)", Storage = "_FormatMask", UpdateCheck = UpdateCheck.Never)]
		public string FormatMask
		{
			get { return _FormatMask; }
			set { _FormatMask = value; }
		}
		private int _OrderID;
		/// <summary>
		/// OrderID
		/// </summary>
		[Column(Name = "OrderID", DbType = "int", Storage = "_OrderID", UpdateCheck = UpdateCheck.Never)]
		public int OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}
		private bool _IsUse;
		/// <summary>
		/// IsUse
		/// </summary>
		[Column(Name = "IsUse", DbType = "bit", Storage = "_IsUse", UpdateCheck = UpdateCheck.Never)]
		public bool IsUse
		{
			get { return _IsUse; }
			set { _IsUse = value; }
		}
		private string _MeasureContent;
		/// <summary>
		/// MeasureContent
		/// </summary>
		[Column(Name = "MeasureContent", DbType = "varchar(100)", Storage = "_MeasureContent", UpdateCheck = UpdateCheck.Never)]
		public string MeasureContent
		{
			get { return _MeasureContent; }
			set { _MeasureContent = value; }
		}
		private int? _InterfaceID;
		/// <summary>
		/// InterfaceID
		/// </summary>
		[Column(Name = "InterfaceID", DbType = "int", Storage = "_InterfaceID", UpdateCheck = UpdateCheck.Never)]
		public int? InterfaceID
		{
			get { return _InterfaceID; }
			set { _InterfaceID = value; }
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
	}
}