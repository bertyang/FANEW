using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_GOODS_FIXED_AUDIT")]
	public class S_GOODS_FIXED_AUDIT
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
		private DateTime _BillTime;
		/// <summary>
		/// BillTime
		/// </summary>
		[Column(Name = "BillTime", DbType = "datetime", Storage = "_BillTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime BillTime
		{
			get { return _BillTime; }
			set { _BillTime = value; }
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
		private int _CreateWorkerID;
		/// <summary>
		/// CreateWorkerID
		/// </summary>
		[Column(Name = "CreateWorkerID", DbType = "int", Storage = "_CreateWorkerID", UpdateCheck = UpdateCheck.Never)]
		public int CreateWorkerID
		{
			get { return _CreateWorkerID; }
			set { _CreateWorkerID = value; }
		}
		private int _GOODSID;
		/// <summary>
		/// GOODSID
		/// </summary>
		[Column(Name = "GOODSID", DbType = "int", Storage = "_GOODSID", UpdateCheck = UpdateCheck.Never)]
		public int GOODSID
		{
			get { return _GOODSID; }
			set { _GOODSID = value; }
		}
		private int _DepartID;
		/// <summary>
		/// DepartID
		/// </summary>
		[Column(Name = "DepartID", DbType = "int", Storage = "_DepartID", UpdateCheck = UpdateCheck.Never)]
		public int DepartID
		{
			get { return _DepartID; }
			set { _DepartID = value; }
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
		private int _WorkFlowId;
		/// <summary>
		/// WorkFlowId
		/// </summary>
		[Column(Name = "WorkFlowId", DbType = "int", Storage = "_WorkFlowId", UpdateCheck = UpdateCheck.Never)]
		public int WorkFlowId
		{
			get { return _WorkFlowId; }
			set { _WorkFlowId = value; }
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
	}
}