using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_ConsumableRecord")]
	public class M_ConsumableRecord
	{
		private int _ConsumableID;
		/// <summary>
		/// ConsumableID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ConsumableID", DbType = "int", Storage = "_ConsumableID")]
		public int ConsumableID
		{
			get { return _ConsumableID; }
			set { _ConsumableID = value; }
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
		private string _CROrder;
		/// <summary>
		/// CROrder
		/// </summary>
		[Column(Name = "CROrder", DbType = "varchar(10)", Storage = "_CROrder", UpdateCheck = UpdateCheck.Never)]
		public string CROrder
		{
			get { return _CROrder; }
			set { _CROrder = value; }
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
		private int _ResID;
		/// <summary>
		/// ResID
		/// </summary>
		[Column(Name = "ResID", DbType = "int", Storage = "_ResID", UpdateCheck = UpdateCheck.Never)]
		public int ResID
		{
			get { return _ResID; }
			set { _ResID = value; }
		}
		private string _UseStyle;
		/// <summary>
		/// UseStyle
		/// </summary>
		[Column(Name = "UseStyle", DbType = "varchar(20)", Storage = "_UseStyle", UpdateCheck = UpdateCheck.Never)]
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
	}
}