using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_8")]
	public class TB_8
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
		private string _ApplyWorker;
		/// <summary>
		/// ApplyWorker
		/// </summary>
		[Column(Name = "ApplyWorker", DbType = "varchar(50)", Storage = "_ApplyWorker", UpdateCheck = UpdateCheck.Never)]
		public string ApplyWorker
		{
			get { return _ApplyWorker; }
			set { _ApplyWorker = value; }
		}
		private DateTime _ApplyTime;
		/// <summary>
		/// ApplyTime
		/// </summary>
		[Column(Name = "ApplyTime", DbType = "datetime", Storage = "_ApplyTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime ApplyTime
		{
			get { return _ApplyTime; }
			set { _ApplyTime = value; }
		}
		private string _Form;
		/// <summary>
		/// Form
		/// </summary>
		[Column(Name = "Form", DbType = "varchar(50)", Storage = "_Form", UpdateCheck = UpdateCheck.Never)]
		public string Form
		{
			get { return _Form; }
			set { _Form = value; }
		}
	}
}