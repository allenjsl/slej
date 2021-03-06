﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZengZhi.aspx.cs" Inherits="EyouSoft.WAP.Member.ZengZhi" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>积分增值</title>
    <link rel="stylesheet" href="/css/e.css" type="text/css" media="screen">
    <link href="/css/ustyle.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script type="text/javascript">

        var myScroll, pullDownEl, pullDownOffset,
	pullUpEl, pullUpOffset,
	generatedCount = 0;

        function pullDownAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                for (i = 0; i < 12; i++) {
                    $(el).append("<li>Generated row " + (++generatedCount) + "</li>")
                }

                myScroll.refresh();
            }, 1000);
        }

        function pullUpAction() {
            setTimeout(function() {
                var el, li, i;
                el = document.getElementById('linelist');

                var index = parseInt($("#pageindex").val()) + 1;
                $("#pageindex").val(index);
                var para = { pageindex: $("#pageindex").val() };
                $.ajax({
                    type: "Get",
                    url: "/CommonPage/ajaxZengZhi.aspx?" + $.param(para),
                    cache: false,
                    success: function(result) {
                        if (result != "" && result.length > 2) {
                            $(el).append(result);
                        }
                        else {
                            pullUpEl.querySelector('.pullUpLabel').innerHTML = '已加载至最后';
                        }
                    }
                });
                myScroll.refresh();
            }, 1000);
        }

        function loaded() {

            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight

            myScroll = new iScroll('wrapper', {
                mouseWheel: true,
                click: true,
                checkDOMChanges: true,
                onRefresh: function() {
                    if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function() {
                    if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '放开刷新..';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function() {
                    if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '正在加载...';
                        pullUpAction();
                    }
                }
            });
        }

        document.addEventListener('touchmove', function(e) { e.preventDefault(); }, false);
        document.addEventListener('DOMContentLoaded', loaded, false);

        function change(i) {
            if (i == 1) {
                $("#a1").show();
                $("#a2").hide();

            }
            else {
                $("#a2").show();
                $("#a1").hide();
            }

            myScroll.scrollToPage(0, 0, 100);


        }


    </script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div id="wrapper">
            <div id="scroller">
                <div id="a1">
                    <div class="car_banner">
                        <img src="/images/jifen-zzbanner.jpg">
                    </div>
                    <div class="paddT paddR paddL">
                        <div class="e_jifen">
                            <div class="e_jifen_head">
                                <ul class="clearfix">
                                    <li>积分日期</li>
                                    <li>额宝余额</li>
                                    <li>日积分率</li>
                                    <li>日积分数</li>
                                </ul>
                            </div>
                            <div class="e_jifen_list">
                                <ul class="clearfix" id="linelist">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <%#Eval("DealDate", "{0:yyyy-MM-dd}")%></li>
                                            <li>
                                                <%#Eval("Account") %></li>
                                            <li>
                                                <%#Convert.ToDecimal(Eval("IntersetRate"))/10000M%></li>
                                            <li>
                                                <%#Eval("DayInCome") %></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                    <div id="pullUp" style="text-align: center">
                        <span class="pullUpIcon"></span><span class="pullUpLabel">
                            <asp:Literal ID="XianShi" runat="server"></asp:Literal></span>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
        <input id="pageindex" type="hidden" value="1" />
    </div>
    <div class="e_bot">
        <div class="e_bot_box">
            <div class="side01">
                <div class="txt">
                    累计积分：<%=getSumJF()%></div>
            </div>
            <div class="side02">
                <ul>
                    <li>已兑换积分：<asp:Literal ID="YiDuiJiFen" runat="server"></asp:Literal></li>
                    <li>被冻结积分：<asp:Literal ID="DongJiJiFen" runat="server"></asp:Literal></li>
                </ul>
            </div>
            <div class="side03">
                <div class="txt">
                    可用积分：<em><asp:Literal ID="KeYongJiFen" runat="server"></asp:Literal></em></div>
                <div class="btn">
                    <a href="" class="step_btn">积分兑换</a></div>
            </div>
        </div>
    </div>

    <script type="text/javascript">        $(function() {
            $("#wrapper").css("top",
    "40px"); $("#wrapper").css("bottom", "120px");
        }); </script>

</body>
</html>
