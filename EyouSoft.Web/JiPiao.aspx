<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true" CodeBehind="JiPiao.aspx.cs" Inherits="EyouSoft.Web.JiPiao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Access-Control-Allow-Origin" content="*">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<form method="post" action="http://jipiao.slej.cn/Login.aspx" onsubmit="return doCheck()">
  <div class="mainbox">
    
      <div class="loginbox">
         <div class="loginbar">
            <h3>�û���¼</h3>
            
            <div class="login_side">
                <ul class="login_form">
                     <li><label>�û�����</label><input id="Uname" name="Uname" class="formsize180 input-style" value="�������ֻ���" /></li>
                     <li><label>��&nbsp;&nbsp;&nbsp;�룺</label><input id="Passwd" name="Passwd" type="password" class="formsize180 input-style" /></li>
                     <li><label>��֤�룺</label><input id="CheckCode" name="CheckCode" class="formsize100 input-style" /> <img border="0" src="http://jipiao.slej.cn/ValidateCode.aspx" width="70" height="23" /></li>
                     <li style="padding-left:9px;">���ںţ�988988   ���룺988988</li>
                     <li style="padding-left:65px;">
                     <input name="image3" type="submit" class="loginbtn" value="��¼" style=" border:0px; cursor:pointer;" />
                     <a id="zhuce" class="login_basicbtn" href="javascript:void(0)"><span>�ǻ�Ա������</span></a></li>
                </ul>
                <div class="login_table">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="29%" height="35">����<span class="font_yellow">������</span></td>
                    <td width="4%" rowspan="4" style="border-right:#ddd solid 1px;">&nbsp;</td>
                    <td align="center">����<span class="font_yellow">�������</span>��׬�߷�������</td>
                  </tr>
                  <tr>
                    <td>���ܸ����ۿ�</td>
                    <td align="center">ӵ�ж���������վ���ֻ�΢��</td>
                  </tr>
                  <tr>
                    <td height="15" align="center"><img src="images/jt_grayb.gif" width="6" height="5" /></td>
                    <td align="center"><img src="images/jt_grayb.gif" width="6" height="5" /></td>
                  </tr>
                  <tr>
                    <td align="center"><a class="login_basicbtn" href="/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767"><span>��������</span></a></td>
                    <td align="center"><a class="login_basicbtn" href="/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652"><span>��������</span></a></td>
                  </tr>
                </table>
                
                </div>        
           </div>
            
         </div>
      </div>
      
      
      <div class="login_list mt10">
         <h3><img src="images/login_listT.gif" /></h3>
         
         <div class="login_listbox fixed">
             <ul style="border-right:#c2c2c2 solid 1px;">
                <li><strong>01.ϵͳ��¼��</strong>��Ʊ��Ŀ�Գ���ϵ���߷��㣨��3-20%����Ʊ��ͨ���ֻ��ŵ�¼�󷽿�Ԥ����</li>
                <li><strong>02.��ѯԤ����</strong>��¼��������ֹ�������ƺͳ������ڲ�ѯ���躽�༰���������Ԥ���ύ��</li>
                <li><strong>03.����֧����</strong>ͨ�����������ÿ����������ۺ��ۼ۸��ڰ�Сʱ����ɷ���֧����</li>
                <li><strong>04.Ʊ��۸�</strong>ֽ�ʻ�Ʊ���г̵�����Ʊ���Ϊ����ǰ�ļ۸񡣷��㲿�ݼ�Ϊ��������ѡ�</li>
                <li><strong>05.��Ʊ���ȣ�</strong>�ڡ��ҵĶ��������пɲ鿴��ƱԤ���ͳ�Ʊ���ȡ�</li>
                <li><strong>06.�ǻ�����</strong>ƾ���֤��Ӥͯƾ���ڱ�������Ʊ��̨���ɰ�������ֽ�ʻ�Ʊ���г̵�����</li>
             </ul>
             
             <ul>
                <li><strong>07.ȡƱ������</strong>ƾ���֤���������д�ӡֽ�ʻ�Ʊ��Ҳ����һ�����µ�0571-85095701ȡƱ��</li>
                <li><strong>08.��Ʊ���棺</strong>��¼<a href="http://www.travelsky.com" target="_blank" class="font_yellow">www.travelsky.com</a>�����������µ�<span class="font_yellow">400-815-8888</span>���л�Ʊ�����ʵ��</li>
                <li><strong>09.Ӥͯ��Ʊ��</strong>�ڡ�����ӤͯƱ��������ͬ�г��˻�Ʊ�����Ӥͯ�������Ӥͯ��Ʊ������</li>
                <li><strong>10.��ǩ��Ʊ��</strong>�������ǩ���������ա�����Ʊ����ť�˽���Ӧ�������ߺ�ȷ����Ӧ������</li>
                <li><strong>11.���ձ��գ�</strong>���� ���ɹ������й��򺽿�������ӱ��գ�һ��ֻ��6-10Ԫ/��/�̡�</li>
                <li><strong>12.�ۺϲ�ѯ��</strong>�����Ʊ���⣬���µ�<span class="font_yellow">400-6588-180</span>������ѯ��</li>
             </ul>
             
         </div>
         
      </div>
    
  </div>

</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
<%--<script type="text/javascript">
    function abc() {
        $.ajax({
            type: "POST",
            url: "http://jipiao.hzjaly.com/Login.aspx",
            data: $("#bnt").closest("form").serialize(), "image3.x": 33, "image3.y": 10
        });
    }
</script>--%>
<script type="text/javascript">
    $(function() {
        $("#zhuce").click(function() {
            window.location.href = '/YuDing.aspx?rurl=' + encodeURIComponent(window.location.href);
        });
        $("#Uname").focus(function() {
        if ($('#Uname').val() == "�������ֻ���") { $('#Uname').val(""); }
        });
        $("#Uname").blur(function() {
        if ($('#Uname').val() == "") { $('#Uname').val("�������ֻ���"); }
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
