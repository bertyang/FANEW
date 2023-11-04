using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientGradeStandard")]
	public class M_PatientGradeStandard
	{
		private string _ProjectID;
		/// <summary>
		/// ProjectID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "ProjectID", DbType = "varchar(50)", Storage = "_ProjectID")]
		public string ProjectID
		{
			get { return _ProjectID; }
			set { _ProjectID = value; }
		}
		private string _ProjectName;
		/// <summary>
		/// ProjectName
		/// </summary>
		[Column(Name = "ProjectName", DbType = "varchar(50)", Storage = "_ProjectName", UpdateCheck = UpdateCheck.Never)]
		public string ProjectName
		{
			get { return _ProjectName; }
			set { _ProjectName = value; }
		}
		private string _Request;
		/// <summary>
		/// Request
		/// </summary>
		[Column(Name = "Request", DbType = "varchar(500)", Storage = "_Request", UpdateCheck = UpdateCheck.Never)]
		public string Request
		{
			get { return _Request; }
			set { _Request = value; }
		}
		private double _Mark;
		/// <summary>
		/// Mark
		/// </summary>
		[Column(Name = "Mark", DbType = "float", Storage = "_Mark", UpdateCheck = UpdateCheck.Never)]
		public double Mark
		{
			get { return _Mark; }
			set { _Mark = value; }
		}
		private bool _IsAdd;
		/// <summary>
		/// IsAdd
		/// </summary>
		[Column(Name = "IsAdd", DbType = "bit", Storage = "_IsAdd", UpdateCheck = UpdateCheck.Never)]
		public bool IsAdd
		{
			get { return _IsAdd; }
			set { _IsAdd = value; }
		}
		private double _DetailMark;
		/// <summary>
		/// DetailMark
		/// </summary>
		[Column(Name = "DetailMark", DbType = "float", Storage = "_DetailMark", UpdateCheck = UpdateCheck.Never)]
		public double DetailMark
		{
			get { return _DetailMark; }
			set { _DetailMark = value; }
		}
		private string _Deduct;
		/// <summary>
		/// Deduct
		/// </summary>
		[Column(Name = "Deduct", DbType = "varchar(100)", Storage = "_Deduct", UpdateCheck = UpdateCheck.Never)]
		public string Deduct
		{
			get { return _Deduct; }
			set { _Deduct = value; }
		}
		private int _DisOrder;
		/// <summary>
		/// DisOrder
		/// </summary>
		[Column(Name = "DisOrder", DbType = "int", Storage = "_DisOrder", UpdateCheck = UpdateCheck.Never)]
		public int DisOrder
		{
			get { return _DisOrder; }
			set { _DisOrder = value; }
		}
		private int _OrderID;
		/// <summary>
		/// OrderID
		/// </summary>
		[Column(Name = "OrderID", DbType = "int", Storage = "_OrderID", UpdateCheck = UpdateCheck.Never)]
		public int OrderID
		{
			get { return _OrderID; }
			set { _OrderID = value; }
		}
		private bool _IsEffect;
		/// <summary>
		/// IsEffect
		/// </summary>
		[Column(Name = "IsEffect", DbType = "bit", Storage = "_IsEffect", UpdateCheck = UpdateCheck.Never)]
		public bool IsEffect
		{
			get { return _IsEffect; }
			set { _IsEffect = value; }
		}
	}
}