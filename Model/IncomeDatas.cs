using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// IncomeDatas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IncomeDatas
	{
		public IncomeDatas()
		{}
		#region Model
		private int _id;
		private int _companyid;
		private int _reportweek;
		private int _reportyear;
		private decimal? _containerincome;
		private decimal? _bulkcargoincome;
		private decimal? _declareincome;
		private decimal? _totalcontainerincome;
		private decimal? _totalbulkcargoincome;
		private decimal? _totaldeclareincome;
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
		public decimal? ContainerIncome
		{
			set{ _containerincome=value;}
			get{return _containerincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BulkCargoIncome
		{
			set{ _bulkcargoincome=value;}
			get{return _bulkcargoincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DeclareIncome
		{
			set{ _declareincome=value;}
			get{return _declareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalContainerIncome
		{
			set{ _totalcontainerincome=value;}
			get{return _totalcontainerincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalBulkCargoIncome
		{
			set{ _totalbulkcargoincome=value;}
			get{return _totalbulkcargoincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalDeclareIncome
		{
			set{ _totaldeclareincome=value;}
			get{return _totaldeclareincome;}
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

