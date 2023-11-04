using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_99")]
	public class TB_99
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
		private int _FlowNo;
		/// <summary>
		/// FlowNo
		/// </summary>
		[Column(Name = "FlowNo", DbType = "int", Storage = "_FlowNo", UpdateCheck = UpdateCheck.Never)]
		public int FlowNo
		{
			get { return _FlowNo; }
			set { _FlowNo = value; }
		}
		private string _CreateWorker;
		/// <summary>
		/// CreateWorker
		/// </summary>
		[Column(Name = "CreateWorker", DbType = "varchar(50)", Storage = "_CreateWorker", UpdateCheck = UpdateCheck.Never)]
		public string CreateWorker
		{
			get { return _CreateWorker; }
			set { _CreateWorker = value; }
		}
		private DateTime _CreateTime;
		/// <summary>
		/// CreateTime
		/// </summary>
		[Column(Name = "CreateTime", DbType = "datetime", Storage = "_CreateTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime CreateTime
		{
			get { return _CreateTime; }
			set { _CreateTime = value; }
		}
		private string _Project;
		/// <summary>
		/// Project
		/// </summary>
		[Column(Name = "Project", DbType = "varchar(100)", Storage = "_Project", UpdateCheck = UpdateCheck.Never)]
		public string Project
		{
			get { return _Project; }
			set { _Project = value; }
		}
		private string _WorkTask;
		/// <summary>
		/// WorkTask
		/// </summary>
		[Column(Name = "WorkTask", DbType = "text(16)", Storage = "_WorkTask", UpdateCheck = UpdateCheck.Never)]
		public string WorkTask
		{
			get { return _WorkTask; }
			set { _WorkTask = value; }
		}
		private double _Workload;
		/// <summary>
		/// Workload
		/// </summary>
		[Column(Name = "Workload", DbType = "float", Storage = "_Workload", UpdateCheck = UpdateCheck.Never)]
		public double Workload
		{
			get { return _Workload; }
			set { _Workload = value; }
		}
	}
}