using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "O_LecturerDoc")]
	public class O_LecturerDoc
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
		private string _TeachingTime;
		/// <summary>
		/// TeachingTime
		/// </summary>
		[Column(Name = "TeachingTime", DbType = "varchar(50)", Storage = "_TeachingTime", UpdateCheck = UpdateCheck.Never)]
		public string TeachingTime
		{
			get { return _TeachingTime; }
			set { _TeachingTime = value; }
		}
		private string _TeachingContent;
		/// <summary>
		/// TeachingContent
		/// </summary>
		[Column(Name = "TeachingContent", DbType = "varchar(200)", Storage = "_TeachingContent", UpdateCheck = UpdateCheck.Never)]
		public string TeachingContent
		{
			get { return _TeachingContent; }
			set { _TeachingContent = value; }
		}
		private string _Feedback;
		/// <summary>
		/// Feedback
		/// </summary>
		[Column(Name = "Feedback", DbType = "nvarchar(510)", Storage = "_Feedback", UpdateCheck = UpdateCheck.Never)]
		public string Feedback
		{
			get { return _Feedback; }
			set { _Feedback = value; }
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
	}
}