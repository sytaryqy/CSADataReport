﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CSADataReport.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelList" TypeName="CSADataReport.BLL.LinerCompany">
            <SelectParameters>
                <asp:Parameter ConvertEmptyStringToNull="False" DefaultValue=" " 
                    Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="Id">
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
