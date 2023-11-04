using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_1")]
	public class TB_1
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
		private string _Worker;
		/// <summary>
		/// Worker
		/// </summary>
		[Column(Name = "Worker", DbType = "varchar(50)", Storage = "_Worker", UpdateCheck = UpdateCheck.Never)]
		public string Worker
		{
			get { return _Worker; }
			set { _Worker = value; }
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
		private DateTime _StartTime;
		/// <summary>
		/// StartTime
		/// </summary>
		[Column(Name = "StartTime", DbType = "datetime", Storage = "_StartTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}
		private DateTime _EndTime;
		/// <summary>
		/// EndTime
		/// </summary>
		[Column(Name = "EndTime", DbType = "datetime", Storage = "_EndTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}
		private int _Day;
		/// <summary>
		/// Day
		/// </summary>
		[Column(Name = "Day", DbType = "int", Storage = "_Day", UpdateCheck = UpdateCheck.Never)]
		public int Day
		{
			get { return _Day; }
			set { _Day = value; }
		}
		private string _LeaveReason;
		/// <summary>
		/// LeaveReason
		/// </summary>
		[Column(Name = "LeaveReason", DbType = "nvarchar(510)", Storage = "_LeaveReason", UpdateCheck = UpdateCheck.Never)]
		public string LeaveReason
		{
			get { return _LeaveReason; }
			set { _LeaveReason = value; }
		}
		private string _Destination;
		/// <summary>
		/// Destination
		/// </summary>
		[Column(Name = "Destination", DbType = "varchar(200)", Storage = "_Destination", UpdateCheck = UpdateCheck.Never)]
		public string Destination
		{
			get { return _Destination; }
			set { _Destination = value; }
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
		private double _Hour;
		/// <summary>
		/// Hour
		/// </summary>
		[Column(Name = "Hour", DbType = "float", Storage = "_Hour", UpdateCheck = UpdateCheck.Never)]
		public double Hour
		{
			get { return _Hour; }
			set { _Hour = value; }
		}
	}
}