using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_BILL_IN")]
	public class S_BILL_IN
	{
		private string _BillNo;
		/// <summary>
		/// BillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "BillNo", DbType = "varchar(20)", Storage = "_BillNo")]
		public string BillNo
		{
			get { return _BillNo; }
			set { _BillNo = value; }
		}
		private int _StoreHouseID;
		/// <summary>
		/// StoreHouseID
		/// </summary>
		[Column(Name = "StoreHouseID", DbType = "int", Storage = "_StoreHouseID", UpdateCheck = UpdateCheck.Never)]
		public int StoreHouseID
		{
			get { return _StoreHouseID; }
			set { _StoreHouseID = value; }
		}
		private string _OldBillNo;
		/// <summary>
		/// OldBillNo
		/// </summary>
		[Column(Name = "OldBillNo", DbType = "varchar(20)", Storage = "_OldBillNo", UpdateCheck = UpdateCheck.Never)]
		public string OldBillNo
		{
			get { return _OldBillNo; }
			set { _OldBillNo = value; }
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
		[Column(Name = "Remark", DbType = "nvarchar(510)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private string _InvoiceNo;
		/// <summary>
		/// InvoiceNo
		/// </summary>
		[Column(Name = "InvoiceNo", DbType = "varchar(50)", Storage = "_InvoiceNo", UpdateCheck = UpdateCheck.Never)]
		public string InvoiceNo
		{
			get { return _InvoiceNo; }
			set { _InvoiceNo = value; }
		}
	}
}