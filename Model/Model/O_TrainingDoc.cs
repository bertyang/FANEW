using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "O_TrainingDoc")]
	public class O_TrainingDoc
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
		private int _Type;
		/// <summary>
		/// Type
		/// </summary>
		[Column(Name = "Type", DbType = "int", Storage = "_Type", UpdateCheck = UpdateCheck.Never)]
		public int Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		private string _Title;
		/// <summary>
		/// Title
		/// </summary>
		[Column(Name = "Title", DbType = "varchar(50)", Storage = "_Title", UpdateCheck = UpdateCheck.Never)]
		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}
		private double _Score;
		/// <summary>
		/// Score
		/// </summary>
		[Column(Name = "Score", DbType = "float", Storage = "_Score", UpdateCheck = UpdateCheck.Never)]
		public double Score
		{
			get { return _Score; }
			set { _Score = value; }
		}
		private string _Organization;
		/// <summary>
		/// Organization
		/// </summary>
		[Column(Name = "Organization", DbType = "varchar(50)", Storage = "_Organization", UpdateCheck = UpdateCheck.Never)]
		public string Organization
		{
			get { return _Organization; }
			set { _Organization = value; }
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
		private string _Unit;
		/// <summary>
		/// Unit
		/// </summary>
		[Column(Name = "Unit", DbType = "varchar(50)", Storage = "_Unit", UpdateCheck = UpdateCheck.Never)]
		public string Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "varchar(50)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
	}
}