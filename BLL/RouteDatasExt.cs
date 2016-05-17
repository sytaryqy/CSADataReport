using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSADataReport.BLL
{
    public partial class RouteDatas
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCondition(string strCondition1, string strCondition2, string strCondition3,string strCondition4)
        {
            string strWhere = strCondition1 + " and " + strCondition2 + " and " + strCondition3 + " and " + strCondition4;
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCondition(string strCondition1, string strCondition2, string strCondition3, string strCondition4,string strCondition5)
        {
            string strWhere = strCondition1 + " and " + strCondition2 + " and " + strCondition3 + " and " + strCondition4 + " and " + strCondition5;
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取LinerDatas信息，附带LinerCompany信息
        /// </summary>
        /// <param name="strCompanyId">公司Id</param>
        /// <returns>LinerDatas的模型list</returns>
        public List<CSADataReport.Model.RouteDatas> GetModelListByCompanyId(string strCompanyId)
        {
            string strWhere = "CompanyId=" + strCompanyId;
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// Get RouteDatas models that have the company's infomations and the route's infomations using the condition string:strWhere
        /// </summary>
        /// <param name="strWhere">search condition</param>
        /// <returns>all routedatas models which equal the condition of strWhere </returns>
        public List<CSADataReport.Model.RouteDatas> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表,附带LinerCompany信息
        /// </summary>
        public List<CSADataReport.Model.RouteDatas> DataTableToListEx(DataTable dt)
        {
            List<CSADataReport.Model.RouteDatas> modelList = new List<CSADataReport.Model.RouteDatas>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CSADataReport.Model.RouteDatas model;
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
        /// 获取原先填报过的数据内容List
        /// </summary>
        /// <param name="strCompanyId">口岸序号</param>
        /// <returns></returns>
        public List<CSADataReport.Model.RouteDatas> LoadRecentDatas(string strCompanyId)
        {
            List<Model.RouteDatas> routeDatasList = null; ;
            if (Maticsoft.Common.DataCache.GetCache("RouteDatasTemp" + strCompanyId) != null)
            {
                byte[] streamBufferWrite = new byte[1024 * 10];
                streamBufferWrite = (byte[])Maticsoft.Common.DataCache.GetCache("RouteDatasTemp" + strCompanyId);
                using (MemoryStream streamTempWrite = new MemoryStream(streamBufferWrite))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    routeDatasList = bf.Deserialize(streamTempWrite) as List<Model.RouteDatas>;
                }
            }
            else
            {
                
                FileInfo fi=new FileInfo(@"C:\CsaDataReportTemp\RouteDatasTemp"+strCompanyId+".dat");
                if (fi.Exists)
                {
                    using (Stream streamTempWrite = new FileStream(@"C:\CsaDataReportTemp\RouteDatasTemp" + strCompanyId + ".dat", FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        routeDatasList = bf.Deserialize(streamTempWrite) as List<Model.RouteDatas>;
                    }
                }
            }
                return routeDatasList;
            }

        /// <summary>
        /// 储存填报的数据内容
        /// </summary>
        /// <param name="strCompanyId">口岸序号</param>
        /// <returns></returns>
        public void SaveInputedDatas(List<Model.RouteDatas> listRouteDatas,string strCompanyId)
        {
            byte[] streamBufferRead = new byte[1024 * 10];
            using (MemoryStream streamTempRead = new MemoryStream(streamBufferRead))
            {
                //string strPath= Server.MapPath("RouteDatasTemp.dat");
                //Stream s = File.Open(strPath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(streamTempRead, listRouteDatas);
                Maticsoft.Common.DataCache.SetCache("RouteDatasTemp"+strCompanyId, streamBufferRead, DateTime.Now.AddDays(31), TimeSpan.Zero);
            }
        }

        /// <summary>
        /// 储存填报的数据内容为缓存文件
        /// </summary>
        /// <param name="strCompanyId">口岸序号</param>
        /// <returns></returns>
        public void SaveInputedDatasToFile(List<Model.RouteDatas> listRouteDatas, string strCompanyId)
        {
            byte[] streamBufferRead = new byte[1024 * 10];
            using (Stream streamTempRead = new FileStream (@"C:\CsaDataReportTemp\RouteDatasTemp"+strCompanyId+".dat",FileMode.Create,FileAccess.Write,FileShare.None))
            {
                //string strPath= Server.MapPath("RouteDatasTemp.dat");
                //Stream s = File.Open(strPath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(streamTempRead, listRouteDatas);
            }
        }

        /// <summary>
        /// 获得报表数据
        /// </summary>
        public DataSet GetReportingDataSet(string strWhere)
        {
            return dal.GetReportingDataSet(strWhere);
        }


        /// <summary>
        /// delete one record by model
        /// </summary>
        public bool DeleteByModel(Model.RouteDatas model)
        {

            return dal.Delete(model.Id);
        }
            
    }
}
