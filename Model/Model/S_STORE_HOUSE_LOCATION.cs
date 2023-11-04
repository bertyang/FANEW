using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_STORE_HOUSE_LOCATION")]
	public class S_STORE_HOUSE_LOCATION
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
		[Column(Name = "Name", DbType = "nvarchar(200)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private int _StoreHouseID;
		/// <summary>
		/// StoreHouseID
		/// </summary>
		[Column(Name = "StoreHouseID", DbType = "int", Storage = "_StoreHouseID", UpdateCheck = UpdateCheck.Never)]
		public int StoreHouseID
		{
			get { return _StoreHouseID; }
			set { _StoreHouseID = value; }
		}
	}
}