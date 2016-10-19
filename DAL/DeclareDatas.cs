using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CSADataReport.DBUtility;//Please add references
namespace CSADataReport.DAL
{
	/// <summary>
	/// 数据访问类:DeclareDatas
	/// </summary>
	public partial class DeclareDatas
	{
		public DeclareDatas()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_DeclareDatas"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_DeclareDatas");
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
		public int Add(CSADataReport.Model.DeclareDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_DeclareDatas(");
			strSql.Append("DeclareReportWeek,DeclareReportYear,CompanyId,GFOuterDeclareBallot,GFSelfDeclareBallot,GFOtherDeclareBallot,QTOuterDeclareBallot,QTSelfDeclareBallot,QTOtherDeclareBallot,GFOuterDeclareContainer,GFSelfDeclareContainer,GFOtherDeclareContainer,QTOuterDeclareContainer,QTSelfDeclareContainer,QTOtherDeclareContainer,GFOuterDeclareIncome,GFSelfDeclareIncome,GFOtherDeclareIncome,QTOuterDeclareIncome,QTSelfDeclareIncome,QTOtherDeclareIncome,AddTime,EditTime,IsReported)");
			strSql.Append(" values (");
			strSql.Append("@DeclareReportWeek,@DeclareReportYear,@CompanyId,@GFOuterDeclareBallot,@GFSelfDeclareBallot,@GFOtherDeclareBallot,@QTOuterDeclareBallot,@QTSelfDeclareBallot,@QTOtherDeclareBallot,@GFOuterDeclareContainer,@GFSelfDeclareContainer,@GFOtherDeclareContainer,@QTOuterDeclareContainer,@QTSelfDeclareContainer,@QTOtherDeclareContainer,@GFOuterDeclareIncome,@GFSelfDeclareIncome,@GFOtherDeclareIncome,@QTOuterDeclareIncome,@QTSelfDeclareIncome,@QTOtherDeclareIncome,@AddTime,@EditTime,@IsReported)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DeclareReportWeek", SqlDbType.Int,4),
					new SqlParameter("@DeclareReportYear", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFSelfDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFOtherDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTOuterDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTSelfDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTOtherDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFSelfDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFOtherDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTOuterDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTSelfDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTOtherDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@GFSelfDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@GFOtherDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTOuterDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTSelfDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTOtherDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@IsReported", SqlDbType.Bit,1)};
			parameters[0].Value = model.DeclareReportWeek;
			parameters[1].Value = model.DeclareReportYear;
			parameters[2].Value = model.CompanyId;
			parameters[3].Value = model.GFOuterDeclareBallot;
			parameters[4].Value = model.GFSelfDeclareBallot;
			parameters[5].Value = model.GFOtherDeclareBallot;
			parameters[6].Value = model.QTOuterDeclareBallot;
			parameters[7].Value = model.QTSelfDeclareBallot;
			parameters[8].Value = model.QTOtherDeclareBallot;
			parameters[9].Value = model.GFOuterDeclareContainer;
			parameters[10].Value = model.GFSelfDeclareContainer;
			parameters[11].Value = model.GFOtherDeclareContainer;
			parameters[12].Value = model.QTOuterDeclareContainer;
			parameters[13].Value = model.QTSelfDeclareContainer;
			parameters[14].Value = model.QTOtherDeclareContainer;
			parameters[15].Value = model.GFOuterDeclareIncome;
			parameters[16].Value = model.GFSelfDeclareIncome;
			parameters[17].Value = model.GFOtherDeclareIncome;
			parameters[18].Value = model.QTOuterDeclareIncome;
			parameters[19].Value = model.QTSelfDeclareIncome;
			parameters[20].Value = model.QTOtherDeclareIncome;
			parameters[21].Value = model.AddTime;
			parameters[22].Value = model.EditTime;
			parameters[23].Value = model.IsReported;

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
		public bool Update(CSADataReport.Model.DeclareDatas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_DeclareDatas set ");
			strSql.Append("DeclareReportWeek=@DeclareReportWeek,");
			strSql.Append("DeclareReportYear=@DeclareReportYear,");
			strSql.Append("CompanyId=@CompanyId,");
			strSql.Append("GFOuterDeclareBallot=@GFOuterDeclareBallot,");
			strSql.Append("GFSelfDeclareBallot=@GFSelfDeclareBallot,");
			strSql.Append("GFOtherDeclareBallot=@GFOtherDeclareBallot,");
			strSql.Append("QTOuterDeclareBallot=@QTOuterDeclareBallot,");
			strSql.Append("QTSelfDeclareBallot=@QTSelfDeclareBallot,");
			strSql.Append("QTOtherDeclareBallot=@QTOtherDeclareBallot,");
			strSql.Append("GFOuterDeclareContainer=@GFOuterDeclareContainer,");
			strSql.Append("GFSelfDeclareContainer=@GFSelfDeclareContainer,");
			strSql.Append("GFOtherDeclareContainer=@GFOtherDeclareContainer,");
			strSql.Append("QTOuterDeclareContainer=@QTOuterDeclareContainer,");
			strSql.Append("QTSelfDeclareContainer=@QTSelfDeclareContainer,");
			strSql.Append("QTOtherDeclareContainer=@QTOtherDeclareContainer,");
			strSql.Append("GFOuterDeclareIncome=@GFOuterDeclareIncome,");
			strSql.Append("GFSelfDeclareIncome=@GFSelfDeclareIncome,");
			strSql.Append("GFOtherDeclareIncome=@GFOtherDeclareIncome,");
			strSql.Append("QTOuterDeclareIncome=@QTOuterDeclareIncome,");
			strSql.Append("QTSelfDeclareIncome=@QTSelfDeclareIncome,");
			strSql.Append("QTOtherDeclareIncome=@QTOtherDeclareIncome,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("EditTime=@EditTime,");
			strSql.Append("IsReported=@IsReported");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@DeclareReportWeek", SqlDbType.Int,4),
					new SqlParameter("@DeclareReportYear", SqlDbType.Int,4),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFSelfDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFOtherDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTOuterDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTSelfDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@QTOtherDeclareBallot", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFSelfDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFOtherDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTOuterDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTSelfDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@QTOtherDeclareContainer", SqlDbType.Int,4),
					new SqlParameter("@GFOuterDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@GFSelfDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@GFOtherDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTOuterDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTSelfDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@QTOtherDeclareIncome", SqlDbType.Decimal,13),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@EditTime", SqlDbType.DateTime),
					new SqlParameter("@IsReported", SqlDbType.Bit,1),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.DeclareReportWeek;
			parameters[1].Value = model.DeclareReportYear;
			parameters[2].Value = model.CompanyId;
			parameters[3].Value = model.GFOuterDeclareBallot;
			parameters[4].Value = model.GFSelfDeclareBallot;
			parameters[5].Value = model.GFOtherDeclareBallot;
			parameters[6].Value = model.QTOuterDeclareBallot;
			parameters[7].Value = model.QTSelfDeclareBallot;
			parameters[8].Value = model.QTOtherDeclareBallot;
			parameters[9].Value = model.GFOuterDeclareContainer;
			parameters[10].Value = model.GFSelfDeclareContainer;
			parameters[11].Value = model.GFOtherDeclareContainer;
			parameters[12].Value = model.QTOuterDeclareContainer;
			parameters[13].Value = model.QTSelfDeclareContainer;
			parameters[14].Value = model.QTOtherDeclareContainer;
			parameters[15].Value = model.GFOuterDeclareIncome;
			parameters[16].Value = model.GFSelfDeclareIncome;
			parameters[17].Value = model.GFOtherDeclareIncome;
			parameters[18].Value = model.QTOuterDeclareIncome;
			parameters[19].Value = model.QTSelfDeclareIncome;
			parameters[20].Value = model.QTOtherDeclareIncome;
			parameters[21].Value = model.AddTime;
			parameters[22].Value = model.EditTime;
			parameters[23].Value = model.IsReported;
			parameters[24].Value = model.Id;

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
			strSql.Append("delete from T_DeclareDatas ");
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
			strSql.Append("delete from T_DeclareDatas ");
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
		public CSADataReport.Model.DeclareDatas GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,DeclareReportWeek,DeclareReportYear,CompanyId,GFOuterDeclareBallot,GFSelfDeclareBallot,GFOtherDeclareBallot,QTOuterDeclareBallot,QTSelfDeclareBallot,QTOtherDeclareBallot,GFOuterDeclareContainer,GFSelfDeclareContainer,GFOtherDeclareContainer,QTOuterDeclareContainer,QTSelfDeclareContainer,QTOtherDeclareContainer,GFOuterDeclareIncome,GFSelfDeclareIncome,GFOtherDeclareIncome,QTOuterDeclareIncome,QTSelfDeclareIncome,QTOtherDeclareIncome,AddTime,EditTime,IsReported from T_DeclareDatas ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			CSADataReport.Model.DeclareDatas model=new CSADataReport.Model.DeclareDatas();
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
		public CSADataReport.Model.DeclareDatas DataRowToModel(DataRow row)
		{
			CSADataReport.Model.DeclareDatas model=new CSADataReport.Model.DeclareDatas();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["DeclareReportWeek"]!=null && row["DeclareReportWeek"].ToString()!="")
				{
					model.DeclareReportWeek=int.Parse(row["DeclareReportWeek"].ToString());
				}
				if(row["DeclareReportYear"]!=null && row["DeclareReportYear"].ToString()!="")
				{
					model.DeclareReportYear=int.Parse(row["DeclareReportYear"].ToString());
				}
				if(row["CompanyId"]!=null && row["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(row["CompanyId"].ToString());
				}
				if(row["GFOuterDeclareBallot"]!=null && row["GFOuterDeclareBallot"].ToString()!="")
				{
					model.GFOuterDeclareBallot=int.Parse(row["GFOuterDeclareBallot"].ToString());
				}
				if(row["GFSelfDeclareBallot"]!=null && row["GFSelfDeclareBallot"].ToString()!="")
				{
					model.GFSelfDeclareBallot=int.Parse(row["GFSelfDeclareBallot"].ToString());
				}
				if(row["GFOtherDeclareBallot"]!=null && row["GFOtherDeclareBallot"].ToString()!="")
				{
					model.GFOtherDeclareBallot=int.Parse(row["GFOtherDeclareBallot"].ToString());
				}
				if(row["QTOuterDeclareBallot"]!=null && row["QTOuterDeclareBallot"].ToString()!="")
				{
					model.QTOuterDeclareBallot=int.Parse(row["QTOuterDeclareBallot"].ToString());
				}
				if(row["QTSelfDeclareBallot"]!=null && row["QTSelfDeclareBallot"].ToString()!="")
				{
					model.QTSelfDeclareBallot=int.Parse(row["QTSelfDeclareBallot"].ToString());
				}
				if(row["QTOtherDeclareBallot"]!=null && row["QTOtherDeclareBallot"].ToString()!="")
				{
					model.QTOtherDeclareBallot=int.Parse(row["QTOtherDeclareBallot"].ToString());
				}
				if(row["GFOuterDeclareContainer"]!=null && row["GFOuterDeclareContainer"].ToString()!="")
				{
					model.GFOuterDeclareContainer=int.Parse(row["GFOuterDeclareContainer"].ToString());
				}
				if(row["GFSelfDeclareContainer"]!=null && row["GFSelfDeclareContainer"].ToString()!="")
				{
					model.GFSelfDeclareContainer=int.Parse(row["GFSelfDeclareContainer"].ToString());
				}
				if(row["GFOtherDeclareContainer"]!=null && row["GFOtherDeclareContainer"].ToString()!="")
				{
					model.GFOtherDeclareContainer=int.Parse(row["GFOtherDeclareContainer"].ToString());
				}
				if(row["QTOuterDeclareContainer"]!=null && row["QTOuterDeclareContainer"].ToString()!="")
				{
					model.QTOuterDeclareContainer=int.Parse(row["QTOuterDeclareContainer"].ToString());
				}
				if(row["QTSelfDeclareContainer"]!=null && row["QTSelfDeclareContainer"].ToString()!="")
				{
					model.QTSelfDeclareContainer=int.Parse(row["QTSelfDeclareContainer"].ToString());
				}
				if(row["QTOtherDeclareContainer"]!=null && row["QTOtherDeclareContainer"].ToString()!="")
				{
					model.QTOtherDeclareContainer=int.Parse(row["QTOtherDeclareContainer"].ToString());
				}
				if(row["GFOuterDeclareIncome"]!=null && row["GFOuterDeclareIncome"].ToString()!="")
				{
					model.GFOuterDeclareIncome=decimal.Parse(row["GFOuterDeclareIncome"].ToString());
				}
				if(row["GFSelfDeclareIncome"]!=null && row["GFSelfDeclareIncome"].ToString()!="")
				{
					model.GFSelfDeclareIncome=decimal.Parse(row["GFSelfDeclareIncome"].ToString());
				}
				if(row["GFOtherDeclareIncome"]!=null && row["GFOtherDeclareIncome"].ToString()!="")
				{
					model.GFOtherDeclareIncome=decimal.Parse(row["GFOtherDeclareIncome"].ToString());
				}
				if(row["QTOuterDeclareIncome"]!=null && row["QTOuterDeclareIncome"].ToString()!="")
				{
					model.QTOuterDeclareIncome=decimal.Parse(row["QTOuterDeclareIncome"].ToString());
				}
				if(row["QTSelfDeclareIncome"]!=null && row["QTSelfDeclareIncome"].ToString()!="")
				{
					model.QTSelfDeclareIncome=decimal.Parse(row["QTSelfDeclareIncome"].ToString());
				}
				if(row["QTOtherDeclareIncome"]!=null && row["QTOtherDeclareIncome"].ToString()!="")
				{
					model.QTOtherDeclareIncome=decimal.Parse(row["QTOtherDeclareIncome"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["EditTime"]!=null && row["EditTime"].ToString()!="")
				{
					model.EditTime=DateTime.Parse(row["EditTime"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,DeclareReportWeek,DeclareReportYear,CompanyId,GFOuterDeclareBallot,GFSelfDeclareBallot,GFOtherDeclareBallot,QTOuterDeclareBallot,QTSelfDeclareBallot,QTOtherDeclareBallot,GFOuterDeclareContainer,GFSelfDeclareContainer,GFOtherDeclareContainer,QTOuterDeclareContainer,QTSelfDeclareContainer,QTOtherDeclareContainer,GFOuterDeclareIncome,GFSelfDeclareIncome,GFOtherDeclareIncome,QTOuterDeclareIncome,QTSelfDeclareIncome,QTOtherDeclareIncome,AddTime,EditTime,IsReported ");
			strSql.Append(" FROM T_DeclareDatas ");
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
			strSql.Append(" Id,DeclareReportWeek,DeclareReportYear,CompanyId,GFOuterDeclareBallot,GFSelfDeclareBallot,GFOtherDeclareBallot,QTOuterDeclareBallot,QTSelfDeclareBallot,QTOtherDeclareBallot,GFOuterDeclareContainer,GFSelfDeclareContainer,GFOtherDeclareContainer,QTOuterDeclareContainer,QTSelfDeclareContainer,QTOtherDeclareContainer,GFOuterDeclareIncome,GFSelfDeclareIncome,GFOtherDeclareIncome,QTOuterDeclareIncome,QTSelfDeclareIncome,QTOtherDeclareIncome,AddTime,EditTime,IsReported ");
			strSql.Append(" FROM T_DeclareDatas ");
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
			strSql.Append("select count(1) FROM T_DeclareDatas ");
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
			strSql.Append(")AS Row, T.*  from T_DeclareDatas T ");
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
			parameters[0].Value = "T_DeclareDatas";
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

