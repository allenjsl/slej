<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/FrontFixed.Master" AutoEventWireup="true" CodeBehind="XingCheLuXian.aspx.cs" Inherits="EyouSoft.Web.XingCheLuXian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html {width: 100%;height: 100%; margin:0;font-family:"΢���ź�";}
		#allmap{height:500px;width:100%;}
		#r-result,#r-result table{width:100%;}
	</style>
	<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=ovOm8pf0QIyWC4n4jx8I5vPG"></script>
	<script type="text/javascript" src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<title>���ݵص��г�·��</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div id="allmap"></div>
<script type="text/javascript">
    // �ٶȵ�ͼAPI����
    var map = new BMap.Map("allmap");
    var dianlist = '<%=Request.QueryString["dibiao"] %>'
    var didian = new Array();
    didian = dianlist.split(',');
    map.enableKeyboard();
    map.enableScrollWheelZoom();
    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
    //���ּݳ����ԣ�����ʱ�䣬��̾��룬�ܿ�����
    var routePolicy = BMAP_DRIVING_POLICY_LEAST_DISTANCE;
    for (var i = 0; i < didian.length - 1; i++) {
        search(didian[i], didian[i + 1], routePolicy);
        function search(start, end, route) {
            var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, autoViewport: true }, policy: route });
            driving.search(start, end);
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
