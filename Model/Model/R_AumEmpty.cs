using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "R_AumEmpty")]
	public class R_AumEmpty
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
		private bool _ISDay;
		/// <summary>
		/// ISDay
		/// </summary>
		[Column(Name = "ISDay", DbType = "bit", Storage = "_ISDay", UpdateCheck = UpdateCheck.Never)]
		public bool ISDay
		{
			get { return _ISDay; }
			set { _ISDay = value; }
		}
		private DateTime _Date;
		/// <summary>
		/// Date
		/// </summary>
		[Column(Name = "Date", DbType = "datetime", Storage = "_Date", UpdateCheck = UpdateCheck.Never)]
		public DateTime Date
		{
			get { return _Date; }
			set { _Date = value; }
		}
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "varchar(20)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private bool _Sex;
		/// <summary>
		/// Sex
		/// </summary>
		[Column(Name = "Sex", DbType = "bit", Storage = "_Sex", UpdateCheck = UpdateCheck.Never)]
		public bool Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}
		private string _Address;
		/// <summary>
		/// Address
		/// </summary>
		[Column(Name = "Address", DbType = "varchar(100)", Storage = "_Address", UpdateCheck = UpdateCheck.Never)]
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}
		private double _Kilometer;
		/// <summary>
		/// Kilometer
		/// </summary>
		[Column(Name = "Kilometer", DbType = "float", Storage = "_Kilometer", UpdateCheck = UpdateCheck.Never)]
		public double Kilometer
		{
			get { return _Kilometer; }
			set { _Kilometer = value; }
		}
		private decimal _Charge;
		/// <summary>
		/// Charge
		/// </summary>
		[Column(Name = "Charge", DbType = "money", Storage = "_Charge", UpdateCheck = UpdateCheck.Never)]
		public decimal Charge
		{
			get { return _Charge; }
			set { _Charge = value; }
		}
		private string _Remark;
		/// <summary>
		/// Remark
		/// </summary>
		[Column(Name = "Remark", DbType = "varchar(200)", Storage = "_Remark", UpdateCheck = UpdateCheck.Never)]
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private int _WorkID;
		/// <summary>
		/// WorkID
		/// </summary>
		[Column(Name = "WorkID", DbType = "int", Storage = "_WorkID", UpdateCheck = UpdateCheck.Never)]
		public int WorkID
		{
			get { return _WorkID; }
			set { _WorkID = value; }
		}
		private DateTime _CreateDate;
		/// <summary>
		/// CreateDate
		/// </summary>
		[Column(Name = "CreateDate", DbType = "datetime", Storage = "_CreateDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime CreateDate
		{
			get { return _CreateDate; }
			set { _CreateDate = value; }
		}
		private DateTime? _ModifyDate;
		/// <summary>
		/// ModifyDate
		/// </summary>
		[Column(Name = "ModifyDate", DbType = "datetime", Storage = "_ModifyDate", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ModifyDate
		{
			get { return _ModifyDate; }
			set { _ModifyDate = value; }
		}
	}
}