using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientCheck")]
	public class M_PatientCheck
	{
		private int _RecordID;
		/// <summary>
		/// RecordID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "RecordID", DbType = "int", Storage = "_RecordID")]
		public int RecordID
		{
			get { return _RecordID; }
			set { _RecordID = value; }
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
		private int _TaskXH;
		/// <summary>
		/// TaskXH
		/// </summary>
		[Column(Name = "TaskXH", DbType = "int", Storage = "_TaskXH", UpdateCheck = UpdateCheck.Never)]
		public int TaskXH
		{
			get { return _TaskXH; }
			set { _TaskXH = value; }
		}
		private int _CheckerID;
		/// <summary>
		/// CheckerID
		/// </summary>
		[Column(Name = "CheckerID", DbType = "int", Storage = "_CheckerID", UpdateCheck = UpdateCheck.Never)]
		public int CheckerID
		{
			get { return _CheckerID; }
			set { _CheckerID = value; }
		}
		private DateTime? _CheckTime;
		/// <summary>
		/// CheckTime
		/// </summary>
		[Column(Name = "CheckTime", DbType = "datetime", Storage = "_CheckTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? CheckTime
		{
			get { return _CheckTime; }
			set { _CheckTime = value; }
		}
		private string _CheckResult;
		/// <summary>
		/// CheckResult
		/// </summary>
		[Column(Name = "CheckResult", DbType = "char(1)", Storage = "_CheckResult", UpdateCheck = UpdateCheck.Never)]
		public string CheckResult
		{
			get { return _CheckResult; }
			set { _CheckResult = value; }
		}
		private string _Content;
		/// <summary>
		/// Content
		/// </summary>
		[Column(Name = "Content", DbType = "nvarchar(510)", Storage = "_Content", UpdateCheck = UpdateCheck.Never)]
		public string Content
		{
			get { return _Content; }
			set { _Content = value; }
		}
		private string _ESign;
		/// <summary>
		/// ESign
		/// </summary>
		[Column(Name = "ESign", DbType = "nvarchar(200)", Storage = "_ESign", UpdateCheck = UpdateCheck.Never)]
		public string ESign
		{
			get { return _ESign; }
			set { _ESign = value; }
		}
		private string _Cert;
		/// <summary>
		/// Cert
		/// </summary>
		[Column(Name = "Cert", DbType = "nvarchar(100)", Storage = "_Cert", UpdateCheck = UpdateCheck.Never)]
		public string Cert
		{
			get { return _Cert; }
			set { _Cert = value; }
		}
	}
}