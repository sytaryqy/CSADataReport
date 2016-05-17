using System;
using Maticsoft.Common;
namespace CSADataReport.Web
{
	/// <summary>
	/// Main 的摘要说明。
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
        protected Model.Users currentUser;
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Session["returnPage"] = this.Request.Url.PathAndQuery;
                    Response.Clear();
                    Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                    Response.End();

                }
                else
                {
                    currentUser = (Model.Users)Session["UserInfo"];
                }

            }
		}
       
      
		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		
	}
}
