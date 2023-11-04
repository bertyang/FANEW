using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Doctor_Default")]
	public class S_Doctor_Default
	{
		private int _GOODSID;
		/// <summary>
		/// GOODSID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "GOODSID", DbType = "int", Storage = "_GOODSID")]
		public int GOODSID
		{
			get { return _GOODSID; }
			set { _GOODSID = value; }
		}
		private double? _DefaultNumber;
		/// <summary>
		/// DefaultNumber
		/// </summary>
		[Column(Name = "DefaultNumber", DbType = "float", Storage = "_DefaultNumber", UpdateCheck = UpdateCheck.Never)]
		public double? DefaultNumber
		{
			get { return _DefaultNumber; }
			set { _DefaultNumber = value; }
		}
	}
}