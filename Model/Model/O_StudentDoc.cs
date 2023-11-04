using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "O_StudentDoc")]
	public class O_StudentDoc
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
		[Column(Name = "Name", DbType = "varchar(50)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _LearningTime;
		/// <summary>
		/// LearningTime
		/// </summary>
		[Column(Name = "LearningTime", DbType = "varchar(40)", Storage = "_LearningTime", UpdateCheck = UpdateCheck.Never)]
		public string LearningTime
		{
			get { return _LearningTime; }
			set { _LearningTime = value; }
		}
		private string _Mobile;
		/// <summary>
		/// Mobile
		/// </summary>
		[Column(Name = "Mobile", DbType = "varchar(50)", Storage = "_Mobile", UpdateCheck = UpdateCheck.Never)]
		public string Mobile
		{
			get { return _Mobile; }
			set { _Mobile = value; }
		}
		private string _Email;
		/// <summary>
		/// Email
		/// </summary>
		[Column(Name = "Email", DbType = "varchar(50)", Storage = "_Email", UpdateCheck = UpdateCheck.Never)]
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}
		private int _OccupationID;
		/// <summary>
		/// OccupationID
		/// </summary>
		[Column(Name = "OccupationID", DbType = "int", Storage = "_OccupationID", UpdateCheck = UpdateCheck.Never)]
		public int OccupationID
		{
			get { return _OccupationID; }
			set { _OccupationID = value; }
		}
		private int _ProfessionID;
		/// <summary>
		/// ProfessionID
		/// </summary>
		[Column(Name = "ProfessionID", DbType = "int", Storage = "_ProfessionID", UpdateCheck = UpdateCheck.Never)]
		public int ProfessionID
		{
			get { return _ProfessionID; }
			set { _ProfessionID = value; }
		}
		private DateTime _ValidityCertificate;
		/// <summary>
		/// ValidityCertificate
		/// </summary>
		[Column(Name = "ValidityCertificate", DbType = "datetime", Storage = "_ValidityCertificate", UpdateCheck = UpdateCheck.Never)]
		public DateTime ValidityCertificate
		{
			get { return _ValidityCertificate; }
			set { _ValidityCertificate = value; }
		}
		private string _Unit;
		/// <summary>
		/// Unit
		/// </summary>
		[Column(Name = "Unit", DbType = "varchar(50)", Storage = "_Unit", UpdateCheck = UpdateCheck.Never)]
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
		}
		private int _CourseType;
		/// <summary>
		/// CourseType
		/// </summary>
		[Column(Name = "CourseType", DbType = "int", Storage = "_CourseType", UpdateCheck = UpdateCheck.Never)]
		public int CourseType
		{
			get { return _CourseType; }
			set { _CourseType = value; }
		}
		private DateTime _LearningDate;
		/// <summary>
		/// LearningDate
		/// </summary>
		[Column(Name = "LearningDate", DbType = "datetime", Storage = "_LearningDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime LearningDate
		{
			get { return _LearningDate; }
			set { _LearningDate = value; }
		}
	}
}