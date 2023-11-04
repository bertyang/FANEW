using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_TransportRecord")]
	public class M_TransportRecord
	{
		private string _TaskCode;
		/// <summary>
		/// TaskCode
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TaskCode", DbType = "char(20)", Storage = "_TaskCode")]
		public string TaskCode
		{
			get { return _TaskCode; }
			set { _TaskCode = value; }
		}
		private string _TROrder;
		/// <summary>
		/// TROrder
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TROrder", DbType = "varchar(10)", Storage = "_TROrder")]
		public string TROrder
		{
			get { return _TROrder; }
			set { _TROrder = value; }
		}
		private string _Station;
		/// <summary>
		/// Station
		/// </summary>
		[Column(Name = "Station", DbType = "varchar(50)", Storage = "_Station", UpdateCheck = UpdateCheck.Never)]
		public string Station
		{
			get { return _Station; }
			set { _Station = value; }
		}
		private string _LinkPhone;
		/// <summary>
		/// LinkPhone
		/// </summary>
		[Column(Name = "LinkPhone", DbType = "varchar(50)", Storage = "_LinkPhone", UpdateCheck = UpdateCheck.Never)]
		public string LinkPhone
		{
			get { return _LinkPhone; }
			set { _LinkPhone = value; }
		}
		private string _RecordID;
		/// <summary>
		/// RecordID
		/// </summary>
		[Column(Name = "RecordID", DbType = "varchar(30)", Storage = "_RecordID", UpdateCheck = UpdateCheck.Never)]
		public string RecordID
		{
			get { return _RecordID; }
			set { _RecordID = value; }
		}
		private string _LocalAdd;
		/// <summary>
		/// LocalAdd
		/// </summary>
		[Column(Name = "LocalAdd", DbType = "varchar(200)", Storage = "_LocalAdd", UpdateCheck = UpdateCheck.Never)]
		public string LocalAdd
		{
			get { return _LocalAdd; }
			set { _LocalAdd = value; }
		}
		private string _SendAdd;
		/// <summary>
		/// SendAdd
		/// </summary>
		[Column(Name = "SendAdd", DbType = "varchar(200)", Storage = "_SendAdd", UpdateCheck = UpdateCheck.Never)]
		public string SendAdd
		{
			get { return _SendAdd; }
			set { _SendAdd = value; }
		}
		private DateTime? _DrivingTime;
		/// <summary>
		/// DrivingTime
		/// </summary>
		[Column(Name = "DrivingTime", DbType = "datetime", Storage = "_DrivingTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? DrivingTime
		{
			get { return _DrivingTime; }
			set { _DrivingTime = value; }
		}
		private DateTime? _ArrivedTime;
		/// <summary>
		/// ArrivedTime
		/// </summary>
		[Column(Name = "ArrivedTime", DbType = "datetime", Storage = "_ArrivedTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ArrivedTime
		{
			get { return _ArrivedTime; }
			set { _ArrivedTime = value; }
		}
		private DateTime? _DeliveredTime;
		/// <summary>
		/// DeliveredTime
		/// </summary>
		[Column(Name = "DeliveredTime", DbType = "datetime", Storage = "_DeliveredTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? DeliveredTime
		{
			get { return _DeliveredTime; }
			set { _DeliveredTime = value; }
		}
		private DateTime? _TaskCompleteTime;
		/// <summary>
		/// TaskCompleteTime
		/// </summary>
		[Column(Name = "TaskCompleteTime", DbType = "datetime", Storage = "_TaskCompleteTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? TaskCompleteTime
		{
			get { return _TaskCompleteTime; }
			set { _TaskCompleteTime = value; }
		}
		private string _TentativeDiagnoseName;
		/// <summary>
		/// TentativeDiagnoseName
		/// </summary>
		[Column(Name = "TentativeDiagnoseName", DbType = "varchar(500)", Storage = "_TentativeDiagnoseName", UpdateCheck = UpdateCheck.Never)]
		public string TentativeDiagnoseName
		{
			get { return _TentativeDiagnoseName; }
			set { _TentativeDiagnoseName = value; }
		}
		private string _TransportDetail;
		/// <summary>
		/// TransportDetail
		/// </summary>
		[Column(Name = "TransportDetail", DbType = "varchar(1000)", Storage = "_TransportDetail", UpdateCheck = UpdateCheck.Never)]
		public string TransportDetail
		{
			get { return _TransportDetail; }
			set { _TransportDetail = value; }
		}
		private DateTime? _RecordCreateTime;
		/// <summary>
		/// RecordCreateTime
		/// </summary>
		[Column(Name = "RecordCreateTime", DbType = "datetime", Storage = "_RecordCreateTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? RecordCreateTime
		{
			get { return _RecordCreateTime; }
			set { _RecordCreateTime = value; }
		}
		private string _FirstAider;
		/// <summary>
		/// FirstAider
		/// </summary>
		[Column(Name = "FirstAider", DbType = "varchar(50)", Storage = "_FirstAider", UpdateCheck = UpdateCheck.Never)]
		public string FirstAider
		{
			get { return _FirstAider; }
			set { _FirstAider = value; }
		}
		private string _Driver;
		/// <summary>
		/// Driver
		/// </summary>
		[Column(Name = "Driver", DbType = "varchar(50)", Storage = "_Driver", UpdateCheck = UpdateCheck.Never)]
		public string Driver
		{
			get { return _Driver; }
			set { _Driver = value; }
		}
		private string _StretcherBearers;
		/// <summary>
		/// StretcherBearers
		/// </summary>
		[Column(Name = "StretcherBearers", DbType = "varchar(50)", Storage = "_StretcherBearers", UpdateCheck = UpdateCheck.Never)]
		public string StretcherBearers
		{
			get { return _StretcherBearers; }
			set { _StretcherBearers = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "varchar(50)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Sex;
		/// <summary>
		/// Sex
		/// </summary>
		[Column(Name = "Sex", DbType = "varchar(10)", Storage = "_Sex", UpdateCheck = UpdateCheck.Never)]
		public string Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}
		private string _Age;
		/// <summary>
		/// Age
		/// </summary>
		[Column(Name = "Age", DbType = "varchar(50)", Storage = "_Age", UpdateCheck = UpdateCheck.Never)]
		public string Age
		{
			get { return _Age; }
			set { _Age = value; }
		}
		private string _Vocation;
		/// <summary>
		/// Vocation
		/// </summary>
		[Column(Name = "Vocation", DbType = "varchar(50)", Storage = "_Vocation", UpdateCheck = UpdateCheck.Never)]
		public string Vocation
		{
			get { return _Vocation; }
			set { _Vocation = value; }
		}
		private bool? _Written;
		/// <summary>
		/// Written
		/// </summary>
		[Column(Name = "Written", DbType = "bit", Storage = "_Written", UpdateCheck = UpdateCheck.Never)]
		public bool? Written
		{
			get { return _Written; }
			set { _Written = value; }
		}
		private bool? _ECGCity;
		/// <summary>
		/// ECGCity
		/// </summary>
		[Column(Name = "ECGCity", DbType = "bit", Storage = "_ECGCity", UpdateCheck = UpdateCheck.Never)]
		public bool? ECGCity
		{
			get { return _ECGCity; }
			set { _ECGCity = value; }
		}
		private bool? _SpO2City;
		/// <summary>
		/// SpO2City
		/// </summary>
		[Column(Name = "SpO2City", DbType = "bit", Storage = "_SpO2City", UpdateCheck = UpdateCheck.Never)]
		public bool? SpO2City
		{
			get { return _SpO2City; }
			set { _SpO2City = value; }
		}
		private bool? _Oxygen;
		/// <summary>
		/// Oxygen
		/// </summary>
		[Column(Name = "Oxygen", DbType = "bit", Storage = "_Oxygen", UpdateCheck = UpdateCheck.Never)]
		public bool? Oxygen
		{
			get { return _Oxygen; }
			set { _Oxygen = value; }
		}
		private bool? _Mask;
		/// <summary>
		/// Mask
		/// </summary>
		[Column(Name = "Mask", DbType = "bit", Storage = "_Mask", UpdateCheck = UpdateCheck.Never)]
		public bool? Mask
		{
			get { return _Mask; }
			set { _Mask = value; }
		}
		private bool? _Sputum;
		/// <summary>
		/// Sputum
		/// </summary>
		[Column(Name = "Sputum", DbType = "bit", Storage = "_Sputum", UpdateCheck = UpdateCheck.Never)]
		public bool? Sputum
		{
			get { return _Sputum; }
			set { _Sputum = value; }
		}
		private bool? _Balloon;
		/// <summary>
		/// Balloon
		/// </summary>
		[Column(Name = "Balloon", DbType = "bit", Storage = "_Balloon", UpdateCheck = UpdateCheck.Never)]
		public bool? Balloon
		{
			get { return _Balloon; }
			set { _Balloon = value; }
		}
		private bool? _Breath;
		/// <summary>
		/// Breath
		/// </summary>
		[Column(Name = "Breath", DbType = "bit", Storage = "_Breath", UpdateCheck = UpdateCheck.Never)]
		public bool? Breath
		{
			get { return _Breath; }
			set { _Breath = value; }
		}
		private bool? _Airpillow;
		/// <summary>
		/// Airpillow
		/// </summary>
		[Column(Name = "Airpillow", DbType = "bit", Storage = "_Airpillow", UpdateCheck = UpdateCheck.Never)]
		public bool? Airpillow
		{
			get { return _Airpillow; }
			set { _Airpillow = value; }
		}
	}
}