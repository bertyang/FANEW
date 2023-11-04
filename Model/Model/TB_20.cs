using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_20")]
	public class TB_20
	{
		private int _FlowNo;
		/// <summary>
		/// FlowNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "FlowNo", DbType = "int", Storage = "_FlowNo")]
		public int FlowNo
		{
			get { return _FlowNo; }
			set { _FlowNo = value; }
		}
		private string _Title;
		/// <summary>
		/// Title
		/// </summary>
		[Column(Name = "Title", DbType = "nvarchar(200)", Storage = "_Title", UpdateCheck = UpdateCheck.Never)]
		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}
	}
}