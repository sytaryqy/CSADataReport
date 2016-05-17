<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="CSADataReport.Web.Admin.UserManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .textright
    {
        text-align:center;
        vertical-align:bottom;      
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelListEx" TypeName="CSADataReport.BLL.Users" 
            DataObjectTypeName="CSADataReport.Model.Users" InsertMethod="Add" 
            UpdateMethod="UpdateEx">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUserRoles" runat="server" 
            SelectMethod="GetModelList" TypeName="CSADataReport.BLL.UserRoles" 
            CacheDuration="300" EnableCaching="True">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsCompanies" runat="server" CacheDuration="300" 
            EnableCaching="True" SelectMethod="GetModelList" 
            TypeName="CSADataReport.BLL.Companies">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUserStates" runat="server" CacheDuration="300" 
            EnableCaching="True" SelectMethod="GetModelList" 
            TypeName="CSADataReport.BLL.UserStates">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
            InsertItemPosition="LastItem" oniteminserting="ListView1_ItemInserting" 
            onitemupdating="ListView1_ItemUpdating" >
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;text-align:center;">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td >
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Width="20px" />
                    </td>
                    <td>
                        <asp:Label ID="CnNameLabel" runat="server" Text='<%# Eval("CnName") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" 
                            Text='<%# Eval("LoginName") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="LoginPwdLabel" runat="server" 
                            Text='<%# Eval("LoginPwd") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" 
                            Text='<%# Eval("U_UserCompany.CompanyName") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="UserRoleIdLabel" runat="server" 
                            Text='<%# Eval("U_UserRoles.Name") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="UserStateIdLabel" runat="server" 
                            Text='<%# Eval("U_UserStates.Name") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #999999;text-align:center;">
                    
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td >
                        <asp:Label ID="EditIdLabel" runat="server" Text='<%# Bind("Id") %>' />
                    </td>
                    <td >
                        <asp:TextBox ID="EditCnNameTextBox" runat="server" 
                            Text='<%# Bind("CnName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EditLoginNameTextBox" runat="server" 
                            Text='<%# Bind("LoginName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EditLoginPwdTextBox" runat="server" 
                            Text='<%# Bind("LoginPwd") %>' Width="280px" />
                    </td>
                    <td>
                        <asp:DropDownList ID="EditCompanyDropDownList" runat="server"  DataSourceID="odsCompanies" DataTextField="CompanyName" DataValueField="Id" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="EditUserRolesDropDownList" runat="server" DataSourceID="odsUserRoles" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="EditUserStatesDropDownList" runat="server" DataSourceID="odsUserStates" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="EditAddTimeTextBox" runat="server" Text='<%# Bind("AddTime") %>' Visible="false" />
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
                <tr style="text-align:center">
                    
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="增加" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:Label ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' Width="20px" />
                    </td>
                    <td>
                        <asp:TextBox ID="CnNameTextBox" runat="server" 
                            Text='<%# Bind("CnName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LoginNameTextBox" runat="server" 
                            Text='<%# Bind("LoginName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LoginPwdTextBox" runat="server" 
                            Text='<%# Bind("LoginPwd") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="CompanyDropDownList" runat="server" DataSourceID="odsCompanies" DataTextField="CompanyName" DataValueField="Id" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="UserRolesDropDownList" runat="server" DataSourceID="odsUserRoles" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="UserStatesDropDownList" runat="server" DataSourceID="odsUserStates" DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="AddTimeTextBox" runat="server" Text='<%# Bind("AddTime") %>' Visible="false" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;text-align:center;">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Width="20px" />
                    </td>
                    <td>
                        <asp:Label ID="CnNameLabel" runat="server" Text='<%# Eval("CnName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" Text='<%# Eval("LoginName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginPwdLabel" runat="server" 
                            Text='<%# Eval("LoginPwd") %>'  />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" 
                            Text='<%# Eval("U_UserCompany.CompanyName") %>' style="text-align:center" />
                    </td>
                    <td>
                        <asp:Label ID="UserRoleIdLabel" runat="server" 
                            Text='<%# Eval("U_UserRoles.Name") %>' style="text-align:center" />
                    </td>
                    <td>
                        <asp:Label ID="UserStateIdLabel" runat="server" 
                            Text='<%# Eval("U_UserStates.Name") %>' style="text-align:center" />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
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
                                    <th id="Th1" runat="server">
                                        Id</th>
                                    <th id="Th2" runat="server">
                                        用户名</th>
                                    <th id="Th3" runat="server">
                                        登录名</th>
                                    <th id="Th4" runat="server">
                                        登录密码</th>
                                    <th id="Th5" runat="server">
                                        口岸名</th>
                                    <th id="Th6" runat="server">
                                        用户级别</th>
                                    <th id="Th7" runat="server">
                                        用户状态</th>
                                    <th id="Th8" runat="server">
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
                <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Width="20px" />
                    </td>
                    <td>
                        <asp:Label ID="CnNameLabel" runat="server" Text='<%# Eval("CnName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" Text='<%# Eval("LoginName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginPwdLabel" runat="server" 
                            Text='<%# Eval("LoginPwd") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyIdLabel" runat="server" 
                            Text='<%# Eval("U_UserCompany.CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UserRoleIdLabel" runat="server" 
                            Text='<%# Eval("U_UserRoles.Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UserStateIdLabel" runat="server" 
                            Text='<%# Eval("U_UserStates.Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddTimeLabel" runat="server" Text='<%# Eval("AddTime") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    
    </div>
    </form>
</body>
</html>
