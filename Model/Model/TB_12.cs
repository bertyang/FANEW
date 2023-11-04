using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_12")]
	public class TB_12
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
		private string _Goods;
		/// <summary>
		/// Goods
		/// </summary>
		[Column(Name = "Goods", DbType = "varchar(50)", Storage = "_Goods", UpdateCheck = UpdateCheck.Never)]
		public string Goods
		{
			get { return _Goods; }
			set { _Goods = value; }
		}
		private string _Type;
		/// <summary>
		/// Type
		/// </summary>
		[Column(Name = "Type", DbType = "varchar(40)", Storage = "_Type", UpdateCheck = UpdateCheck.Never)]
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
		}
		private string _CarNo;
		/// <summary>
		/// CarNo
		/// </summary>
		[Column(Name = "CarNo", DbType = "varchar(20)", Storage = "_CarNo", UpdateCheck = UpdateCheck.Never)]
		public string CarNo
		{
			get { return _CarNo; }
			set { _CarNo = value; }
		}
		private string _Symptom;
		/// <summary>
		/// Symptom
		/// </summary>
		[Column(Name = "Symptom", DbType = "varchar(100)", Storage = "_Symptom", UpdateCheck = UpdateCheck.Never)]
		public string Symptom
		{
			get { return _Symptom; }
			set { _Symptom = value; }
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
		private DateTime? _AppointmentDate;
		/// <summary>
		/// AppointmentDate
		/// </summary>
		[Column(Name = "AppointmentDate", DbType = "datetime", Storage = "_AppointmentDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime? AppointmentDate
		{
			get { return _AppointmentDate; }
			set { _AppointmentDate = value; }
		}
		private string _Satisfaction;
		/// <summary>
		/// Satisfaction
		/// </summary>
		[Column(Name = "Satisfaction", DbType = "char(1)", Storage = "_Satisfaction", UpdateCheck = UpdateCheck.Never)]
		public string Satisfaction
		{
			get { return _Satisfaction; }
			set { _Satisfaction = value; }
		}
		private string _Opinion;
		/// <summary>
		/// Opinion
		/// </summary>
		[Column(Name = "Opinion", DbType = "nvarchar(200)", Storage = "_Opinion", UpdateCheck = UpdateCheck.Never)]
		public string Opinion
		{
			get { return _Opinion; }
			set { _Opinion = value; }
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
		private int _ApplyWorkerID;
		/// <summary>
		/// ApplyWorkerID
		/// </summary>
		[Column(Name = "ApplyWorkerID", DbType = "int", Storage = "_ApplyWorkerID", UpdateCheck = UpdateCheck.Never)]
		public int ApplyWorkerID
		{
			get { return _ApplyWorkerID; }
			set { _ApplyWorkerID = value; }
		}
		private int _DepartManagerID;
		/// <summary>
		/// DepartManagerID
		/// </summary>
		[Column(Name = "DepartManagerID", DbType = "int", Storage = "_DepartManagerID", UpdateCheck = UpdateCheck.Never)]
		public int DepartManagerID
		{
			get { return _DepartManagerID; }
			set { _DepartManagerID = value; }
		}
		private DateTime? _FinishTime;
		/// <summary>
		/// FinishTime
		/// </summary>
		[Column(Name = "FinishTime", DbType = "datetime", Storage = "_FinishTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? FinishTime
		{
			get { return _FinishTime; }
			set { _FinishTime = value; }
		}
		private string _GoodsCategory;
		/// <summary>
		/// GoodsCategory
		/// </summary>
		[Column(Name = "GoodsCategory", DbType = "varchar(20)", Storage = "_GoodsCategory", UpdateCheck = UpdateCheck.Never)]
		public string GoodsCategory
		{
			get { return _GoodsCategory; }
			set { _GoodsCategory = value; }
		}
		private string _MaterialName;
		/// <summary>
		/// MaterialName
		/// </summary>
		[Column(Name = "MaterialName", DbType = "nvarchar(100)", Storage = "_MaterialName", UpdateCheck = UpdateCheck.Never)]
		public string MaterialName
		{
			get { return _MaterialName; }
			set { _MaterialName = value; }
		}
		private decimal? _MaterialAmount;
		/// <summary>
		/// MaterialAmount
		/// </summary>
		[Column(Name = "MaterialAmount", DbType = "money", Storage = "_MaterialAmount", UpdateCheck = UpdateCheck.Never)]
		public decimal? MaterialAmount
		{
			get { return _MaterialAmount; }
			set { _MaterialAmount = value; }
		}
		private int? _cost;
		/// <summary>
		/// cost
		/// </summary>
		[Column(Name = "cost", DbType = "int", Storage = "_cost", UpdateCheck = UpdateCheck.Never)]
		public int? cost
		{
			get { return _cost; }
			set { _cost = value; }
		}
		private string _EquipmentNo;
		/// <summary>
		/// EquipmentNo
		/// </summary>
		[Column(Name = "EquipmentNo", DbType = "nvarchar(200)", Storage = "_EquipmentNo", UpdateCheck = UpdateCheck.Never)]
		public string EquipmentNo
		{
			get { return _EquipmentNo; }
			set { _EquipmentNo = value; }
		}
	}
}