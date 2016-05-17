using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CSADataReport.BLL
{
    public partial class LinerDatas
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCondition(string strCondition1, string strCondition2, string strCondition3, string strCondition4)
        {
            string strWhere = strCondition1 + " and " + strCondition2 + " and " + strCondition3 + " and " + strCondition4;
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取LinerDatas信息，附带LinerCompany信息
        /// </summary>
        /// <param name="strCompanyId">公司Id</param>
        /// <returns>LinerDatas的模型list</returns>
        public List<CSADataReport.Model.LinerDatas> GetModelListByCompanyId(string strCompanyId)
        {
            string strWhere = "CompanyId=" + strCompanyId;
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        public List<CSADataReport.Model.LinerDatas> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表,附带LinerCompany信息
        /// </summary>
        public List<CSADataReport.Model.LinerDatas> DataTableToListEx(DataTable dt)
        {
            List<CSADataReport.Model.LinerDatas> modelList = new List<CSADataReport.Model.LinerDatas>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CSADataReport.Model.LinerDatas model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelEx(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得Liner组合报表报表数据
        /// </summary>
        public DataSet GetReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate, int iLastYearSameTimeBeginDate, int iLastYearSameTimeEndDate, int iLastMonthBeginDate, int iLastMonthEndDate)
        {
            return dal.GetReportingDataSet(iBaseYear, iBeginDate, iEndDate, iLastYearSameTimeBeginDate, iLastYearSameTimeEndDate, iLastMonthBeginDate, iLastMonthEndDate);
        }

        /// <summary>
        /// 获得LinerDatas数据
        /// </summary>
        public DataSet GetLinerDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            return dal.GetLinerDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
        }

        /// <summary>
        /// delete one record by model
        /// </summary>
        public bool DeleteByModel(Model.LinerDatas model)
        {

            return dal.Delete(model.Id);
        }
    }
}
