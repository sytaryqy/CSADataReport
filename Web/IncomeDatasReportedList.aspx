<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeDatasReportedList.aspx.cs" Inherits="CSADataReport.Web.IncomeDatasReportedList" %>

<%@ Register src="Controls/copyright.ascx" tagname="copyright" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h3 align="center">收入历史数据</h3>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelListByCompanyId" TypeName="CSADataReport.BLL.IncomeDatas">
            <SelectParameters>
                <asp:SessionParameter Name="strCompanyId" SessionField="MyCompany" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataSourceID="ObjectDataSource1" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="没有查到任何数据"></asp:Label>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                    Visible="False" />
                <asp:BoundField DataField="CompanyId" HeaderText="CompanyId" 
                    SortExpression="CompanyId" Visible="False" />
                <asp:BoundField DataField="ReportYear" HeaderText="上报年" 
                    SortExpression="ReportYear">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportWeek" HeaderText="上报周" 
                    SortExpression="ReportWeek">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EditTime" HeaderText="上报日期" 
                    SortExpression="EditTime" />
                <asp:BoundField DataField="ContainerIncome" HeaderText="集装箱货代收入" 
                    SortExpression="ContainerIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="BulkCargoIncome" HeaderText="散货货代收入" 
                    SortExpression="BulkCargoIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="DeclareIncome" HeaderText="散货报关收入" 
                    SortExpression="DeclareIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalContainerIncome" HeaderText="累计集装箱货代收入" 
                    SortExpression="TotalContainerIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalBulkCargoIncome" HeaderText="累计散货货代收入" 
                    SortExpression="TotalBulkCargoIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalDeclareIncome" HeaderText="累计散货报关收入" 
                    SortExpression="TotalDeclareIncome">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="IsReported" HeaderText="是否上报" 
                    SortExpression="IsReported">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:BoundField DataField="AddTime" HeaderText="添加时间" 
                    SortExpression="AddTime" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </center>
    </div>
    <uc1:copyright ID="copyright1" runat="server" />
    </form>
</body>
</html>
