using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_BILL_APPLY")]
	public class S_BILL_APPLY
	{
		private int _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BillNo", DbType = "int", Storage = "_BillNo")]
		public int BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
		private DateTime? _CreateTime;
		/// <summary>
		/// CreateTime
		/// </summary>
		[Column(Name = "CreateTime", DbType = "datetime", Storage = "_CreateTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? CreateTime
		{
			get { return _CreateTime; }
			set { _CreateTime = value; }
		}
		private int? _CreateWorkerID;
		/// <summary>
		/// CreateWorkerID
		/// </summary>
		[Column(Name = "CreateWorkerID", DbType = "int", Storage = "_CreateWorkerID", UpdateCheck = UpdateCheck.Never)]
		public int? CreateWorkerID
		{
			get { return _CreateWorkerID; }
			set { _CreateWorkerID = value; }
		}
		private string _Status;
		/// <summary>
		/// Status
		/// </summary>
		[Column(Name = "Status", DbType = "char(1)", Storage = "_Status", UpdateCheck = UpdateCheck.Never)]
		public string Status
		{
			get { return _Status; }
			set { _Status = value; }
		}
		private int? _WorkFlowNo;
		/// <summary>
		/// WorkFlowNo
		/// </summary>
		[Column(Name = "WorkFlowNo", DbType = "int", Storage = "_WorkFlowNo", UpdateCheck = UpdateCheck.Never)]
		public int? WorkFlowNo
		{
			get { return _WorkFlowNo; }
			set { _WorkFlowNo = value; }
		}
		private string _Remark;
		/// <summary>
		/// Remark
		/// </summary>
		[Column(Name = "Remark", DbType = "varchar(255)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private string _BillOutNo;
		/// <summary>
		/// BillOutNo
		/// </summary>
		[Column(Name = "BillOutNo", DbType = "varchar(20)", Storage = "_BillOutNo", UpdateCheck = UpdateCheck.Never)]
		public string BillOutNo
		{
			get { return _BillOutNo; }
			set { _BillOutNo = value; }
		}
	}
}