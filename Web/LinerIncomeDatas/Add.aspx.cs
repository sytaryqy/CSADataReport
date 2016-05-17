using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace CSADataReport.Web.LinerIncomeDatas
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtCompanyId.Text))
			{
				strErr+="CompanyId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtReportWeek.Text))
			{
				strErr+="ReportWeek格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtReportYear.Text))
			{
				strErr+="ReportYear格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLinerCompanyId.Text))
			{
				strErr+="LinerCompanyId格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtProxyShipIncome.Text))
			{
				strErr+="ProxyShipIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtDocumentIncome.Text))
			{
				strErr+="DocumentIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAddTime.Text))
			{
				strErr+="AddTime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtEditTime.Text))
			{
				strErr+="EditTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CompanyId=int.Parse(this.txtCompanyId.Text);
			int ReportWeek=int.Parse(this.txtReportWeek.Text);
			int ReportYear=int.Parse(this.txtReportYear.Text);
			int LinerCompanyId=int.Parse(this.txtLinerCompanyId.Text);
			decimal ProxyShipIncome=decimal.Parse(this.txtProxyShipIncome.Text);
			decimal DocumentIncome=decimal.Parse(this.txtDocumentIncome.Text);
			bool IsReported=this.chkIsReported.Checked;
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime EditTime=DateTime.Parse(this.txtEditTime.Text);

			CSADataReport.Model.LinerIncomeDatas model=new CSADataReport.Model.LinerIncomeDatas();
			model.CompanyId=CompanyId;
			model.ReportWeek=ReportWeek;
			model.ReportYear=ReportYear;
			model.LinerCompanyId=LinerCompanyId;
			model.ProxyShipIncome=ProxyShipIncome;
			model.DocumentIncome=DocumentIncome;
			model.IsReported=IsReported;
			model.AddTime=AddTime;
			model.EditTime=EditTime;

			CSADataReport.BLL.LinerIncomeDatas bll=new CSADataReport.BLL.LinerIncomeDatas();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
