using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "R_DriverWork")]
	public class R_DriverWork
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
		private string _StaCode;
		/// <summary>
		/// StaCode
		/// </summary>
		[Column(Name = "StaCode", DbType = "varchar(10)", Storage = "_StaCode", UpdateCheck = UpdateCheck.Never)]
		public string StaCode
		{
			get { return _StaCode; }
			set { _StaCode = value; }
		}
		private DateTime _BTime;
		/// <summary>
		/// BTime
		/// </summary>
		[Column(Name = "BTime", DbType = "datetime", Storage = "_BTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime BTime
		{
			get { return _BTime; }
			set { _BTime = value; }
		}
		private DateTime _ETime;
		/// <summary>
		/// ETime
		/// </summary>
		[Column(Name = "ETime", DbType = "datetime", Storage = "_ETime", UpdateCheck = UpdateCheck.Never)]
		public DateTime ETime
		{
			get { return _ETime; }
			set { _ETime = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "varchar(20)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private int _TotalNum;
		/// <summary>
		/// TotalNum
		/// </summary>
		[Column(Name = "TotalNum", DbType = "int", Storage = "_TotalNum", UpdateCheck = UpdateCheck.Never)]
		public int TotalNum
		{
			get { return _TotalNum; }
			set { _TotalNum = value; }
		}
		private int _EmptyNum;
		/// <summary>
		/// EmptyNum
		/// </summary>
		[Column(Name = "EmptyNum", DbType = "int", Storage = "_EmptyNum", UpdateCheck = UpdateCheck.Never)]
		public int EmptyNum
		{
			get { return _EmptyNum; }
			set { _EmptyNum = value; }
		}
		private int _EffectNum;
		/// <summary>
		/// EffectNum
		/// </summary>
		[Column(Name = "EffectNum", DbType = "int", Storage = "_EffectNum", UpdateCheck = UpdateCheck.Never)]
		public int EffectNum
		{
			get { return _EffectNum; }
			set { _EffectNum = value; }
		}
		private double _TotalKilometer;
		/// <summary>
		/// TotalKilometer
		/// </summary>
		[Column(Name = "TotalKilometer", DbType = "float", Storage = "_TotalKilometer", UpdateCheck = UpdateCheck.Never)]
		public double TotalKilometer
		{
			get { return _TotalKilometer; }
			set { _TotalKilometer = value; }
		}
		private double _EmptyKilometer;
		/// <summary>
		/// EmptyKilometer
		/// </summary>
		[Column(Name = "EmptyKilometer", DbType = "float", Storage = "_EmptyKilometer", UpdateCheck = UpdateCheck.Never)]
		public double EmptyKilometer
		{
			get { return _EmptyKilometer; }
			set { _EmptyKilometer = value; }
		}
		private double _EffectKilometer;
		/// <summary>
		/// EffectKilometer
		/// </summary>
		[Column(Name = "EffectKilometer", DbType = "float", Storage = "_EffectKilometer", UpdateCheck = UpdateCheck.Never)]
		public double EffectKilometer
		{
			get { return _EffectKilometer; }
			set { _EffectKilometer = value; }
		}
		private decimal _TotalCharge;
		/// <summary>
		/// TotalCharge
		/// </summary>
		[Column(Name = "TotalCharge", DbType = "money", Storage = "_TotalCharge", UpdateCheck = UpdateCheck.Never)]
		public decimal TotalCharge
		{
			get { return _TotalCharge; }
			set { _TotalCharge = value; }
		}
		private decimal _EmptyCharge;
		/// <summary>
		/// EmptyCharge
		/// </summary>
		[Column(Name = "EmptyCharge", DbType = "money", Storage = "_EmptyCharge", UpdateCheck = UpdateCheck.Never)]
		public decimal EmptyCharge
		{
			get { return _EmptyCharge; }
			set { _EmptyCharge = value; }
		}
		private decimal _EffectCharge;
		/// <summary>
		/// EffectCharge
		/// </summary>
		[Column(Name = "EffectCharge", DbType = "money", Storage = "_EffectCharge", UpdateCheck = UpdateCheck.Never)]
		public decimal EffectCharge
		{
			get { return _EffectCharge; }
			set { _EffectCharge = value; }
		}
		private string _Remark;
		/// <summary>
		/// Remark
		/// </summary>
		[Column(Name = "Remark", DbType = "varchar(200)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private int _WorkID;
		/// <summary>
		/// WorkID
		/// </summary>
		[Column(Name = "WorkID", DbType = "int", Storage = "_WorkID", UpdateCheck = UpdateCheck.Never)]
		public int WorkID
		{
			get { return _WorkID; }
			set { _WorkID = value; }
		}
		private DateTime _CreateDate;
		/// <summary>
		/// CreateDate
		/// </summary>
		[Column(Name = "CreateDate", DbType = "datetime", Storage = "_CreateDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime CreateDate
		{
			get { return _CreateDate; }
			set { _CreateDate = value; }
		}
		private DateTime? _ModifyDate;
		/// <summary>
		/// ModifyDate
		/// </summary>
		[Column(Name = "ModifyDate", DbType = "datetime", Storage = "_ModifyDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ModifyDate
		{
			get { return _ModifyDate; }
			set { _ModifyDate = value; }
		}
	}
}