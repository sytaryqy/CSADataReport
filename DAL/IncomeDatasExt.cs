using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CSADataReport.DBUtility;

namespace CSADataReport.DAL
{
    public partial class IncomeDatas
    {
        public bool Exists(Model.IncomeDatas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_IncomeDatas");
            strSql.Append(" where CompanyId=@CompanyId and ReportYear=@ReportYear and ReportWeek=@ReportWeek");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@ReportYear", SqlDbType.Int,4),
                    new SqlParameter("@ReportWeek", SqlDbType.Int,4)
			};
            parameters[0].Value = model.CompanyId;
            parameters[1].Value = model.ReportYear;
            parameters[2].Value = model.ReportWeek;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据实体模型中的CompanyId、ReportYear、ReportWeek得到一个对象实体
        /// </summary>
        public CSADataReport.Model.IncomeDatas GetModel(Model.IncomeDatas inputmodel)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CompanyId,ReportWeek,ReportYear,ContainerIncome,BulkCargoIncome,DeclareIncome,TotalContainerIncome,TotalBulkCargoIncome,TotalDeclareIncome,IsReported,AddTime,EditTime from T_IncomeDatas ");
            strSql.Append(" where CompanyId=@CompanyId and ReportYear=@ReportYear and ReportWeek=@ReportWeek");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@ReportYear", SqlDbType.Int,4),
                    new SqlParameter("@ReportWeek", SqlDbType.Int,4)
			};
            parameters[0].Value = inputmodel.CompanyId;
            parameters[1].Value = inputmodel.ReportYear;
            parameters[2].Value = inputmodel.ReportWeek;

            CSADataReport.Model.IncomeDatas model = new CSADataReport.Model.IncomeDatas();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.IncomeDatas DataRowToModelEx(DataRow row)
        {
            CSADataReport.Model.IncomeDatas model = new CSADataReport.Model.IncomeDatas();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CompanyId"] != null && row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                    model.D_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                }
                if (row["ReportWeek"] != null && row["ReportWeek"].ToString() != "")
                {
                    model.ReportWeek = int.Parse(row["ReportWeek"].ToString());
                }
                if (row["ReportYear"] != null && row["ReportYear"].ToString() != "")
                {
                    model.ReportYear = int.Parse(row["ReportYear"].ToString());
                }
                if (row["ContainerIncome"] != null && row["ContainerIncome"].ToString() != "")
                {
                    model.ContainerIncome = decimal.Parse(row["ContainerIncome"].ToString());
                }
                if (row["BulkCargoIncome"] != null && row["BulkCargoIncome"].ToString() != "")
                {
                    model.BulkCargoIncome = decimal.Parse(row["BulkCargoIncome"].ToString());
                }
                if (row["DeclareIncome"] != null && row["DeclareIncome"].ToString() != "")
                {
                    model.DeclareIncome = decimal.Parse(row["DeclareIncome"].ToString());
                }
                if (row["TotalContainerIncome"] != null && row["TotalContainerIncome"].ToString() != "")
                {
                    model.TotalContainerIncome = decimal.Parse(row["TotalContainerIncome"].ToString());
                }
                if (row["TotalBulkCargoIncome"] != null && row["TotalBulkCargoIncome"].ToString() != "")
                {
                    model.TotalBulkCargoIncome = decimal.Parse(row["TotalBulkCargoIncome"].ToString());
                }
                if (row["TotalDeclareIncome"] != null && row["TotalDeclareIncome"].ToString() != "")
                {
                    model.TotalDeclareIncome = decimal.Parse(row["TotalDeclareIncome"].ToString());
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
            return DbHelperSQL.RunProcedure("sp_MutipleDatas_GetCombineDatas", parameters, "DataTable1");
        }

        /// <summary>
        /// 执行存储过程获取指定时间段的收入数据
        /// </summary>
        /// <param name="iBaseYear">指定年份</param>
        /// <param name="iBeginDate">开始周</param>
        /// <param name="iEndDate">结束周</param>
        /// <returns>获取收入的数据集</returns>
        public DataSet GetIncomeDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaseReprotYear", SqlDbType.Int,4),
					new SqlParameter("@BaseReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@BaseReportEndWeek", SqlDbType.Int,4)};
            parameters[0].Value = iBaseYear;
            parameters[1].Value = iBeginDate;
            parameters[2].Value = iEndDate;
            return DbHelperSQL.RunProcedure("sp_IncomeDatas_GetIncomeDatasByWeekPlusMax", parameters, "DataTable1");
        }
    }
}
