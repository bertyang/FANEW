using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "O_Course")]
	public class O_Course
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
		private DateTime _Time;
		/// <summary>
		/// Time
		/// </summary>
		[Column(Name = "Time", DbType = "datetime", Storage = "_Time", UpdateCheck = UpdateCheck.Never)]
		public DateTime Time
		{
			get { return _Time; }
			set { _Time = value; }
		}
		private int _Type;
		/// <summary>
		/// Type
		/// </summary>
		[Column(Name = "Type", DbType = "int", Storage = "_Type", UpdateCheck = UpdateCheck.Never)]
		public int Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		private string _Content;
		/// <summary>
		/// Content
		/// </summary>
		[Column(Name = "Content", DbType = "varchar(200)", Storage = "_Content", UpdateCheck = UpdateCheck.Never)]
		public string Content
		{
			get { return _Content; }
			set { _Content = value; }
		}
		private string _Object;
		/// <summary>
		/// Object
		/// </summary>
		[Column(Name = "Object", DbType = "varchar(50)", Storage = "_Object", UpdateCheck = UpdateCheck.Never)]
		public string Object
		{
			get { return _Object; }
			set { _Object = value; }
		}
		private string _Lecturer;
		/// <summary>
		/// Lecturer
		/// </summary>
		[Column(Name = "Lecturer", DbType = "varchar(50)", Storage = "_Lecturer", UpdateCheck = UpdateCheck.Never)]
		public string Lecturer
		{
			get { return _Lecturer; }
			set { _Lecturer = value; }
		}
		private double _Score;
		/// <summary>
		/// Score
		/// </summary>
		[Column(Name = "Score", DbType = "float", Storage = "_Score", UpdateCheck = UpdateCheck.Never)]
		public double Score
		{
			get { return _Score; }
			set { _Score = value; }
		}
		private string _Duration;
		/// <summary>
		/// Duration
		/// </summary>
		[Column(Name = "Duration", DbType = "varchar(50)", Storage = "_Duration", UpdateCheck = UpdateCheck.Never)]
		public string Duration
		{
			get { return _Duration; }
			set { _Duration = value; }
		}
		private string _Remark;
		/// <summary>
		/// Remark
		/// </summary>
		[Column(Name = "Remark", DbType = "nvarchar(510)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
	}
}