using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientGradeDetail")]
	public class M_PatientGradeDetail
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
		private int _PatientOrder;
		/// <summary>
		/// PatientOrder
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "PatientOrder", DbType = "int", Storage = "_PatientOrder")]
		public int PatientOrder
		{
			get { return _PatientOrder; }
			set { _PatientOrder = value; }
		}
		private string _ScoreID;
		/// <summary>
		/// ScoreID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ScoreID", DbType = "varchar(50)", Storage = "_ScoreID")]
		public string ScoreID
		{
			get { return _ScoreID; }
			set { _ScoreID = value; }
		}
		private double? _Score;
		/// <summary>
		/// Score
		/// </summary>
		[Column(Name = "Score", DbType = "float", Storage = "_Score", UpdateCheck = UpdateCheck.Never)]
		public double? Score
		{
			get { return _Score; }
			set { _Score = value; }
		}
		private string _Reason;
		/// <summary>
		/// Reason
		/// </summary>
		[Column(Name = "Reason", DbType = "varchar(500)", Storage = "_Reason", UpdateCheck = UpdateCheck.Never)]
		public string Reason
		{
			get { return _Reason; }
			set { _Reason = value; }
		}
	}
}