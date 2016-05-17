using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// DeclareDatas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DeclareDatas
	{
		public DeclareDatas()
		{}
		#region Model
		private int _id;
		private int _declarereportweek;
		private int _declarereportyear;
		private int _companyid;
		private int _gfouterdeclareballot;
		private int _gfselfdeclareballot;
		private int _gfotherdeclareballot;
		private int _qtouterdeclareballot;
		private int _qtselfdeclareballot;
		private int _qtotherdeclareballot;
		private int _gfouterdeclarecontainer;
		private int _gfselfdeclarecontainer;
		private int _gfotherdeclarecontainer;
		private int _qtouterdeclarecontainer;
		private int _qtselfdeclarecontainer;
		private int _qtotherdeclarecontainer;
		private decimal _gfouterdeclareincome;
		private decimal _gfselfdeclareincome;
		private decimal _gfotherdeclareincome;
		private decimal _qtouterdeclareincome;
		private decimal _qtselfdeclareincome;
		private decimal _qtotherdeclareincome;
		private DateTime _addtime= DateTime.Now;
		private DateTime? _edittime;
		private bool _isreported= false;
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
		public int DeclareReportWeek
		{
			set{ _declarereportweek=value;}
			get{return _declarereportweek;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DeclareReportYear
		{
			set{ _declarereportyear=value;}
			get{return _declarereportyear;}
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
		public int GFOuterDeclareBallot
		{
			set{ _gfouterdeclareballot=value;}
			get{return _gfouterdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GFSelfDeclareBallot
		{
			set{ _gfselfdeclareballot=value;}
			get{return _gfselfdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GFOtherDeclareBallot
		{
			set{ _gfotherdeclareballot=value;}
			get{return _gfotherdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTOuterDeclareBallot
		{
			set{ _qtouterdeclareballot=value;}
			get{return _qtouterdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTSelfDeclareBallot
		{
			set{ _qtselfdeclareballot=value;}
			get{return _qtselfdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTOtherDeclareBallot
		{
			set{ _qtotherdeclareballot=value;}
			get{return _qtotherdeclareballot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GFOuterDeclareContainer
		{
			set{ _gfouterdeclarecontainer=value;}
			get{return _gfouterdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GFSelfDeclareContainer
		{
			set{ _gfselfdeclarecontainer=value;}
			get{return _gfselfdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GFOtherDeclareContainer
		{
			set{ _gfotherdeclarecontainer=value;}
			get{return _gfotherdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTOuterDeclareContainer
		{
			set{ _qtouterdeclarecontainer=value;}
			get{return _qtouterdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTSelfDeclareContainer
		{
			set{ _qtselfdeclarecontainer=value;}
			get{return _qtselfdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QTOtherDeclareContainer
		{
			set{ _qtotherdeclarecontainer=value;}
			get{return _qtotherdeclarecontainer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GFOuterDeclareIncome
		{
			set{ _gfouterdeclareincome=value;}
			get{return _gfouterdeclareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GFSelfDeclareIncome
		{
			set{ _gfselfdeclareincome=value;}
			get{return _gfselfdeclareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GFOtherDeclareIncome
		{
			set{ _gfotherdeclareincome=value;}
			get{return _gfotherdeclareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal QTOuterDeclareIncome
		{
			set{ _qtouterdeclareincome=value;}
			get{return _qtouterdeclareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal QTSelfDeclareIncome
		{
			set{ _qtselfdeclareincome=value;}
			get{return _qtselfdeclareincome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal QTOtherDeclareIncome
		{
			set{ _qtotherdeclareincome=value;}
			get{return _qtotherdeclareincome;}
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
		/// <summary>
		/// 
		/// </summary>
		public bool IsReported
		{
			set{ _isreported=value;}
			get{return _isreported;}
		}
		#endregion Model

	}
}

