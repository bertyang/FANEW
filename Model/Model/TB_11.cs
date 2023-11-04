using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "TB_11")]
	public class TB_11
	{
		private int _FlowNo;
		/// <summary>
		/// FlowNo
		/// </summary>
		[Column(IsPrimaryKey = true, Name = "FlowNo", DbType = "int", Storage = "_FlowNo")]
		public int FlowNo
		{
			get { return _FlowNo; }
			set { _FlowNo = value; }
		}
		private DateTime _AcceptTime;
		/// <summary>
		/// AcceptTime
		/// </summary>
		[Column(Name = "AcceptTime", DbType = "datetime", Storage = "_AcceptTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime AcceptTime
		{
			get { return _AcceptTime; }
			set { _AcceptTime = value; }
		}
		private string _AcceptUnit;
		/// <summary>
		/// AcceptUnit
		/// </summary>
		[Column(Name = "AcceptUnit", DbType = "varchar(40)", Storage = "_AcceptUnit", UpdateCheck = UpdateCheck.Never)]
		public string AcceptUnit
		{
			get { return _AcceptUnit; }
			set { _AcceptUnit = value; }
		}
		private string _LetterPerson;
		/// <summary>
		/// LetterPerson
		/// </summary>
		[Column(Name = "LetterPerson", DbType = "varchar(50)", Storage = "_LetterPerson", UpdateCheck = UpdateCheck.Never)]
		public string LetterPerson
		{
			get { return _LetterPerson; }
			set { _LetterPerson = value; }
		}
		private string _LetterTel;
		/// <summary>
		/// LetterTel
		/// </summary>
		[Column(Name = "LetterTel", DbType = "varchar(20)", Storage = "_LetterTel", UpdateCheck = UpdateCheck.Never)]
		public string LetterTel
		{
			get { return _LetterTel; }
			set { _LetterTel = value; }
		}
		private string _LetterWay;
		/// <summary>
		/// LetterWay
		/// </summary>
		[Column(Name = "LetterWay", DbType = "varchar(20)", Storage = "_LetterWay", UpdateCheck = UpdateCheck.Never)]
		public string LetterWay
		{
			get { return _LetterWay; }
			set { _LetterWay = value; }
		}
		private string _LetterCategory;
		/// <summary>
		/// LetterCategory
		/// </summary>
		[Column(Name = "LetterCategory", DbType = "varchar(20)", Storage = "_LetterCategory", UpdateCheck = UpdateCheck.Never)]
		public string LetterCategory
		{
			get { return _LetterCategory; }
			set { _LetterCategory = value; }
		}
		private string _ReportNo;
		/// <summary>
		/// ReportNo
		/// </summary>
		[Column(Name = "ReportNo", DbType = "varchar(20)", Storage = "_ReportNo", UpdateCheck = UpdateCheck.Never)]
		public string ReportNo
		{
			get { return _ReportNo; }
			set { _ReportNo = value; }
		}
		private DateTime _ReportTime;
		/// <summary>
		/// ReportTime
		/// </summary>
		[Column(Name = "ReportTime", DbType = "datetime", Storage = "_ReportTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime ReportTime
		{
			get { return _ReportTime; }
			set { _ReportTime = value; }
		}
		private DateTime _FeedbackTime;
		/// <summary>
		/// FeedbackTime
		/// </summary>
		[Column(Name = "FeedbackTime", DbType = "datetime", Storage = "_FeedbackTime", UpdateCheck = UpdateCheck.Never)]
		public DateTime FeedbackTime
		{
			get { return _FeedbackTime; }
			set { _FeedbackTime = value; }
		}
		private string _ReportContent;
		/// <summary>
		/// ReportContent
		/// </summary>
		[Column(Name = "ReportContent", DbType = "text(16)", Storage = "_ReportContent", UpdateCheck = UpdateCheck.Never)]
		public string ReportContent
		{
			get { return _ReportContent; }
			set { _ReportContent = value; }
		}
		private string _Undertaker;
		/// <summary>
		/// Undertaker
		/// </summary>
		[Column(Name = "Undertaker", DbType = "varchar(50)", Storage = "_Undertaker", UpdateCheck = UpdateCheck.Never)]
		public string Undertaker
		{
			get { return _Undertaker; }
			set { _Undertaker = value; }
		}
		private string _UndertakerMobile;
		/// <summary>
		/// UndertakerMobile
		/// </summary>
		[Column(Name = "UndertakerMobile", DbType = "varchar(20)", Storage = "_UndertakerMobile", UpdateCheck = UpdateCheck.Never)]
		public string UndertakerMobile
		{
			get { return _UndertakerMobile; }
			set { _UndertakerMobile = value; }
		}
		private string _Result;
		/// <summary>
		/// Result
		/// </summary>
		[Column(Name = "Result", DbType = "text(16)", Storage = "_Result", UpdateCheck = UpdateCheck.Never)]
		public string Result
		{
			get { return _Result; }
			set { _Result = value; }
		}
		private string _Satisfaction;
		/// <summary>
		/// Satisfaction
		/// </summary>
		[Column(Name = "Satisfaction", DbType = "varchar(10)", Storage = "_Satisfaction", UpdateCheck = UpdateCheck.Never)]
		public string Satisfaction
		{
			get { return _Satisfaction; }
			set { _Satisfaction = value; }
		}
		private string _BranchAdvice;
		/// <summary>
		/// BranchAdvice
		/// </summary>
		[Column(Name = "BranchAdvice", DbType = "varchar(10)", Storage = "_BranchAdvice", UpdateCheck = UpdateCheck.Never)]
		public string BranchAdvice
		{
			get { return _BranchAdvice; }
			set { _BranchAdvice = value; }
		}
		private string _UndertakeUnit;
		/// <summary>
		/// UndertakeUnit
		/// </summary>
		[Column(Name = "UndertakeUnit", DbType = "varchar(40)", Storage = "_UndertakeUnit", UpdateCheck = UpdateCheck.Never)]
		public string UndertakeUnit
		{
			get { return _UndertakeUnit; }
			set { _UndertakeUnit = value; }
		}
	}
}