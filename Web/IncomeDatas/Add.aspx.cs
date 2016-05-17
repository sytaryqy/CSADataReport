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
namespace CSADataReport.Web.IncomeDatas
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
			if(!PageValidate.IsDecimal(txtContainerIncome.Text))
			{
				strErr+="ContainerIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtBulkCargoIncome.Text))
			{
				strErr+="BulkCargoIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtDeclareIncome.Text))
			{
				strErr+="DeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTotalContainerIncome.Text))
			{
				strErr+="TotalContainerIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTotalBulkCargoIncome.Text))
			{
				strErr+="TotalBulkCargoIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTotalDeclareIncome.Text))
			{
				strErr+="TotalDeclareIncome格式错误！\\n";	
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
			decimal ContainerIncome=decimal.Parse(this.txtContainerIncome.Text);
			decimal BulkCargoIncome=decimal.Parse(this.txtBulkCargoIncome.Text);
			decimal DeclareIncome=decimal.Parse(this.txtDeclareIncome.Text);
			decimal TotalContainerIncome=decimal.Parse(this.txtTotalContainerIncome.Text);
			decimal TotalBulkCargoIncome=decimal.Parse(this.txtTotalBulkCargoIncome.Text);
			decimal TotalDeclareIncome=decimal.Parse(this.txtTotalDeclareIncome.Text);
			bool IsReported=this.chkIsReported.Checked;
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime EditTime=DateTime.Parse(this.txtEditTime.Text);

			CSADataReport.Model.IncomeDatas model=new CSADataReport.Model.IncomeDatas();
			model.CompanyId=CompanyId;
			model.ReportWeek=ReportWeek;
			model.ReportYear=ReportYear;
			model.ContainerIncome=ContainerIncome;
			model.BulkCargoIncome=BulkCargoIncome;
			model.DeclareIncome=DeclareIncome;
			model.TotalContainerIncome=TotalContainerIncome;
			model.TotalBulkCargoIncome=TotalBulkCargoIncome;
			model.TotalDeclareIncome=TotalDeclareIncome;
			model.IsReported=IsReported;
			model.AddTime=AddTime;
			model.EditTime=EditTime;

			CSADataReport.BLL.IncomeDatas bll=new CSADataReport.BLL.IncomeDatas();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
