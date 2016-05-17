using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.SessionState;

namespace CSADataReport.Web.Ashx
{
    /// <summary>
    /// GetLastMonthDatas 的摘要说明
    /// </summary>
    public class GetLastMonthDatas : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context){
            string strDate = context.Request.QueryString["date"];
            Model.Users currentuser = context.Session["UserInfo"] as Model.Users;
            BLL.IncomeDatas ibll = new BLL.IncomeDatas();
            //string[] strDate= strTableName.Split('-');
            //string strReportYear = strDate[0];
            //string strReportMonth = strDate[1];
            //string strLastMonth = (int.Parse(strReportMonth) - 1).ToString();
            //List< Model.IncomeDatas> list = ibll.GetModelList("CompanyId="+currentuser.CompanyId+" and "+"ReportYear="+strReportYear+" and "+"ReportWeek in (" + strLastMonth + "," + strReportMonth  + ")");
            DateTime dateInput = DateTime.Parse(strDate);
            int intReportYear = dateInput.Year;
            DateTime date = dateInput.AddDays(14);
            int intLastReportWeek = Common.WeekOfYear.GetWeekOfYear(date.AddMonths(-1));
            List<Model.IncomeDatas> list = ibll.GetModelList("CompanyId=" + currentuser.CompanyId + " and " + "ReportYear =" + intReportYear + " and " + "ReportWeek =" + intLastReportWeek );
            if (list.Count > 0)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                StringBuilder sb = new StringBuilder();
                sb.Append("{IncomeDatas:");
                //List<MyGssms.Model.Grade> gds = new List<MyGssms.Model.Grade>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //   MyGssms.Model.Grade gd= ConvertDrToModel( dr);
                //   gds.Add(gd);
                //}
                sb.Append(jss.Serialize(list));
                sb.Append("}");
                context.Response.Write("ok@" + sb.ToString());
            }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    //private MyGssms.Model.Grade ConvertDrToModel(DataRow dr)
    //{
    //    MyGssms.Model.Grade gd = new MyGssms.Model.Grade();
    //    gd.GID =int.Parse( dr["GID"].ToString());
    //    gd.GName = dr["GName"].ToString();
    //    gd.GAddtime = DateTime.Parse(dr["GAddtime"].ToString());
    //    gd.GIsDel = bool.Parse(dr["GIsDel"].ToString());
    //    return gd;
    //}
    }
}