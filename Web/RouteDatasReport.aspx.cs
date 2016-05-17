using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using log4net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace CSADataReport.Web
{
    public partial class RouteDatasReport : System.Web.UI.Page
    {
        //存放用户输入后保存的数据
        private static List<Model.RouteDatas> listTemp = new List<Model.RouteDatas>();

        //log4net对象
        private static ILog log = LogManager.GetLogger(typeof(RouteDatasReport));

        //临时存放html页面的数据输入table的内容
        private DataTable dataTable = null;

        //当前操作的用户实体
        protected Model.Users currentUser;

        //进行业务逻辑层操作的实体
        private BLL.RouteDatas routedatasBussiness = new BLL.RouteDatas();


        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化页面操作
            if (!Page.IsPostBack)
            {
                //判断用户是否登录
                if (Session["UserInfo"] == null)
                {
                    Session["returnPage"] = this.Request.Url.PathAndQuery;
                    Response.Clear();
                    Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                    Response.End();
                }
                else
                {
                    currentUser = (Model.Users)Session["UserInfo"];
                    this.Bind(true);
                    List<Model.RouteDatas> routeDatasList = routedatasBussiness.LoadRecentDatas(currentUser.CompanyId.ToString());
                    if (routeDatasList != null)
                    {
                        if (routeDatasList[0].EditTime != null)
                        {
                            txbReportDate.Value = ((DateTime)routeDatasList[0].EditTime).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            txbReportDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                        for (int i = 0; i < routeDatasList.Count; i++)
                        {
                            if (i == 0)
                            {
                                InitGridView(i, routeDatasList[i]);
                            }
                            else
                            {
                                LinkButton1_Click(null, new EventArgs());
                                InitGridView(i, routeDatasList[i]);
                            }
                        }
                    }
                    else
                    {
                        InitGridView(0, null);
                        txbReportDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                }
            }

            //非第一次登录状态下判断用户是否登录
            if (Session["UserInfo"] == null)
            {
                Session["returnPage"] = this.Request.Url.PathAndQuery;
                Response.Clear();
                Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                Response.End();
            }
            else
            {
                currentUser = (Model.Users)Session["UserInfo"];
            }
        }

        /// <summary>
        /// 初始化GridView
        /// </summary>
        /// <param name="i">GridView中的行数</param>
        /// <param name="model">数据源实体</param>
        private void InitGridView(int i,Model.RouteDatas model)
        {
            GridViewRow row = GridView1.Rows[i];
            DropDownList x1 = row.FindControl("x1") as DropDownList;
            x1.DataSource = new BLL.Routes().GetAllList();
            x1.DataTextField = "Name";
            x1.DataValueField = "Id";
            x1.DataBind();
            if (model != null)
            {
                x1.SelectedValue = model.RouteId.ToString();
            }
            string s = x1.SelectedValue;
            DropDownList x2 = row.FindControl("x2") as DropDownList;
            x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
            x2.DataTextField = "Name";
            x2.DataValueField = "Id";
            x2.DataBind();
            TextBox x3 = row.FindControl("x3") as TextBox;
            TextBox x4 = row.FindControl("x4") as TextBox;
            TextBox x5 = row.FindControl("x5") as TextBox;
            TextBox x6 = row.FindControl("x6") as TextBox;
            TextBox x7 = row.FindControl("x7") as TextBox;
            TextBox x8 = row.FindControl("x8") as TextBox;
            x1.AutoPostBack = x2.AutoPostBack = true;
            //x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
            //x4.AutoPostBack = x5.AutoPostBack = true;
            //x6.AutoPostBack = x7.AutoPostBack = x8.AutoPostBack = true;
            x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
            //x2.SelectedIndexChanged += new EventHandler(x2_SelectedIndexChanged);
            if (model != null) 
            {
                //x1.SelectedValue = model.RouteId.ToString();
                x2.SelectedValue = model.LineId.ToString();
                x3.Text = model.GP20.ToString();
                x4.Text = model.GP40.ToString();
                x5.Text = model.HQ40.ToString();
                x6.Text = model.HQ45.ToString();
                x7.Text = model.Others.ToString();
                x8.Text = model.TEU.ToString();
            }
        }

        /// <summary>
        /// 获取页面对应的table结构内容
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            if (ViewState["dt"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("routeName", typeof(String));
                dataTable.Columns.Add("lineName", typeof(String));
                dataTable.Columns.Add("GP20", typeof(String));
                dataTable.Columns.Add("GP40", typeof(String));
                dataTable.Columns.Add("HQ40", typeof(String));
                dataTable.Columns.Add("HQ45", typeof(String));
                dataTable.Columns.Add("others", typeof(String));
                dataTable.Columns.Add("TEU", typeof(String));
                return dataTable;
            }
            else
            {
                return ViewState["dt"] as DataTable;
            }
        }

        /// <summary>
        /// 修改页面table后重新绑定GridView
        /// </summary>
        /// <param name="AddBlankRow">是否新增行</param>
        private void Bind(bool AddBlankRow)
        {
            dataTable = GetDataTable();
            if (AddBlankRow)
            {
                dataTable.Rows.Add(dataTable.NewRow());
                ViewState["dt"] = dataTable;
            }
            this.GridView1.DataSource = dataTable;
            this.GridView1.DataBind();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList x1 = e.Row.FindControl("x1") as DropDownList;
                DropDownList x2 = e.Row.FindControl("x2") as DropDownList;
                TextBox x3 = e.Row.FindControl("x3") as TextBox;
                TextBox x4 = e.Row.FindControl("x4") as TextBox;
                TextBox x5 = e.Row.FindControl("x5") as TextBox;
                TextBox x6 = e.Row.FindControl("x6") as TextBox;
                TextBox x7 = e.Row.FindControl("x7") as TextBox;
                TextBox x8 = e.Row.FindControl("x8") as TextBox;

                String routeName = DataBinder.Eval(e.Row.DataItem, "routeName").ToString();
                String lineName = DataBinder.Eval(e.Row.DataItem, "lineName").ToString();
                String GP20 = DataBinder.Eval(e.Row.DataItem, "GP20").ToString();
                String GP40 = DataBinder.Eval(e.Row.DataItem, "GP40").ToString();
                String HQ40 = DataBinder.Eval(e.Row.DataItem, "HQ40").ToString();
                String HQ45 = DataBinder.Eval(e.Row.DataItem, "HQ45").ToString();
                String others = DataBinder.Eval(e.Row.DataItem, "others").ToString();
                String TEU = DataBinder.Eval(e.Row.DataItem, "TEU").ToString();

                x3.Text = GP20;
                x4.Text = GP40;
                x5.Text = HQ40;
                x6.Text = HQ45;
                x7.Text = others;
                x8.Text = TEU;
                ListItem xx1 = x1.Items.FindByValue(routeName);
                if (xx1 != null) xx1.Selected = true;
                if (!string.IsNullOrEmpty(routeName))
                {
                    x2.Items.Clear();

                    foreach (Model.Lines line in new BLL.Lines().GetModelList("RouteId=" + routeName))
                    {
                        ListItem item = new ListItem(line.Name, line.Id.ToString());
                        x2.Items.Add(item);
                    }
                }
                ListItem xx2 = x2.Items.FindByValue(lineName);
                if (xx2 != null) xx2.Selected = true;
            }
        }

        //添加行按钮对应事件
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //总是取最后的一行
            GridViewRow row = GridView1.Rows[GridView1.Rows.Count - 1];
            DropDownList x1 = row.FindControl("x1") as DropDownList;
            DropDownList x2 = row.FindControl("x2") as DropDownList;
            TextBox x3 = row.FindControl("x3") as TextBox;
            TextBox x4 = row.FindControl("x4") as TextBox;
            TextBox x5 = row.FindControl("x5") as TextBox;
            TextBox x6 = row.FindControl("x6") as TextBox;
            TextBox x7 = row.FindControl("x7") as TextBox;
            TextBox x8 = row.FindControl("x8") as TextBox;
            dataTable = this.GetDataTable();
            DataRow newRow = dataTable.NewRow();
            if (dataTable.Rows.Count > 0)
            {
                newRow = dataTable.Rows[dataTable.Rows.Count - 1];
            }

            newRow["routeName"] = x1.SelectedValue;
            newRow["lineName"] = x2.SelectedValue;
            newRow["GP20"] = x3.Text;
            newRow["GP40"] = x4.Text;
            newRow["HQ40"] = x5.Text;
            newRow["HQ45"] = x6.Text;
            newRow["others"] = x7.Text;
            newRow["TEU"] = x8.Text;
            if (dataTable.Rows.Count == 0)
            {
                dataTable.Rows.Add(newRow);
            }

            ViewState["dt"] = dataTable;
            this.Bind(true);

        }

        //删除行按钮对应事件
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            dataTable = this.GetDataTable();
            if (dataTable.Rows.Count <= 1) return;
            dataTable.Rows.RemoveAt(dataTable.Rows.Count - 1);
            ViewState["dt"] = dataTable;
            this.Bind(false);
        }

        //航线修改后出发事件，修改对应的线路等数据
        protected void x1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList x1 = sender as DropDownList;
            GridViewRow r = x1.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["routeName"] = x1.SelectedValue;
            string s = x1.SelectedValue;
            DropDownList x2 = r.FindControl("x2") as DropDownList;
            x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
            x2.DataTextField = "Name";
            x2.DataValueField = "Id";
            x2.DataBind();
            dataTable.Rows[r.RowIndex]["lineName"] = x2.SelectedValue;
            TextBox x3 = r.FindControl("x3") as TextBox;
            dataTable.Rows[r.RowIndex]["GP20"] = x3.Text;
            TextBox x4 = r.FindControl("x4") as TextBox;
            dataTable.Rows[r.RowIndex]["GP40"] = x4.Text;
            TextBox x5 = r.FindControl("x5") as TextBox;
            dataTable.Rows[r.RowIndex]["HQ40"] = x5.Text;
            TextBox x6 = r.FindControl("x6") as TextBox;
            dataTable.Rows[r.RowIndex]["HQ45"] = x6.Text;
            TextBox x7 = r.FindControl("x7") as TextBox;
            dataTable.Rows[r.RowIndex]["others"] = x7.Text;
            TextBox x8 = r.FindControl("x8") as TextBox;
            dataTable.Rows[r.RowIndex]["TEU"] = x8.Text;
            ViewState["dt"] = dataTable;
            this.Bind(false);
        }

        protected void x2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList x2 = sender as DropDownList;
            GridViewRow r = x2.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["lineName"] = x2.SelectedValue;
            ViewState["dt"] = dataTable;
            //this.Bind(false);
        }


        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex <= this.GetDataTable().Rows.Count - 1)
                {
                    DropDownList x1 = e.Row.FindControl("x1") as DropDownList;
                    x1.DataSource = new BLL.Routes().GetAllList();
                    x1.DataTextField = "Name";
                    x1.DataValueField = "Id";
                    x1.DataBind();
                    string s = x1.SelectedValue;
                    DropDownList x2 = e.Row.FindControl("x2") as DropDownList;
                    x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
                    x2.DataTextField = "Name";
                    x2.DataValueField = "Id";
                    x2.DataBind();
                    TextBox x3 = e.Row.FindControl("x3") as TextBox;
                    TextBox x4 = e.Row.FindControl("x4") as TextBox;
                    TextBox x5 = e.Row.FindControl("x5") as TextBox;
                    TextBox x6 = e.Row.FindControl("x6") as TextBox;
                    TextBox x7 = e.Row.FindControl("x7") as TextBox;
                    TextBox x8 = e.Row.FindControl("x8") as TextBox;
                    x1.AutoPostBack = x2.AutoPostBack = true;
                    //x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
                    //x4.AutoPostBack = x5.AutoPostBack = true;
                    //x6.AutoPostBack = x7.AutoPostBack = x8.AutoPostBack = true;
                    x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
                    x2.SelectedIndexChanged += new EventHandler(x2_SelectedIndexChanged);
                    //x3.TextChanged += new EventHandler(x3_TextChanged);
                }
            }
        }

        //保存按钮事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int iRowCount = GridView1.Rows.Count;
            //int iShipTotal = 0;
            //int iContainerTotal = 0;
            if (listTemp == null)
            {
                listTemp = new List<Model.RouteDatas>();
            }
            else
            {
                if (listTemp.Count > 0)
                {
                    listTemp.Clear();
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    DropDownList x1 = row.FindControl("x1") as DropDownList;
                    Model.RouteDatas model = new Model.RouteDatas();
                    if (currentUser == null)
                    {
                        currentUser = (Model.Users)Session["UserInfo"];
                    }
                    model.CompanyId = currentUser.CompanyId;
                    model.RouteId = int.Parse(x1.SelectedValue);
                    model.R_Routes.Id = model.RouteId;
                    model.R_Routes.Name = x1.SelectedItem.Text;
                    //string strLinerComany = x1.Text;
                    DropDownList x2 = row.FindControl("x2") as DropDownList;
                    model.LineId = int.Parse(x2.SelectedValue);
                    model.R_Lines.Id = model.LineId;
                    model.R_Lines.Name = x2.SelectedItem.Text;
                    string strDate = txbReportDate.Value.Trim();
                    //ViewState["ReportDate"] = strDate;
                    DateTime dtReport;
                    if (DateTime.TryParse(strDate, out dtReport))
                    {
                        model.ReportWeek = Common.WeekOfYear.GetWeekOfYear(dtReport);
                        model.ReportYear = dtReport.Year;
                        model.EditTime = dtReport;
                    }
                    else
                    {
                        MessageBox.Show(this, "请选择填报数据对应的日期");
                        return;
                    }
                    TextBox x3 = row.FindControl("x3") as TextBox;
                    TextBox x4 = row.FindControl("x4") as TextBox;
                    TextBox x5 = row.FindControl("x5") as TextBox;
                    TextBox x6 = row.FindControl("x6") as TextBox;
                    TextBox x7 = row.FindControl("x7") as TextBox;
                    TextBox x8 = row.FindControl("x8") as TextBox;
                    float fGP20;
                    if (float.TryParse(x3.Text.Trim(), out fGP20))
                    {
                        model.GP20 = Convert.ToInt32(fGP20);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }

                    float fGP40;
                    if (float.TryParse(x4.Text.Trim(), out fGP40))
                    {
                        model.GP40 = Convert.ToInt32(fGP40);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }

                    float fHQ40;
                    if (float.TryParse(x5.Text.Trim(), out fHQ40))
                    {
                        model.HQ40 = Convert.ToInt32(fHQ40);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }

                    float fHQ45;
                    if (float.TryParse(x6.Text.Trim(), out fHQ45))
                    {
                        model.HQ45 = Convert.ToInt32(fHQ45);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }

                    float fOthers;
                    if (float.TryParse(x7.Text.Trim(), out fOthers))
                    {
                        model.Others = Convert.ToInt32(fOthers);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }

                    float fTEU;
                    if (float.TryParse(x8.Text.Trim(), out fTEU))
                    {
                        model.TEU = Convert.ToDecimal(fTEU);
                    }
                    else
                    {
                        MessageBox.Show(this, "请填入有效数字，无业务请填0");
                        return;
                    }
                    //try
                    //{
                    //    model.Id= linerBll.Add(model);
                    //}
                    //catch (Exception ex)
                    //{
                    //    lblMsg.Text =strLinerComany+ "的数据保存失败";
                    //    log.Error(strLinerComany+ "的数据保存失败"+"错误信息："+ex.Message);
                    //    return;
                    //}
                    listTemp.Add(model);
                    //iShipTotal += model.ProxyShipCount;
                    //iContainerTotal += model.ProxyContainerCount;
                    
                }
            }
            routedatasBussiness.SaveInputedDatasToFile(listTemp, currentUser.CompanyId.ToString());
            //byte[] streamBufferRead = new byte[1024 * 10];
            //using (MemoryStream streamTempRead = new MemoryStream(streamBufferRead))
            //{
            //    //string strPath= Server.MapPath("RouteDatasTemp.dat");
            //    //Stream s = File.Open(strPath, FileMode.Create);
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(streamTempRead, listTemp);
            //    Maticsoft.Common.DataCache.SetCache("RouteDatasTemp1", streamBufferRead, DateTime.Now.AddDays(1), TimeSpan.Zero);
            //}
            
                //streamTemp.Seek(0, SeekOrigin.Begin);
                //List<Model.RouteDatas> obj1111 = bf.Deserialize(streamTemp) as List<Model.RouteDatas>;
                
            lblMsg.Text = "保存成功！";

            //lblShipTotal.Text = iShipTotal.ToString();
            //lblContainerTotal.Text = iContainerTotal.ToString();
            //lblMsg.Text = iRowCount.ToString();
        }

        //修改按钮对应事件
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        //上报按钮对应事件
        protected void btnReport_Click(object sender, EventArgs e)
        {
            //添加的记录数
            int iAddedRecord = 0;
            //对象集合的对象数
            int iListCount = 0;
            MessageBox.ShowConfirm(btnReport, "确认上报吗？上报后数据将无法更改！");

            //如果临时数据对象list不存在，作相应处理
            if (listTemp == null) 
            {
                MessageBox.Show(this, "没有发现保存过的数据！");
                return;
            }
            if (listTemp != null && listTemp.Count > 0)
            {
                iListCount = listTemp.Count;
                foreach (Model.RouteDatas model in listTemp)
                {
                    model.IsReported = true;
                    List<Model.RouteDatas> list = new List<Model.RouteDatas>();
                    try
                    {
                        DataSet ds = routedatasBussiness.GetListByCondition("ReportYear=" + model.ReportYear, "ReportWeek=" + model.ReportWeek,"RouteId="+model.RouteId,"LineId="+model.LineId, "CompanyId=" + model.CompanyId);
                        if (ds != null && ds.Tables[0] != null)
                        {
                            list = routedatasBussiness.DataTableToList(ds.Tables[0]);
                        }

                        if (list.Count > 0)
                        {
                            lblMsg.Text = "航线:" + model.R_Routes.Name +"的线路："+model.R_Lines.Name+ " 第" + model.ReportWeek + "周的数据已经存在";
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("口岸：" + model.R_UserCompany.CompanyName + "查询条件为：RouteId=" + model.RouteId + "LineId=" + model.LineId + "，时间为："+model.ReportYear+"年第" + model.ReportWeek + "周的数据查询失败" + "错误信息：" + ex.Message);
                        return;
                    }
                    try
                    {
                        routedatasBussiness.Add(model);
                        iAddedRecord += 1;
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "数据上报失败";
                        log.Error("口岸:"+model.R_UserCompany.CompanyName + "的" + model.R_Routes.Name+" "+model.R_Lines.Name + "的数据添加失败" + "错误信息：" + ex.Message);
                        return;
                    }
                }
            }
            if (iAddedRecord == iListCount && iListCount != 0)
            {
                lblMsg.Text = "上报成功！";
            }
        }
    }
}