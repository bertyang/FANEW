using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_ChargeMain")]
	public class M_ChargeMain
	{
		private Int64 _ChargeID;
		/// <summary>
		/// ChargeID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ChargeID", DbType = "bigint", Storage = "_ChargeID")]
		public Int64 ChargeID
		{
			get { return _ChargeID; }
			set { _ChargeID = value; }
		}
		private string _TaskID;
		/// <summary>
		/// TaskID
		/// </summary>
		[Column(Name = "TaskID", DbType = "char(20)", Storage = "_TaskID", UpdateCheck = UpdateCheck.Never)]
		public string TaskID
		{
			get { return _TaskID; }
			set { _TaskID = value; }
		}
		private string _PatientID;
		/// <summary>
		/// PatientID
		/// </summary>
		[Column(Name = "PatientID", DbType = "char(21)", Storage = "_PatientID", UpdateCheck = UpdateCheck.Never)]
		public string PatientID
		{
			get { return _PatientID; }
			set { _PatientID = value; }
		}
		private string _ChargeStyle;
		/// <summary>
		/// ChargeStyle
		/// </summary>
		[Column(Name = "ChargeStyle", DbType = "char(10)", Storage = "_ChargeStyle", UpdateCheck = UpdateCheck.Never)]
		public string ChargeStyle
		{
			get { return _ChargeStyle; }
			set { _ChargeStyle = value; }
		}
		private double? _ShouldIn;
		/// <summary>
		/// ShouldIn
		/// </summary>
		[Column(Name = "ShouldIn", DbType = "float", Storage = "_ShouldIn", UpdateCheck = UpdateCheck.Never)]
		public double? ShouldIn
		{
			get { return _ShouldIn; }
			set { _ShouldIn = value; }
		}
		private double? _RealIn;
		/// <summary>
		/// RealIn
		/// </summary>
		[Column(Name = "RealIn", DbType = "float", Storage = "_RealIn", UpdateCheck = UpdateCheck.Never)]
		public double? RealIn
		{
			get { return _RealIn; }
			set { _RealIn = value; }
		}
		private string _BillBookNo;
		/// <summary>
		/// BillBookNo
		/// </summary>
		[Column(Name = "BillBookNo", DbType = "varchar(50)", Storage = "_BillBookNo", UpdateCheck = UpdateCheck.Never)]
		public string BillBookNo
		{
			get { return _BillBookNo; }
			set { _BillBookNo = value; }
		}
		private string _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(Name = "BillNo", DbType = "varchar(50)", Storage = "_BillNo", UpdateCheck = UpdateCheck.Never)]
		public string BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
		private int? _WorkID;
		/// <summary>
		/// WorkID
		/// </summary>
		[Column(Name = "WorkID", DbType = "int", Storage = "_WorkID", UpdateCheck = UpdateCheck.Never)]
		public int? WorkID
		{
			get { return _WorkID; }
			set { _WorkID = value; }
		}
		private string _Status;
		/// <summary>
		/// Status
		/// </summary>
		[Column(Name = "Status", DbType = "char(1)", Storage = "_Status", UpdateCheck = UpdateCheck.Never)]
		public string Status
		{
			get { return _Status; }
			set { _Status = value; }
		}
		private int? _WorkFlowNo;
		/// <summary>
		/// WorkFlowNo
		/// </summary>
		[Column(Name = "WorkFlowNo", DbType = "int", Storage = "_WorkFlowNo", UpdateCheck = UpdateCheck.Never)]
		public int? WorkFlowNo
		{
			get { return _WorkFlowNo; }
			set { _WorkFlowNo = value; }
		}
		private double? _StartKM;
		/// <summary>
		/// StartKM
		/// </summary>
		[Column(Name = "StartKM", DbType = "float", Storage = "_StartKM", UpdateCheck = UpdateCheck.Never)]
		public double? StartKM
		{
			get { return _StartKM; }
			set { _StartKM = value; }
		}
		private double? _KM;
		/// <summary>
		/// KM
		/// </summary>
		[Column(Name = "KM", DbType = "float", Storage = "_KM", UpdateCheck = UpdateCheck.Never)]
		public double? KM
		{
			get { return _KM; }
			set { _KM = value; }
		}
		private DateTime? _ChargeTime;
		/// <summary>
		/// ChargeTime
		/// </summary>
		[Column(Name = "ChargeTime", DbType = "datetime", Storage = "_ChargeTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ChargeTime
		{
			get { return _ChargeTime; }
			set { _ChargeTime = value; }
		}
		private bool _IsOweFee;
		/// <summary>
		/// IsOweFee
		/// </summary>
		[Column(Name = "IsOweFee", DbType = "bit", Storage = "_IsOweFee", UpdateCheck = UpdateCheck.Never)]
		public bool IsOweFee
		{
			get { return _IsOweFee; }
			set { _IsOweFee = value; }
		}
		private string _OweReason;
		/// <summary>
		/// OweReason
		/// </summary>
		[Column(Name = "OweReason", DbType = "varchar(20)", Storage = "_OweReason", UpdateCheck = UpdateCheck.Never)]
		public string OweReason
		{
			get { return _OweReason; }
			set { _OweReason = value; }
		}
		private bool? _IsInvalid;
		/// <summary>
		/// IsInvalid
		/// </summary>
		[Column(Name = "IsInvalid", DbType = "bit", Storage = "_IsInvalid", UpdateCheck = UpdateCheck.Never)]
		public bool? IsInvalid
		{
			get { return _IsInvalid; }
			set { _IsInvalid = value; }
		}
		private string _BillType;
		/// <summary>
		/// BillType
		/// </summary>
		[Column(Name = "BillType", DbType = "varchar(20)", Storage = "_BillType", UpdateCheck = UpdateCheck.Never)]
		public string BillType
		{
			get { return _BillType; }
			set { _BillType = value; }
		}
		private string _StartAdd;
		/// <summary>
		/// StartAdd
		/// </summary>
		[Column(Name = "StartAdd", DbType = "varchar(150)", Storage = "_StartAdd", UpdateCheck = UpdateCheck.Never)]
		public string StartAdd
		{
			get { return _StartAdd; }
			set { _StartAdd = value; }
		}
		private string _SendAdd;
		/// <summary>
		/// SendAdd
		/// </summary>
		[Column(Name = "SendAdd", DbType = "varchar(150)", Storage = "_SendAdd", UpdateCheck = UpdateCheck.Never)]
		public string SendAdd
		{
			get { return _SendAdd; }
			set { _SendAdd = value; }
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
		private string _Total;
		/// <summary>
		/// Total
		/// </summary>
		[Column(Name = "Total", DbType = "varchar(50)", Storage = "_Total", UpdateCheck = UpdateCheck.Never)]
		public string Total
		{
			get { return _Total; }
			set { _Total = value; }
		}
	}
}