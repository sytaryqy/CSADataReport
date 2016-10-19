using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CSADataReport.DBUtility;

namespace CSADataReport.DAL
{
    public partial class DeclareDatas
    {
        /// <summary>
        /// 获取DeclareDatas对象及其关联属性的实体
        /// </summary>
        /// <param name="Id">DeclareDatas对象ID</param>
        /// <returns>DeclareDatas对象实体</returns>
        public CSADataReport.Model.DeclareDatas GetModelEx(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,DeclareReportWeek,DeclareReportYear,CompanyId,GFOuterDeclareBallot,GFSelfDeclareBallot,GFOtherDeclareBallot,QTOuterDeclareBallot,QTSelfDeclareBallot,QTOtherDeclareBallot,GFOuterDeclareContainer,GFSelfDeclareContainer,GFOtherDeclareContainer,QTOuterDeclareContainer,QTSelfDeclareContainer,QTOtherDeclareContainer,GFOuterDeclareIncome,GFSelfDeclareIncome,GFOtherDeclareIncome,QTOuterDeclareIncome,QTSelfDeclareIncome,QTOtherDeclareIncome,AddTime,EditTime,IsReported from T_DeclareDatas ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            CSADataReport.Model.DeclareDatas model = new CSADataReport.Model.DeclareDatas();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                model.D_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                //model.D_DeclareOperationType = new DAL.DeclareOperationTypes().GetModel(model.DeclareOperationTypeId);
                //model.D_DeclareType = new DAL.DeclareTypes().GetModel(model.DeclareTypeId);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据的上报状态
        /// </summary>
        public bool UpdateReportState(CSADataReport.Model.DeclareDatas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_DeclareDatas set ");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("IsReported=@IsReported");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.EditTime;
            parameters[1].Value = model.IsReported;
            parameters[2].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetReportingDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select dd.Id,dd.DeclareReportYear,dd.DeclareReportWeek,ca.CompanyName,ca.AreaName,ca.CompanyNum,sum(dd.GFOtherDeclareBallot+dd.GFOuterDeclareBallot+dd.GFSelfDeclareBallot+dd.QTOtherDeclareBallot+dd.QTOuterDeclareBallot+dd.QTSelfDeclareBallot) as TotalBallot,SUM(GFOtherDeclareContainer+GFOuterDeclareContainer+GFSelfDeclareContainer+QTOtherDeclareContainer+QTOuterDeclareContainer+QTSelfDeclareContainer) as TotalContainer,SUM(GFOtherDeclareIncome+GFOuterDeclareIncome+GFSelfDeclareIncome+QTOtherDeclareIncome+QTOuterDeclareIncome+QTSelfDeclareIncome) as TotalIncome from dbo.T_DeclareDatas as dd join (select a.Id,a.CompanyName,a.CompanyCode,a.CompanyNum,b.AreaName from dbo.T_Companies as a join dbo.T_Areas as b on a.AreaId=b.Id) as ca on dd.CompanyId=ca.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("GROUP BY dd.Id,dd.DeclareReportYear,dd.DeclareReportWeek,ca.CompanyName,ca.AreaName,ca.CompanyNum");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 执行存储过程获取指定时间段的报关数据
        /// </summary>
        /// <param name="iBaseYear">指定年份</param>
        /// <param name="iBeginDate">开始周</param>
        /// <param name="iEndDate">结束周</param>
        /// <returns>获取报关的数据集</returns>
        public DataSet GetDeclareDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaseReprotYear", SqlDbType.Int,4),
					new SqlParameter("@BaseReportBeginWeek", SqlDbType.Int,4),
					new SqlParameter("@BaseReportEndWeek", SqlDbType.Int,4)};
            parameters[0].Value = iBaseYear;
            parameters[1].Value = iBeginDate;
            parameters[2].Value = iEndDate;
            return DbHelperSQL.RunProcedure("sp_DeclareDatas_GetDeclareDatasByWeek", parameters, "DataTable1");
        }
    }
}
