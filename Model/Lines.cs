using System;
namespace CSADataReport.Model
{
	/// <summary>
	/// Lines:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lines
	{
		public Lines()
		{}
		#region Model
		private int _id;
		private string _name;
		private int _routeid;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RouteId
		{
			set{ _routeid=value;}
			get{return _routeid;}
		}
		#endregion Model

	}
}

