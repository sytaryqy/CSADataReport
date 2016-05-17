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
namespace CSADataReport.Web.Areas
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		CSADataReport.BLL.Areas bll=new CSADataReport.BLL.Areas();
		CSADataReport.Model.Areas model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtAreaName.Text=model.AreaName;
		this.txtAreaCode.Text=model.AreaCode;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtAreaName.Text.Trim().Length==0)
			{
				strErr+="AreaName不能为空！\\n";	
			}
			if(this.txtAreaCode.Text.Trim().Length==0)
			{
				strErr+="AreaCode不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string AreaName=this.txtAreaName.Text;
			string AreaCode=this.txtAreaCode.Text;


			CSADataReport.Model.Areas model=new CSADataReport.Model.Areas();
			model.Id=Id;
			model.AreaName=AreaName;
			model.AreaCode=AreaCode;

			CSADataReport.BLL.Areas bll=new CSADataReport.BLL.Areas();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
