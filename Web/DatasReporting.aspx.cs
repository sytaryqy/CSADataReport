using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace CSADataReport.Web
{
    public partial class DatasReporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*先清空原来数据集*/
                ReportViewer1.ShowReportBody = false;

                //estimate the user's login state
                Common.CheckLogin.CheckUserRoleNotAllowed("普通用户");

            }
        }

        //用户点击生成报表按钮处理事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strReportDate = string.Empty;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            if (iBeginDate < iEndDate)
            {
                strReportDate = "第" + iBeginDate + "-" + iEndDate + "周";
            }
            if (iBeginDate == iEndDate)
            {
                strReportDate = "第" + iBeginDate + "周";
            }

            //load ReportViewer1's default set,clear the set of LocalReport
            ReportViewer1.Reset();
            /*先清空原来数据集*/
            ReportViewer1.LocalReport.DataSources.Clear();


            /*数据集的填充，效果2-3才需要*/
            Microsoft.Reporting.WebForms.ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            switch (ddlReportingType.SelectedValue)
            {
                case "Declare":
                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + "Style2" + ".rdlc";

                    ReportParameter rpDeclare = new ReportParameter();
                    rpDeclare.Name = "ReportDateParameter";
                    rpDeclare.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpDeclare);
                    ReportViewer1.ShowReportBody = true;
                    ///*设置报表文件*/
                    //ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + "Style2" + ".rdlc";
                    /*设置数据源对应的表*/
                    rds.Value = loadDeclareData();
                    //rds.DataSourceId = "ObjectDataSource1";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "DeclareDatas":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpDeclareDatas = new ReportParameter();
                    rpDeclareDatas.Name = "ReportDateParameter";
                    rpDeclareDatas.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpDeclareDatas);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadDeclareDatas();
                    //rds.DataSourceId = "ObjectDataSource1";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "Routes":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + "Style2" + ".rdlc";

                    ReportParameter rpRoutes = new ReportParameter();
                    rpRoutes.Name = "ReportDateParameter";
                    rpRoutes.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpRoutes);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadRoutesData();
                    //rds.DataSourceId="ObjectDataSource2";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "LinerDatas":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpLinerDatas = new ReportParameter();
                    rpLinerDatas.Name = "ReportDateParameter";
                    rpLinerDatas.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpLinerDatas);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadLinerDatas();
                    //rds.DataSourceId="ObjectDataSource2";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "LinerIncome":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpLinerIncome = new ReportParameter();
                    rpLinerIncome.Name = "ReportDateParameter";
                    rpLinerIncome.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpLinerIncome);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadLinerIncome();
                    //rds.DataSourceId="ObjectDataSource2";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "IncomeDatas":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpIncomeDatas = new ReportParameter();
                    rpIncomeDatas.Name = "ReportDateParameter";
                    rpIncomeDatas.Values.Add(strReportDate);
                    //ReportViewer1.LocalReport.SetParameters(rpIncomeDatas);
                    ReportParameter rpIncomeDatasEnd = new ReportParameter();
                    rpIncomeDatasEnd.Name = "ReportParameter1";
                    rpIncomeDatasEnd.Values.Add("1-"+iEndDate.ToString());
                    //ReportViewer1.LocalReport.SetParameters(rpIncomeDatasEnd);
                    ReportParameterCollection paramsReport = new ReportParameterCollection();
                    paramsReport.Add(rpIncomeDatas);
                    paramsReport.Add(rpIncomeDatasEnd);
                    ReportViewer1.LocalReport.SetParameters(paramsReport);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadIncomeDatas();
                    //rds.DataSourceId="ObjectDataSource2";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                case "Composite":

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpComposite = new ReportParameter();
                    rpComposite.Name = "ReportDateParameter";
                    rpComposite.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpComposite);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadCompositeData();
                    //rds.DataSourceId="ObjectDataSource4";
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    break;

                default:

                    /*设置报表文件*/
                    ReportViewer1.LocalReport.ReportPath = "App_LocalResources/Report" + ddlReportingType.SelectedValue + ".rdlc";

                    ReportParameter rpLiner = new ReportParameter();
                    rpLiner.Name = "ReportDateParameter";
                    rpLiner.Values.Add(strReportDate);
                    ReportViewer1.LocalReport.SetParameters(rpLiner);
                    ReportViewer1.ShowReportBody = true;
                    /*设置数据源对应的表*/
                    rds.Value = loadLinerData();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ///*设置报表文件*/
                    //ReportViewer1.LocalReport.ReportPath = "Report" + ddlReportingType.SelectedValue + ".rdlc";
                    ///*设置数据源对应的表*/
                    //rds.Value = loadLinerData();
                    break;
            }

            //ReportDataSource rds = new ReportDataSource("DataSet1", loadDeclareData());   
            /*将数据集添加到本地报表，效果2-3才需要*/
            ReportViewer1.LocalReport.DataSources.Add(rds);
            /*刷新报表显示*/
            ReportViewer1.LocalReport.Refresh();
        }


        /// <summary>
        /// 获取报关数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadDeclareData()
        {
            string strDeclareCondition = GetDeclareReportCondition();
            BLL.DeclareDatas declareBll = new BLL.DeclareDatas();
            DataSet ds = declareBll.GetReportingDataSet(strDeclareCondition);
            return ds.Tables[0];
        }


        /// <summary>
        /// 获取航线数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadRoutesData()
        {
            string strRoutesCondition = GetReportCondition();
            BLL.RouteDatas routesBll = new BLL.RouteDatas();
            DataSet ds = routesBll.GetReportingDataSet(strRoutesCondition);
            return ds.Tables[0];
        }


        /// <summary>
        /// 读取班轮货量数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadLinerDatas()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            BLL.LinerDatas linerBll = new BLL.LinerDatas();
            DataSet ds = linerBll.GetLinerDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取班轮收入数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadLinerIncome()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            BLL.LinerIncomeDatas linerBll = new BLL.LinerIncomeDatas();
            DataSet ds = linerBll.GetLinerIncomeReportingDataSet(iBaseYear, iBeginDate, iEndDate);
            return ds.Tables[0];
        }


        /// <summary>
        /// 获取收入数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadIncomeDatas()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            BLL.IncomeDatas incomeBll = new BLL.IncomeDatas();
            DataSet ds = incomeBll.GetIncomeDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取报关数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadDeclareDatas()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            BLL.DeclareDatas declareBll = new BLL.DeclareDatas();
            DataSet ds = declareBll.GetDeclareDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
            return ds.Tables[0];
        }


        /// <summary>
        /// 获取综合报表相关数据
        /// </summary>
        /// <returns></returns>
        private DataTable loadCompositeData()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            int iLastYearSameTimeBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastYearSameTimeBeginDate.Text));
            int iLastYearSameTimeEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastYearSameTimeEndDate.Text));
            int iLastMonthBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastMonthBeginDate.Text));
            int iLastMonthEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastMonthEndDate.Text));
            string strIncomeCondition = GetReportCondition();
            BLL.IncomeDatas incomeBll = new BLL.IncomeDatas();
            DataSet ds = incomeBll.GetReportingDataSet(iBaseYear, iBeginDate, iEndDate, iLastYearSameTimeBeginDate, iLastYearSameTimeEndDate, iLastMonthBeginDate, iLastMonthEndDate);
            return ds.Tables[0];
        }


        /// <summary>
        /// 获取集装箱班轮报表数据
        /// </summary>
        /// <returns>数据表</returns>
        private DataTable loadLinerData()
        {
            int iBaseYear = DateTime.Parse(txbEndDate.Text).Year;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            int iLastYearSameTimeBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastYearSameTimeBeginDate.Text));
            int iLastYearSameTimeEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastYearSameTimeEndDate.Text));
            int iLastMonthBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastMonthBeginDate.Text));
            int iLastMonthEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbLastMonthEndDate.Text));
            //string strLinerCondition = GetReportCondition();
            BLL.LinerDatas linerBll = new BLL.LinerDatas();
            DataSet ds = linerBll.GetReportingDataSet(iBaseYear, iBeginDate, iEndDate, iLastYearSameTimeBeginDate, iLastYearSameTimeEndDate, iLastMonthBeginDate, iLastMonthEndDate);
            return ds.Tables[0];
        }


        /// <summary>
        /// 获取报关查询条件字符串
        /// </summary>
        /// <returns>字符串</returns>
        private string GetDeclareReportCondition()
        {
            string strCondition = string.Empty;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            if (iBeginDate < iEndDate)
            {
                strCondition = " DeclareReportYear= " + DateTime.Parse(txbEndDate.Text).Year + " and DeclareReportWeek BETWEEN " + iBeginDate + " AND " + iEndDate + " and IsReported = 'true'";
            }
            if (iBeginDate == iEndDate)
            {
                strCondition = " DeclareReportYear= " + DateTime.Parse(txbEndDate.Text).Year + " and DeclareReportWeek =" + iEndDate + " and IsReported = 'true'";
            }
            return strCondition;
        }


        /// <summary>
        /// 获取查询用的条件字符串
        /// </summary>
        /// <returns>字符串</returns>
        private string GetReportCondition()
        {
            string strCondition = string.Empty;
            int iBeginDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbBeginDate.Text));
            int iEndDate = Common.WeekOfYear.GetWeekOfYear(DateTime.Parse(txbEndDate.Text));
            if (iBeginDate < iEndDate)
            {
                strCondition = " ReportYear= " + DateTime.Parse(txbEndDate.Text).Year + " and ReportWeek BETWEEN " + iBeginDate + " AND " + iEndDate + " and IsReported = 'true'";
            }
            if (iBeginDate == iEndDate)
            {
                strCondition = " ReportYear= " + DateTime.Parse(txbEndDate.Text).Year + " and ReportWeek =" + iEndDate + " and IsReported = 'true'";
            }
            return strCondition;
        }


        /// <summary>
        /// 下拉框选择项变化后，显示相应的日期选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlReportingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果选择的值为Liner或者Composite，则显示同比和环比日期所在的panal，并将相应元素加入按钮验证组
            if (ddlReportingType.SelectedValue == "Liner" || ddlReportingType.SelectedValue == "Composite")
            {
                panCombine.Visible = true;
                LYSTBeginRequiredFieldValidator.ValidationGroup = "ValidateGetReport";
                LYSTEndRequiredFieldValidator.ValidationGroup = "ValidateGetReport";
                LMBeginRequiredFieldValidator.ValidationGroup = "ValidateGetReport";
                LMEndRequiredFieldValidator.ValidationGroup = "ValidateGetReport";
            }
            //如果选择的值不是Liner或者Composite，则隐藏panal，并将相应元素从按钮验证组中去掉
            else
            {
                panCombine.Visible = false;
                LYSTBeginRequiredFieldValidator.ValidationGroup = "";
                LYSTEndRequiredFieldValidator.ValidationGroup = "";
                LMBeginRequiredFieldValidator.ValidationGroup = "";
                LMEndRequiredFieldValidator.ValidationGroup = "";
            }
        }

    }
}