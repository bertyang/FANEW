using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "B_POST")]
	public class B_POST
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
		[Column(Name = "Name", DbType = "varchar(20)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private int _Level;
		/// <summary>
		/// Level
		/// </summary>
		[Column(Name = "Level", DbType = "int", Storage = "_Level", UpdateCheck = UpdateCheck.Never)]
		public int Level
		{
			get { return _Level; }
			set { _Level = value; }
		}
	}
}