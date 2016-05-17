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
namespace CSADataReport.Web.DeclareDatas
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
		CSADataReport.BLL.DeclareDatas bll=new CSADataReport.BLL.DeclareDatas();
		CSADataReport.Model.DeclareDatas model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblDeclareReportWeek.Text=model.DeclareReportWeek.ToString();
		this.lblDeclareReportYear.Text=model.DeclareReportYear.ToString();
		this.lblCompanyId.Text=model.CompanyId.ToString();
		this.lblGFOuterDeclareBallot.Text=model.GFOuterDeclareBallot.ToString();
		this.lblGFSelfDeclareBallot.Text=model.GFSelfDeclareBallot.ToString();
		this.lblGFOtherDeclareBallot.Text=model.GFOtherDeclareBallot.ToString();
		this.lblQTOuterDeclareBallot.Text=model.QTOuterDeclareBallot.ToString();
		this.lblQTSelfDeclareBallot.Text=model.QTSelfDeclareBallot.ToString();
		this.lblQTOtherDeclareBallot.Text=model.QTOtherDeclareBallot.ToString();
		this.lblGFOuterDeclareContainer.Text=model.GFOuterDeclareContainer.ToString();
		this.lblGFSelfDeclareContainer.Text=model.GFSelfDeclareContainer.ToString();
		this.lblGFOtherDeclareContainer.Text=model.GFOtherDeclareContainer.ToString();
		this.lblQTOuterDeclareContainer.Text=model.QTOuterDeclareContainer.ToString();
		this.lblQTSelfDeclareContainer.Text=model.QTSelfDeclareContainer.ToString();
		this.lblQTOtherDeclareContainer.Text=model.QTOtherDeclareContainer.ToString();
		this.lblGFOuterDeclareIncome.Text=model.GFOuterDeclareIncome.ToString();
		this.lblGFSelfDeclareIncome.Text=model.GFSelfDeclareIncome.ToString();
		this.lblGFOtherDeclareIncome.Text=model.GFOtherDeclareIncome.ToString();
		this.lblQTOuterDeclareIncome.Text=model.QTOuterDeclareIncome.ToString();
		this.lblQTSelfDeclareIncome.Text=model.QTSelfDeclareIncome.ToString();
		this.lblQTOtherDeclareIncome.Text=model.QTOtherDeclareIncome.ToString();
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblEditTime.Text=model.EditTime.ToString();
		this.lblIsReported.Text=model.IsReported?"是":"否";

	}


    }
}
