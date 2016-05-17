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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string AreaName=this.txtAreaName.Text;
			string AreaCode=this.txtAreaCode.Text;

			CSADataReport.Model.Areas model=new CSADataReport.Model.Areas();
			model.AreaName=AreaName;
			model.AreaCode=AreaCode;

			CSADataReport.BLL.Areas bll=new CSADataReport.BLL.Areas();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
