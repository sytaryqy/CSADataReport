﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web
{
    public partial class RouteDatasReportList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Common.CheckLogin.ShowLoginPageAndReturn();

            }

        }
    }
}