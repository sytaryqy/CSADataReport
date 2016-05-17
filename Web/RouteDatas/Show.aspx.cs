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
namespace CSADataReport.Web.RouteDatas
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
		CSADataReport.BLL.RouteDatas bll=new CSADataReport.BLL.RouteDatas();
		CSADataReport.Model.RouteDatas model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblReportWeek.Text=model.ReportWeek.ToString();
		this.lblReportYear.Text=model.ReportYear.ToString();
		this.lblCompanyId.Text=model.CompanyId.ToString();
		this.lblRouteId.Text=model.RouteId.ToString();
		this.lblLineId.Text=model.LineId.ToString();
		this.lblGP20.Text=model.GP20.ToString();
		this.lblGP40.Text=model.GP40.ToString();
		this.lblHQ40.Text=model.HQ40.ToString();
		this.lblHQ45.Text=model.HQ45.ToString();
		this.lblTEU.Text=model.TEU.ToString();
		this.lblOthers.Text=model.Others.ToString();
		this.lblIsReported.Text=model.IsReported?"是":"否";
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblEditTime.Text=model.EditTime.ToString();

	}


    }
}
