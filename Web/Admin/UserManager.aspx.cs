using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CSADataReport.Common;

namespace CSADataReport.Web.Admin
{
    public partial class UserManager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //判断用户是否管理员
                CSADataReport.Common.CheckLogin.CheckUserRoleAllowed("管理员");

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
                CSADataReport.Common.MD5Helper md5help=new CSADataReport.Common.MD5Helper ();
                string key = "cs";
                string encPassword=key+ md5help.GetMD5(e.Values["LoginPwd"].ToString() + key);
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
                CSADataReport.Common.MD5Helper md5help = new CSADataReport.Common.MD5Helper();
                string encPassword = key + md5help.GetMD5(e.NewValues["LoginPwd"].ToString() + key);
                e.NewValues["LoginPwd"] = encPassword;
            }

        }

    }
}