using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_ConsumableDetail")]
	public class M_ConsumableDetail
	{
		private string _ProjectID;
		/// <summary>
		/// ProjectID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ProjectID", DbType = "varchar(10)", Storage = "_ProjectID")]
		public string ProjectID
		{
			get { return _ProjectID; }
			set { _ProjectID = value; }
		}
		private int _ResID;
		/// <summary>
		/// ResID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ResID", DbType = "int", Storage = "_ResID")]
		public int ResID
		{
			get { return _ResID; }
			set { _ResID = value; }
		}
		private string _DefaultNum;
		/// <summary>
		/// DefaultNum
		/// </summary>
		[Column(Name = "DefaultNum", DbType = "varchar(10)", Storage = "_DefaultNum", UpdateCheck = UpdateCheck.Never)]
		public string DefaultNum
		{
			get { return _DefaultNum; }
			set { _DefaultNum = value; }
		}
		private double? _ChargePrice;
		/// <summary>
		/// ChargePrice
		/// </summary>
		[Column(Name = "ChargePrice", DbType = "float", Storage = "_ChargePrice", UpdateCheck = UpdateCheck.Never)]
		public double? ChargePrice
		{
			get { return _ChargePrice; }
			set { _ChargePrice = value; }
		}
	}
}