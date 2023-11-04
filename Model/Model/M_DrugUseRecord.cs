using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_DrugUseRecord")]
	public class M_DrugUseRecord
	{
		private int _DrugUseID;
		/// <summary>
		/// DrugUseID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "DrugUseID", DbType = "int", Storage = "_DrugUseID")]
		public int DrugUseID
		{
			get { return _DrugUseID; }
			set { _DrugUseID = value; }
		}
		private string _TROrder;
		/// <summary>
		/// TROrder
		/// </summary>
		[Column(Name = "TROrder", DbType = "varchar(10)", Storage = "_TROrder", UpdateCheck = UpdateCheck.Never)]
		public string TROrder
		{
			get { return _TROrder; }
			set { _TROrder = value; }
		}
		private string _PatientRecordID;
		/// <summary>
		/// PatientRecordID
		/// </summary>
		[Column(Name = "PatientRecordID", DbType = "varchar(25)", Storage = "_PatientRecordID", UpdateCheck = UpdateCheck.Never)]
		public string PatientRecordID
		{
			get { return _PatientRecordID; }
			set { _PatientRecordID = value; }
		}
		private string _GroupNo;
		/// <summary>
		/// GroupNo
		/// </summary>
		[Column(Name = "GroupNo", DbType = "varchar(10)", Storage = "_GroupNo", UpdateCheck = UpdateCheck.Never)]
		public string GroupNo
		{
			get { return _GroupNo; }
			set { _GroupNo = value; }
		}
		private string _UseNo;
		/// <summary>
		/// UseNo
		/// </summary>
		[Column(Name = "UseNo", DbType = "varchar(10)", Storage = "_UseNo", UpdateCheck = UpdateCheck.Never)]
		public string UseNo
		{
			get { return _UseNo; }
			set { _UseNo = value; }
		}
		private int _DrugsID;
		/// <summary>
		/// DrugsID
		/// </summary>
		[Column(Name = "DrugsID", DbType = "int", Storage = "_DrugsID", UpdateCheck = UpdateCheck.Never)]
		public int DrugsID
		{
			get { return _DrugsID; }
			set { _DrugsID = value; }
		}
		private double _Num;
		/// <summary>
		/// Num
		/// </summary>
		[Column(Name = "Num", DbType = "float", Storage = "_Num", UpdateCheck = UpdateCheck.Never)]
		public double Num
		{
			get { return _Num; }
			set { _Num = value; }
		}
		private double _ActualDose;
		/// <summary>
		/// ActualDose
		/// </summary>
		[Column(Name = "ActualDose", DbType = "float", Storage = "_ActualDose", UpdateCheck = UpdateCheck.Never)]
		public double ActualDose
		{
			get { return _ActualDose; }
			set { _ActualDose = value; }
		}
		private double _Price;
		/// <summary>
		/// Price
		/// </summary>
		[Column(Name = "Price", DbType = "float", Storage = "_Price", UpdateCheck = UpdateCheck.Never)]
		public double Price
		{
			get { return _Price; }
			set { _Price = value; }
		}
		private string _UseStyle;
		/// <summary>
		/// UseStyle
		/// </summary>
		[Column(Name = "UseStyle", DbType = "varchar(50)", Storage = "_UseStyle", UpdateCheck = UpdateCheck.Never)]
		public string UseStyle
		{
			get { return _UseStyle; }
			set { _UseStyle = value; }
		}
		private string _GoodsName;
		/// <summary>
		/// GoodsName
		/// </summary>
		[Column(Name = "GoodsName", DbType = "varchar(100)", Storage = "_GoodsName", UpdateCheck = UpdateCheck.Never)]
		public string GoodsName
		{
			get { return _GoodsName; }
			set { _GoodsName = value; }
		}
		private string _Loss;
		/// <summary>
		/// Loss
		/// </summary>
		[Column(Name = "Loss", DbType = "varchar(20)", Storage = "_Loss", UpdateCheck = UpdateCheck.Never)]
		public string Loss
		{
			get { return _Loss; }
			set { _Loss = value; }
		}
		private string _Spec;
		/// <summary>
		/// Spec
		/// </summary>
		[Column(Name = "Spec", DbType = "varchar(50)", Storage = "_Spec", UpdateCheck = UpdateCheck.Never)]
		public string Spec
		{
			get { return _Spec; }
			set { _Spec = value; }
		}
		private double _LossVal;
		/// <summary>
		/// LossVal
		/// </summary>
		[Column(Name = "LossVal", DbType = "float", Storage = "_LossVal", UpdateCheck = UpdateCheck.Never)]
		public double LossVal
		{
			get { return _LossVal; }
			set { _LossVal = value; }
		}
		private string _UseNum;
		/// <summary>
		/// UseNum
		/// </summary>
		[Column(Name = "UseNum", DbType = "varchar(30)", Storage = "_UseNum", UpdateCheck = UpdateCheck.Never)]
		public string UseNum
		{
			get { return _UseNum; }
			set { _UseNum = value; }
		}
	}
}