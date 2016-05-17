using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace CSADataReport.DAL
{
    public partial class LinerIncomeDatas
    {
        /// <summary>
        /// 得到一个对象实体,并附带LinerCompany信息
        /// </summary>
        public CSADataReport.Model.LinerIncomeDatas DataRowToModelEx(DataRow row)
        {
            CSADataReport.Model.LinerIncomeDatas model = new CSADataReport.Model.LinerIncomeDatas();
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
                if (row["ProxyShipIncome"] != null && row["ProxyShipIncome"].ToString() != "")
                {
                    model.ProxyShipIncome = decimal.Parse(row["ProxyShipIncome"].ToString());
                }
                if (row["DocumentIncome"] != null && row["DocumentIncome"].ToString() != "")
                {
                    model.DocumentIncome = decimal.Parse(row["DocumentIncome"].ToString());
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

        /// <summary>
        /// 执行存储过程，获取班轮收入数据
        /// </summary>
        /// <param name="iBaseYear">查询年份</param>
        /// <param name="iBeginDate">起始周</param>
        /// <param name="iEndDate">结束周</param>
        /// <returns>返回班轮收入数据集</returns>
        public DataSet GetLinerIncomeReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaseReprotYear", SqlDbType.Int,4),
					new SqlParameter("@BaseReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@BaseReportEndWeek", SqlDbType.Int,4)};
            parameters[0].Value = iBaseYear;
            parameters[1].Value = iBeginDate;
            parameters[2].Value = iEndDate;
            return DbHelperSQL.RunProcedure("sp_LinerIncome_GetLinerIncomeByWeek", parameters, "DataTable1");
        }
    }
}
