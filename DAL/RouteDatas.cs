using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace CSADataReport.DAL
{
	/// <summary>
	/// 数据访问类:RouteDatas
	/// </summary>
	public partial class RouteDatas
	{
		public RouteDatas()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_RouteDatas"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_RouteDatas");
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
		public int Add(CSADataReport.Model.RouteDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_RouteDatas(");
			strSql.Append("ReportWeek,ReportYear,CompanyId,RouteId,LineId,GP20,GP40,HQ40,HQ45,TEU,Others,IsReported,AddTime,EditTime)");
			strSql.Append(" values (");
			strSql.Append("@ReportWeek,@ReportYear,@CompanyId,@RouteId,@LineId,@GP20,@GP40,@HQ40,@HQ45,@TEU,@Others,@IsReported,@AddTime,@EditTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportWeek", SqlDbType.Int,4),
					new SqlParameter("@ReportYear", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@RouteId", SqlDbType.Int,4),
					new SqlParameter("@LineId", SqlDbType.Int,4),
					new SqlParameter("@GP20", SqlDbType.Int,4),
					new SqlParameter("@GP40", SqlDbType.Int,4),
					new SqlParameter("@HQ40", SqlDbType.Int,4),
					new SqlParameter("@HQ45", SqlDbType.Int,4),
					new SqlParameter("@TEU", SqlDbType.Decimal,13),
					new SqlParameter("@Others", SqlDbType.Decimal,13),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ReportWeek;
			parameters[1].Value = model.ReportYear;
			parameters[2].Value = model.CompanyId;
			parameters[3].Value = model.RouteId;
			parameters[4].Value = model.LineId;
			parameters[5].Value = model.GP20;
			parameters[6].Value = model.GP40;
			parameters[7].Value = model.HQ40;
			parameters[8].Value = model.HQ45;
			parameters[9].Value = model.TEU;
			parameters[10].Value = model.Others;
			parameters[11].Value = model.IsReported;
			parameters[12].Value = model.AddTime;
			parameters[13].Value = model.EditTime;

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
		public bool Update(CSADataReport.Model.RouteDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_RouteDatas set ");
			strSql.Append("ReportWeek=@ReportWeek,");
			strSql.Append("ReportYear=@ReportYear,");
			strSql.Append("CompanyId=@CompanyId,");
			strSql.Append("RouteId=@RouteId,");
			strSql.Append("LineId=@LineId,");
			strSql.Append("GP20=@GP20,");
			strSql.Append("GP40=@GP40,");
			strSql.Append("HQ40=@HQ40,");
			strSql.Append("HQ45=@HQ45,");
			strSql.Append("TEU=@TEU,");
			strSql.Append("Others=@Others,");
			strSql.Append("IsReported=@IsReported,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("EditTime=@EditTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@ReportWeek", SqlDbType.Int,4),
					new SqlParameter("@ReportYear", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@RouteId", SqlDbType.Int,4),
					new SqlParameter("@LineId", SqlDbType.Int,4),
					new SqlParameter("@GP20", SqlDbType.Int,4),
					new SqlParameter("@GP40", SqlDbType.Int,4),
					new SqlParameter("@HQ40", SqlDbType.Int,4),
					new SqlParameter("@HQ45", SqlDbType.Int,4),
					new SqlParameter("@TEU", SqlDbType.Decimal,13),
					new SqlParameter("@Others", SqlDbType.Decimal,13),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.ReportWeek;
			parameters[1].Value = model.ReportYear;
			parameters[2].Value = model.CompanyId;
			parameters[3].Value = model.RouteId;
			parameters[4].Value = model.LineId;
			parameters[5].Value = model.GP20;
			parameters[6].Value = model.GP40;
			parameters[7].Value = model.HQ40;
			parameters[8].Value = model.HQ45;
			parameters[9].Value = model.TEU;
			parameters[10].Value = model.Others;
			parameters[11].Value = model.IsReported;
			parameters[12].Value = model.AddTime;
			parameters[13].Value = model.EditTime;
			parameters[14].Value = model.Id;

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
			strSql.Append("delete from T_RouteDatas ");
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
			strSql.Append("delete from T_RouteDatas ");
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
		public CSADataReport.Model.RouteDatas GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,ReportWeek,ReportYear,CompanyId,RouteId,LineId,GP20,GP40,HQ40,HQ45,TEU,Others,IsReported,AddTime,EditTime from T_RouteDatas ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			CSADataReport.Model.RouteDatas model=new CSADataReport.Model.RouteDatas();
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
		public CSADataReport.Model.RouteDatas DataRowToModel(DataRow row)
		{
			CSADataReport.Model.RouteDatas model=new CSADataReport.Model.RouteDatas();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["ReportWeek"]!=null && row["ReportWeek"].ToString()!="")
				{
					model.ReportWeek=int.Parse(row["ReportWeek"].ToString());
				}
				if(row["ReportYear"]!=null && row["ReportYear"].ToString()!="")
				{
					model.ReportYear=int.Parse(row["ReportYear"].ToString());
				}
				if(row["CompanyId"]!=null && row["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(row["CompanyId"].ToString());
				}
				if(row["RouteId"]!=null && row["RouteId"].ToString()!="")
				{
					model.RouteId=int.Parse(row["RouteId"].ToString());
				}
				if(row["LineId"]!=null && row["LineId"].ToString()!="")
				{
					model.LineId=int.Parse(row["LineId"].ToString());
				}
				if(row["GP20"]!=null && row["GP20"].ToString()!="")
				{
					model.GP20=int.Parse(row["GP20"].ToString());
				}
				if(row["GP40"]!=null && row["GP40"].ToString()!="")
				{
					model.GP40=int.Parse(row["GP40"].ToString());
				}
				if(row["HQ40"]!=null && row["HQ40"].ToString()!="")
				{
					model.HQ40=int.Parse(row["HQ40"].ToString());
				}
				if(row["HQ45"]!=null && row["HQ45"].ToString()!="")
				{
					model.HQ45=int.Parse(row["HQ45"].ToString());
				}
				if(row["TEU"]!=null && row["TEU"].ToString()!="")
				{
					model.TEU=decimal.Parse(row["TEU"].ToString());
				}
				if(row["Others"]!=null && row["Others"].ToString()!="")
				{
					model.Others=decimal.Parse(row["Others"].ToString());
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
			strSql.Append("select Id,ReportWeek,ReportYear,CompanyId,RouteId,LineId,GP20,GP40,HQ40,HQ45,TEU,Others,IsReported,AddTime,EditTime ");
			strSql.Append(" FROM T_RouteDatas ");
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
			strSql.Append(" Id,ReportWeek,ReportYear,CompanyId,RouteId,LineId,GP20,GP40,HQ40,HQ45,TEU,Others,IsReported,AddTime,EditTime ");
			strSql.Append(" FROM T_RouteDatas ");
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
			strSql.Append("select count(1) FROM T_RouteDatas ");
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
			strSql.Append(")AS Row, T.*  from T_RouteDatas T ");
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
			parameters[0].Value = "T_RouteDatas";
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

