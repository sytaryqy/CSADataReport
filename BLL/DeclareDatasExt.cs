using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CSADataReport.BLL
{
    public partial class DeclareDatas
    {
        public CSADataReport.Model.DeclareDatas GetModelEx(int Id)
        {
            return new DAL.DeclareDatas().GetModelEx(Id);
        }

        /// <summary>
        /// get the data table 
        /// </summary>
        public List<CSADataReport.Model.DeclareDatas> GetModelListByCompanyId(string strCompanyId)
        {
            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(strCompanyId))
            {
                ds = dal.GetList("CompanyId=" + strCompanyId);
            }
            else
            {
                ds = dal.GetList("");
            }
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// get the combined data table
        /// </summary>
        public List<CSADataReport.Model.DeclareDatas> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// get model collections by transforming DataTable's DataRows
        /// </summary>
        public List<CSADataReport.Model.DeclareDatas> DataTableToListEx(DataTable dt)
        {
            List<CSADataReport.Model.DeclareDatas> modelList = new List<CSADataReport.Model.DeclareDatas>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CSADataReport.Model.DeclareDatas model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        model.D_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                        //model.D_DeclareOperationType = new DAL.DeclareOperationTypes().GetModel(model.DeclareOperationTypeId);
                        //model.D_DeclareType = new DAL.DeclareTypes().GetModel(model.DeclareTypeId);
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 更新一条数据的上报状态
        /// update one model's field which named "IsReported"
        /// </summary>
        public bool UpdateReportState(CSADataReport.Model.DeclareDatas model)
        {
            DAL.DeclareDatas dldDAL = new DAL.DeclareDatas();
            return dldDAL.UpdateReportState(model);
        }

        /// <summary>
        /// 获得报表数据
        /// get the reporting datas
        /// </summary>
        public DataSet GetReportingDataSet(string strWhere)
        {
            return dal.GetReportingDataSet(strWhere);
        }


        /// <summary>
        /// 获得DeclareDatas数据
        /// </summary>
        public DataSet GetDeclareDatasReportingDataSet(int iBaseYear, int iBeginDate, int iEndDate)
        {
            return dal.GetDeclareDatasReportingDataSet(iBaseYear, iBeginDate, iEndDate);
        }

        /// <summary>
        /// delete one record by model
        /// </summary>
        public bool DeleteByModel(Model.DeclareDatas model)
        {

            return dal.Delete(model.Id);
        }
    }
}
