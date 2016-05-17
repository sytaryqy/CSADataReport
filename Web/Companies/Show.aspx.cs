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
namespace CSADataReport.Web.Companies
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
		CSADataReport.BLL.Companies bll=new CSADataReport.BLL.Companies();
		CSADataReport.Model.Companies model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblCompanyName.Text=model.CompanyName;
		this.lblCompanyCode.Text=model.CompanyCode;
		this.lblCompanyNum.Text=model.CompanyNum;
		this.lblAreaId.Text=model.AreaId.ToString();
		this.lblCompanyTypeId.Text=model.CompanyTypeId.ToString();
		this.lblParentCompanyId.Text=model.ParentCompanyId.ToString();
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblIsDel.Text=model.IsDel?"是":"否";

	}


    }
}
