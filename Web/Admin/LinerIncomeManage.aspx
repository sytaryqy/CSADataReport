<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinerIncomeManage.aspx.cs" Inherits="CSADataReport.Web.Admin.LinerIncomeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班轮收入数据管理</title>
</head>
<body id="tBody">
<div align="left">
    <a href="DatasManageMain.aspx">返回</a>
</div>
    <form id="form1" runat="server">
    <div align="center">
    &nbsp;
    <h2>班轮收入数据管理</h2>
        <div>
        &nbsp;</div>
        <span>
        <label for="txbBeginYear">查询起始年：</label>
        <asp:TextBox ID="txbBeginYear" runat="server" TextMode="Number" CssClass="btn"></asp:TextBox>
        </span>
        &nbsp;
        <span>
        <label for="txbBeginWeek">查询起始周：</label>
        <asp:TextBox ID="txbBeginWeek" runat="server" TextMode="Number"></asp:TextBox>
        </span>
        &nbsp;
        <span>
        <asp:CheckBox ID="ckbIsSelectAllDatas" runat="server" Text="是否检索所有数据" 
            AutoPostBack="True" Checked="True" 
            oncheckedchanged="ckbIsSelectAllDatas_CheckedChanged" />
        <asp:DropDownList ID="ddlCompanyInfos" runat="server" Visible="false"
            DataSourceID="odsCompanyInfos" DataTextField="CompanyName" DataValueField="Id">
        </asp:DropDownList>
        </span>
        <div>
        &nbsp;</div>
        <div>
            <asp:Button ID="btnGetDatas" runat="server" Text="获取数据" 
                onclick="btnGetDatas_Click" />
        </div>
    
    </div>
    &nbsp;
    <div align="center">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteByModel" 
            SelectMethod="GetModelListEx" TypeName="CSADataReport.BLL.LinerIncomeDatas" 
            OldValuesParameterFormatString="original_{0}" 
            DataObjectTypeName="CSADataReport.Model.LinerIncomeDatas">
            <SelectParameters>
                <asp:Parameter Name="strWhere" Type="String" DefaultValue="ReportYear = 0 " />
            </SelectParameters>
        
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCompanyInfos" runat="server" 
            SelectMethod="GetAllList" TypeName="CSADataReport.BLL.Companies">
        </asp:ObjectDataSource>
        <asp:ListView ID="ListView1" runat="server" 
            DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" 
            DataKeyNames="Id" >
            <AlternatingItemTemplate>
                <tr align="center" style="background-color: #FFFFFF;color: #284775;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" 
                            Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("L_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportWeekLabel" runat="server" 
                            Text='<%# Eval("ReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportYearLabel" runat="server" 
                            Text='<%# Eval("ReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_linerCompanyLabel" runat="server" 
                            Text='<%# Eval("L_linerCompany.Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LinerCompanyIdLabel" runat="server" 
                            Text='<%# Eval("LinerCompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProxyShipIncomeLabel" runat="server" 
                            Text='<%# Eval("ProxyShipIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DocumentIncomeLabel" runat="server" 
                            Text='<%# Eval("DocumentIncome") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" 
                            Text='<%# Eval("AddTime") %>' />
                    </td>

                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr align="center" style="background-color: #999999;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" Enabled="false" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:TextBox ID="IdTextBox" runat="server" 
                            Text='<%# Bind("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="L_UserCompanyTextBox" runat="server" 
                            Text='<%# Bind("L_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyIdTextBox" runat="server" 
                            Text='<%# Bind("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReportWeekTextBox" runat="server" 
                            Text='<%# Bind("ReportWeek") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReportYearTextBox" runat="server" 
                            Text='<%# Bind("ReportYear") %>' />
                    </td>
                    
                    <td>
                        <asp:TextBox ID="L_linerCompanyTextBox" runat="server" 
                            Text='<%# Bind("L_linerCompany.Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LinerCompanyIdTextBox" runat="server" 
                            Text='<%# Bind("LinerCompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ProxyShipIncomeTextBox" runat="server" 
                            Text='<%# Bind("ProxyShipIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DocumentIncomeTextBox" runat="server" 
                            Text='<%# Bind("DocumentIncome") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Bind("IsReported") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddTimeTextBox" runat="server" 
                            Text='<%# Bind("AddTime") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr align="center" style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" Enabled="false" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:TextBox ID="IdTextBox" runat="server"  Width ="25px"
                            Text='<%# Bind("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="L_UserCompanyTextBox" runat="server" 
                            Text='<%# Bind("L_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyIdTextBox" runat="server" Width ="50px"
                            Text='<%# Bind("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReportWeekTextBox" runat="server" Width ="50px"
                            Text='<%# Bind("ReportWeek") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ReportYearTextBox" runat="server" Width ="50px"
                            Text='<%# Bind("ReportYear") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="L_linerCompanyTextBox" runat="server" 
                            Text='<%# Bind("L_linerCompany.Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LinerCompanyIdTextBox" runat="server" Width ="75px"
                            Text='<%# Bind("LinerCompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ProxyShipIncomeTextBox" runat="server" 
                            Text='<%# Bind("ProxyShipIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DocumentIncomeTextBox" runat="server" 
                            Text='<%# Bind("DocumentIncome") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Bind("IsReported") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddTimeTextBox" runat="server" 
                            Text='<%# Bind("AddTime") %>' />
                    </td>
                    
                    
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr align="center" style="background-color: #E0FFFF;color: #333333;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" 
                            Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("L_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportWeekLabel" runat="server" 
                            Text='<%# Eval("ReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportYearLabel" runat="server" 
                            Text='<%# Eval("ReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_linerCompanyLabel" runat="server" 
                            Text='<%# Eval("L_linerCompany.Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LinerCompanyIdLabel" runat="server" 
                            Text='<%# Eval("LinerCompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProxyShipIncomeLabel" runat="server" 
                            Text='<%# Eval("ProxyShipIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DocumentIncomeLabel" runat="server" 
                            Text='<%# Eval("DocumentIncome") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" 
                            Text='<%# Eval("AddTime") %>' />
                    </td>
                    
                    
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                    <th runat="server">
                                    </th>
                                    <th runat="server">
                                        编号</th>
                                    <th runat="server">
                                        口岸名称</th>
                                    <th runat="server">
                                        口岸编号</th>
                                    <th runat="server">
                                        上报周</th>
                                    <th runat="server">
                                        上报年</th>
                                    <th runat="server">
                                        班轮公司</th>
                                    <th runat="server">
                                        班轮公司编号</th>
                                    <th runat="server">
                                        代理艘次收入</th>
                                    <th runat="server">
                                        单证收入</th>
                                    <th runat="server">
                                        是否上报</th>
                                    <th runat="server">
                                        添加时间</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr align="center" style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" 
                            Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("L_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportWeekLabel" runat="server" 
                            Text='<%# Eval("ReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ReportYearLabel" runat="server" 
                            Text='<%# Eval("ReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="L_linerCompanyLabel" runat="server" 
                            Text='<%# Eval("L_linerCompany.Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LinerCompanyIdLabel" runat="server" 
                            Text='<%# Eval("LinerCompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ProxyShipIncomeLabel" runat="server" 
                            Text='<%# Eval("ProxyShipIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DocumentIncomeLabel" runat="server" 
                            Text='<%# Eval("DocumentIncome") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" 
                            Text='<%# Eval("AddTime") %>' />
                    </td>
                    
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
