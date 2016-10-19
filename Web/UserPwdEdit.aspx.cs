using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using CSADataReport.Common;

namespace CSADataReport.Web
{
    public partial class UserPwdEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] != null)
                {
                    Model.Users currentUser = (Model.Users)Session["UserInfo"];
                    txtUname.Text = currentUser.LoginName;
                    txtUname.ReadOnly = true;
                    txtUname.BackColor = Color.FromArgb(155, 187, 88);
                    txtUname.BorderWidth = 0;
                }
            }

        }

        protected void btnS_Click(object sender, EventArgs e)
        {
            string strUname = txtUname.Text;
            string strOrigPwd = txtOrgPwd.Text;
            MD5Helper helper = new MD5Helper();
            string key = "cs";
            string encPassword=key+ helper.GetMD5(strOrigPwd + key);
            BLL.Users userBLL = new BLL.Users();
            DataSet ds= userBLL.GetList("LoginName='" + strUname +"' and "+ "LoginPwd='" + encPassword+"'");
            if (ds == null || ds.Tables[0].Rows.Count <= 0) 
            {
                MessageBox.Show(this, "用户名或者密码错误！");
                return;
            }
            string strNewPwd = txtPwdConfirm.Text;
            string encNewPassword=key+ helper.GetMD5(strNewPwd + key);
            Model.Users model=new Model.Users ();
            model.LoginName=strUname;
            model.LoginPwd=encNewPassword;
            if (userBLL.UpdatePwd(model))
            {
                MessageBox.ShowAndRedirect(this, "密码修改成功！", this.Request.UrlReferrer.PathAndQuery);
            }
            else
            {
                MessageBox.Show(this, "密码修改失败！");
            }
                
        }
    }
}