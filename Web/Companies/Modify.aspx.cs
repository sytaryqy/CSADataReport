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
namespace CSADataReport.Web.Companies
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
		CSADataReport.BLL.Companies bll=new CSADataReport.BLL.Companies();
		CSADataReport.Model.Companies model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtCompanyName.Text=model.CompanyName;
		this.txtCompanyCode.Text=model.CompanyCode;
		this.txtCompanyNum.Text=model.CompanyNum;
		this.txtAreaId.Text=model.AreaId.ToString();
		this.txtCompanyTypeId.Text=model.CompanyTypeId.ToString();
		this.txtParentCompanyId.Text=model.ParentCompanyId.ToString();
		this.txtAddTime.Text=model.AddTime.ToString();
		this.chkIsDel.Checked=model.IsDel;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCompanyName.Text.Trim().Length==0)
			{
				strErr+="CompanyName不能为空！\\n";	
			}
			if(this.txtCompanyCode.Text.Trim().Length==0)
			{
				strErr+="CompanyCode不能为空！\\n";	
			}
			if(this.txtCompanyNum.Text.Trim().Length==0)
			{
				strErr+="CompanyNum不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAreaId.Text))
			{
				strErr+="AreaId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCompanyTypeId.Text))
			{
				strErr+="CompanyTypeId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtParentCompanyId.Text))
			{
				strErr+="ParentCompanyId格式错误！\\n";	
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
			string CompanyName=this.txtCompanyName.Text;
			string CompanyCode=this.txtCompanyCode.Text;
			string CompanyNum=this.txtCompanyNum.Text;
			int AreaId=int.Parse(this.txtAreaId.Text);
			int CompanyTypeId=int.Parse(this.txtCompanyTypeId.Text);
			int ParentCompanyId=int.Parse(this.txtParentCompanyId.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			bool IsDel=this.chkIsDel.Checked;


			CSADataReport.Model.Companies model=new CSADataReport.Model.Companies();
			model.Id=Id;
			model.CompanyName=CompanyName;
			model.CompanyCode=CompanyCode;
			model.CompanyNum=CompanyNum;
			model.AreaId=AreaId;
			model.CompanyTypeId=CompanyTypeId;
			model.ParentCompanyId=ParentCompanyId;
			model.AddTime=AddTime;
			model.IsDel=IsDel;

			CSADataReport.BLL.Companies bll=new CSADataReport.BLL.Companies();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
