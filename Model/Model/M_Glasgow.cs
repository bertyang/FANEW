using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_Glasgow")]
	public class M_Glasgow
	{
		private int _SuperID;
		/// <summary>
		/// SuperID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "SuperID", DbType = "int", Storage = "_SuperID")]
		public int SuperID
		{
			get { return _SuperID; }
			set { _SuperID = value; }
		}
		private int? _ID;
		/// <summary>
		/// ID
		/// </summary>
		[Column(Name = "ID", DbType = "int", Storage = "_ID", UpdateCheck = UpdateCheck.Never)]
		public int? ID
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
		private int? _Score;
		/// <summary>
		/// Score
		/// </summary>
		[Column(Name = "Score", DbType = "int", Storage = "_Score", UpdateCheck = UpdateCheck.Never)]
		public int? Score
		{
			get { return _Score; }
			set { _Score = value; }
		}
	}
}