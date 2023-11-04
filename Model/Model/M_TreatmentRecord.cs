using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_TreatmentRecord")]
	public class M_TreatmentRecord
	{
		private string _PatientRecordID;
		/// <summary>
		/// PatientRecordID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "PatientRecordID", DbType = "varchar(25)", Storage = "_PatientRecordID")]
		public string PatientRecordID
		{
			get { return _PatientRecordID; }
			set { _PatientRecordID = value; }
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
		private string _ProjectID;
		/// <summary>
		/// ProjectID
		/// </summary>
		[Column(Name = "ProjectID", DbType = "varchar(10)", Storage = "_ProjectID", UpdateCheck = UpdateCheck.Never)]
		public string ProjectID
		{
			get { return _ProjectID; }
			set { _ProjectID = value; }
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
		private string _Results;
		/// <summary>
		/// Results
		/// </summary>
		[Column(Name = "Results", DbType = "varchar(1024)", Storage = "_Results", UpdateCheck = UpdateCheck.Never)]
		public string Results
		{
			get { return _Results; }
			set { _Results = value; }
		}
		private DateTime? _DoTime;
		/// <summary>
		/// DoTime
		/// </summary>
		[Column(Name = "DoTime", DbType = "datetime", Storage = "_DoTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? DoTime
		{
			get { return _DoTime; }
			set { _DoTime = value; }
		}
		private double? _Number;
		/// <summary>
		/// Number
		/// </summary>
		[Column(Name = "Number", DbType = "float", Storage = "_Number", UpdateCheck = UpdateCheck.Never)]
		public double? Number
		{
			get { return _Number; }
			set { _Number = value; }
		}
		private int? _DoOrder;
		/// <summary>
		/// DoOrder
		/// </summary>
		[Column(Name = "DoOrder", DbType = "int", Storage = "_DoOrder", UpdateCheck = UpdateCheck.Never)]
		public int? DoOrder
		{
			get { return _DoOrder; }
			set { _DoOrder = value; }
		}
		private string _Place;
		/// <summary>
		/// Place
		/// </summary>
		[Column(Name = "Place", DbType = "varchar(20)", Storage = "_Place", UpdateCheck = UpdateCheck.Never)]
		public string Place
		{
			get { return _Place; }
			set { _Place = value; }
		}
	}
}