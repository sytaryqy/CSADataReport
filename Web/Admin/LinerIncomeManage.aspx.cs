using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace CSADataReport.Web.Admin
{
    public partial class LinerIncomeManage: System.Web.UI.Page
    {
        //当前操作的用户实体
        protected Model.Users currentUser;

        protected void Page_Load(object sender, EventArgs e)
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