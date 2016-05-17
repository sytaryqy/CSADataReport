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
namespace CSADataReport.Web.IncomeDatas
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int Id=(Convert.ToInt32(strid));
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(int Id)
	{
		CSADataReport.BLL.IncomeDatas bll=new CSADataReport.BLL.IncomeDatas();
		CSADataReport.Model.IncomeDatas model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblCompanyId.Text=model.CompanyId.ToString();
		this.lblReportWeek.Text=model.ReportWeek.ToString();
		this.lblReportYear.Text=model.ReportYear.ToString();
		this.lblContainerIncome.Text=model.ContainerIncome.ToString();
		this.lblBulkCargoIncome.Text=model.BulkCargoIncome.ToString();
		this.lblDeclareIncome.Text=model.DeclareIncome.ToString();
		this.lblTotalContainerIncome.Text=model.TotalContainerIncome.ToString();
		this.lblTotalBulkCargoIncome.Text=model.TotalBulkCargoIncome.ToString();
		this.lblTotalDeclareIncome.Text=model.TotalDeclareIncome.ToString();
		this.lblIsReported.Text=model.IsReported?"是":"否";
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblEditTime.Text=model.EditTime.ToString();

	}


    }
}
