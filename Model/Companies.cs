using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// Companies:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Companies
	{
		public Companies()
		{}
		#region Model
		private int _id;
		private string _companyname;
		private string _companycode;
		private string _companynum;
		private int _areaid;
		private int _companytypeid=2;
		private int _parentcompanyid=1;
		private DateTime _addtime= DateTime.Now;
		private bool _isdel= false;
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
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyCode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyNum
		{
			set{ _companynum=value;}
			get{return _companynum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AreaId
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CompanyTypeId
		{
			set{ _companytypeid=value;}
			get{return _companytypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentCompanyId
		{
			set{ _parentcompanyid=value;}
			get{return _parentcompanyid;}
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
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

