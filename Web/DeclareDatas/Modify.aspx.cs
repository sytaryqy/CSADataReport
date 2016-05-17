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
namespace CSADataReport.Web.DeclareDatas
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
		CSADataReport.BLL.DeclareDatas bll=new CSADataReport.BLL.DeclareDatas();
		CSADataReport.Model.DeclareDatas model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtDeclareReportWeek.Text=model.DeclareReportWeek.ToString();
		this.txtDeclareReportYear.Text=model.DeclareReportYear.ToString();
		this.txtCompanyId.Text=model.CompanyId.ToString();
		this.txtGFOuterDeclareBallot.Text=model.GFOuterDeclareBallot.ToString();
		this.txtGFSelfDeclareBallot.Text=model.GFSelfDeclareBallot.ToString();
		this.txtGFOtherDeclareBallot.Text=model.GFOtherDeclareBallot.ToString();
		this.txtQTOuterDeclareBallot.Text=model.QTOuterDeclareBallot.ToString();
		this.txtQTSelfDeclareBallot.Text=model.QTSelfDeclareBallot.ToString();
		this.txtQTOtherDeclareBallot.Text=model.QTOtherDeclareBallot.ToString();
		this.txtGFOuterDeclareContainer.Text=model.GFOuterDeclareContainer.ToString();
		this.txtGFSelfDeclareContainer.Text=model.GFSelfDeclareContainer.ToString();
		this.txtGFOtherDeclareContainer.Text=model.GFOtherDeclareContainer.ToString();
		this.txtQTOuterDeclareContainer.Text=model.QTOuterDeclareContainer.ToString();
		this.txtQTSelfDeclareContainer.Text=model.QTSelfDeclareContainer.ToString();
		this.txtQTOtherDeclareContainer.Text=model.QTOtherDeclareContainer.ToString();
		this.txtGFOuterDeclareIncome.Text=model.GFOuterDeclareIncome.ToString();
		this.txtGFSelfDeclareIncome.Text=model.GFSelfDeclareIncome.ToString();
		this.txtGFOtherDeclareIncome.Text=model.GFOtherDeclareIncome.ToString();
		this.txtQTOuterDeclareIncome.Text=model.QTOuterDeclareIncome.ToString();
		this.txtQTSelfDeclareIncome.Text=model.QTSelfDeclareIncome.ToString();
		this.txtQTOtherDeclareIncome.Text=model.QTOtherDeclareIncome.ToString();
		this.txtAddTime.Text=model.AddTime.ToString();
		this.txtEditTime.Text=model.EditTime.ToString();
		this.chkIsReported.Checked=model.IsReported;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtDeclareReportWeek.Text))
			{
				strErr+="DeclareReportWeek格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDeclareReportYear.Text))
			{
				strErr+="DeclareReportYear格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCompanyId.Text))
			{
				strErr+="CompanyId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFOuterDeclareBallot.Text))
			{
				strErr+="GFOuterDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFSelfDeclareBallot.Text))
			{
				strErr+="GFSelfDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFOtherDeclareBallot.Text))
			{
				strErr+="GFOtherDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTOuterDeclareBallot.Text))
			{
				strErr+="QTOuterDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTSelfDeclareBallot.Text))
			{
				strErr+="QTSelfDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTOtherDeclareBallot.Text))
			{
				strErr+="QTOtherDeclareBallot格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFOuterDeclareContainer.Text))
			{
				strErr+="GFOuterDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFSelfDeclareContainer.Text))
			{
				strErr+="GFSelfDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGFOtherDeclareContainer.Text))
			{
				strErr+="GFOtherDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTOuterDeclareContainer.Text))
			{
				strErr+="QTOuterDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTSelfDeclareContainer.Text))
			{
				strErr+="QTSelfDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQTOtherDeclareContainer.Text))
			{
				strErr+="QTOtherDeclareContainer格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGFOuterDeclareIncome.Text))
			{
				strErr+="GFOuterDeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGFSelfDeclareIncome.Text))
			{
				strErr+="GFSelfDeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGFOtherDeclareIncome.Text))
			{
				strErr+="GFOtherDeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtQTOuterDeclareIncome.Text))
			{
				strErr+="QTOuterDeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtQTSelfDeclareIncome.Text))
			{
				strErr+="QTSelfDeclareIncome格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtQTOtherDeclareIncome.Text))
			{
				strErr+="QTOtherDeclareIncome格式错误！\\n";	
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
			int Id=int.Parse(this.lblId.Text);
			int DeclareReportWeek=int.Parse(this.txtDeclareReportWeek.Text);
			int DeclareReportYear=int.Parse(this.txtDeclareReportYear.Text);
			int CompanyId=int.Parse(this.txtCompanyId.Text);
			int GFOuterDeclareBallot=int.Parse(this.txtGFOuterDeclareBallot.Text);
			int GFSelfDeclareBallot=int.Parse(this.txtGFSelfDeclareBallot.Text);
			int GFOtherDeclareBallot=int.Parse(this.txtGFOtherDeclareBallot.Text);
			int QTOuterDeclareBallot=int.Parse(this.txtQTOuterDeclareBallot.Text);
			int QTSelfDeclareBallot=int.Parse(this.txtQTSelfDeclareBallot.Text);
			int QTOtherDeclareBallot=int.Parse(this.txtQTOtherDeclareBallot.Text);
			int GFOuterDeclareContainer=int.Parse(this.txtGFOuterDeclareContainer.Text);
			int GFSelfDeclareContainer=int.Parse(this.txtGFSelfDeclareContainer.Text);
			int GFOtherDeclareContainer=int.Parse(this.txtGFOtherDeclareContainer.Text);
			int QTOuterDeclareContainer=int.Parse(this.txtQTOuterDeclareContainer.Text);
			int QTSelfDeclareContainer=int.Parse(this.txtQTSelfDeclareContainer.Text);
			int QTOtherDeclareContainer=int.Parse(this.txtQTOtherDeclareContainer.Text);
			decimal GFOuterDeclareIncome=decimal.Parse(this.txtGFOuterDeclareIncome.Text);
			decimal GFSelfDeclareIncome=decimal.Parse(this.txtGFSelfDeclareIncome.Text);
			decimal GFOtherDeclareIncome=decimal.Parse(this.txtGFOtherDeclareIncome.Text);
			decimal QTOuterDeclareIncome=decimal.Parse(this.txtQTOuterDeclareIncome.Text);
			decimal QTSelfDeclareIncome=decimal.Parse(this.txtQTSelfDeclareIncome.Text);
			decimal QTOtherDeclareIncome=decimal.Parse(this.txtQTOtherDeclareIncome.Text);
			DateTime AddTime=DateTime.Parse(this.txtAddTime.Text);
			DateTime EditTime=DateTime.Parse(this.txtEditTime.Text);
			bool IsReported=this.chkIsReported.Checked;


			CSADataReport.Model.DeclareDatas model=new CSADataReport.Model.DeclareDatas();
			model.Id=Id;
			model.DeclareReportWeek=DeclareReportWeek;
			model.DeclareReportYear=DeclareReportYear;
			model.CompanyId=CompanyId;
			model.GFOuterDeclareBallot=GFOuterDeclareBallot;
			model.GFSelfDeclareBallot=GFSelfDeclareBallot;
			model.GFOtherDeclareBallot=GFOtherDeclareBallot;
			model.QTOuterDeclareBallot=QTOuterDeclareBallot;
			model.QTSelfDeclareBallot=QTSelfDeclareBallot;
			model.QTOtherDeclareBallot=QTOtherDeclareBallot;
			model.GFOuterDeclareContainer=GFOuterDeclareContainer;
			model.GFSelfDeclareContainer=GFSelfDeclareContainer;
			model.GFOtherDeclareContainer=GFOtherDeclareContainer;
			model.QTOuterDeclareContainer=QTOuterDeclareContainer;
			model.QTSelfDeclareContainer=QTSelfDeclareContainer;
			model.QTOtherDeclareContainer=QTOtherDeclareContainer;
			model.GFOuterDeclareIncome=GFOuterDeclareIncome;
			model.GFSelfDeclareIncome=GFSelfDeclareIncome;
			model.GFOtherDeclareIncome=GFOtherDeclareIncome;
			model.QTOuterDeclareIncome=QTOuterDeclareIncome;
			model.QTSelfDeclareIncome=QTSelfDeclareIncome;
			model.QTOtherDeclareIncome=QTOtherDeclareIncome;
			model.AddTime=AddTime;
			model.EditTime=EditTime;
			model.IsReported=IsReported;

			CSADataReport.BLL.DeclareDatas bll=new CSADataReport.BLL.DeclareDatas();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
