using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CSADataReport.DAL
{
	/// <summary>
	/// 数据访问类:LinerDatas
	/// </summary>
	public partial class LinerDatas
	{
		public LinerDatas()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_LinerDatas"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_LinerDatas");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CSADataReport.Model.LinerDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_LinerDatas(");
			strSql.Append("CompanyId,ReportWeek,ReportYear,LinerCompanyId,ProxyShipCount,ProxyContainerCount,IsReported,AddTime,EditTime)");
			strSql.Append(" values (");
			strSql.Append("@CompanyId,@ReportWeek,@ReportYear,@LinerCompanyId,@ProxyShipCount,@ProxyContainerCount,@IsReported,@AddTime,@EditTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@ReportWeek", SqlDbType.Int,4),
					new SqlParameter("@ReportYear", SqlDbType.Int,4),
					new SqlParameter("@LinerCompanyId", SqlDbType.Int,4),
					new SqlParameter("@ProxyShipCount", SqlDbType.Int,4),
					new SqlParameter("@ProxyContainerCount", SqlDbType.Int,4),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime)};
			parameters[0].Value = model.CompanyId;
			parameters[1].Value = model.ReportWeek;
			parameters[2].Value = model.ReportYear;
			parameters[3].Value = model.LinerCompanyId;
			parameters[4].Value = model.ProxyShipCount;
			parameters[5].Value = model.ProxyContainerCount;
			parameters[6].Value = model.IsReported;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.EditTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CSADataReport.Model.LinerDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_LinerDatas set ");
			strSql.Append("CompanyId=@CompanyId,");
			strSql.Append("ReportWeek=@ReportWeek,");
			strSql.Append("ReportYear=@ReportYear,");
			strSql.Append("LinerCompanyId=@LinerCompanyId,");
			strSql.Append("ProxyShipCount=@ProxyShipCount,");
			strSql.Append("ProxyContainerCount=@ProxyContainerCount,");
			strSql.Append("IsReported=@IsReported,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("EditTime=@EditTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@ReportWeek", SqlDbType.Int,4),
					new SqlParameter("@ReportYear", SqlDbType.Int,4),
					new SqlParameter("@LinerCompanyId", SqlDbType.Int,4),
					new SqlParameter("@ProxyShipCount", SqlDbType.Int,4),
					new SqlParameter("@ProxyContainerCount", SqlDbType.Int,4),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.CompanyId;
			parameters[1].Value = model.ReportWeek;
			parameters[2].Value = model.ReportYear;
			parameters[3].Value = model.LinerCompanyId;
			parameters[4].Value = model.ProxyShipCount;
			parameters[5].Value = model.ProxyContainerCount;
			parameters[6].Value = model.IsReported;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.EditTime;
			parameters[9].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LinerDatas ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LinerDatas ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public CSADataReport.Model.LinerDatas GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,CompanyId,ReportWeek,ReportYear,LinerCompanyId,ProxyShipCount,ProxyContainerCount,IsReported,AddTime,EditTime from T_LinerDatas ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			CSADataReport.Model.LinerDatas model=new CSADataReport.Model.LinerDatas();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public CSADataReport.Model.LinerDatas DataRowToModel(DataRow row)
		{
			CSADataReport.Model.LinerDatas model=new CSADataReport.Model.LinerDatas();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["CompanyId"]!=null && row["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(row["CompanyId"].ToString());
				}
				if(row["ReportWeek"]!=null && row["ReportWeek"].ToString()!="")
				{
					model.ReportWeek=int.Parse(row["ReportWeek"].ToString());
				}
				if(row["ReportYear"]!=null && row["ReportYear"].ToString()!="")
				{
					model.ReportYear=int.Parse(row["ReportYear"].ToString());
				}
				if(row["LinerCompanyId"]!=null && row["LinerCompanyId"].ToString()!="")
				{
					model.LinerCompanyId=int.Parse(row["LinerCompanyId"].ToString());
				}
				if(row["ProxyShipCount"]!=null && row["ProxyShipCount"].ToString()!="")
				{
					model.ProxyShipCount=int.Parse(row["ProxyShipCount"].ToString());
				}
				if(row["ProxyContainerCount"]!=null && row["ProxyContainerCount"].ToString()!="")
				{
					model.ProxyContainerCount=int.Parse(row["ProxyContainerCount"].ToString());
				}
				if(row["IsReported"]!=null && row["IsReported"].ToString()!="")
				{
					if((row["IsReported"].ToString()=="1")||(row["IsReported"].ToString().ToLower()=="true"))
					{
						model.IsReported=true;
					}
					else
					{
						model.IsReported=false;
					}
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["EditTime"]!=null && row["EditTime"].ToString()!="")
				{
					model.EditTime=DateTime.Parse(row["EditTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,CompanyId,ReportWeek,ReportYear,LinerCompanyId,ProxyShipCount,ProxyContainerCount,IsReported,AddTime,EditTime ");
			strSql.Append(" FROM T_LinerDatas ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,CompanyId,ReportWeek,ReportYear,LinerCompanyId,ProxyShipCount,ProxyContainerCount,IsReported,AddTime,EditTime ");
			strSql.Append(" FROM T_LinerDatas ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_LinerDatas ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from T_LinerDatas T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_LinerDatas";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

