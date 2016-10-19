<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeclareDatasManage.aspx.cs" Inherits="CSADataReport.Web.Admin.RecordManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body id="tBody">
    <form id="form1" runat="server">
    <div align="center">
    <div align="left">
        <a href="DatasManageMain.aspx">返回</a>&nbsp;</div>
    <h2>报关数据管理</h2>
        
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
            SelectMethod="GetModelListEx" TypeName="CSADataReport.BLL.DeclareDatas" 
            OldValuesParameterFormatString="original_{0}" 
            DataObjectTypeName="CSADataReport.Model.DeclareDatas">
            <SelectParameters>
                <asp:Parameter Name="strWhere" Type="String" DefaultValue="DeclareReportYear = 0" />
            </SelectParameters>
        
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCompanyInfos" runat="server" 
            SelectMethod="GetAllList" TypeName="CSADataReport.BLL.Companies">
        </asp:ObjectDataSource>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" 
            DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem" >
            <AlternatingItemTemplate>
                <tr align="center" style="background-color: #FFFFFF;color: #284775;text-align:center">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" Enabled="false" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="D_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("D_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportWeekLabel" runat="server" 
                            Text='<%# Eval("DeclareReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportYearLabel" runat="server" 
                            Text='<%# Eval("DeclareReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EditTimeLabel" runat="server" Text='<%# Eval("EditTime") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr align="center" style="background-color: #999999;text-align:center">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" Enabled="false"  />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="D_UserCompanyTextBox" runat="server" 
                            Text='<%# Bind("D_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DeclareReportWeekTextBox" runat="server" 
                            Text='<%# Bind("DeclareReportWeek") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DeclareReportYearTextBox" runat="server" 
                            Text='<%# Bind("DeclareReportYear") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyIdTextBox" runat="server" 
                            Text='<%# Bind("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("GFOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("GFSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("GFOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("QTOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("QTSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareBallotTextBox" runat="server" 
                            Text='<%# Bind("QTOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("GFOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("GFSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("GFOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("QTOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("QTSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareContainerTextBox" runat="server" 
                            Text='<%# Bind("QTOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("GFOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("GFSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("GFOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("QTOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("QTSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareIncomeTextBox" runat="server" 
                            Text='<%# Bind("QTOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddTimeTextBox" runat="server" Text='<%# Bind("AddTime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EditTimeTextBox" runat="server" 
                            Text='<%# Bind("EditTime") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Bind("IsReported") %>' />
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
                <tr align="center" style="text-align:center">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" Enabled="false" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' Width="25px" />
                    </td>
                    <td>
                        <asp:TextBox ID="D_UserCompanyTextBox" runat="server" 
                            Text='<%# Bind("D_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DeclareReportWeekTextBox" runat="server" Width="50px"
                            Text='<%# Bind("DeclareReportWeek") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DeclareReportYearTextBox" runat="server" Width="50px"
                            Text='<%# Bind("DeclareReportYear") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyIdTextBox" runat="server" Width="75px"
                            Text='<%# Bind("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareBallotTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareContainerTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOuterDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFSelfDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="GFOtherDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("GFOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOuterDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTSelfDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="QTOtherDeclareIncomeTextBox" runat="server" Width="75px"
                            Text='<%# Bind("QTOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddTimeTextBox" runat="server" Text='<%# Bind("AddTime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EditTimeTextBox" runat="server" 
                            Text='<%# Bind("EditTime") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Bind("IsReported") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr align="center" style="background-color: #E0FFFF;color: #333333;text-align:center">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" Enabled="false"  />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="D_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("D_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportWeekLabel" runat="server" 
                            Text='<%# Eval("DeclareReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportYearLabel" runat="server" 
                            Text='<%# Eval("DeclareReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EditTimeLabel" runat="server" Text='<%# Eval("EditTime") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr align="center" runat="server">
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
                                        上报周</th>
                                    <th runat="server">
                                        上报年</th>
                                    <th runat="server">
                                        口岸编号</th>
                                    <th runat="server">
                                        班轮关封票数</th>
                                    <th runat="server">
                                        班轮空箱票数</th>
                                    <th runat="server">
                                        班轮其它票数</th>
                                    <th runat="server">
                                        货代外包票数</th>
                                    <th runat="server">
                                        货代自报票数</th>
                                    <th runat="server">
                                        货代其它票数</th>
                                    <th runat="server">
                                        班轮关封箱量</th>
                                    <th runat="server">
                                        班轮空箱箱量</th>
                                    <th runat="server">
                                        班轮其它箱量</th>
                                    <th runat="server">
                                        货代外包箱量</th>
                                    <th runat="server">
                                        货代自报箱量</th>
                                    <th runat="server">
                                        货代其它箱量</th>
                                    <th runat="server">
                                        班轮关封收入</th>
                                    <th runat="server">
                                        班轮空箱收入</th>
                                    <th runat="server">
                                        班轮其它收入</th>
                                    <th runat="server">
                                        货代外包收入</th>
                                    <th runat="server">
                                        货代自报收入</th>
                                    <th runat="server">
                                        货代其它收入</th>
                                    <th runat="server">
                                        添加时间</th>
                                    <th runat="server">
                                        修改时间</th>
                                    <th runat="server">
                                        是否上报</th>
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
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="D_UserCompanyLabel" runat="server" 
                            Text='<%# Eval("D_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportWeekLabel" runat="server" 
                            Text='<%# Eval("DeclareReportWeek") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DeclareReportYearLabel" runat="server" 
                            Text='<%# Eval("DeclareReportYear") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" Text='<%# Eval("CompanyId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareBallotLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareBallot") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareContainerLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareContainer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="GFOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("GFOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOuterDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOuterDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTSelfDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTSelfDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QTOtherDeclareIncomeLabel" runat="server" 
                            Text='<%# Eval("QTOtherDeclareIncome") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EditTimeLabel" runat="server" Text='<%# Eval("EditTime") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="IsReportedCheckBox" runat="server" 
                            Checked='<%# Eval("IsReported") %>' Enabled="false" />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
