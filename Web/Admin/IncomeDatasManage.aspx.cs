using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web.Admin
{
    public partial class IncomeDatasManage: System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否登录
            CSADataReport.Common.CheckLogin.CheckUserRoleAllowed("管理员");
            
        }

        protected void btnGetDatas_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            //Judge the content of the textbox named txbBeginYear
            if (!string.IsNullOrEmpty(txbBeginYear.Text))   
            {
                //Judge the content of the textbox named txbBeginWeek
                if (!string.IsNullOrEmpty(txbBeginWeek.Text))
                {
                    strWhere = "ReportYear>=" + txbBeginYear.Text + " and ReportWeek>=" +
                txbBeginWeek.Text;
                    //Judge the state of the checkbox named ckbIsSelectAllDatas
                    //If false add the string like "CompanyId=XX" to strWhere
                    if (ckbIsSelectAllDatas.Checked != true)
                    {
                        strWhere += " and CompanyId="+ddlCompanyInfos.SelectedValue;
                    }
                }
                else
                {
                    strWhere = "ReportYear>=" + txbBeginYear.Text;
                    if (ckbIsSelectAllDatas.Checked != true)
                    {
                        strWhere += " and CompanyId=" + ddlCompanyInfos.SelectedValue;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txbBeginWeek.Text))
                {
                    strWhere = "ReportWeek>=" + txbBeginWeek.Text;
                    if (ckbIsSelectAllDatas.Checked != true)
                    {
                        strWhere += " and CompanyId=" + ddlCompanyInfos.SelectedValue;
                    }
                }
                else
                {
                    if (ckbIsSelectAllDatas.Checked != true)
                    {
                        strWhere += "CompanyId=" + ddlCompanyInfos.SelectedValue;
                    }
                    else
                    {
                        strWhere = " ";
                    }
                }
            }
            ObjectDataSource1.SelectParameters["strWhere"].DefaultValue = strWhere;
            ObjectDataSource1.Select();
            ObjectDataSource1.DataBind();
        }

        protected void ckbIsSelectAllDatas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIsSelectAllDatas.Checked == true)
            {
                ddlCompanyInfos.Visible = false;
            }
            else
            {
                ddlCompanyInfos.Visible = true;
            }
        }
        
    }
}