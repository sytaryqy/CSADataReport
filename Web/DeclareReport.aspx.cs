using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSADataReport.Web
{
    public partial class DeclareReport : System.Web.UI.Page
    {
        //protected Model.Users currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserInfo"] == null)
                {
                    //Session["returnPage"] = this.Request.Url.PathAndQuery;
                    //Response.Clear();
                    //Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                    //Response.End();

                    Common.CheckLogin.ShowLoginPageAndReturn();
                    
                }
                else
                {
                    Model.Users currentUser = (Model.Users)Session["UserInfo"];
                    lblMsg.Text = "";
                    if (Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId] != null)
                    {
                        if (!string.IsNullOrEmpty(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value))
                        {
                            int intReportRecordId = int.Parse(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value);
                            BLL.DeclareDatas declareDataBll = new BLL.DeclareDatas();
                            Model.DeclareDatas model = new Model.DeclareDatas();
                            model = declareDataBll.GetModel(intReportRecordId);
                            if (model != null && model.IsReported==false)
                            {
                                txbWaibaoGuanfengContainer.Text = model.GFOuterDeclareContainer.ToString();
                                txbWaibaoGuanfengIncome.Text = model.GFOuterDeclareIncome.ToString();
                                txbWaibaoGuanfengNum.Text = model.GFOuterDeclareBallot.ToString();
                                txbWaibaoQitaContainer.Text = model.QTOuterDeclareContainer.ToString();
                                txbWaibaoQitaIncome.Text = model.QTOuterDeclareIncome.ToString();
                                txbWaibaoQitaNum.Text = model.QTOuterDeclareBallot.ToString();
                                txbZibaoGuanfengContainer.Text = model.GFSelfDeclareContainer.ToString();
                                txbZibaoGuanfengIncome.Text = model.GFSelfDeclareIncome.ToString();
                                txbZibaoGuanfengNum.Text = model.GFSelfDeclareBallot.ToString();
                                txbZibaoQitaContainer.Text = model.QTSelfDeclareContainer.ToString();
                                txbZibaoQitaIncome.Text = model.QTSelfDeclareIncome.ToString();
                                txbZibaoQitaNum.Text = model.QTSelfDeclareBallot.ToString();
                                txbQitaContainer.Text = model.QTOtherDeclareContainer.ToString();
                                txbQitaIncome.Text = model.QTOtherDeclareIncome.ToString();
                                txbQitaNum.Text = model.QTOtherDeclareBallot.ToString();
                                txbQitaGuanfengContainer.Text = model.GFOtherDeclareContainer.ToString();
                                txbQitaGuanfengIncome.Text = model.GFOtherDeclareIncome.ToString();
                                txbQitaGuanfengNum.Text = model.GFOtherDeclareBallot.ToString();
                                if (model.EditTime != null)
                                {
                                    txbReportDate.Value = ((DateTime)model.EditTime).ToString("yyyy-MM-dd");
                                }
                                lblBallotTotal.Text = (model.GFOtherDeclareBallot + model.GFOuterDeclareBallot + model.GFSelfDeclareBallot + model.QTOtherDeclareBallot + model.QTOuterDeclareBallot + model.QTSelfDeclareBallot).ToString();
                                lblContainerTotal.Text = (model.GFOtherDeclareContainer + model.GFOuterDeclareContainer + model.GFSelfDeclareContainer + model.QTOtherDeclareContainer + model.QTOuterDeclareContainer + model.QTSelfDeclareContainer).ToString();
                                lblIncomeTotal.Text = (model.GFOtherDeclareIncome + model.GFOuterDeclareIncome + model.GFSelfDeclareIncome + model.QTOtherDeclareIncome + model.QTOuterDeclareIncome + model.QTSelfDeclareIncome).ToString();
                                btnReport.Enabled = true;
                            }
                        }
                    }
                    if(string.IsNullOrEmpty(txbReportDate.Value))
                    {
                        txbReportDate.Value = DateTime.Today.ToString("yyyy-MM-dd");
                    }
                }

            }
            //else
            //{
            //    if (Session["UserInfo"] == null)
            //    {
            //        Session["returnPage"] = this.Request.Url.PathAndQuery;
            //        Response.Clear();
            //        Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
            //        Response.End();
            //    }
            //    else
            //    {
            //        currentUser = (Model.Users)Session["UserInfo"];
            //        lblMsg.Text = "";
            //        txbReportDate.Value = DateTime.Today.ToShortDateString().Replace("/","-");
            //    }
                
 
            //}

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Users currentUser = (Model.Users)Session["UserInfo"];
            int intAddedRecordNum = 0;
            int intBallotTotal = 0;
            int intContainerTotal = 0;
            decimal decIncomeTotal = 0;
            lblMsg.Text = "";
            string strMsg = "";
            BLL.DeclareDatas declareDateBll = new BLL.DeclareDatas();
            Model.DeclareDatas model = new Model.DeclareDatas();
            string strDate = txbReportDate.Value;
            DateTime dtReporte = new DateTime();
            if (!string.IsNullOrEmpty(strDate))
            {
                dtReporte = DateTime.Parse(strDate);
            }
            else
            {
                dtReporte = DateTime.Now;
            }
            model.DeclareReportYear = dtReporte.Year;
            model.DeclareReportWeek = Common.WeekOfYear.GetWeekOfYear(dtReporte);

            //添加外包关封报关数据
            model.CompanyId = currentUser.CompanyId;
            if (!string.IsNullOrEmpty(txbWaibaoGuanfengNum.Text))
            {
                model.GFOuterDeclareBallot = int.Parse(txbWaibaoGuanfengNum.Text);
                intBallotTotal += int.Parse(txbWaibaoGuanfengNum.Text);
            }
            else
            {
                model.GFOuterDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbWaibaoGuanfengContainer.Text))
            {
                model.GFOuterDeclareContainer = int.Parse(txbWaibaoGuanfengContainer.Text);
                intContainerTotal += int.Parse(txbWaibaoGuanfengContainer.Text);
            }
            else
            {
                model.GFOuterDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbWaibaoGuanfengIncome.Text))
            {
                model.GFOuterDeclareIncome = decimal.Parse(txbWaibaoGuanfengIncome.Text);
                decIncomeTotal += decimal.Parse(txbWaibaoGuanfengIncome.Text);
            }
            else
            {
                model.GFOuterDeclareIncome = 0;
            }


            //添加自报关封报关数据
            if (!string.IsNullOrEmpty(txbZibaoGuanfengNum.Text))
            {
                model.GFSelfDeclareBallot = int.Parse(txbZibaoGuanfengNum.Text);
                intBallotTotal += int.Parse(txbZibaoGuanfengNum.Text);
            }
            else
            {
                model.GFSelfDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbZibaoGuanfengContainer.Text))
            {
                model.GFSelfDeclareContainer = int.Parse(txbZibaoGuanfengContainer.Text);
                intContainerTotal += int.Parse(txbZibaoGuanfengContainer.Text);
            }
            else
            {
                model.GFSelfDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbZibaoGuanfengIncome.Text))
            {
                model.GFSelfDeclareIncome = decimal.Parse(txbZibaoGuanfengIncome.Text);
                decIncomeTotal += decimal.Parse(txbZibaoGuanfengIncome.Text);
            }
            else
            {
                model.GFSelfDeclareIncome = 0;
            }


            //添加其他关封报关数据
            if (!string.IsNullOrEmpty(txbQitaGuanfengNum.Text))
            {
                model.GFOtherDeclareBallot = int.Parse(txbQitaGuanfengNum.Text);
                intBallotTotal += int.Parse(txbQitaGuanfengNum.Text);
            }
            else
            {
                model.GFOtherDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbQitaGuanfengContainer.Text))
            {
                model.GFOtherDeclareContainer = int.Parse(txbQitaGuanfengContainer.Text);
                intContainerTotal += int.Parse(txbQitaGuanfengContainer.Text);
            }
            else
            {
                model.GFOtherDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbQitaGuanfengIncome.Text))
            {
                model.GFOtherDeclareIncome = decimal.Parse(txbQitaGuanfengIncome.Text);
                decIncomeTotal += decimal.Parse(txbQitaGuanfengIncome.Text);
            }
            else
            {
                model.GFOtherDeclareIncome = 0;
            }


            //添加外包其他报关数据
            if (!string.IsNullOrEmpty(txbWaibaoQitaNum.Text))
            {
                model.QTOuterDeclareBallot = int.Parse(txbWaibaoQitaNum.Text);
                intBallotTotal += int.Parse(txbWaibaoQitaNum.Text);
            }
            else
            {
                model.QTOuterDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbWaibaoQitaContainer.Text))
            {
                model.QTOuterDeclareContainer = int.Parse(txbWaibaoQitaContainer.Text);
                intContainerTotal += int.Parse(txbWaibaoQitaContainer.Text);
            }
            else
            {
                model.QTOuterDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbWaibaoQitaIncome.Text))
            {
                model.QTOuterDeclareIncome = decimal.Parse(txbWaibaoQitaIncome.Text);
                decIncomeTotal += decimal.Parse(txbWaibaoQitaIncome.Text);
            }
            else
            {
                model.QTOuterDeclareIncome = 0;
            }

            //添加自报其他报关数据
            if (!string.IsNullOrEmpty(txbZibaoQitaNum.Text))
            {
                model.QTSelfDeclareBallot = int.Parse(txbZibaoQitaNum.Text);
                intBallotTotal += int.Parse(txbZibaoQitaNum.Text);
            }
            else
            {
                model.QTSelfDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbZibaoQitaContainer.Text))
            {
                model.QTSelfDeclareContainer = int.Parse(txbZibaoQitaContainer.Text);
                intContainerTotal += int.Parse(txbZibaoQitaContainer.Text);
            }
            else
            {
                model.QTSelfDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbZibaoQitaIncome.Text))
            {
                model.QTSelfDeclareIncome = decimal.Parse(txbZibaoQitaIncome.Text);
                decIncomeTotal += decimal.Parse(txbZibaoQitaIncome.Text);
            }
            else
            {
                model.QTSelfDeclareIncome = 0;
            }

            //添加其他报关数据
            if (!string.IsNullOrEmpty(txbQitaNum.Text))
            {
                model.QTOtherDeclareBallot = int.Parse(txbQitaNum.Text);
                intBallotTotal += int.Parse(txbQitaNum.Text);
            }
            else
            {
                model.QTOtherDeclareBallot = 0;
            }
            if (!string.IsNullOrEmpty(txbQitaContainer.Text))
            {
                model.QTOtherDeclareContainer = int.Parse(txbQitaContainer.Text);
                intContainerTotal += int.Parse(txbQitaContainer.Text);
            }
            else
            {
                model.QTOtherDeclareContainer = 0;
            }
            if (!string.IsNullOrEmpty(txbQitaIncome.Text))
            {
                model.QTOtherDeclareIncome = decimal.Parse(txbQitaIncome.Text);
                decIncomeTotal += decimal.Parse(txbQitaIncome.Text);
            }
            else
            {
                model.QTOtherDeclareIncome = 0;
            }
            model.EditTime = DateTime.Parse(txbReportDate.Value);
            string strWhere="CompanyId="+currentUser.CompanyId+" and DeclareReportWeek="+model.DeclareReportWeek+" and DeclareReportYear="+model.DeclareReportYear;
            List<Model.DeclareDatas> list=new List<Model.DeclareDatas> ();
            list = declareDateBll.GetModelList(strWhere);
            if (list.Count > 0)
            {
                if (list[0].IsReported)
                {
                    strMsg = "该周数据已经上报过了，不能保存！";
                }
                else
                {
                    model.IsReported = false;
                    model.Id = list[0].Id;
                    if (declareDateBll.Update(model))
                    {
                        HttpCookie cookie = new HttpCookie("LastSavedDeclareReport" + currentUser.CompanyId, model.Id.ToString());
                        cookie.Expires = DateTime.Now.AddMonths(1);
                        Response.Cookies.Add(cookie);
                        strMsg = "数据修改成功！";
                        btnReport.Enabled = true;
                    }
                    else
                    {
                        strMsg = "数据修改失败！";
                    }
                }

            }
            else
            {
                if (intBallotTotal <= 0 && intContainerTotal <= 0 && decIncomeTotal <= 0)
                {
                    strMsg = "票数、箱量、收入的总和都不大于0，请核对数据有效性！";
                    return;
                }
                if ((intAddedRecordNum = declareDateBll.Add(model)) > 0)
                {
                    //intAddedRecord += 1;
                    ViewState["SavedRecordId"] = intAddedRecordNum;
                    HttpCookie cookie = new HttpCookie("LastSavedDeclareReport" + currentUser.CompanyId, intAddedRecordNum.ToString());
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(cookie);
                    strMsg = "数据保存成功！";
                    btnReport.Enabled = true;
                }
                else
                {
                    strMsg = " 数据保存失败！";
                }
            }
            
            lblMsg.Text = strMsg;
            lblBallotTotal.Text = intBallotTotal.ToString();
            lblContainerTotal.Text = intContainerTotal.ToString();
            lblIncomeTotal.Text = decIncomeTotal.ToString();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Model.Users currentUser = (Model.Users)Session["UserInfo"];
            if (ViewState["SavedRecordId"] != null)
            {
                string strSavedRecordId = ViewState["SavedRecordId"].ToString();
                if (!string.IsNullOrEmpty(strSavedRecordId))
                {
                    int intReportRecordId = int.Parse(strSavedRecordId);
                    BLL.DeclareDatas declareDateBll = new BLL.DeclareDatas();
                    Model.DeclareDatas model = new Model.DeclareDatas();
                    model = declareDateBll.GetModel(intReportRecordId);
                    if (model != null)
                    {
                        if (model.IsReported == true)
                        {
                            lblMsg.Text = "该记录已经上报！";
                            return;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "记录号：" + intReportRecordId + "的记录不存在！";
                        return;
                    }

                    model.IsReported = true;

                    if (declareDateBll.UpdateReportState(model))
                    {
                        Response.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Expires = DateTime.Now.AddDays(-1);
                        lblMsg.Text = "上报成功！";
                    }
                    else
                    {
                        lblMsg.Text = "上报失败！";
                    }
                    return;
                }
                else
                {
                    if (Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId] != null)
                    {
                        if (!string.IsNullOrEmpty(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value))
                        {
                            int intReportRecordId = int.Parse(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value);
                            BLL.DeclareDatas declareDateBll = new BLL.DeclareDatas();
                            Model.DeclareDatas model = new Model.DeclareDatas();
                            model = declareDateBll.GetModel(intReportRecordId);
                            if (model != null)
                            {
                                if (model.IsReported == true)
                                {
                                    lblMsg.Text = "该记录已经上报！";
                                    return;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "记录号：" + intReportRecordId + "的记录不存在！";
                                return;
                            }
                            //model.EditTime = DateTime.Now;
                            model.IsReported = true;
                            if (declareDateBll.UpdateReportState(model))
                            {
                                Response.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Expires.AddMonths(-1);
                                lblMsg.Text = "上报成功！";
                                return;
                            }
                            else
                            {
                                lblMsg.Text = "上报失败！";
                                return;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "没有保存过的记录，请先保存！";
                            btnReport.Enabled = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "没有保存过的记录，请先保存！";
                        btnReport.Enabled = false;
                    }
                }
            }
            else
            {
                if (Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId] != null) 
                {
                    if (!string.IsNullOrEmpty(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value))
                    {
                        int intReportRecordId = int.Parse(Request.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Value);
                        BLL.DeclareDatas declareDateBll = new BLL.DeclareDatas();
                        Model.DeclareDatas model = new Model.DeclareDatas();
                        model = declareDateBll.GetModel(intReportRecordId);
                        if (model != null)
                        {
                            if (model.IsReported == true)
                            {
                                lblMsg.Text = "该记录已经上报！";
                                return;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "记录号："+intReportRecordId+"的记录不存在！";
                            return;
                        }
                        //model.EditTime = DateTime.Now;
                        model.IsReported = true;
                        if (declareDateBll.UpdateReportState(model))
                        {
                            Response.Cookies["LastSavedDeclareReport" + currentUser.CompanyId].Expires=DateTime.Now.AddMonths(-1);
                            lblMsg.Text = "上报成功！";
                            return;
                        }
                        else
                        {
                            lblMsg.Text = "上报失败！";
                            return;
                        }
                    }
                }

                lblMsg.Text = "没有保存过的记录，请先保存！";
                btnReport.Enabled = false;
            }
        }
    }
}