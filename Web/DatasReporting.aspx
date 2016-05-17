<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatasReporting.aspx.cs" Inherits="CSADataReport.Web.DatasReporting" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>报表中心</title>
    <script src="lib/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <h2>报表中心</h2>
    <asp:Label ID="lblReportingType" runat="server" Text="报表类型："></asp:Label>
    <asp:DropDownList ID="ddlReportingType" runat="server" 
            onselectedindexchanged="ddlReportingType_SelectedIndexChanged" 
            AutoPostBack="True">
<%--            <asp:ListItem Value="Declare">报关</asp:ListItem>--%>
            <asp:ListItem Value="DeclareDatas">报关</asp:ListItem>
            <asp:ListItem Value="Routes">航线</asp:ListItem>
            <asp:ListItem Value="IncomeDatas">收入</asp:ListItem>
            <asp:ListItem Value="Composite">综合</asp:ListItem>
            <asp:ListItem Value="LinerDatas">班轮货量</asp:ListItem>
            <asp:ListItem Value="LinerIncome">班轮收入</asp:ListItem>
            <asp:ListItem Value="Liner">集装箱班轮</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblBeginDate" AssociatedControlID="txbBeginDate" runat="server" Text="报表起始日期："></asp:Label>
        <asp:TextBox ID="txbBeginDate" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txbBeginDate" Display="Dynamic" ErrorMessage="报表起始日期不能为空" 
            ValidationGroup="ValidateGetReport">*</asp:RequiredFieldValidator>
        <asp:Label ID="lblEndDate" AssociatedControlID="txbEndDate" runat="server" Text="报表结束日期："></asp:Label>
        <asp:TextBox ID="txbEndDate"  runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txbEndDate" ErrorMessage="报表结束日期不能为空" 
            ValidationGroup="ValidateGetReport" Display="Dynamic">*</asp:RequiredFieldValidator>  
        <br />
        <asp:Panel ID="panCombine" runat="server"  Visible="false">
        <div>
        <asp:Label ID="lblLastMonthBeginDate" AssociatedControlID="txbLastMonthBeginDate" runat="server" Text="环比起始日期："></asp:Label>
        <asp:TextBox ID="txbLastMonthBeginDate" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="LMBeginRequiredFieldValidator" runat="server" 
                ControlToValidate="txbLastMonthBeginDate" ErrorMessage="环比起始日期不能为空" 
                Display="Dynamic">*</asp:RequiredFieldValidator>
        <asp:Label ID="lblLastMonthEndDate" AssociatedControlID="txbLastMonthEndDate" runat="server" Text="环比结束日期："></asp:Label>
        <asp:TextBox ID="txbLastMonthEndDate"  runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="LMEndRequiredFieldValidator" runat="server" 
                ControlToValidate="txbLastMonthEndDate" Display="Dynamic" 
                ErrorMessage="环比结束日期不能为空">*</asp:RequiredFieldValidator><br />
           <asp:Label ID="lblLastYearSameTimeBeginDate" AssociatedControlID="txbLastYearSameTimeBeginDate" runat="server" Text="同比起始日期："></asp:Label>
        <asp:TextBox ID="txbLastYearSameTimeBeginDate" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="LYSTBeginRequiredFieldValidator" runat="server" 
                ControlToValidate="txbLastYearSameTimeBeginDate" Display="Dynamic" 
                ErrorMessage="同比起始日期不能为空">*</asp:RequiredFieldValidator>
        <asp:Label ID="lblLastYearSameTimeEndDate" AssociatedControlID="txbLastYearSameTimeEndDate" runat="server" Text="同比结束日期："></asp:Label>
        <asp:TextBox ID="txbLastYearSameTimeEndDate"  runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClera:false})" ></asp:TextBox>&nbsp;&nbsp; 
            <asp:RequiredFieldValidator ID="LYSTEndRequiredFieldValidator" runat="server" 
                ControlToValidate="txbLastYearSameTimeEndDate" ErrorMessage="同比结束日期不能为空" 
                Display="Dynamic">*</asp:RequiredFieldValidator><br />
        </div>
        </asp:Panel>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ShowSummary="False" />
    <hr width="80%" />
    <center>
    <asp:Button ID="Button1" runat="server" Text="生成报表" onclick="Button1_Click" 
            ValidationGroup="ValidateGetReport" />
    </div>
    </center>
    <hr width="90%" />
    <center>
    <div>
    
        <%--<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="GetData" 
            
            TypeName="CSADataReport.Web.LinerDataSetTableAdapters.DataTable1TableAdapter" 
            OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>--%>
        <%--<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="CSADataReport.Web.RoutesDataSetTableAdapters.DataTable1TableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="CSADataReport.Web.DeclareDataSetTableAdapters.DataTable1TableAdapter">
        </asp:ObjectDataSource>--%>
    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt" Width="90%" Height="301px">
            <localreport reportpath="">
                <datasources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </datasources>
            </localreport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetData" 
            TypeName="Web.DeclareDataSetTableAdapters.DataTable1TableAdapter">
        </asp:ObjectDataSource>
    
    </div>
    </center>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</body>
</html>
