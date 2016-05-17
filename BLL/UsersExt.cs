using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CSADataReport.BLL
{
    public partial class Users
    {
        public CSADataReport.Model.Users GetModelEx(int Id)
        {
            return new DAL.Users().GetModelEx(Id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(CSADataReport.Model.Users model)
        {
            return dal.UpdateEx(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CSADataReport.Model.Users> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CSADataReport.Model.Users> DataTableToListEx(DataTable dt)
        {
            List<CSADataReport.Model.Users> modelList = new List<CSADataReport.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CSADataReport.Model.Users model;
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
        /// 更新制定用户名的密码
        /// </summary>
        public bool UpdatePwd(CSADataReport.Model.Users model)
        {
            return dal.UpdatePwd(model);
        }
    }

}
