using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Drug_Apply_NurseHead")]
	public class S_Drug_Apply_NurseHead
	{
		private int _StoreHouseID;
		/// <summary>
		/// StoreHouseID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "StoreHouseID", DbType = "int", Storage = "_StoreHouseID")]
		public int StoreHouseID
		{
			get { return _StoreHouseID; }
			set { _StoreHouseID = value; }
		}
		private int _GoodsID;
		/// <summary>
		/// GoodsID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GoodsID", DbType = "int", Storage = "_GoodsID")]
		public int GoodsID
		{
			get { return _GoodsID; }
			set { _GoodsID = value; }
		}
		private int _UsableAmount;
		/// <summary>
		/// UsableAmount
		/// </summary>
		[Column(Name = "UsableAmount", DbType = "int", Storage = "_UsableAmount", UpdateCheck = UpdateCheck.Never)]
		public int UsableAmount
		{
			get { return _UsableAmount; }
			set { _UsableAmount = value; }
		}
		private int _LastUnAmount;
		/// <summary>
		/// LastUnAmount
		/// </summary>
		[Column(Name = "LastUnAmount", DbType = "int", Storage = "_LastUnAmount", UpdateCheck = UpdateCheck.Never)]
		public int LastUnAmount
		{
			get { return _LastUnAmount; }
			set { _LastUnAmount = value; }
		}
	}
}