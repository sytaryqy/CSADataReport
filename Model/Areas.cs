using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// Areas:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Areas
	{
		public Areas()
		{}
		#region Model
		private int _id;
		private string _areaname;
		private string _areacode;
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
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaCode
		{
			set{ _areacode=value;}
			get{return _areacode;}
		}
		#endregion Model

	}
}

