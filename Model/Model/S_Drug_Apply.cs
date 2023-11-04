using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Drug_Apply")]
	public class S_Drug_Apply
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
		private int? _StoreHouseID;
		/// <summary>
		/// StoreHouseID
		/// </summary>
		[Column(Name = "StoreHouseID", DbType = "int", Storage = "_StoreHouseID", UpdateCheck = UpdateCheck.Never)]
		public int? StoreHouseID
		{
			get { return _StoreHouseID; }
			set { _StoreHouseID = value; }
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
		private string _TransferBillNo;
		/// <summary>
		/// TransferBillNo
		/// </summary>
		[Column(Name = "TransferBillNo", DbType = "varchar(20)", Storage = "_TransferBillNo", UpdateCheck = UpdateCheck.Never)]
		public string TransferBillNo
		{
			get { return _TransferBillNo; }
			set { _TransferBillNo = value; }
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
	}
}