using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_AmbulanceToStore")]
	public class S_AmbulanceToStore
	{
		private string _AmbulanceID;
		/// <summary>
		/// AmbulanceID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "AmbulanceID", DbType = "char(5)", Storage = "_AmbulanceID")]
		public string AmbulanceID
		{
			get { return _AmbulanceID; }
			set { _AmbulanceID = value; }
		}
		private int _LocationID;
		/// <summary>
		/// LocationID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "LocationID", DbType = "int", Storage = "_LocationID")]
		public int LocationID
		{
			get { return _LocationID; }
			set { _LocationID = value; }
		}
	}
}