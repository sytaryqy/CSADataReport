using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;

namespace CSADataReport.Web.Admin
{
    public partial class UserManager : System.Web.UI.Page
    {
         //当前操作的用户实体
        protected Model.Users currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //判断用户是否登录
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
                    if (currentUser.U_UserRoles.Name != "管理员")
                    {
                        Response.Clear();
                        Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                        Response.End();
                    }
                }
            }

        }

        protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            BLL.Users userBll=new BLL.Users ();
            DataSet ds = userBll.GetList("LoginName='" + e.Values["LoginName"].ToString()+"'");
            if (ds.Tables[0]!=null && ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this, "用户名重复，请更换！");
                e.Cancel = true;
                return;
            }
            DropDownList CompanyDropDownList= e.Item.FindControl("CompanyDropDownList") as DropDownList;
            e.Values.Add("CompanyId", CompanyDropDownList.SelectedValue);
            DropDownList UserRolesDropDownList = e.Item.FindControl("UserRolesDropDownList") as DropDownList;
            e.Values.Add("UserRoleId", UserRolesDropDownList.SelectedValue);
            DropDownList UserStatesDropDownList = e.Item.FindControl("UserStatesDropDownList") as DropDownList;
            e.Values.Add("UserStateId", UserStatesDropDownList.SelectedValue);
                Maticsoft.Common.MD5Helper md5help=new Maticsoft.Common.MD5Helper ();
                string key = "cs";
                string encPassword=key+ md5help.GetMD5(e.Values["LoginPwd"].ToString() + key);
                //md5help.GetMD5(e.Values["LoginPwd"].ToString());
                e.Values["LoginPwd"] = encPassword;
                e.Values["AddTime"] = DateTime.Now;

        }


        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            DropDownList EditCompanyDropDownList = ListView1.EditItem.FindControl("EditCompanyDropDownList") as DropDownList;
            e.NewValues.Add("CompanyId", EditCompanyDropDownList.SelectedValue);
            DropDownList EditUserRolesDropDownList = ListView1.EditItem.FindControl("EditUserRolesDropDownList") as DropDownList;
            e.NewValues.Add("UserRoleId", EditUserRolesDropDownList.SelectedValue);
            DropDownList EditUserStatesDropDownList = ListView1.EditItem.FindControl("EditUserStatesDropDownList") as DropDownList;
            e.NewValues.Add("UserStateId", EditUserStatesDropDownList.SelectedValue);
            if (e.OldValues["LoginPwd"].ToString() != e.NewValues["LoginPwd"].ToString())
            {
                string key = "cs";
                Maticsoft.Common.MD5Helper md5help = new Maticsoft.Common.MD5Helper();
                string encPassword = key + md5help.GetMD5(e.NewValues["LoginPwd"].ToString() + key);
                e.NewValues["LoginPwd"] = encPassword;
            }

        }

    }
}