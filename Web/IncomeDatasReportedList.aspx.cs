using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web
{
    public partial class IncomeDatasReportedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                //judge the user's login state
                if (Session["UserInfo"] == null)
                {
                    Common.CheckLogin.ShowLoginPageAndReturn();
                }
        }
    }
}