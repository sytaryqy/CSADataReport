<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinerReportedList.aspx.cs" Inherits="CSADataReport.Web.LinerReportedList" %>

<%@ Register src="Controls/copyright.ascx" tagname="copyright" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h3 align="center">班轮货量已上报数据</h3>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelListByCompanyId" 
            TypeName="CSADataReport.BLL.LinerDatas">
            <SelectParameters>
                <asp:SessionParameter Name="strCompanyId" SessionField="MyCompany" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <center>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataSourceID="ObjectDataSource1" GridLines="Vertical">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="没有查到任何数据"></asp:Label>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="ReportYear" HeaderText="上报年" 
                    SortExpression="ReportYear" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportWeek" HeaderText="上报周" 
                    SortExpression="ReportWeek" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="L_linerCompany.Name" HeaderText="班轮公司名称" 
                    SortExpression="LinerCompanyId" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ProxyShipCount" HeaderText="代理艘次" 
                    SortExpression="ProxyShipCount" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ProxyContainerCount" 
                    HeaderText="代理箱量" SortExpression="ProxyContainerCount" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AddTime" HeaderText="上报时间" 
                    SortExpression="AddTime" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
