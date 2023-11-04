using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_UpdateLog")]
	public class M_UpdateLog
	{
		private Int64 _logID;
		/// <summary>
		/// logID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "logID", DbType = "bigint", Storage = "_logID")]
		public Int64 logID
		{
			get { return _logID; }
			set { _logID = value; }
		}
		private string _TableName;
		/// <summary>
		/// TableName
		/// </summary>
		[Column(Name = "TableName", DbType = "varchar(50)", Storage = "_TableName", UpdateCheck = UpdateCheck.Never)]
		public string TableName
		{
			get { return _TableName; }
			set { _TableName = value; }
		}
		private string _ModifyItem;
		/// <summary>
		/// ModifyItem
		/// </summary>
		[Column(Name = "ModifyItem", DbType = "varchar(50)", Storage = "_ModifyItem", UpdateCheck = UpdateCheck.Never)]
		public string ModifyItem
		{
			get { return _ModifyItem; }
			set { _ModifyItem = value; }
		}
		private string _OriginContent;
		/// <summary>
		/// OriginContent
		/// </summary>
		[Column(Name = "OriginContent", DbType = "text(16)", Storage = "_OriginContent", UpdateCheck = UpdateCheck.Never)]
		public string OriginContent
		{
			get { return _OriginContent; }
			set { _OriginContent = value; }
		}
		private string _NewContent;
		/// <summary>
		/// NewContent
		/// </summary>
		[Column(Name = "NewContent", DbType = "text(16)", Storage = "_NewContent", UpdateCheck = UpdateCheck.Never)]
		public string NewContent
		{
			get { return _NewContent; }
			set { _NewContent = value; }
		}
		private DateTime _updateTime;
		/// <summary>
		/// updateTime
		/// </summary>
		[Column(Name = "updateTime", DbType = "datetime", Storage = "_updateTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime updateTime
		{
			get { return _updateTime; }
			set { _updateTime = value; }
		}
		private int _workerID;
		/// <summary>
		/// workerID
		/// </summary>
		[Column(Name = "workerID", DbType = "int", Storage = "_workerID", UpdateCheck = UpdateCheck.Never)]
		public int workerID
		{
			get { return _workerID; }
			set { _workerID = value; }
		}
		private string _PatientRecordID;
		/// <summary>
		/// PatientRecordID
		/// </summary>
		[Column(Name = "PatientRecordID", DbType = "varchar(50)", Storage = "_PatientRecordID", UpdateCheck = UpdateCheck.Never)]
		public string PatientRecordID
		{
			get { return _PatientRecordID; }
			set { _PatientRecordID = value; }
		}
	}
}