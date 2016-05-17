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
namespace CSADataReport.Web.Users
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
		CSADataReport.BLL.Users bll=new CSADataReport.BLL.Users();
		CSADataReport.Model.Users model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtCnName.Text=model.CnName;
		this.txtLoginName.Text=model.LoginName;
		this.txtLoginPwd.Text=model.LoginPwd;
		this.txtCompanyId.Text=model.CompanyId.ToString();
		this.txtUserRoleId.Text=model.UserRoleId.ToString();
		this.txtUserStateId.Text=model.UserStateId.ToString();
		this.txtAddTime.Text=model.AddTime.ToString();
		this.chkIsDel.Checked=model.IsDel;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCnName.Text.Trim().Length==0)
			{
				strErr+="CnName不能为空！\\n";	
			}
			if(this.txtLoginName.Text.Trim().Length==0)
			{
				strErr+="LoginName不能为空！\\n";	
			}
			if(this.txtLoginPwd.Text.Trim().Length==0)
			{
				strErr+="LoginPwd不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCompanyId.Text))
			{
				strErr+="CompanyId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserRoleId.Text))
			{
				strErr+="UserRoleId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserStateId.Text))
			{
				strErr+="UserStateId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAddTime.Text))
			{
				strErr+="AddTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string CnName=this.txtCnName.Text;
			string LoginName=this.txtLoginName.Text;
			string LoginPwd=this.txtLoginPwd.Text;
			int CompanyId=int.Parse(this.txtCompanyId.Text);
			int UserRoleId=int.Parse(this.txtUserRoleId.Text);
			int UserStateId=int.Parse(this.txtUserStateId.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			bool IsDel=this.chkIsDel.Checked;


			CSADataReport.Model.Users model=new CSADataReport.Model.Users();
			model.Id=Id;
			model.CnName=CnName;
			model.LoginName=LoginName;
			model.LoginPwd=LoginPwd;
			model.CompanyId=CompanyId;
			model.UserRoleId=UserRoleId;
			model.UserStateId=UserStateId;
			model.AddTime=AddTime;
			model.IsDel=IsDel;

			CSADataReport.BLL.Users bll=new CSADataReport.BLL.Users();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
