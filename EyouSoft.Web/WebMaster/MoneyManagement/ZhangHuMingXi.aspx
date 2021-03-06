﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhangHuMingXi.aspx.cs" Inherits="EyouSoft.Web.WebMaster.MoneyManagement.ZhangHuMingXi" %>
<%@ Register Assembly="ControlLibrary" Namespace="Adpost.Common.ExporPage" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/webmaster/boxy.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.boxy.js" type="text/javascript"></script>

    <script src="/JS/datepicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/JS/InitialPageInputTagValue.js" type="text/javascript"></script>

</head>
<body>
    <table width="99%" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanleft.gif" alt="" />
                </td>
                <td>
                    <form id="form1">
                    <div class="searchbox">
                        
                            <%--<label>用户帐号：</label>
                        <input id="UserName" name="UserName" type="text" class = "inputtext" value="<%=Request.QueryString["UserName"] %>" />--%>
                        <%--<%=Html.TextBoxFor(x => x.UserName, new { @class = "inputtext" })%>--%>
                        
                            <%--<label>充值金额：</label>
                        <input id="ChongZhiJinE1" name="ChongZhiJinE1" type="text" class = "inputtext formsize50"  value="<%=Request.QueryString["ChongZhiJinE1"] %>"/>-<input id="ChongZhiJinE2" name="ChongZhiJinE2" type="text" class = "inputtext formsize50" value="<%=Request.QueryString["ChongZhiJinE2"] %>" />--%>
                        <%--<%=Html.TextBoxFor(x => x.ChongZhiJinE1, new { @class = "inputtext formsize50" })%>-
                        <%=Html.TextBoxFor(x => x.ChongZhiJinE2, new { @class = "inputtext formsize50" })%>--%>
                        <label>
                            交易日期：</label>
                            <input id="StartTime" name="StartTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["StartTime"] %>" />-<input id="EndTime" name="EndTime" class = "inputtext formsize120" onfocus = "WdatePicker()" type="text" value="<%=Request.QueryString["EndTime"] %>" />
                       <%-- <%=Html.TextBoxFor(x => x.StartTime, new { @class = "inputtext formsize50", size = 10, onfocus = "WdatePicker({minDate:'#F{$dp.$D(\\'EndTime\\')}'})" })%>-
                        <%=Html.TextBoxFor(x => x.EndTime, new { @class = "inputtext formsize50", size = 10, onfocus = "WdatePicker({minDate:'#F{$dp.$D(\\'StartTime\\')}'})" })%>--%>
                        <%--<label>
                            状态：</label>--%>
                        <%--<%=Html.DropDownListFor(x=>x.State2, new Linq.Web.SelectListItem{  Text="-请选择-"}) %>--%>
                        <input type="submit" class="search-btn" value="" />
                    </div>
                    </form>
                </td>
                <td width="10" valign="top">
                    <img src="/Images/webmaster/yuanright.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="tablelist">
    <div style="text-align:center; font-size:16px; color:Red; font-weight:bolder;">总账户金额：<asp:Literal ID="Literal2" runat="server"></asp:Literal>元</div>
        <table width="100%" cellspacing="1" cellpadding="0" border="0" id="liststyle">
            <tbody>
                <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        用户名
                    </th>
                    <th align="center">
                        操作方式
                    </th>
                    <th align="center">
                        操作金额
                    </th>
                    <%--<th align="center">
                        操作对象
                    </th>--%>
                    <th align="center">
                        操作时间
                    </th>
                    
                    <th align="center">
                        操作状态
                    </th>
                    <th align="center">
                        描述
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rptList">
                    <ItemTemplate>
                        <tr class="<%# Container.ItemIndex % 2 == 0 ? "even" : "odd"%>">
                            <%--<td height="30" align="center">
                                <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>">
                            </td>--%>
                            <td align="center">
                                <%#GetMemberNameByID(Eval("HuiYuanId"))%>
                            </td>
                            <td align="center">
                                <%#Eval("JiaoYiLeiBie")%>
                            </td>
                            <td align="center">
                            <%# GetJinE(Eval("JiaoYiJinE"),Eval("JiaoYiLeiBie"))%>
                                <%--<%#Eval("JiaoYiJinE","{0:F4}") %>--%>
                            </td>
                            <%--<td align="center">
                                <%#GetMemberNameByID(Eval("TranUserId"))%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("JiaoYiShiJian")%>
                            </td>
                            
                            <td align="center">
                                <%#Eval("JiaoYiStatus")%>
                            </td>
                            <td align="center">
                                <%#Eval("JiaoYiMiaoShu")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot><tr><td colspan="8"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td></tr>
             <tr>
                    <%--<th width="60" height="30" align="center">
                        <input type="checkbox" id="checkbox3" name="checkbox3">全选
                    </th>--%>
                    <th align="center">
                        用户名
                    </th>
                    <th align="center">
                        操作方式
                    </th>
                    <th align="center">
                        操作金额
                    </th>
                    <%--<th align="center">
                        操作对象
                    </th>--%>
                    <th align="center">
                        操作时间
                    </th>
                    
                    <th align="center">
                        操作状态
                    </th>
                    <th align="center">
                        描述
                    </th>
                </tr>
            </tfoot>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" align="right" class="pageup" colspan="13">
                    <cc1:ExporPageInfoSelect ID="ExportPageInfo1" runat="server" />
                </td>
            </tr>
        </table>
    </div><br /><br />
</body>

<script type="text/javascript">
    var intance = new InitialPageInputTagValue();
    intance.Init();
</script>
</html>
