using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_Utstein")]
	public class M_Utstein
	{
		private string _PatientRecordID;
		/// <summary>
		/// PatientRecordID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "PatientRecordID", DbType = "varchar(25)", Storage = "_PatientRecordID")]
		public string PatientRecordID
		{
			get { return _PatientRecordID; }
			set { _PatientRecordID = value; }
		}
		private DateTime? _HelpTime;
		/// <summary>
		/// HelpTime
		/// </summary>
		[Column(Name = "HelpTime", DbType = "datetime", Storage = "_HelpTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? HelpTime
		{
			get { return _HelpTime; }
			set { _HelpTime = value; }
		}
		private DateTime? _ComaTime;
		/// <summary>
		/// ComaTime
		/// </summary>
		[Column(Name = "ComaTime", DbType = "datetime", Storage = "_ComaTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ComaTime
		{
			get { return _ComaTime; }
			set { _ComaTime = value; }
		}
		private DateTime? _DrivingTime;
		/// <summary>
		/// DrivingTime
		/// </summary>
		[Column(Name = "DrivingTime", DbType = "datetime", Storage = "_DrivingTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? DrivingTime
		{
			get { return _DrivingTime; }
			set { _DrivingTime = value; }
		}
		private DateTime? _ArriveTime;
		/// <summary>
		/// ArriveTime
		/// </summary>
		[Column(Name = "ArriveTime", DbType = "datetime", Storage = "_ArriveTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ArriveTime
		{
			get { return _ArriveTime; }
			set { _ArriveTime = value; }
		}
		private DateTime? _LeaveTime;
		/// <summary>
		/// LeaveTime
		/// </summary>
		[Column(Name = "LeaveTime", DbType = "datetime", Storage = "_LeaveTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? LeaveTime
		{
			get { return _LeaveTime; }
			set { _LeaveTime = value; }
		}
		private DateTime? _ArriveHosTime;
		/// <summary>
		/// ArriveHosTime
		/// </summary>
		[Column(Name = "ArriveHosTime", DbType = "datetime", Storage = "_ArriveHosTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ArriveHosTime
		{
			get { return _ArriveHosTime; }
			set { _ArriveHosTime = value; }
		}
		private string _TelZD;
		/// <summary>
		/// TelZD
		/// </summary>
		[Column(Name = "TelZD", DbType = "varchar(50)", Storage = "_TelZD", UpdateCheck = UpdateCheck.Never)]
		public string TelZD
		{
			get { return _TelZD; }
			set { _TelZD = value; }
		}
		private string _TelZDTrue;
		/// <summary>
		/// TelZDTrue
		/// </summary>
		[Column(Name = "TelZDTrue", DbType = "varchar(50)", Storage = "_TelZDTrue", UpdateCheck = UpdateCheck.Never)]
		public string TelZDTrue
		{
			get { return _TelZDTrue; }
			set { _TelZDTrue = value; }
		}
		private string _CCPerson;
		/// <summary>
		/// CCPerson
		/// </summary>
		[Column(Name = "CCPerson", DbType = "varchar(50)", Storage = "_CCPerson", UpdateCheck = UpdateCheck.Never)]
		public string CCPerson
		{
			get { return _CCPerson; }
			set { _CCPerson = value; }
		}
		private string _DocLS;
		/// <summary>
		/// DocLS
		/// </summary>
		[Column(Name = "DocLS", DbType = "varchar(50)", Storage = "_DocLS", UpdateCheck = UpdateCheck.Never)]
		public string DocLS
		{
			get { return _DocLS; }
			set { _DocLS = value; }
		}
		private string _SeriesTime;
		/// <summary>
		/// SeriesTime
		/// </summary>
		[Column(Name = "SeriesTime", DbType = "varchar(50)", Storage = "_SeriesTime", UpdateCheck = UpdateCheck.Never)]
		public string SeriesTime
		{
			get { return _SeriesTime; }
			set { _SeriesTime = value; }
		}
		private string _DocName;
		/// <summary>
		/// DocName
		/// </summary>
		[Column(Name = "DocName", DbType = "varchar(50)", Storage = "_DocName", UpdateCheck = UpdateCheck.Never)]
		public string DocName
		{
			get { return _DocName; }
			set { _DocName = value; }
		}
		private string _DocTitle;
		/// <summary>
		/// DocTitle
		/// </summary>
		[Column(Name = "DocTitle", DbType = "varchar(50)", Storage = "_DocTitle", UpdateCheck = UpdateCheck.Never)]
		public string DocTitle
		{
			get { return _DocTitle; }
			set { _DocTitle = value; }
		}
		private string _DocAge;
		/// <summary>
		/// DocAge
		/// </summary>
		[Column(Name = "DocAge", DbType = "varchar(50)", Storage = "_DocAge", UpdateCheck = UpdateCheck.Never)]
		public string DocAge
		{
			get { return _DocAge; }
			set { _DocAge = value; }
		}
		private string _WorkYear;
		/// <summary>
		/// WorkYear
		/// </summary>
		[Column(Name = "WorkYear", DbType = "varchar(50)", Storage = "_WorkYear", UpdateCheck = UpdateCheck.Never)]
		public string WorkYear
		{
			get { return _WorkYear; }
			set { _WorkYear = value; }
		}
		private string _PatientName;
		/// <summary>
		/// PatientName
		/// </summary>
		[Column(Name = "PatientName", DbType = "varchar(50)", Storage = "_PatientName", UpdateCheck = UpdateCheck.Never)]
		public string PatientName
		{
			get { return _PatientName; }
			set { _PatientName = value; }
		}
		private string _Sex;
		/// <summary>
		/// Sex
		/// </summary>
		[Column(Name = "Sex", DbType = "varchar(50)", Storage = "_Sex", UpdateCheck = UpdateCheck.Never)]
		public string Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}
		private string _Age;
		/// <summary>
		/// Age
		/// </summary>
		[Column(Name = "Age", DbType = "varchar(50)", Storage = "_Age", UpdateCheck = UpdateCheck.Never)]
		public string Age
		{
			get { return _Age; }
			set { _Age = value; }
		}
		private string _Death;
		/// <summary>
		/// Death
		/// </summary>
		[Column(Name = "Death", DbType = "varchar(50)", Storage = "_Death", UpdateCheck = UpdateCheck.Never)]
		public string Death
		{
			get { return _Death; }
			set { _Death = value; }
		}
		private string _Healthy;
		/// <summary>
		/// Healthy
		/// </summary>
		[Column(Name = "Healthy", DbType = "varchar(50)", Storage = "_Healthy", UpdateCheck = UpdateCheck.Never)]
		public string Healthy
		{
			get { return _Healthy; }
			set { _Healthy = value; }
		}
		private string _History;
		/// <summary>
		/// History
		/// </summary>
		[Column(Name = "History", DbType = "varchar(50)", Storage = "_History", UpdateCheck = UpdateCheck.Never)]
		public string History
		{
			get { return _History; }
			set { _History = value; }
		}
		private string _DieReson;
		/// <summary>
		/// DieReson
		/// </summary>
		[Column(Name = "DieReson", DbType = "varchar(50)", Storage = "_DieReson", UpdateCheck = UpdateCheck.Never)]
		public string DieReson
		{
			get { return _DieReson; }
			set { _DieReson = value; }
		}
		private string _Trauma;
		/// <summary>
		/// Trauma
		/// </summary>
		[Column(Name = "Trauma", DbType = "varchar(50)", Storage = "_Trauma", UpdateCheck = UpdateCheck.Never)]
		public string Trauma
		{
			get { return _Trauma; }
			set { _Trauma = value; }
		}
		private string _Witness;
		/// <summary>
		/// Witness
		/// </summary>
		[Column(Name = "Witness", DbType = "varchar(50)", Storage = "_Witness", UpdateCheck = UpdateCheck.Never)]
		public string Witness
		{
			get { return _Witness; }
			set { _Witness = value; }
		}
		private string _WitnessType;
		/// <summary>
		/// WitnessType
		/// </summary>
		[Column(Name = "WitnessType", DbType = "varchar(50)", Storage = "_WitnessType", UpdateCheck = UpdateCheck.Never)]
		public string WitnessType
		{
			get { return _WitnessType; }
			set { _WitnessType = value; }
		}
		private string _WitnessCure;
		/// <summary>
		/// WitnessCure
		/// </summary>
		[Column(Name = "WitnessCure", DbType = "varchar(50)", Storage = "_WitnessCure", UpdateCheck = UpdateCheck.Never)]
		public string WitnessCure
		{
			get { return _WitnessCure; }
			set { _WitnessCure = value; }
		}
		private string _Cure;
		/// <summary>
		/// Cure
		/// </summary>
		[Column(Name = "Cure", DbType = "varchar(50)", Storage = "_Cure", UpdateCheck = UpdateCheck.Never)]
		public string Cure
		{
			get { return _Cure; }
			set { _Cure = value; }
		}
		private string _RightSure;
		/// <summary>
		/// RightSure
		/// </summary>
		[Column(Name = "RightSure", DbType = "varchar(50)", Storage = "_RightSure", UpdateCheck = UpdateCheck.Never)]
		public string RightSure
		{
			get { return _RightSure; }
			set { _RightSure = value; }
		}
		private string _Ffracture;
		/// <summary>
		/// Ffracture
		/// </summary>
		[Column(Name = "Ffracture", DbType = "varchar(50)", Storage = "_Ffracture", UpdateCheck = UpdateCheck.Never)]
		public string Ffracture
		{
			get { return _Ffracture; }
			set { _Ffracture = value; }
		}
		private string _Breathe;
		/// <summary>
		/// Breathe
		/// </summary>
		[Column(Name = "Breathe", DbType = "varchar(50)", Storage = "_Breathe", UpdateCheck = UpdateCheck.Never)]
		public string Breathe
		{
			get { return _Breathe; }
			set { _Breathe = value; }
		}
		private string _Recovery;
		/// <summary>
		/// Recovery
		/// </summary>
		[Column(Name = "Recovery", DbType = "varchar(50)", Storage = "_Recovery", UpdateCheck = UpdateCheck.Never)]
		public string Recovery
		{
			get { return _Recovery; }
			set { _Recovery = value; }
		}
		private string _RecoveryNo;
		/// <summary>
		/// RecoveryNo
		/// </summary>
		[Column(Name = "RecoveryNo", DbType = "varchar(50)", Storage = "_RecoveryNo", UpdateCheck = UpdateCheck.Never)]
		public string RecoveryNo
		{
			get { return _RecoveryNo; }
			set { _RecoveryNo = value; }
		}
		private string _Press;
		/// <summary>
		/// Press
		/// </summary>
		[Column(Name = "Press", DbType = "varchar(50)", Storage = "_Press", UpdateCheck = UpdateCheck.Never)]
		public string Press
		{
			get { return _Press; }
			set { _Press = value; }
		}
		private string _ParticipateIn;
		/// <summary>
		/// ParticipateIn
		/// </summary>
		[Column(Name = "ParticipateIn", DbType = "varchar(50)", Storage = "_ParticipateIn", UpdateCheck = UpdateCheck.Never)]
		public string ParticipateIn
		{
			get { return _ParticipateIn; }
			set { _ParticipateIn = value; }
		}
		private DateTime? _startTime;
		/// <summary>
		/// startTime
		/// </summary>
		[Column(Name = "startTime", DbType = "datetime", Storage = "_startTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? startTime
		{
			get { return _startTime; }
			set { _startTime = value; }
		}
		private DateTime? _ECGTime;
		/// <summary>
		/// ECGTime
		/// </summary>
		[Column(Name = "ECGTime", DbType = "datetime", Storage = "_ECGTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ECGTime
		{
			get { return _ECGTime; }
			set { _ECGTime = value; }
		}
		private string _Rhythms;
		/// <summary>
		/// Rhythms
		/// </summary>
		[Column(Name = "Rhythms", DbType = "varchar(50)", Storage = "_Rhythms", UpdateCheck = UpdateCheck.Never)]
		public string Rhythms
		{
			get { return _Rhythms; }
			set { _Rhythms = value; }
		}
		private string _DJcount;
		/// <summary>
		/// DJcount
		/// </summary>
		[Column(Name = "DJcount", DbType = "varchar(50)", Storage = "_DJcount", UpdateCheck = UpdateCheck.Never)]
		public string DJcount
		{
			get { return _DJcount; }
			set { _DJcount = value; }
		}
		private string _Energy;
		/// <summary>
		/// Energy
		/// </summary>
		[Column(Name = "Energy", DbType = "varchar(50)", Storage = "_Energy", UpdateCheck = UpdateCheck.Never)]
		public string Energy
		{
			get { return _Energy; }
			set { _Energy = value; }
		}
		private string _Tracheal;
		/// <summary>
		/// Tracheal
		/// </summary>
		[Column(Name = "Tracheal", DbType = "varchar(50)", Storage = "_Tracheal", UpdateCheck = UpdateCheck.Never)]
		public string Tracheal
		{
			get { return _Tracheal; }
			set { _Tracheal = value; }
		}
		private string _CGresult;
		/// <summary>
		/// CGresult
		/// </summary>
		[Column(Name = "CGresult", DbType = "varchar(50)", Storage = "_CGresult", UpdateCheck = UpdateCheck.Never)]
		public string CGresult
		{
			get { return _CGresult; }
			set { _CGresult = value; }
		}
		private string _Saccule;
		/// <summary>
		/// Saccule
		/// </summary>
		[Column(Name = "Saccule", DbType = "varchar(50)", Storage = "_Saccule", UpdateCheck = UpdateCheck.Never)]
		public string Saccule
		{
			get { return _Saccule; }
			set { _Saccule = value; }
		}
		private string _Oropharyngeal;
		/// <summary>
		/// Oropharyngeal
		/// </summary>
		[Column(Name = "Oropharyngeal", DbType = "varchar(50)", Storage = "_Oropharyngeal", UpdateCheck = UpdateCheck.Never)]
		public string Oropharyngeal
		{
			get { return _Oropharyngeal; }
			set { _Oropharyngeal = value; }
		}
		private string _LaryngealMask;
		/// <summary>
		/// LaryngealMask
		/// </summary>
		[Column(Name = "LaryngealMask", DbType = "varchar(50)", Storage = "_LaryngealMask", UpdateCheck = UpdateCheck.Never)]
		public string LaryngealMask
		{
			get { return _LaryngealMask; }
			set { _LaryngealMask = value; }
		}
		private string _JMKT;
		/// <summary>
		/// JMKT
		/// </summary>
		[Column(Name = "JMKT", DbType = "varchar(50)", Storage = "_JMKT", UpdateCheck = UpdateCheck.Never)]
		public string JMKT
		{
			get { return _JMKT; }
			set { _JMKT = value; }
		}
		private string _KTresult;
		/// <summary>
		/// KTresult
		/// </summary>
		[Column(Name = "KTresult", DbType = "varchar(50)", Storage = "_KTresult", UpdateCheck = UpdateCheck.Never)]
		public string KTresult
		{
			get { return _KTresult; }
			set { _KTresult = value; }
		}
		private string _SSXS;
		/// <summary>
		/// SSXS
		/// </summary>
		[Column(Name = "SSXS", DbType = "varchar(50)", Storage = "_SSXS", UpdateCheck = UpdateCheck.Never)]
		public string SSXS
		{
			get { return _SSXS; }
			set { _SSXS = value; }
		}
		private string _Dose;
		/// <summary>
		/// Dose
		/// </summary>
		[Column(Name = "Dose", DbType = "varchar(50)", Storage = "_Dose", UpdateCheck = UpdateCheck.Never)]
		public string Dose
		{
			get { return _Dose; }
			set { _Dose = value; }
		}
		private string _Count;
		/// <summary>
		/// Count
		/// </summary>
		[Column(Name = "Count", DbType = "varchar(50)", Storage = "_Count", UpdateCheck = UpdateCheck.Never)]
		public string Count
		{
			get { return _Count; }
			set { _Count = value; }
		}
		private string _XGJYS;
		/// <summary>
		/// XGJYS
		/// </summary>
		[Column(Name = "XGJYS", DbType = "varchar(50)", Storage = "_XGJYS", UpdateCheck = UpdateCheck.Never)]
		public string XGJYS
		{
			get { return _XGJYS; }
			set { _XGJYS = value; }
		}
		private string _Amiodarone;
		/// <summary>
		/// Amiodarone
		/// </summary>
		[Column(Name = "Amiodarone", DbType = "varchar(50)", Storage = "_Amiodarone", UpdateCheck = UpdateCheck.Never)]
		public string Amiodarone
		{
			get { return _Amiodarone; }
			set { _Amiodarone = value; }
		}
		private string _FSTime;
		/// <summary>
		/// FSTime
		/// </summary>
		[Column(Name = "FSTime", DbType = "varchar(50)", Storage = "_FSTime", UpdateCheck = UpdateCheck.Never)]
		public string FSTime
		{
			get { return _FSTime; }
			set { _FSTime = value; }
		}
		private string _IScffs;
		/// <summary>
		/// IScffs
		/// </summary>
		[Column(Name = "IScffs", DbType = "varchar(50)", Storage = "_IScffs", UpdateCheck = UpdateCheck.Never)]
		public string IScffs
		{
			get { return _IScffs; }
			set { _IScffs = value; }
		}
		private string _Clinical;
		/// <summary>
		/// Clinical
		/// </summary>
		[Column(Name = "Clinical", DbType = "varchar(50)", Storage = "_Clinical", UpdateCheck = UpdateCheck.Never)]
		public string Clinical
		{
			get { return _Clinical; }
			set { _Clinical = value; }
		}
		private string _Finish;
		/// <summary>
		/// Finish
		/// </summary>
		[Column(Name = "Finish", DbType = "varchar(50)", Storage = "_Finish", UpdateCheck = UpdateCheck.Never)]
		public string Finish
		{
			get { return _Finish; }
			set { _Finish = value; }
		}
		private string _ROSC;
		/// <summary>
		/// ROSC
		/// </summary>
		[Column(Name = "ROSC", DbType = "varchar(50)", Storage = "_ROSC", UpdateCheck = UpdateCheck.Never)]
		public string ROSC
		{
			get { return _ROSC; }
			set { _ROSC = value; }
		}
		private string _HFTime;
		/// <summary>
		/// HFTime
		/// </summary>
		[Column(Name = "HFTime", DbType = "varchar(50)", Storage = "_HFTime", UpdateCheck = UpdateCheck.Never)]
		public string HFTime
		{
			get { return _HFTime; }
			set { _HFTime = value; }
		}
		private DateTime? _Recover;
		/// <summary>
		/// Recover
		/// </summary>
		[Column(Name = "Recover", DbType = "datetime", Storage = "_Recover", UpdateCheck = UpdateCheck.Never)]
		public DateTime? Recover
		{
			get { return _Recover; }
			set { _Recover = value; }
		}
		private string _HidPrimaryDiagnoses;
		/// <summary>
		/// HidPrimaryDiagnoses
		/// </summary>
		[Column(Name = "HidPrimaryDiagnoses", DbType = "varchar(50)", Storage = "_HidPrimaryDiagnoses", UpdateCheck = UpdateCheck.Never)]
		public string HidPrimaryDiagnoses
		{
			get { return _HidPrimaryDiagnoses; }
			set { _HidPrimaryDiagnoses = value; }
		}
		private string _ROSCTime;
		/// <summary>
		/// ROSCTime
		/// </summary>
		[Column(Name = "ROSCTime", DbType = "varchar(50)", Storage = "_ROSCTime", UpdateCheck = UpdateCheck.Never)]
		public string ROSCTime
		{
			get { return _ROSCTime; }
			set { _ROSCTime = value; }
		}
		private string _Conscious;
		/// <summary>
		/// Conscious
		/// </summary>
		[Column(Name = "Conscious", DbType = "varchar(50)", Storage = "_Conscious", UpdateCheck = UpdateCheck.Never)]
		public string Conscious
		{
			get { return _Conscious; }
			set { _Conscious = value; }
		}
		private string _RecoverTime;
		/// <summary>
		/// RecoverTime
		/// </summary>
		[Column(Name = "RecoverTime", DbType = "varchar(50)", Storage = "_RecoverTime", UpdateCheck = UpdateCheck.Never)]
		public string RecoverTime
		{
			get { return _RecoverTime; }
			set { _RecoverTime = value; }
		}
		private DateTime? _Concrete;
		/// <summary>
		/// Concrete
		/// </summary>
		[Column(Name = "Concrete", DbType = "datetime", Storage = "_Concrete", UpdateCheck = UpdateCheck.Never)]
		public DateTime? Concrete
		{
			get { return _Concrete; }
			set { _Concrete = value; }
		}
		private string _Mind;
		/// <summary>
		/// Mind
		/// </summary>
		[Column(Name = "Mind", DbType = "varchar(50)", Storage = "_Mind", UpdateCheck = UpdateCheck.Never)]
		public string Mind
		{
			get { return _Mind; }
			set { _Mind = value; }
		}
		private string _RecoverMind;
		/// <summary>
		/// RecoverMind
		/// </summary>
		[Column(Name = "RecoverMind", DbType = "varchar(50)", Storage = "_RecoverMind", UpdateCheck = UpdateCheck.Never)]
		public string RecoverMind
		{
			get { return _RecoverMind; }
			set { _RecoverMind = value; }
		}
		private DateTime? _ConcreteMind;
		/// <summary>
		/// ConcreteMind
		/// </summary>
		[Column(Name = "ConcreteMind", DbType = "datetime", Storage = "_ConcreteMind", UpdateCheck = UpdateCheck.Never)]
		public DateTime? ConcreteMind
		{
			get { return _ConcreteMind; }
			set { _ConcreteMind = value; }
		}
		private string _LapseTo;
		/// <summary>
		/// LapseTo
		/// </summary>
		[Column(Name = "LapseTo", DbType = "varchar(50)", Storage = "_LapseTo", UpdateCheck = UpdateCheck.Never)]
		public string LapseTo
		{
			get { return _LapseTo; }
			set { _LapseTo = value; }
		}
		private string _Hosp;
		/// <summary>
		/// Hosp
		/// </summary>
		[Column(Name = "Hosp", DbType = "varchar(50)", Storage = "_Hosp", UpdateCheck = UpdateCheck.Never)]
		public string Hosp
		{
			get { return _Hosp; }
			set { _Hosp = value; }
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
	}
}