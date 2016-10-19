using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web.Admin
{
    public partial class DatasManageMain : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否登录
            CSADataReport.Common.CheckLogin.CheckUserRoleAllowed("管理员");

        }
    }
}