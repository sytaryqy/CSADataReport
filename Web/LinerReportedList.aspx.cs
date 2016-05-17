using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web
{
    public partial class LinerReportedList : System.Web.UI.Page
    {
        protected Model.Users currentUser;
        protected void Page_Load(object sender, EventArgs e)
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
            else
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
    }
}