<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeDatasReport.aspx.cs" Inherits="CSADataReport.Web.IncomeDatasReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收入数据上报(月报)</title>
    <script src="lib/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Css/Default.css" rel="stylesheet" type="text/css" />
    <link href="Css/btnclass.css" rel="stylesheet" type="text/css" />
    <script src="Scripte/common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var xhr = null;
    
        function DoDateChange() {
            var s = document.getElementById("txbReportDate").value;
            document.getElementById("txbReportDate").value = s;
            xhr = createXmlHttp()
            xhr.open("GET", "/Ashx/GetLastMonthDatas.ashx?date="+s, true);
            xhr.onreadystatechange = watching;
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xhr.setRequestHeader("If-Modified-Since", 0);
            xhr.send();
        }

        function watching() {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    //                    alert(xhr.responseText);
                    var msg = xhr.responseText;
                    var msgArr = msg.split("@");
                    if (msgArr[0] == "ok") {
                        //                        alert(msgArr[1]);
                        var incomedata = eval("(" + msgArr[1] + ")");
                  //      alert(incomedata.IncomeDatas[0].TotalContainerIncome);
                        for (var i = 0; i < incomedata.IncomeDatas.length; i++) {
                            getById("txbLastMonthContainerIncome").value = incomedata.IncomeDatas[0].TotalContainerIncome;
                            getById("hfLastMonthContainerIncome").value = incomedata.IncomeDatas[0].TotalContainerIncome;
                            getById("txbLastMonthBlukCargoIncome").value = incomedata.IncomeDatas[0].TotalBulkCargoIncome;
                            getById("hfLastMonthBlukCargoIncome").value = incomedata.IncomeDatas[0].TotalBulkCargoIncome;
                            getById("txbLastMonthDeclareIncome").value = incomedata.IncomeDatas[0].TotalDeclareIncome;
                            getById("hfLastMonthDeclareIncome").value = incomedata.IncomeDatas[0].TotalDeclareIncome;
                        }

                    } else {
                        getById("txbLastMonthContainerIncome").value = "无数据";
                        getById("hfLastMonthContainerIncome").value = "无数据";
                        getById("txbLastMonthBlukCargoIncome").value = "无数据";
                        getById("hfLastMonthBlukCargoIncome").value = "无数据";
                        getById("txbLastMonthDeclareIncome").value = "无数据";
                        getById("hfLastMonthDeclareIncome").value = "无数据";
                    }
                    

                } else {
                    alert(xhr.status);
                }
            }
        };

    </script>
</head>
<body>
<%--<div>
<img alt="中海船务" src="Images/CSALog.png" />
</div>--%>
    <form id="form1" runat="server">
    <div>
<h2 align="center">收入数据填报(月报)</h2>
<br />
</div>
    <table id="tDate" align="center">
        <tbody>
        <tr>
            <td width="60%">
                &nbsp;</td>
            <td colspan="4" style="text-align:right">数据日期：</td><td><input id="txbReportDate" name="ReportTime" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM',maxDate:new Date(),readOnly:true,isShowClear:false})" onchange="DoDateChange()" />
            </td>
        </tr>
        <tr>
        <td></td></tr>
        </tbody>
        </table>
    <center>
    <div>
    <table id="tBody">
        <tbody>
            <tr>
                <td></td>
                <td style="width:170px;height:25px;">本月收入</td>
                <td>上月累计收入</td>
                <td style="width:170px">累计收入</td>
            </tr>
            <tr>
                <td>集装箱货代</td>
                <td>
                    <asp:TextBox ID="txbContainerIncome" runat="server" style="text-align:right" Height="23px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txbContainerIncome" Display="Dynamic" 
                        ErrorMessage="集装箱货代收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txbContainerIncome" Display="Dynamic" 
                        ErrorMessage="集装箱货代本周收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>
                <td>
                    
                    <asp:TextBox ID="txbLastMonthContainerIncome" runat="server" ReadOnly="true"
                        BackColor="#9bbb58" BorderWidth="0px" style="text-align:center" 
                        TabIndex="-1" ></asp:TextBox>
                    
                    <asp:HiddenField ID="hfLastMonthContainerIncome" runat="server" />
                    
                    </td>
                <td>
                    <asp:TextBox ID="txbTotalContainerIncome" runat="server" style="text-align:right" Height="23px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txbTotalContainerIncome" Display="Dynamic" 
                        ErrorMessage="集装箱货代累计收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" 
                        ControlToValidate="txbTotalContainerIncome" Display="Dynamic" 
                        ErrorMessage="集装箱货代累计收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>散货货代</td>
                <td>
                    <asp:TextBox ID="txbBulkCargoIncome" runat="server" style="text-align:right" Height="23px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txbBulkCargoIncome" Display="Dynamic" 
                        ErrorMessage="散货货代收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="txbBulkCargoIncome" Display="Dynamic" 
                        ErrorMessage="散货货代本周收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txbLastMonthBlukCargoIncome" runat="server" ReadOnly="true"
                        BackColor="#9BBB58" BorderWidth="0px"  style="text-align:center" 
                        TabIndex="-1"></asp:TextBox>
                        <asp:HiddenField ID="hfLastMonthBlukCargoIncome" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txbTotalBulkIncome" runat="server" style="text-align:right" Height="23px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txbTotalBulkIncome" Display="Dynamic" 
                        ErrorMessage="散货货代累计收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator5" runat="server" 
                        ControlToValidate="txbTotalBulkIncome" Display="Dynamic" 
                        ErrorMessage="散货货代累计收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>

            </tr>
            <tr>
                <td>散货报关</td>
                <td>
                    <asp:TextBox ID="txbDelcareIncome" runat="server" style="text-align:right" Height="23px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txbDelcareIncome" Display="Dynamic" 
                        ErrorMessage="散货报关收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToValidate="txbDelcareIncome" Display="Dynamic" 
                        ErrorMessage="散货报关本周收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>
                <td>
                    <asp:TextBox ID="txbLastMonthDeclareIncome" runat="server" BackColor="#9BBB58" ReadOnly="true"
                        BorderWidth="0px"  style="text-align:center" TabIndex="-1"></asp:TextBox>
                        <asp:HiddenField ID="hfLastMonthDeclareIncome" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txbTotalDelcareIncome" runat="server" style="text-align:right" Height="23px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txbTotalDelcareIncome" Display="Dynamic" 
                        ErrorMessage="散货报关累计收入不能为空" ValidationGroup="SaveValidate">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator6" runat="server" 
                        ControlToValidate="txbContainerIncome" Display="Dynamic" 
                        ErrorMessage="散货报关累计收入请填写有效的数字" Operator="DataTypeCheck" Type="Double" 
                        ValidationGroup="SaveValidate">*</asp:CompareValidator>
                </td>
            </tr>
        </tbody>
    </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="SaveValidate" />
            <br />
    <table>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="保 存" 
                    onclick="btnSave_Click" ValidationGroup="SaveValidate" />
            </td>
            <td>
                <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="上 报" 
                    onclick="btnReport_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" Width="300px" style="text-align:center" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
    </div></center>
    </form>
</body>
</html>
