using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using LTP.Accounts.Bus;

namespace CSADataReport.Web
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                this.lblGUID.Text = this.ViewState["GUID"].ToString();
                
            }
        }
        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                if (PassErroeCount > 3)
                {
                    txtUsername.Disabled = true;
                    txtPass.Disabled = true;
                    btnLogin.Enabled = false;
                    this.lblMsg.Text = "对不起，你错误登录了三次，系统登录锁定！";
                    return;
                }

            }

            #region 检查验证码
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
            {
                if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
                {
                    this.lblMsg.Text = "所填写的验证码与所给的不符 !";
                    Session["CheckCode"] = null;
                    return;
                }
                else
                {
                    Session["CheckCode"] = null;
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            #endregion

            string userName = CSADataReport.Common.PageValidate.InputText(txtUsername.Value.Trim(), 30);
            string Password = CSADataReport.Common.PageValidate.InputText(txtPass.Value.Trim(), 30);

            //验证登录信息，如果验证通过则返回当前用户对象的安全上下文信息
            //AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(userName, Password);
            
            Model.Users newUser =CSADataReport.Common.ValidateInformation.ValidateLoginUser(userName, Password);
            if (newUser == null)//登录信息不对
            {
                this.lblMsg.Text = "登陆失败： " + userName;
                if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                {
                    int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                    Session["PassErrorCountAdmin"] = PassErroeCount + 1;
                }
                else
                {
                    Session["PassErrorCountAdmin"] = 1;
                }
            }
            else
            {
                Model.Users currentUser = newUser;
                
                    //保存当前用户对象信息
                    //FormsAuthentication.SetAuthCookie(userName, false);
                    Session["UserInfo"] = currentUser;
                    Session["MyCompany"] = currentUser.CompanyId.ToString();
                    //HttpCookie cookie = new HttpCookie("MyCompany", currentUser.CompanyId.ToString());
                    //cookie.Expires=DateTime.Now.AddDays(1);
                    //Response.Cookies.Add(cookie);
                    //Session["Style"] = currentUser.Style;
                    if (Session["returnPage"] != null)
                    {
                        string returnpage = Session["returnPage"].ToString();
                        Session["returnPage"] = null;
                        Response.Redirect(returnpage);
                    }
                    else
                    {
                        Response.Redirect("/main.htm");
                    }
                }
            }
        }
}