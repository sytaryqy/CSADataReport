using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CSADataReport.Common;

namespace CSADataReport.Web
{
    public partial class IncomeDatasReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Common.CheckLogin.ShowLoginPageAndReturn();
                }
                else
                {
                    txbReportDate.Value = DateTime.Today.ToString("yyyy-MM");
                    Model.Users currentUser = (Model.Users)Session["UserInfo"];
                    BLL.IncomeDatas ibll = new BLL.IncomeDatas();
                    string strDate = txbReportDate.Value;
                    DateTime dateInput = DateTime.Parse(strDate);
                    int intReportYear= dateInput.Year;
                    DateTime date= dateInput.AddDays(14);
                    int intReportWeek = Common.WeekOfYear.GetWeekOfYear(date);
                    //int intReportMonth = DateTime.Today.Month;
                    int intLastWeek = Common.WeekOfYear.GetWeekOfYear(date.AddMonths(-1));
                    DataSet ds = ibll.GetList("CompanyId=" + currentUser.CompanyId + " and " + "ReportYear=" + intReportYear + " and " + "ReportWeek=" + intLastWeek);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txbLastMonthContainerIncome.Text = ds.Tables[0].Rows[0]["TotalContainerIncome"].ToString();
                        txbLastMonthBlukCargoIncome.Text = ds.Tables[0].Rows[0]["TotalBulkCargoIncome"].ToString();
                        txbLastMonthDeclareIncome.Text = ds.Tables[0].Rows[0]["TotalDeclareIncome"].ToString();
                    }
                    DataSet dsThis = ibll.GetList("CompanyId=" + currentUser.CompanyId + " and " + "ReportYear=" + intReportYear + " and " + "ReportWeek=" + intReportWeek);
                    if (dsThis != null && dsThis.Tables[0].Rows.Count > 0)
                    {
                        txbContainerIncome.Text = dsThis.Tables[0].Rows[0]["ContainerIncome"].ToString();
                        txbBulkCargoIncome.Text = dsThis.Tables[0].Rows[0]["BulkCargoIncome"].ToString();
                        txbDelcareIncome.Text = dsThis.Tables[0].Rows[0]["DeclareIncome"].ToString();
                        txbTotalContainerIncome.Text = dsThis.Tables[0].Rows[0]["TotalContainerIncome"].ToString();
                        txbTotalBulkIncome.Text = dsThis.Tables[0].Rows[0]["TotalBulkCargoIncome"].ToString();
                        txbTotalDelcareIncome.Text = dsThis.Tables[0].Rows[0]["TotalDeclareIncome"].ToString();
                    }

                }
            }
            //else
            //{
            //    if (Session["UserInfo"] == null)
            //    {
            //        Session["returnPage"] = this.Request.Url.PathAndQuery;
            //        Response.Clear();
            //        Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
            //        Response.End();
            //    }
            //    else
            //    {
            //        currentUser = (Model.Users)Session["UserInfo"];
            //    }
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Users currentUser = (Model.Users)Session["UserInfo"];
            Model.IncomeDatas model = new Model.IncomeDatas();

            //计算集装箱货代收入是否匹配
            decimal decContainerIncome;
            if (decimal.TryParse(txbContainerIncome.Text, out decContainerIncome))
            {
                model.ContainerIncome = decContainerIncome;
            }
            decimal decTotalContainerIncome;
            if (decimal.TryParse(txbTotalContainerIncome.Text, out decTotalContainerIncome))
            {
                model.TotalContainerIncome = decTotalContainerIncome;
            }
            decimal decLastMonthContainerIncome ;
            if (!decimal.TryParse(hfLastMonthContainerIncome.Value, out decLastMonthContainerIncome))
            {
                decLastMonthContainerIncome = 0;
            }
            txbLastMonthContainerIncome.Text = hfLastMonthContainerIncome.Value;
            txbLastMonthBlukCargoIncome.Text = hfLastMonthBlukCargoIncome.Value;
            txbLastMonthDeclareIncome.Text = hfLastMonthDeclareIncome.Value;
            if ((model.ContainerIncome + decLastMonthContainerIncome) != model.TotalContainerIncome)
            {
                MessageBox.Show(this, "集装箱货代本月收入和集装箱货代上月底累计收入之和与本月底累计收入不同，请检查问题后再保存！");
                return;
            }
            //计算散货货代收入是否匹配
            decimal decBulkCargoIncome;
            if (decimal.TryParse(txbBulkCargoIncome.Text, out decBulkCargoIncome))
            {
                model.BulkCargoIncome = decBulkCargoIncome;
            }
            decimal decTotalBulkIncome;
            if (decimal.TryParse(txbTotalBulkIncome.Text, out decTotalBulkIncome))
            {
                model.TotalBulkCargoIncome = decTotalBulkIncome;
            }
            decimal decLastMonthBulkCargoIncome;
            if (!decimal.TryParse(hfLastMonthBlukCargoIncome.Value, out decLastMonthBulkCargoIncome))
            {
                decLastMonthBulkCargoIncome=0;
            }
            if ((model.BulkCargoIncome + decLastMonthBulkCargoIncome) != model.TotalBulkCargoIncome)
            {
                MessageBox.Show(this, "散货货代本月收入和散货货代上月底累计收入之和与本月底累计收入不同，请检查问题后再保存！");
                return;
            }
            //计算散货报关收入是否匹配
            decimal decDeclareIncome;
            if (decimal.TryParse(txbDelcareIncome.Text, out decDeclareIncome))
            {
                model.DeclareIncome = decDeclareIncome;
            }
            decimal decTotalDelcareIncome;
            if (decimal.TryParse(txbTotalDelcareIncome.Text, out decTotalDelcareIncome))
            {
                model.TotalDeclareIncome = decTotalDelcareIncome;
            }
            decimal decLastMonthDeclareIncome;
            if (!decimal.TryParse(hfLastMonthDeclareIncome.Value, out decLastMonthDeclareIncome))
            {
                decLastMonthDeclareIncome=0;
            }
            if ((model.DeclareIncome + decLastMonthDeclareIncome) != model.TotalDeclareIncome)
            {
                MessageBox.Show(this, "散货报关本月收入和散货报关上月底累计收入之和与本月底累计收入不同，请检查问题后再保存！");
                return;
            }

            string strDate = txbReportDate.Value;
            DateTime dateInput = DateTime.Parse(strDate);
            model.ReportYear = dateInput.Year;
            DateTime date= dateInput.AddDays(14);
            model.EditTime = date;
            model.ReportWeek = Common.WeekOfYear.GetWeekOfYear(date);
            //int intLastMonth = model.ReportWeek - 1;
            model.CompanyId = currentUser.CompanyId;
            BLL.IncomeDatas incomeBLL = new BLL.IncomeDatas();
            Model.IncomeDatas modelLoaded = new Model.IncomeDatas();
            if ((modelLoaded = incomeBLL.GetModel(model)) != null)
            {
                if (modelLoaded.IsReported)
                {
                    lblMsg.Text = "该月数据已经上报，不能进行保存操作！";
                    return;
                }
                else
                {
                    model.Id = modelLoaded.Id;
                    if (incomeBLL.Update(model))
                    {
                        lblMsg.Text = "修改成功，可以进行上报！";
                        return;
                    }
                    else
                    {
                        lblMsg.Text = "修改失败！";
                        return;
                    }
                }

            }
            else
            {
                if (incomeBLL.Add(model) > 0)
                {
                    lblMsg.Text = "保存成功，可以进行上报！";
                }
                else
                {
                    lblMsg.Text = "保存失败！";
                }
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Model.Users currentUser = (Model.Users)Session["UserInfo"];
            Model.IncomeDatas model = new Model.IncomeDatas();
            string strDate = txbReportDate.Value;
            //DateTime date = DateTime.Parse(strDate);
            DateTime dateInput = DateTime.Parse(strDate);
            model.ReportYear = dateInput.Year;
            DateTime date = dateInput.AddDays(14);
            model.ReportWeek = Common.WeekOfYear.GetWeekOfYear(date);
            model.CompanyId = currentUser.CompanyId;
            BLL.IncomeDatas incomeBLL = new BLL.IncomeDatas();
            Model.IncomeDatas modelloaded = new Model.IncomeDatas();
            modelloaded= incomeBLL.GetModel(model);
            if (modelloaded != null)
            {
                if (modelloaded.IsReported)
                {
                    lblMsg.Text = "该月数据已经上报过，请勿重复上报！";
                    return;
                }
                else
                {
                    modelloaded.IsReported = true;
                    if (incomeBLL.Update(modelloaded))
                    {
                        lblMsg.Text = "上报成功！";
                    }
                    else
                    {
                        lblMsg.Text = "上报失败！";
                    }
                }
            }
            else
            {
                lblMsg.Text = "不存在对应月的数据，请先保存数据！";
            }
        }
    }
}