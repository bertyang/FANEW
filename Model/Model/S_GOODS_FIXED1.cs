using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
	[Table(Name = "S_GOODS_FIXED1")]
	public class S_GOODS_FIXED1
	{
		private string _资产编号;
		/// <summary>
		/// 资产编号
		/// </summary>
		[Column(Name = "资产编号", DbType = "nvarchar(510)", Storage = "_资产编号", UpdateCheck = UpdateCheck.Never)]
		public string 资产编号
		{
			get { return _资产编号; }
			set { _资产编号 = value; }
		}
		private string _资产分类;
		/// <summary>
		/// 资产分类
		/// </summary>
		[Column(Name = "资产分类", DbType = "nvarchar(510)", Storage = "_资产分类", UpdateCheck = UpdateCheck.Never)]
		public string 资产分类
		{
			get { return _资产分类; }
			set { _资产分类 = value; }
		}
		private string _资产名称;
		/// <summary>
		/// 资产名称
		/// </summary>
		[Column(Name = "资产名称", DbType = "nvarchar(510)", Storage = "_资产名称", UpdateCheck = UpdateCheck.Never)]
		public string 资产名称
		{
			get { return _资产名称; }
			set { _资产名称 = value; }
		}
		private string _财务入账日期;
		/// <summary>
		/// 财务入账日期
		/// </summary>
		[Column(Name = "财务入账日期", DbType = "nvarchar(510)", Storage = "_财务入账日期", UpdateCheck = UpdateCheck.Never)]
		public string 财务入账日期
		{
			get { return _财务入账日期; }
			set { _财务入账日期 = value; }
		}
		private string _价值类型;
		/// <summary>
		/// 价值类型
		/// </summary>
		[Column(Name = "价值类型", DbType = "nvarchar(510)", Storage = "_价值类型", UpdateCheck = UpdateCheck.Never)]
		public string 价值类型
		{
			get { return _价值类型; }
			set { _价值类型 = value; }
		}
		private double? _价值;
		/// <summary>
		/// 价值
		/// </summary>
		[Column(Name = "价值", DbType = "float", Storage = "_价值", UpdateCheck = UpdateCheck.Never)]
		public double? 价值
		{
			get { return _价值; }
			set { _价值 = value; }
		}
		private string _取得方式;
		/// <summary>
		/// 取得方式
		/// </summary>
		[Column(Name = "取得方式", DbType = "nvarchar(510)", Storage = "_取得方式", UpdateCheck = UpdateCheck.Never)]
		public string 取得方式
		{
			get { return _取得方式; }
			set { _取得方式 = value; }
		}
		private string _取得日期;
		/// <summary>
		/// 取得日期
		/// </summary>
		[Column(Name = "取得日期", DbType = "nvarchar(510)", Storage = "_取得日期", UpdateCheck = UpdateCheck.Never)]
		public string 取得日期
		{
			get { return _取得日期; }
			set { _取得日期 = value; }
		}
		private string _使用状况;
		/// <summary>
		/// 使用状况
		/// </summary>
		[Column(Name = "使用状况", DbType = "nvarchar(510)", Storage = "_使用状况", UpdateCheck = UpdateCheck.Never)]
		public string 使用状况
		{
			get { return _使用状况; }
			set { _使用状况 = value; }
		}
		private string _使用方向;
		/// <summary>
		/// 使用方向
		/// </summary>
		[Column(Name = "使用方向", DbType = "nvarchar(510)", Storage = "_使用方向", UpdateCheck = UpdateCheck.Never)]
		public string 使用方向
		{
			get { return _使用方向; }
			set { _使用方向 = value; }
		}
		private string _使用部门;
		/// <summary>
		/// 使用部门
		/// </summary>
		[Column(Name = "使用部门", DbType = "nvarchar(510)", Storage = "_使用部门", UpdateCheck = UpdateCheck.Never)]
		public string 使用部门
		{
			get { return _使用部门; }
			set { _使用部门 = value; }
		}
		private string _管理部门;
		/// <summary>
		/// 管理部门
		/// </summary>
		[Column(Name = "管理部门", DbType = "nvarchar(510)", Storage = "_管理部门", UpdateCheck = UpdateCheck.Never)]
		public string 管理部门
		{
			get { return _管理部门; }
			set { _管理部门 = value; }
		}
		private string _使用人;
		/// <summary>
		/// 使用人
		/// </summary>
		[Column(Name = "使用人", DbType = "nvarchar(510)", Storage = "_使用人", UpdateCheck = UpdateCheck.Never)]
		public string 使用人
		{
			get { return _使用人; }
			set { _使用人 = value; }
		}
		private double? _数量;
		/// <summary>
		/// 数量
		/// </summary>
		[Column(Name = "数量", DbType = "float", Storage = "_数量", UpdateCheck = UpdateCheck.Never)]
		public double? 数量
		{
			get { return _数量; }
			set { _数量 = value; }
		}
		private string _制单人;
		/// <summary>
		/// 制单人
		/// </summary>
		[Column(Name = "制单人", DbType = "nvarchar(510)", Storage = "_制单人", UpdateCheck = UpdateCheck.Never)]
		public string 制单人
		{
			get { return _制单人; }
			set { _制单人 = value; }
		}
		private string _制单时间;
		/// <summary>
		/// 制单时间
		/// </summary>
		[Column(Name = "制单时间", DbType = "nvarchar(510)", Storage = "_制单时间", UpdateCheck = UpdateCheck.Never)]
		public string 制单时间
		{
			get { return _制单时间; }
			set { _制单时间 = value; }
		}
		private string _清查编号;
		/// <summary>
		/// 清查编号
		/// </summary>
		[Column(Name = "清查编号", DbType = "nvarchar(510)", Storage = "_清查编号", UpdateCheck = UpdateCheck.Never)]
		public string 清查编号
		{
			get { return _清查编号; }
			set { _清查编号 = value; }
		}
		private string _所属单位;
		/// <summary>
		/// 所属单位
		/// </summary>
		[Column(Name = "所属单位", DbType = "nvarchar(510)", Storage = "_所属单位", UpdateCheck = UpdateCheck.Never)]
		public string 所属单位
		{
			get { return _所属单位; }
			set { _所属单位 = value; }
		}
		private string _卡片状态;
		/// <summary>
		/// 卡片状态
		/// </summary>
		[Column(Name = "卡片状态", DbType = "nvarchar(510)", Storage = "_卡片状态", UpdateCheck = UpdateCheck.Never)]
		public string 卡片状态
		{
			get { return _卡片状态; }
			set { _卡片状态 = value; }
		}
		private double? _累计折旧;
		/// <summary>
		/// 累计折旧
		/// </summary>
		[Column(Name = "累计折旧", DbType = "float", Storage = "_累计折旧", UpdateCheck = UpdateCheck.Never)]
		public double? 累计折旧
		{
			get { return _累计折旧; }
			set { _累计折旧 = value; }
		}
		private double? _已提折旧月数;
		/// <summary>
		/// 已提折旧月数
		/// </summary>
		[Column(Name = "已提折旧月数", DbType = "float", Storage = "_已提折旧月数", UpdateCheck = UpdateCheck.Never)]
		public double? 已提折旧月数
		{
			get { return _已提折旧月数; }
			set { _已提折旧月数 = value; }
		}
		private double? _净值;
		/// <summary>
		/// 净值
		/// </summary>
		[Column(Name = "净值", DbType = "float", Storage = "_净值", UpdateCheck = UpdateCheck.Never)]
		public double? 净值
		{
			get { return _净值; }
			set { _净值 = value; }
		}
	}
}