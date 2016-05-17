using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CSADataReport.BLL
{
    public partial class IncomeDatas
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Model.IncomeDatas model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.IncomeDatas GetModel(Model.IncomeDatas model)
        {

            return dal.GetModel(model);
        }

        /// <summary>
        /// 获取IncomeDatas信息
        /// </summary>
        /// <param name="strCompanyId">公司Id</param>
        /// <returns>LinerDatas的模型list</returns>
        public List<CSADataReport.Model.IncomeDatas> GetModelListByCompanyId(string strCompanyId)
        {
            string strWhere = "CompanyId=" + strCompanyId;
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }


        /// <summary>
        /// Get IncomeDatas model list with CompanyName
        /// </summary>
        /// <param name="strWhere">search condition</param>
        /// <returns>IncomeDatas list</returns>
        public List<CSADataReport.Model.IncomeDatas> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CSADataReport.Model.IncomeDatas> DataTableToListEx(DataTable dt)
        {
            List<CSADataReport.Model.IncomeDatas> modelList = new List<CSADataReport.Model.IncomeDatas>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CSADataReport.Model.IncomeDatas model;
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
        /// 获得报表数据
        /// </summary>
        public DataSet GetReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate, int iLastYearSameTimeBeginDate, int iLastYearSameTimeEndDate, int iLastMonthBeginDate, int iLastMonthEndDate)
        {
            return dal.GetReportingDataSet(iBaseYear, iBeginDate, iEndDate, iLastYearSameTimeBeginDate, iLastYearSameTimeEndDate, iLastMonthBeginDate, iLastMonthEndDate);
        }

        /// <summary>
        /// 获得LinerDatas数据
        /// </summary>
        public DataSet GetIncomeDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            return dal.GetIncomeDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
        }

        /// <summary>
        /// delete one record by model
        /// </summary>
        public bool DeleteByModel(Model.IncomeDatas model)
        {

            return dal.Delete(model.Id);
        }

    }
}
