using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// LinerIncomeDatas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LinerIncomeDatas
	{
		public LinerIncomeDatas()
		{}
		#region Model
		private int _id;
		private int _companyid;
		private int _reportweek;
		private int _reportyear;
		private int _linercompanyid;
		private decimal? _proxyshipincome;
		private decimal? _documentincome;
		private bool _isreported= false;
		private DateTime _addtime= DateTime.Now;
		private DateTime? _edittime;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CompanyId
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ReportWeek
		{
			set{ _reportweek=value;}
			get{return _reportweek;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ReportYear
		{
			set{ _reportyear=value;}
			get{return _reportyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LinerCompanyId
		{
			set{ _linercompanyid=value;}
			get{return _linercompanyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProxyShipIncome
		{
			set{ _proxyshipincome=value;}
			get{return _proxyshipincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DocumentIncome
		{
			set{ _documentincome=value;}
			get{return _documentincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsReported
		{
			set{ _isreported=value;}
			get{return _isreported;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EditTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
		}
		#endregion Model

	}
}

