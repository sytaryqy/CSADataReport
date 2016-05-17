using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using log4net;

namespace CSADataReport.Web
{
    public partial class LinerReport : System.Web.UI.Page
    {
        private static List<Model.LinerDatas> listTemp=new List<Model.LinerDatas> ();
        private static ILog log = LogManager.GetLogger(typeof(LinerReport));
        private DataTable dataTable = null;
        protected Model.Users currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    Session["returnPage"] = this.Request.Url.PathAndQuery;
                    Response.Clear();
                    Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                    Response.End();
                }
                else
                {
                    this.Bind(true);
                    GridViewRow row = GridView1.Rows[0];
                    DropDownList x1 = row.FindControl("x1") as DropDownList;
                    x1.DataSource = new BLL.LinerCompany().GetAllList();
                    x1.DataTextField = "Name";
                    x1.DataValueField = "Id";
                    x1.DataBind();
                    //string s = x1.SelectedValue;
                    //DropDownList x2 = row.FindControl("x2") as DropDownList;
                    //x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
                    //x2.DataTextField = "Name";
                    //x2.DataValueField = "Id";
                    //x2.DataBind();
                    TextBox x2 = row.FindControl("x2") as TextBox;
                    TextBox x3 = row.FindControl("x3") as TextBox;
                    //x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
                    x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
                    //x2.TextChanged += new EventHandler(x2_TextChanged);
                    //x3.TextChanged += new EventHandler(x3_TextChanged);
                    txbReportDate.Value = DateTime.Today.ToString("yyyy-MM-dd");
                    currentUser = (Model.Users)Session["UserInfo"];
                }
            }


        }

        private DataTable GetDataTable()
        {
            if (ViewState["dt"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("linerCompany", typeof(String));
                dataTable.Columns.Add("proxyShipCount", typeof(String));
                dataTable.Columns.Add("proxyContainerCount", typeof(String));
                return dataTable;
            }
            else
            {
                return ViewState["dt"] as DataTable;
            }
        }

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
                TextBox x2 = e.Row.FindControl("x2") as TextBox; ;
                TextBox x3 = e.Row.FindControl("x3") as TextBox;

                String linerCompany = DataBinder.Eval(e.Row.DataItem, "linerCompany").ToString();
                String proxyShipCount = DataBinder.Eval(e.Row.DataItem, "proxyShipCount").ToString();
                String proxyContainerCount = DataBinder.Eval(e.Row.DataItem, "proxyContainerCount").ToString();

                x2.Text = proxyShipCount;
                x3.Text = proxyContainerCount;
                ListItem xx1 = x1.Items.FindByValue(linerCompany);
                if (xx1 != null) xx1.Selected = true;
                //if (!string.IsNullOrEmpty(usage))
                //{
                //    x2.Items.Clear();
                //    foreach (Model.Lines line in new BLL.Lines().GetModelList("RouteId=" + usage))
                //    {
                //        ListItem item = new ListItem(line.Name, line.Id.ToString());
                //        x2.Items.Add(item);
                //    }
                //}
                //ListItem xx2 = x2.Items.FindByValue(steelKind);
                //if (xx2 != null) xx2.Selected = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //总是取最后的一行
            GridViewRow row = GridView1.Rows[GridView1.Rows.Count - 1];
            DropDownList x1 = row.FindControl("x1") as DropDownList;
            TextBox x2 = row.FindControl("x2") as TextBox;
            TextBox x3 = row.FindControl("x3") as TextBox;

            dataTable = this.GetDataTable();
            DataRow newRow = dataTable.NewRow();
            if (dataTable.Rows.Count > 0)
            {
                newRow = dataTable.Rows[dataTable.Rows.Count - 1];
            }

            newRow["linerCompany"] = x1.SelectedValue;
            newRow["proxyShipCount"] = x2.Text;
            newRow["proxyContainerCount"] = x3.Text;
            if (dataTable.Rows.Count == 0)
            {
                dataTable.Rows.Add(newRow);
            }

            ViewState["dt"] = dataTable;
            this.Bind(true);
            //ViewState["ReportDate"]= txbReportDate.Value.Trim();
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            dataTable = this.GetDataTable();
            if (dataTable.Rows.Count <= 1) return;
            dataTable.Rows.RemoveAt(dataTable.Rows.Count - 1);
            ViewState["dt"] = dataTable;
            this.Bind(false);
            //ViewState["ReportDate"] = txbReportDate.Value.Trim();
        }


        protected void x1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList x1 = sender as DropDownList;
            GridViewRow r = x1.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["linerCompany"] = x1.SelectedValue;
            //string s = x1.SelectedValue;
            //DropDownList x2 = r.FindControl("x2") as DropDownList;
            //x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
            //x2.DataTextField = "Name";
            //x2.DataValueField = "Id";
            //x2.DataBind();
            //dataTable.Rows[r.RowIndex]["steelKind"] = x2.SelectedValue;
            ViewState["dt"] = dataTable;
            //ViewState["ReportDate"] = txbReportDate.Value.Trim();
            //this.Bind(false);
            //DropDownList x1 = sender as DropDownList;
            //GridViewRow r = x1.Parent.Parent as GridViewRow;
            //dataTable = this.GetDataTable();
            //dataTable.Rows[r.RowIndex]["usage"] = x1.SelectedValue;
            //ViewState["dt"] = dataTable;
            //this.Bind(false);
        }

        //protected void x2_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox x2 = sender as TextBox;
        //    GridViewRow r = x2.Parent.Parent as GridViewRow;
        //    dataTable = this.GetDataTable();
        //    dataTable.Rows[r.RowIndex]["proxyShipCount"] = x2.Text;
        //    ViewState["dt"] = dataTable;
        //    this.Bind(false);
        //}

        //protected void x3_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox x3 = sender as TextBox;
        //    GridViewRow r = x3.Parent.Parent as GridViewRow;
        //    dataTable = this.GetDataTable();
        //    dataTable.Rows[r.RowIndex]["proxyContainerCount"] = x3.Text;
        //    ViewState["dt"] = dataTable;
        //    this.Bind(false);
        //}

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex <= this.GetDataTable().Rows.Count - 1)
                {
                    DropDownList x1 = e.Row.FindControl("x1") as DropDownList;
                    x1.DataSource = new BLL.LinerCompany().GetAllList();
                    x1.DataTextField = "Name";
                    x1.DataValueField = "Id";
                    x1.DataBind();
                    //string s = x1.SelectedValue;
                    //DropDownList x2 = e.Row.FindControl("x2") as DropDownList;
                    //x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
                    //x2.DataTextField = "Name";
                    //x2.DataValueField = "Id";
                    //x2.DataBind();
                    TextBox x2 = e.Row.FindControl("x2") as TextBox;
                    TextBox x3 = e.Row.FindControl("x3") as TextBox;
                    //x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
                    x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
                    //x2.TextChanged += new EventHandler(x2_TextChanged);
                    //x3.TextChanged += new EventHandler(x3_TextChanged);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int iRowCount = GridView1.Rows.Count;
            int iShipTotal = 0;
            int iContainerTotal = 0;
            if (listTemp == null)
            {
                listTemp = new List<Model.LinerDatas>();
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
                    Model.LinerDatas model = new Model.LinerDatas();
                    if (currentUser == null)
                    {
                        currentUser = (Model.Users)Session["UserInfo"];
                    }
                    model.CompanyId = currentUser.CompanyId;
                    model.LinerCompanyId = int.Parse(x1.SelectedValue);
                    model.L_linerCompany.Id = model.LinerCompanyId;
                    model.L_linerCompany.Name = x1.SelectedItem.Text;
                    //string strLinerComany = x1.Text;
                    TextBox x2 = row.FindControl("x2") as TextBox;
                    float fProxyShipCount;
                    string strDate = txbReportDate.Value.Trim();
                    //ViewState["ReportDate"] = strDate;
                    DateTime dtReport;
                    if (DateTime.TryParse(strDate, out dtReport))
                    {
                        model.ReportWeek = Common.WeekOfYear.GetWeekOfYear(dtReport);
                        model.ReportYear = dtReport.Year;
                    }
                    else
                    {
                        MessageBox.Show(this, "请选择填报数据对应的日期");
                        return;
                    }
                    if (float.TryParse(x2.Text.Trim(), out fProxyShipCount))
                    {
                        model.ProxyShipCount = Convert.ToInt32(fProxyShipCount);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
                        return;
                    }
                    TextBox x3 = row.FindControl("x3") as TextBox;
                    float fProxyContainerCount;
                    if (float.TryParse(x3.Text.Trim(), out fProxyContainerCount))
                    {
                        model.ProxyContainerCount = Convert.ToInt32(fProxyContainerCount);
                    }
                    else
                    {
                        MessageBox.Show(this, "数据不能为空，无业务请填0");
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
                    iShipTotal += model.ProxyShipCount;
                    iContainerTotal += model.ProxyContainerCount;
                }
            }
            lblMsg.Text = "保存成功！";

            lblShipTotal.Text = iShipTotal.ToString();
            lblContainerTotal.Text = iContainerTotal.ToString();
            //lblMsg.Text = iRowCount.ToString();
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            //ViewState["ReportDate"] = txbReportDate.Value.Trim();
            int iAddedRecord = 0;
            int iListCount=0;
            MessageBox.ShowConfirm(btnReport, "确认上报吗？上报后数据将无法更改！");
            if (listTemp!=null && listTemp.Count > 0)
            {
                iListCount=listTemp.Count;
                BLL.LinerDatas linerBll = new BLL.LinerDatas();
                foreach (Model.LinerDatas model in listTemp)
                {
                    model.IsReported = true;
                    List<Model.LinerDatas> list = new List<Model.LinerDatas>();
                    try
                    {
                        DataSet ds = linerBll.GetListByCondition("LinerCompanyId=" + model.LinerCompanyId,"ReportYear=" + model.ReportYear, "ReportWeek=" + model.ReportWeek, "CompanyId=" + model.CompanyId);
                        if (ds != null && ds.Tables[0] != null)
                        {
                            list = linerBll.DataTableToList(ds.Tables[0]);
                        }
                        if (list.Count > 0)
                        {
                            lblMsg.Text = "航线:" + model.L_linerCompany.Name +" "+model.ReportYear+"年"+ " 第" + model.ReportWeek + "周的数据已经存在";
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("口岸编号为："+model.CompanyId+"查询条件为：LinerCompanyId=" + model.LinerCompanyId + "且ReportWeek=" + model.ReportWeek + "的数据查询失败" + "错误信息：" + ex.Message);
                        return;
                    }
                    try
                    {
                        linerBll.Add(model);
                        iAddedRecord += 1;
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "数据上报失败";
                        log.Error(model.CompanyId + "的" + model.LinerCompanyId + "的数据添加失败" + "错误信息：" + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "没有发现保存过的数据！");
            }
            if (iAddedRecord == iListCount && iListCount != 0)
            {
                lblMsg.Text = "上报成功！";
            }
        }
    }
}