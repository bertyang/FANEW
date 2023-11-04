using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_10")]
	public class TB_10
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
		private string _Unit;
		/// <summary>
		/// Unit
		/// </summary>
		[Column(Name = "Unit", DbType = "varchar(40)", Storage = "_Unit", UpdateCheck = UpdateCheck.Never)]
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
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
		private string _ApplyReason;
		/// <summary>
		/// ApplyReason
		/// </summary>
		[Column(Name = "ApplyReason", DbType = "varchar(200)", Storage = "_ApplyReason", UpdateCheck = UpdateCheck.Never)]
		public string ApplyReason
		{
			get { return _ApplyReason; }
			set { _ApplyReason = value; }
		}
	}
}