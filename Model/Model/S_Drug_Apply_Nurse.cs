using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_Drug_Apply_Nurse")]
	public class S_Drug_Apply_Nurse
	{
		private int _NurseBillNo;
		/// <summary>
		/// NurseBillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "NurseBillNo", DbType = "int", Storage = "_NurseBillNo")]
		public int NurseBillNo
		{
			get { return _NurseBillNo; }
			set { _NurseBillNo = value; }
		}
		private int _NurseHeadBillNo;
		/// <summary>
		/// NurseHeadBillNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "NurseHeadBillNo", DbType = "int", Storage = "_NurseHeadBillNo")]
		public int NurseHeadBillNo
		{
			get { return _NurseHeadBillNo; }
			set { _NurseHeadBillNo = value; }
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
	}
}