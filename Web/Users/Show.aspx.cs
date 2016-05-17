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
namespace CSADataReport.Web.Users
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
		CSADataReport.BLL.Users bll=new CSADataReport.BLL.Users();
		CSADataReport.Model.Users model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblCnName.Text=model.CnName;
		this.lblLoginName.Text=model.LoginName;
		this.lblLoginPwd.Text=model.LoginPwd;
		this.lblCompanyId.Text=model.CompanyId.ToString();
		this.lblUserRoleId.Text=model.UserRoleId.ToString();
		this.lblUserStateId.Text=model.UserStateId.ToString();
		this.lblAddTime.Text=model.AddTime.ToString();
		this.lblIsDel.Text=model.IsDel?"是":"否";

	}


    }
}
