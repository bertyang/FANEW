using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "R_AumTrans")]
	public class R_AumTrans
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
		private double _BeginKilometer;
		/// <summary>
		/// BeginKilometer
		/// </summary>
		[Column(Name = "BeginKilometer", DbType = "float", Storage = "_BeginKilometer", UpdateCheck = UpdateCheck.Never)]
		public double BeginKilometer
		{
			get { return _BeginKilometer; }
			set { _BeginKilometer = value; }
		}
		private double _EndKilometer;
		/// <summary>
		/// EndKilometer
		/// </summary>
		[Column(Name = "EndKilometer", DbType = "float", Storage = "_EndKilometer", UpdateCheck = UpdateCheck.Never)]
		public double EndKilometer
		{
			get { return _EndKilometer; }
			set { _EndKilometer = value; }
		}
		private double _TravelKilometer;
		/// <summary>
		/// TravelKilometer
		/// </summary>
		[Column(Name = "TravelKilometer", DbType = "float", Storage = "_TravelKilometer", UpdateCheck = UpdateCheck.Never)]
		public double TravelKilometer
		{
			get { return _TravelKilometer; }
			set { _TravelKilometer = value; }
		}
		private bool _ISRefuel;
		/// <summary>
		/// ISRefuel
		/// </summary>
		[Column(Name = "ISRefuel", DbType = "bit", Storage = "_ISRefuel", UpdateCheck = UpdateCheck.Never)]
		public bool ISRefuel
		{
			get { return _ISRefuel; }
			set { _ISRefuel = value; }
		}
		private bool _ISLicense;
		/// <summary>
		/// ISLicense
		/// </summary>
		[Column(Name = "ISLicense", DbType = "bit", Storage = "_ISLicense", UpdateCheck = UpdateCheck.Never)]
		public bool ISLicense
		{
			get { return _ISLicense; }
			set { _ISLicense = value; }
		}
		private bool _ISTools;
		/// <summary>
		/// ISTools
		/// </summary>
		[Column(Name = "ISTools", DbType = "bit", Storage = "_ISTools", UpdateCheck = UpdateCheck.Never)]
		public bool ISTools
		{
			get { return _ISTools; }
			set { _ISTools = value; }
		}
		private bool _ISEngine;
		/// <summary>
		/// ISEngine
		/// </summary>
		[Column(Name = "ISEngine", DbType = "bit", Storage = "_ISEngine", UpdateCheck = UpdateCheck.Never)]
		public bool ISEngine
		{
			get { return _ISEngine; }
			set { _ISEngine = value; }
		}
		private bool _ISSteering;
		/// <summary>
		/// ISSteering
		/// </summary>
		[Column(Name = "ISSteering", DbType = "bit", Storage = "_ISSteering", UpdateCheck = UpdateCheck.Never)]
		public bool ISSteering
		{
			get { return _ISSteering; }
			set { _ISSteering = value; }
		}
		private bool _ISBrake;
		/// <summary>
		/// ISBrake
		/// </summary>
		[Column(Name = "ISBrake", DbType = "bit", Storage = "_ISBrake", UpdateCheck = UpdateCheck.Never)]
		public bool ISBrake
		{
			get { return _ISBrake; }
			set { _ISBrake = value; }
		}
		private bool _ISLight;
		/// <summary>
		/// ISLight
		/// </summary>
		[Column(Name = "ISLight", DbType = "bit", Storage = "_ISLight", UpdateCheck = UpdateCheck.Never)]
		public bool ISLight
		{
			get { return _ISLight; }
			set { _ISLight = value; }
		}
		private bool _ISAlarmLight;
		/// <summary>
		/// ISAlarmLight
		/// </summary>
		[Column(Name = "ISAlarmLight", DbType = "bit", Storage = "_ISAlarmLight", UpdateCheck = UpdateCheck.Never)]
		public bool ISAlarmLight
		{
			get { return _ISAlarmLight; }
			set { _ISAlarmLight = value; }
		}
		private bool _ISTire;
		/// <summary>
		/// ISTire
		/// </summary>
		[Column(Name = "ISTire", DbType = "bit", Storage = "_ISTire", UpdateCheck = UpdateCheck.Never)]
		public bool ISTire
		{
			get { return _ISTire; }
			set { _ISTire = value; }
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