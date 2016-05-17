using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CSADataReport.Web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private DataTable dataTable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Bind(true);
                GridViewRow row = GridView1.Rows[0];
                DropDownList x1 = row.FindControl("x1") as DropDownList;
                x1.DataSource = new BLL.Routes().GetAllList();
                x1.DataTextField = "Name";
                x1.DataValueField = "Id";
                x1.DataBind();
                string s = x1.SelectedValue;
                DropDownList x2 = row.FindControl("x2") as DropDownList;
                x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
                x2.DataTextField = "Name";
                x2.DataValueField = "Id";
                x2.DataBind();
                TextBox x3 = row.FindControl("x3") as TextBox;
                x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
                x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
                x2.SelectedIndexChanged += new EventHandler(x2_SelectedIndexChanged);
                x3.TextChanged += new EventHandler(x3_TextChanged);
            }
        }

        private DataTable GetDataTable()
        {
            if (ViewState["dt"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("usage", typeof(String));
                dataTable.Columns.Add("steelKind", typeof(String));
                dataTable.Columns.Add("castingTon", typeof(String));
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
                DropDownList x2 = e.Row.FindControl("x2") as DropDownList;
                TextBox x3 = e.Row.FindControl("x3") as TextBox;

                String usage = DataBinder.Eval(e.Row.DataItem, "usage").ToString();
                String steelKind = DataBinder.Eval(e.Row.DataItem, "steelKind").ToString();
                String castingTon = DataBinder.Eval(e.Row.DataItem, "castingTon").ToString();

                x3.Text = castingTon;
                ListItem xx1 = x1.Items.FindByValue(usage);
                if (xx1 != null) xx1.Selected = true;
                if (!string.IsNullOrEmpty(usage))
                {
                    x2.Items.Clear();

                    foreach (Model.Lines line in new BLL.Lines().GetModelList("RouteId=" + usage))
                    {
                        ListItem item = new ListItem(line.Name, line.Id.ToString());
                        x2.Items.Add(item);
                    }
                } 
                ListItem xx2 = x2.Items.FindByValue(steelKind);
                if (xx2 != null) xx2.Selected = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //总是取最后的一行
            GridViewRow row = GridView1.Rows[GridView1.Rows.Count - 1];
            DropDownList x1 = row.FindControl("x1") as DropDownList;
            DropDownList x2 = row.FindControl("x2") as DropDownList;
            TextBox x3 = row.FindControl("x3") as TextBox;

            dataTable = this.GetDataTable();
            DataRow newRow = dataTable.NewRow();
            if (dataTable.Rows.Count > 0)
            {
                newRow = dataTable.Rows[dataTable.Rows.Count - 1];
            }

            newRow["usage"] = x1.SelectedValue;
            newRow["steelKind"] = x2.SelectedValue;
            newRow["castingTon"] = x3.Text;
            if (dataTable.Rows.Count == 0)
            {
                dataTable.Rows.Add(newRow);
            }

            ViewState["dt"] = dataTable;
            this.Bind(true);

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            dataTable = this.GetDataTable();
            if (dataTable.Rows.Count <= 1) return;
            dataTable.Rows.RemoveAt(dataTable.Rows.Count - 1);
            ViewState["dt"] = dataTable;
            this.Bind(false);
        }

        protected void x1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList x1 = sender as DropDownList;
            GridViewRow r = x1.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["usage"] = x1.SelectedValue;
            string s = x1.SelectedValue;
            DropDownList x2 = r.FindControl("x2") as DropDownList;
            x2.DataSource = new BLL.Lines().GetList("RouteId=" + s);
            x2.DataTextField = "Name";
            x2.DataValueField = "Id";
            x2.DataBind();
            dataTable.Rows[r.RowIndex]["steelKind"] = x2.SelectedValue;
            ViewState["dt"] = dataTable;
            this.Bind(false);
            //DropDownList x1 = sender as DropDownList;
            //GridViewRow r = x1.Parent.Parent as GridViewRow;
            //dataTable = this.GetDataTable();
            //dataTable.Rows[r.RowIndex]["usage"] = x1.SelectedValue;
            //ViewState["dt"] = dataTable;
            //this.Bind(false);
        }

        protected void x2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList x2 = sender as DropDownList;
            GridViewRow r = x2.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["steelKind"] = x2.SelectedValue;
            ViewState["dt"] = dataTable;
            this.Bind(false);
        }

        protected void x3_TextChanged(object sender, EventArgs e)
        {
            TextBox x3 = sender as TextBox;
            GridViewRow r = x3.Parent.Parent as GridViewRow;
            dataTable = this.GetDataTable();
            dataTable.Rows[r.RowIndex]["castingTon"] = x3.Text;
            ViewState["dt"] = dataTable;
            this.Bind(false);
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
                    x1.AutoPostBack = x2.AutoPostBack = x3.AutoPostBack = true;
                    x1.SelectedIndexChanged += new EventHandler(x1_SelectedIndexChanged);
                    x2.SelectedIndexChanged += new EventHandler(x2_SelectedIndexChanged);
                    x3.TextChanged += new EventHandler(x3_TextChanged);
                }
            }
        }
    }
}