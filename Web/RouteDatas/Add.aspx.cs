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
namespace CSADataReport.Web.RouteDatas
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtReportWeek.Text))
			{
				strErr+="ReportWeek格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtReportYear.Text))
			{
				strErr+="ReportYear格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCompanyId.Text))
			{
				strErr+="CompanyId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRouteId.Text))
			{
				strErr+="RouteId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLineId.Text))
			{
				strErr+="LineId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGP20.Text))
			{
				strErr+="GP20格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGP40.Text))
			{
				strErr+="GP40格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtHQ40.Text))
			{
				strErr+="HQ40格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtHQ45.Text))
			{
				strErr+="HQ45格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTEU.Text))
			{
				strErr+="TEU格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtOthers.Text))
			{
				strErr+="Others格式错误！\\n";	
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
			int ReportWeek=int.Parse(this.txtReportWeek.Text);
			int ReportYear=int.Parse(this.txtReportYear.Text);
			int CompanyId=int.Parse(this.txtCompanyId.Text);
			int RouteId=int.Parse(this.txtRouteId.Text);
			int LineId=int.Parse(this.txtLineId.Text);
			int GP20=int.Parse(this.txtGP20.Text);
			int GP40=int.Parse(this.txtGP40.Text);
			int HQ40=int.Parse(this.txtHQ40.Text);
			int HQ45=int.Parse(this.txtHQ45.Text);
			decimal TEU=decimal.Parse(this.txtTEU.Text);
			decimal Others=decimal.Parse(this.txtOthers.Text);
			bool IsReported=this.chkIsReported.Checked;
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime EditTime=DateTime.Parse(this.txtEditTime.Text);

			CSADataReport.Model.RouteDatas model=new CSADataReport.Model.RouteDatas();
			model.ReportWeek=ReportWeek;
			model.ReportYear=ReportYear;
			model.CompanyId=CompanyId;
			model.RouteId=RouteId;
			model.LineId=LineId;
			model.GP20=GP20;
			model.GP40=GP40;
			model.HQ40=HQ40;
			model.HQ45=HQ45;
			model.TEU=TEU;
			model.Others=Others;
			model.IsReported=IsReported;
			model.AddTime=AddTime;
			model.EditTime=EditTime;

			CSADataReport.BLL.RouteDatas bll=new CSADataReport.BLL.RouteDatas();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
