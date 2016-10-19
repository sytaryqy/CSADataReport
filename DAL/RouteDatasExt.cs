using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSADataReport.DBUtility;

namespace CSADataReport.DAL
{
    public partial class RouteDatas
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.RouteDatas DataRowToModelEx(DataRow row)
        {
            CSADataReport.Model.RouteDatas model = new CSADataReport.Model.RouteDatas();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ReportWeek"] != null && row["ReportWeek"].ToString() != "")
                {
                    model.ReportWeek = int.Parse(row["ReportWeek"].ToString());
                }
                if (row["ReportYear"] != null && row["ReportYear"].ToString() != "")
                {
                    model.ReportYear = int.Parse(row["ReportYear"].ToString());
                }
                if (row["CompanyId"] != null && row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                    model.R_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                }
                if (row["RouteId"] != null && row["RouteId"].ToString() != "")
                {
                    model.RouteId = int.Parse(row["RouteId"].ToString());
                    model.R_Routes = new DAL.Routes().GetModel(model.RouteId);
                }
                if (row["LineId"] != null && row["LineId"].ToString() != "")
                {
                    model.LineId = int.Parse(row["LineId"].ToString());
                    model.R_Lines = new DAL.Lines().GetModel(model.LineId);
                }
                if (row["GP20"] != null && row["GP20"].ToString() != "")
                {
                    model.GP20 = int.Parse(row["GP20"].ToString());
                }
                if (row["GP40"] != null && row["GP40"].ToString() != "")
                {
                    model.GP40 = int.Parse(row["GP40"].ToString());
                }
                if (row["HQ40"] != null && row["HQ40"].ToString() != "")
                {
                    model.HQ40 = int.Parse(row["HQ40"].ToString());
                }
                if (row["HQ45"] != null && row["HQ45"].ToString() != "")
                {
                    model.HQ45 = int.Parse(row["HQ45"].ToString());
                }
                if (row["TEU"] != null && row["TEU"].ToString() != "")
                {
                    model.TEU = decimal.Parse(row["TEU"].ToString());
                }
                if (row["Others"] != null && row["Others"].ToString() != "")
                {
                    model.Others = decimal.Parse(row["Others"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetReportingDataSet(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select dd.Id,dd.ReportYear,dd.ReportWeek,bb.Name as RouteName,cc.Name as LineName, ca.CompanyName,ca.AreaName,ca.CompanyNum,sum(GP20) as TotalGp20,SUM(GP40) as TotalGp40,SUM(HQ40) as TotalHq40,SUM(HQ45) as TotalOther20,SUM(Others) as TotalOther40,SUM( TEU) as TotalTeu from dbo.T_RouteDatas as dd join dbo.T_Routes as bb on dd.RouteId=bb.Id join dbo.T_Lines as cc on dd.LineId=cc.Id join (select a.Id,a.CompanyName,a.CompanyCode,a.CompanyNum,b.AreaName from dbo.T_Companies as a join dbo.T_Areas as b on a.AreaId=b.Id) as ca on dd.CompanyId=ca.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("GROUP BY dd.Id,dd.ReportYear,dd.ReportWeek,ca.CompanyName,ca.AreaName,ca.CompanyNum ,bb.Name,cc.Name");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
