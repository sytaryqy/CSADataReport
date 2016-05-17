using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// RouteDatas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RouteDatas
	{
		public RouteDatas()
		{}
		#region Model
		private int _id;
		private int _reportweek;
		private int _reportyear;
		private int _companyid;
		private int _routeid;
		private int _lineid;
		private int _gp20;
		private int _gp40;
		private int _hq40;
		private int _hq45;
		private decimal _teu;
		private decimal _others;
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
		public int CompanyId
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RouteId
		{
			set{ _routeid=value;}
			get{return _routeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LineId
		{
			set{ _lineid=value;}
			get{return _lineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GP20
		{
			set{ _gp20=value;}
			get{return _gp20;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GP40
		{
			set{ _gp40=value;}
			get{return _gp40;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int HQ40
		{
			set{ _hq40=value;}
			get{return _hq40;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int HQ45
		{
			set{ _hq45=value;}
			get{return _hq45;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TEU
		{
			set{ _teu=value;}
			get{return _teu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Others
		{
			set{ _others=value;}
			get{return _others;}
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

