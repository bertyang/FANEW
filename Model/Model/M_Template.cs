using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "M_Template")]
	public class M_Template
	{
		private int _TemplateID;
		/// <summary>
		/// TemplateID
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "TemplateID", DbType = "int", Storage = "_TemplateID")]
		public int TemplateID
		{
			get { return _TemplateID; }
			set { _TemplateID = value; }
		}
		private string _TemplateName;
		/// <summary>
		/// TemplateName
		/// </summary>
		[Column(Name = "TemplateName", DbType = "varchar(50)", Storage = "_TemplateName", UpdateCheck = UpdateCheck.Never)]
		public string TemplateName
		{
			get { return _TemplateName; }
			set { _TemplateName = value; }
		}
		private string _PresentHistory;
		/// <summary>
		/// PresentHistory
		/// </summary>
		[Column(Name = "PresentHistory", DbType = "varchar(500)", Storage = "_PresentHistory", UpdateCheck = UpdateCheck.Never)]
		public string PresentHistory
		{
			get { return _PresentHistory; }
			set { _PresentHistory = value; }
		}
		private string _MedicalHistory;
		/// <summary>
		/// MedicalHistory
		/// </summary>
		[Column(Name = "MedicalHistory", DbType = "varchar(500)", Storage = "_MedicalHistory", UpdateCheck = UpdateCheck.Never)]
		public string MedicalHistory
		{
			get { return _MedicalHistory; }
			set { _MedicalHistory = value; }
		}
		private string _DrugAllergyHistory;
		/// <summary>
		/// DrugAllergyHistory
		/// </summary>
		[Column(Name = "DrugAllergyHistory", DbType = "varchar(500)", Storage = "_DrugAllergyHistory", UpdateCheck = UpdateCheck.Never)]
		public string DrugAllergyHistory
		{
			get { return _DrugAllergyHistory; }
			set { _DrugAllergyHistory = value; }
		}
		private string _Diagnoses;
		/// <summary>
		/// Diagnoses
		/// </summary>
		[Column(Name = "Diagnoses", DbType = "varchar(1000)", Storage = "_Diagnoses", UpdateCheck = UpdateCheck.Never)]
		public string Diagnoses
		{
			get { return _Diagnoses; }
			set { _Diagnoses = value; }
		}
		private string _OnTheWay;
		/// <summary>
		/// OnTheWay
		/// </summary>
		[Column(Name = "OnTheWay", DbType = "varchar(1000)", Storage = "_OnTheWay", UpdateCheck = UpdateCheck.Never)]
		public string OnTheWay
		{
			get { return _OnTheWay; }
			set { _OnTheWay = value; }
		}
		private string _ChiefComplaint;
		/// <summary>
		/// ChiefComplaint
		/// </summary>
		[Column(Name = "ChiefComplaint", DbType = "varchar(300)", Storage = "_ChiefComplaint", UpdateCheck = UpdateCheck.Never)]
		public string ChiefComplaint
		{
			get { return _ChiefComplaint; }
			set { _ChiefComplaint = value; }
		}
	}
}