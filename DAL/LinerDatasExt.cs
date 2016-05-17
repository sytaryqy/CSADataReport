using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace CSADataReport.DAL
{
    public partial class LinerDatas
    {
        /// <summary>
        /// 得到一个对象实体,并附带LinerCompany信息
        /// </summary>
        public CSADataReport.Model.LinerDatas DataRowToModelEx(DataRow row)
        {
            CSADataReport.Model.LinerDatas model = new CSADataReport.Model.LinerDatas();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CompanyId"] != null && row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                    model.L_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                }
                if (row["ReportWeek"] != null && row["ReportWeek"].ToString() != "")
                {
                    model.ReportWeek = int.Parse(row["ReportWeek"].ToString());
                }
                if (row["ReportYear"] != null && row["ReportYear"].ToString() != "")
                {
                    model.ReportYear = int.Parse(row["ReportYear"].ToString());
                }
                if (row["LinerCompanyId"] != null && row["LinerCompanyId"].ToString() != "")
                {
                    model.LinerCompanyId = int.Parse(row["LinerCompanyId"].ToString());
                    model.L_linerCompany = new DAL.LinerCompany().GetModel(model.LinerCompanyId);
                }
                if (row["ProxyShipCount"] != null && row["ProxyShipCount"].ToString() != "")
                {
                    model.ProxyShipCount = int.Parse(row["ProxyShipCount"].ToString());
                }
                if (row["ProxyContainerCount"] != null && row["ProxyContainerCount"].ToString() != "")
                {
                    model.ProxyContainerCount = int.Parse(row["ProxyContainerCount"].ToString());
                }
                if (row["IsReported"] != null && row["IsReported"].ToString() != "")
                {
                    if ((row["IsReported"].ToString() == "1") || (row["IsReported"].ToString().ToLower() == "true"))
                    {
                        model.IsReported = true;
                    }
                    else
                    {
                        model.IsReported = false;
                    }
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["EditTime"] != null && row["EditTime"].ToString() != "")
                {
                    model.EditTime = DateTime.Parse(row["EditTime"].ToString());
                }
            }
            return model;
        }

        public DataSet GetReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate, int iLastYearSameTimeBeginDate, int iLastYearSameTimeEndDate, int iLastMonthBeginDate, int iLastMonthEndDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaseReprotYear", SqlDbType.Int,4),
					new SqlParameter("@BaseReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@BaseReportEndWeek", SqlDbType.Int,4),
                    new SqlParameter("@LastYearReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@LastYearReportEndWeek", SqlDbType.Int,4),
					new SqlParameter("@PrevMonthReportBeginWeek", SqlDbType.Int,4),
                    new SqlParameter("@PrevMonthReportEndWeek", SqlDbType.Int,4)};
            parameters[0].Value = iBaseYear;
            parameters[1].Value = iBeginDate;
            parameters[2].Value = iEndDate;
            parameters[3].Value = iLastYearSameTimeBeginDate;
            parameters[4].Value = iLastYearSameTimeEndDate;
            parameters[5].Value = iLastMonthBeginDate;
            parameters[6].Value = iLastMonthEndDate;
            return DbHelperSQL.RunProcedure("sp_LinerDatas_GetCombineDatas", parameters, "DataTable1");
        }

        public DataSet GetLinerDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaseReprotYear", SqlDbType.Int,4),
					new SqlParameter("@BaseReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@BaseReportEndWeek", SqlDbType.Int,4)};
            parameters[0].Value = iBaseYear;
            parameters[1].Value = iBeginDate;
            parameters[2].Value = iEndDate;
            return DbHelperSQL.RunProcedure("sp_LinerDatas_GetLinerDatasByWeek", parameters, "DataTable1");
        }
    }
}
