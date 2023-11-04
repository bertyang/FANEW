using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_FollowUpRecord")]
	public class M_FollowUpRecord
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
		private string _Person;
		/// <summary>
		/// Person
		/// </summary>
		[Column(Name = "Person", DbType = "varchar(25)", Storage = "_Person", UpdateCheck = UpdateCheck.Never)]
		public string Person
		{
			get { return _Person; }
			set { _Person = value; }
		}
		private DateTime? _FollowUpTime;
		/// <summary>
		/// FollowUpTime
		/// </summary>
		[Column(Name = "FollowUpTime", DbType = "datetime", Storage = "_FollowUpTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? FollowUpTime
		{
			get { return _FollowUpTime; }
			set { _FollowUpTime = value; }
		}
		private string _Diagnose;
		/// <summary>
		/// Diagnose
		/// </summary>
		[Column(Name = "Diagnose", DbType = "varchar(300)", Storage = "_Diagnose", UpdateCheck = UpdateCheck.Never)]
		public string Diagnose
		{
			get { return _Diagnose; }
			set { _Diagnose = value; }
		}
		private string _WhereAbouts;
		/// <summary>
		/// WhereAbouts
		/// </summary>
		[Column(Name = "WhereAbouts", DbType = "varchar(300)", Storage = "_WhereAbouts", UpdateCheck = UpdateCheck.Never)]
		public string WhereAbouts
		{
			get { return _WhereAbouts; }
			set { _WhereAbouts = value; }
		}
	}
}