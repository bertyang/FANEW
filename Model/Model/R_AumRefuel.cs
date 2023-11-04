using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "R_AumRefuel")]
	public class R_AumRefuel
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
		private string _AmbulanceID;
		/// <summary>
		/// AmbulanceID
		/// </summary>
		[Column(Name = "AmbulanceID", DbType = "char(5)", Storage = "_AmbulanceID", UpdateCheck = UpdateCheck.Never)]
		public string AmbulanceID
		{
			get { return _AmbulanceID; }
			set { _AmbulanceID = value; }
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
		private double _CurrentKilometer;
		/// <summary>
		/// CurrentKilometer
		/// </summary>
		[Column(Name = "CurrentKilometer", DbType = "float", Storage = "_CurrentKilometer", UpdateCheck = UpdateCheck.Never)]
		public double CurrentKilometer
		{
			get { return _CurrentKilometer; }
			set { _CurrentKilometer = value; }
		}
		private double _Kilo;
		/// <summary>
		/// Kilo
		/// </summary>
		[Column(Name = "Kilo", DbType = "float", Storage = "_Kilo", UpdateCheck = UpdateCheck.Never)]
		public double Kilo
		{
			get { return _Kilo; }
			set { _Kilo = value; }
		}
		private double _NextKilometer;
		/// <summary>
		/// NextKilometer
		/// </summary>
		[Column(Name = "NextKilometer", DbType = "float", Storage = "_NextKilometer", UpdateCheck = UpdateCheck.Never)]
		public double NextKilometer
		{
			get { return _NextKilometer; }
			set { _NextKilometer = value; }
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