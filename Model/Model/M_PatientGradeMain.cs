using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientGradeMain")]
	public class M_PatientGradeMain
	{
		private string _TaskCode;
		/// <summary>
		/// TaskCode
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TaskCode", DbType = "char(20)", Storage = "_TaskCode")]
		public string TaskCode
		{
			get { return _TaskCode; }
			set { _TaskCode = value; }
		}
		private int _PatientOrder;
		/// <summary>
		/// PatientOrder
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "PatientOrder", DbType = "int", Storage = "_PatientOrder")]
		public int PatientOrder
		{
			get { return _PatientOrder; }
			set { _PatientOrder = value; }
		}
		private double? _Score;
		/// <summary>
		/// Score
		/// </summary>
		[Column(Name = "Score", DbType = "float", Storage = "_Score", UpdateCheck = UpdateCheck.Never)]
		public double? Score
		{
			get { return _Score; }
			set { _Score = value; }
		}
		private double? _Deducted;
		/// <summary>
		/// Deducted
		/// </summary>
		[Column(Name = "Deducted", DbType = "float", Storage = "_Deducted", UpdateCheck = UpdateCheck.Never)]
		public double? Deducted
		{
			get { return _Deducted; }
			set { _Deducted = value; }
		}
		private double? _Plus;
		/// <summary>
		/// Plus
		/// </summary>
		[Column(Name = "Plus", DbType = "float", Storage = "_Plus", UpdateCheck = UpdateCheck.Never)]
		public double? Plus
		{
			get { return _Plus; }
			set { _Plus = value; }
		}
	}
}