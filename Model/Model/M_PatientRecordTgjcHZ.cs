using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_PatientRecordTgjcHZ")]
	public class M_PatientRecordTgjcHZ
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
		private string _T;
		/// <summary>
		/// T
		/// </summary>
		[Column(Name = "T", DbType = "varchar(10)", Storage = "_T", UpdateCheck = UpdateCheck.Never)]
		public string T
		{
			get { return _T; }
			set { _T = value; }
		}
		private string _P;
		/// <summary>
		/// P
		/// </summary>
		[Column(Name = "P", DbType = "varchar(10)", Storage = "_P", UpdateCheck = UpdateCheck.Never)]
		public string P
		{
			get { return _P; }
			set { _P = value; }
		}
		private string _R;
		/// <summary>
		/// R
		/// </summary>
		[Column(Name = "R", DbType = "varchar(10)", Storage = "_R", UpdateCheck = UpdateCheck.Never)]
		public string R
		{
			get { return _R; }
			set { _R = value; }
		}
		private string _BP1;
		/// <summary>
		/// BP1
		/// </summary>
		[Column(Name = "BP1", DbType = "varchar(10)", Storage = "_BP1", UpdateCheck = UpdateCheck.Never)]
		public string BP1
		{
			get { return _BP1; }
			set { _BP1 = value; }
		}
		private string _BP2;
		/// <summary>
		/// BP2
		/// </summary>
		[Column(Name = "BP2", DbType = "varchar(10)", Storage = "_BP2", UpdateCheck = UpdateCheck.Never)]
		public string BP2
		{
			get { return _BP2; }
			set { _BP2 = value; }
		}
		private string _Mind;
		/// <summary>
		/// Mind
		/// </summary>
		[Column(Name = "Mind", DbType = "varchar(25)", Storage = "_Mind", UpdateCheck = UpdateCheck.Never)]
		public string Mind
		{
			get { return _Mind; }
			set { _Mind = value; }
		}
		private string _Pupil;
		/// <summary>
		/// Pupil
		/// </summary>
		[Column(Name = "Pupil", DbType = "varchar(25)", Storage = "_Pupil", UpdateCheck = UpdateCheck.Never)]
		public string Pupil
		{
			get { return _Pupil; }
			set { _Pupil = value; }
		}
		private string _Refle;
		/// <summary>
		/// Refle
		/// </summary>
		[Column(Name = "Refle", DbType = "varchar(200)", Storage = "_Refle", UpdateCheck = UpdateCheck.Never)]
		public string Refle
		{
			get { return _Refle; }
			set { _Refle = value; }
		}
		private string _Pate;
		/// <summary>
		/// Pate
		/// </summary>
		[Column(Name = "Pate", DbType = "varchar(200)", Storage = "_Pate", UpdateCheck = UpdateCheck.Never)]
		public string Pate
		{
			get { return _Pate; }
			set { _Pate = value; }
		}
		private string _Heart;
		/// <summary>
		/// Heart
		/// </summary>
		[Column(Name = "Heart", DbType = "varchar(200)", Storage = "_Heart", UpdateCheck = UpdateCheck.Never)]
		public string Heart
		{
			get { return _Heart; }
			set { _Heart = value; }
		}
		private string _DoubleLung;
		/// <summary>
		/// DoubleLung
		/// </summary>
		[Column(Name = "DoubleLung", DbType = "varchar(200)", Storage = "_DoubleLung", UpdateCheck = UpdateCheck.Never)]
		public string DoubleLung
		{
			get { return _DoubleLung; }
			set { _DoubleLung = value; }
		}
		private string _Chest;
		/// <summary>
		/// Chest
		/// </summary>
		[Column(Name = "Chest", DbType = "varchar(200)", Storage = "_Chest", UpdateCheck = UpdateCheck.Never)]
		public string Chest
		{
			get { return _Chest; }
			set { _Chest = value; }
		}
		private string _Belly;
		/// <summary>
		/// Belly
		/// </summary>
		[Column(Name = "Belly", DbType = "varchar(200)", Storage = "_Belly", UpdateCheck = UpdateCheck.Never)]
		public string Belly
		{
			get { return _Belly; }
			set { _Belly = value; }
		}
		private string _Limbs;
		/// <summary>
		/// Limbs
		/// </summary>
		[Column(Name = "Limbs", DbType = "varchar(200)", Storage = "_Limbs", UpdateCheck = UpdateCheck.Never)]
		public string Limbs
		{
			get { return _Limbs; }
			set { _Limbs = value; }
		}
		private string _HZOther;
		/// <summary>
		/// HZOther
		/// </summary>
		[Column(Name = "HZOther", DbType = "varchar(200)", Storage = "_HZOther", UpdateCheck = UpdateCheck.Never)]
		public string HZOther
		{
			get { return _HZOther; }
			set { _HZOther = value; }
		}
		private string _ECG;
		/// <summary>
		/// ECG
		/// </summary>
		[Column(Name = "ECG", DbType = "varchar(50)", Storage = "_ECG", UpdateCheck = UpdateCheck.Never)]
		public string ECG
		{
			get { return _ECG; }
			set { _ECG = value; }
		}
		private string _Sugar;
		/// <summary>
		/// Sugar
		/// </summary>
		[Column(Name = "Sugar", DbType = "varchar(25)", Storage = "_Sugar", UpdateCheck = UpdateCheck.Never)]
		public string Sugar
		{
			get { return _Sugar; }
			set { _Sugar = value; }
		}
		private string _SPo2;
		/// <summary>
		/// SPo2
		/// </summary>
		[Column(Name = "SPo2", DbType = "varchar(25)", Storage = "_SPo2", UpdateCheck = UpdateCheck.Never)]
		public string SPo2
		{
			get { return _SPo2; }
			set { _SPo2 = value; }
		}
	}
}