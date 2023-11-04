using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_MANUFACTURER")]
	public class S_MANUFACTURER
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
		private string _Name;
		/// <summary>
		/// Name
		/// </summary>
		[Column(Name = "Name", DbType = "nvarchar(200)", Storage = "_Name", UpdateCheck = UpdateCheck.Never)]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Address;
		/// <summary>
		/// Address
		/// </summary>
		[Column(Name = "Address", DbType = "nvarchar(100)", Storage = "_Address", UpdateCheck = UpdateCheck.Never)]
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}
		private string _Tel;
		/// <summary>
		/// Tel
		/// </summary>
		[Column(Name = "Tel", DbType = "nvarchar(100)", Storage = "_Tel", UpdateCheck = UpdateCheck.Never)]
		public string Tel
		{
			get { return _Tel; }
			set { _Tel = value; }
		}
		private string _Contact;
		/// <summary>
		/// Contact
		/// </summary>
		[Column(Name = "Contact", DbType = "nvarchar(100)", Storage = "_Contact", UpdateCheck = UpdateCheck.Never)]
		public string Contact
		{
			get { return _Contact; }
			set { _Contact = value; }
		}
	}
}