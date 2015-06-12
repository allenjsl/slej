<%@ Page Language="C#" Title="��������" AutoEventWireup="true" MasterPageFile="~/MasterPage/Front2.Master"
    CodeBehind="Weather.aspx.cs" Inherits="EyouSoft.Web.ToolsPage.Weather" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta content="text/html; charset=gb2312" http-equiv="Content-Type">
    <meta name="GENERATOR" content="MSHTML 8.00.6001.18702">
    <style type="text/css">
        H3
        {
            margin: 0px;
        }
        .clearit
        {
            clear: both;
        }
        .link14listStyle LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 23px;
            padding-left: 9px;
            padding-right: 0px;
            background: url(/images/toolspage/weather/news_law_hz_012.gif) no-repeat 0px 50%;
            font-size: 14px;
            padding-top: 0px;
        }
        .link14list LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 23px;
            padding-left: 0px;
            padding-right: 0px;
            font-size: 14px;
            padding-top: 0px;
        }
        .link12listStyle LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 20px;
            padding-left: 9px;
            padding-right: 0px;
            background: url(/images/toolspage/weather/news_law_hz_012.gif) no-repeat 0px 45%;
            font-size: 12px;
            padding-top: 0px;
        }
        .link12list LI
        {
            text-align: left;
            padding-bottom: 0px;
            line-height: 20px;
            padding-left: 0px;
            padding-right: 0px;
            font-size: 12px;
            padding-top: 0px;
        }
        #wrap
        {
            text-align: left;
            margin: 0px auto;
        }
        .sina_w_search
        {
            position: relative;
            text-align: right;
            margin-top: 10px;
            padding-right: 5px;
        }
        .sina_search_ico
        {
            z-index: 999;
            position: absolute;
            height: 27px;
            top: -3px;
            right: 195px;
        }
        .sina_w_city_input
        {
            padding-left: 10px;
            width: 150px;
            color: #ccc;
        }
        .sina_w_city_btn
        {
            width: 35px;
            margin-left: 2px;
        }
        .sina_w_custom
        {
            text-align: right;
            padding-right: 5px;
        }
        .sina_w_custom_province
        {
        }
        .sina_w_custom_city
        {
        }
        .sina_w_custom_submit
        {
            width: 35px;
            margin-left: 2px;
        }
        .sina_w_view
        {
        }
        .sina_w_view_title
        {
            line-height: 30px;
            margin-bottom: 8px;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left bottom;
            height: 30px;
        }
        .sina_w_view_title SPAN
        {
            float: right;
        }
        .sina_w_view_title H3
        {
            color: #ff0000;
            font-size: 18px;
        }
        .sina_w_view_today
        {
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
        }
        .sina_w_view_today H3
        {
            color: #04086b;
            font-size: 16px;
        }
        .sina_w_view_today H3 STRONG
        {
            color: #999;
            font-size: 12px;
            font-weight: normal;
        }
        .sina_w_view_today H3 SPAN
        {
            color: #999;
            font-size: 12px;
            font-weight: normal;
        }
        .sina_w_view_today_status
        {
            padding-bottom: 4px;
            padding-top: 4px;
        }
        .sina_w_view_today_status IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_today_status STRONG
        {
            font-size: 12px;
        }
        .sina_w_view_today_status SPAN
        {
        }
        .sina_w_view_today_table
        {
        }
        .sina_w_view_today_table TABLE
        {
        }
        .sina_w_view_today_table TABLE TD
        {
            line-height: 18px;
        }
        .sina_w_view_today_table TABLE TD STRONG
        {
            color: #04086b;
            font-weight: normal;
        }
        .sina_w_view_today_more
        {
            text-align: right;
        }
        .sina_w_view_others
        {
            border-left: medium none;
            margin-top: 5px;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left top;
            float: left;
            border-right: medium none;
        }
        .sina_w_view_others_patch
        {
            padding-bottom: 10px;
            line-height: 24px;
            padding-left: 10px;
            width: 100%;
            padding-right: 10px;
            display: inline-block;
            background: url(/images/toolspage/weather/dot_01.gif) repeat-x left bottom;
            float: left;
            padding-top: 10px;
        }
        .sina_w_view_tomorrow
        {
            width: 50%;
            float: left;
        }
        .sina_w_view_tomorrow H3
        {
            color: #999;
            font-size: 14px;
            ling-height: 35px;
        }
        .sina_w_view_tomorrow H3 IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_tomorrow P
        {
            line-height: 20px;
        }
        .sina_w_view_after_tomorrow
        {
            padding-left: 8px;
            width: 43%;
            background: url(/images/toolspage/weather/dot_02.gif) repeat-y left 50%;
            float: left;
            margin-left: 40px;
        }
        .sina_w_view_after_tomorrow H3
        {
            color: #999;
            font-size: 14px;
            ling-height: 35px;
        }
        .sina_w_view_after_tomorrow H3 IMG
        {
            vertical-align: middle;
            margin-right: 2px;
        }
        .sina_w_view_after_tomorrow P
        {
            line-height: 20px;
        }
    </style>
    <style>
        .main_div
        {
            width: 100%;
            height: 420px;
        }
        .bottom_words
        {
            padding-right: 10px;
            font-family: verdana;
            color: #e1e1e1;
            font-size: 10px;
        }
        FORM
        {
            margin: 0px;
        }
        .color_red
        {
            color: #ce5834;
            font-size: 14px;
        }
    </style>

    <script type="text/javascript" src="/JS/toolspage/weather/io_script-1.0.js"></script>

    <script type="text/javascript" src="/JS/toolspage/weather/jscookie.js"></script>

    <script type="text/javascript" src="/JS/toolspage/weather/weather_process-1.0.js"></script>

    <script type="text/javascript"> 
<!--        //--><![CDATA[//><!--
        function $_$(id) {
            return document.getElementById(id);
        }

        function rtrim(str, s) {
            if (typeof s == 'undefined') {
                s = "\s+";
            }
            var reg = new RegExp(s + "$");
            return str.replace(reg, '');
        }
        /**
        * �ж��ַ����Ƿ�ȫΪ����
        * @author abear
        * @param {string} chinese char
        * @return {Boolean}
        * @example
        * (code)
        * isChinese('��');
        * (returns)
        * true
        */
        var isChinese = function(sStr) {
            return /^[\u4e00-\u9fa5]+$/.test(sStr);
        };
        //--><!]]>
    </script>
<script type="text/javascript">
    $(function() {
        //$('.n_leftbox').css('width', 0);
        //$('.n_leftbox').hide();
        ///$('.n_rightbox').css('width', 1090);
        //$('.n_rightbox').css('height', 394);

        //$('.main_div').css('margin-left', $('.n_rightbox').width() / 2 - $('.main_div')[0].offsetWidth / 2)
    });
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="main_div">
        <form style="height:auto;">
        <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tbody>
                <tr>
                    <td>
                        <img src="/images/toolspage/weather/title.gif" width="143" height="45">
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#e0dcd1" height="323" valign="top" align="middle">
                        <table border="0" cellspacing="0" cellpadding="0" width="90%">
                            <tbody>
                                <tr>
                                    <td height="54" align="right">
                                        <label for="wide_01">
                                            <input id="wide_01" checked=checked align="absMiddle" type="radio" name="wide">
                                            <span class="color_red">���ڳ���</span></label>
                                        &nbsp;&nbsp;<label for="wide_02">
                                        <%--<input id="wide_02" align="absMiddle" type="radio"  name="wide">--%>
                                            <span class="color_red">
                                                <select style="color: #000000" id="sina_w_custom_province" class="sina_w_custom_province"
                                                    title="��ѡ��ʡ��" onchange="CitysHandler.insertCitys(this.options[this.selectedIndex].value);"
                                                    name="sina_w_custom_province">
                                                    <option selected value="">��ѡ��ʡ��</option>
                                                    <option value="����">����</option>
                                                    <option value="���">���</option>
                                                    <option value="�ӱ�">�ӱ�</option>
                                                    <option value="ɽ��">ɽ��</option>
                                                    <option value="ɽ��">ɽ��</option>
                                                    <option value="���ɹ�">���ɹ�</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="�Ϻ�">�Ϻ�</option>
                                                    <option value="����">����</option>
                                                    <option value="�㽭">�㽭</option>
                                                    <option value="����">����</option>
                                                    <option value="�㶫">�㶫</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="������">������</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="�½�">�½�</option>
                                                    <option value="�ຣ">�ຣ</option>
                                                    <option value="����">����</option>
                                                    <option value="�Ĵ�">�Ĵ�</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="����">����</option>
                                                    <option value="�۰�̨">�۰�̨</option>
                                                </select>
                                                <select id="sina_w_custom_city" class="sina_w_custom_city" title="��ѡ�����" name="sina_w_custom_city">
                                                    <option selected value="">��ѡ�����</option>
                                                </select>

                                                <script type="text/javascript">
<!--                                                    //--><![CDATA[//><!--
                                                    var CitysHandler = {
                                                        init: function() {
                                                            this.io = "http://php.weather.sina.com.cn/iframe/get_citys.php?province=@province@&code=js&charset=gbk" + "&_=@random@";
                                                            this.eSelectCity = $_$('sina_w_custom_city');
                                                            this.eSelectProvince = $_$('sina_w_custom_province');
                                                            this.__initSelect();
                                                        },
                                                        /**
                                                        * ��ʼ��selected
                                                        */
                                                        __initSelect: function() {
                                                            this.eSelectCity.options[0].selected = 'selected';
                                                            this.eSelectProvince.options[0].selected = 'selected';
                                                        },
                                                        /**
                                                        * ��������б�
                                                        */
                                                        insertCitys: function(sProvince) {
                                                            if (sProvince == '') {
                                                                this.__clearOption(eSelect, true);
                                                                return false;
                                                            }
                                                            //clear select citys options
                                                            this.eSelectCity.options.length = 1;
                                                            var url = this.io;
                                                            var random = (new Date()).getTime();
                                                            url = url.replace(/@province@/g, sProvince);
                                                            url = url.replace(/@random@/g, random);
                                                            var jsloader = new IO.Script();
                                                            jsloader.load(url, function() {
                                                                try {
                                                                    this.__insertCitys(this.eSelectCity, SINA_W_CITYS[sProvince]);
                                                                } catch (e) { }
                                                            } .Bind(this));

                                                        },
                                                        __insertCitys: function(eSelect, aCitys) {
                                                            var sOptionText, sOptionValue;
                                                            for (var i = 0; i < aCitys.length; i++) {
                                                                sOptionText = sOptionValue = aCitys[i];
                                                                this.__insertOption(eSelect, sOptionText, sOptionValue);
                                                            }
                                                        },
                                                        __clearOption: function(eSelect, bDefault) {
                                                            //eSelect.options.length = 0;
                                                            bDefault = !!bDefault;
                                                            if (bDefault) {
                                                                //this.__insertOption(eSelect,'��ѡ�����','',true);
                                                                eSelect.options.length = 1;
                                                            } else {
                                                                eSelect.options.length = 0;
                                                            }
                                                        },
                                                        //add a option for a select
                                                        __insertOption: function(eSelect, sOptionText, sOptionValue, bSelected) {
                                                            if (!eSelect || sOptionText == '') {
                                                                return false;
                                                            }
                                                            try {
                                                                option = new Option(sOptionText, sOptionValue);
                                                                eSelect.options.add(option);
                                                                if ((!!bSelected) === true) {
                                                                    //option.selected = "selected";
                                                                    option.selected = true;
                                                                }
                                                                //alert('ss')
                                                            } catch (e) {
                                                                return false;
                                                            }
                                                            return true;
                                                        }
                                                    };
                                                    CitysHandler.init();
                                                    //--><!]]>
                                                </script>

                                                <input class="sina_w_custom_submit" title="���Ƹó���������Ϣ" onclick="Customer.custom(CitysHandler.eSelectCity.options[CitysHandler.eSelectCity.selectedIndex].value);"
                                                    value="�鿴" type="button" name="submit">
                                            </span>
                                        </label>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <!---��̬������ʾ��ʼ-->
                                        <div class="sina_w_view">
                                            <div style="visibility: hidden" id="sina_w_view_title" class="sina_w_view_title">
                                                <h3 style="text-align: left">
                                                    @city@</h3>
                                            </div>
                                            <!-- today begin -->
                                            <div style="visibility: hidden" id="sina_w_view_today" class="sina_w_view_today">
                                                <h3 style="text-align: left; margin-left: 10px">
                                                    ���� <strong>@Y@-@m@-@d@ @week@</strong></h3>
                                                <div style="text-align: left; margin-left: 10px" class="sina_w_view_today_status">
                                                    @figure@@status@ @temperature@<span>������@power@</span></div>
                                                <div class="sina_w_view_today_table">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="padding-left: 10px" width="52%" align="left">
                                                                    <strong>����˵����</strong>@chy_l@
                                                                </td>
                                                                <td style="padding-left: 10px" width="48%" align="left">
                                                                    <strong>��Ⱦ˵����</strong>@pollution_l@
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-left: 10px" align="left">
                                                                    <strong>��ɹ˵����</strong>@fas_l@
                                                                </td>
                                                                <td style="padding-left: 10px" align="left">
                                                                    <strong>ϴ��˵����</strong>@xcz_l@
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left; padding-left: 10px" align="left">
                                                                    <strong>���ʶ�˵����</strong>@ssd_l@
                                                                </td>
                                                                <td align="left">
                                                                    <div class="sina_w_view_today_more">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <!-- today end -->
                                            <!-- tomorrow and day after tomorrow begin -->
                                            <div class="sina_w_view_others">
                                                <div class="sina_w_view_others_patch">
                                                    <!-- tomorrow begin -->
                                                    <div style="visibility: hidden" id="sina_w_view_tomorrow" class="sina_w_view_tomorrow">
                                                        <h3 style="text-align: left">
                                                            ���� @figure@</h3>
                                                        <div style="text-align: left">
                                                            @status@ @temperature@</div>
                                                        <div style="text-align: left">
                                                            ������@power@ <span><a title="�鿴��ϸ" href="http://php.weather.sina.com.cn/search.php?city=@city@&amp;f=1"
                                                                target="_blank"></a></span>
                                                        </div>
                                                    </div>
                                                    <!-- tomorrow end -->
                                                    <!-- day after tomorrow begin -->
                                                    <div style="visibility: hidden" id="sina_w_view_after_tomorrow" class="sina_w_view_after_tomorrow">
                                                        <h3 style="text-align: left">
                                                            ���� @figure@</h3>
                                                        <div style="text-align: left">
                                                            @status@ @temperature@</div>
                                                        <div style="text-align: left">
                                                            ������@power@ <span><a title="�鿴��ϸ" href="http://php.weather.sina.com.cn/search.php?city=@city@&amp;f=1"
                                                                target="_blank"></a></span>
                                                        </div>
                                                    </div>
                                                    <!-- day after tomorrow end -->
                                                </div>
                                            </div>
                                            <!-- tomorrow and day after tomorrow end -->
                                        </div>
                                        <!---��̬������ʾ����-->
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
    </div>
    <div style="display: none; margin-bottom:10px;" >
        <form method="get" name="sina_search_form" action="http://php.weather.sina.com.cn/search.php"
        target="_blank">
        <fieldset>
            <a title="����" href="http://weather.news.sina.com.cn/" target="_blank"></a>
            <input style="display: none" id="city_input" class="sina_w_city_input" title="�����������"
                value="�����������" type="text" name="city"><input value="1" type="hidden" name="f"><input
                    value="1" type="hidden" name="dpc"></fieldset>
        </form>
        <div id="wrap">
            <!-- search begin -->
            <!-- ������������ begin -->

            <script type="text/javascript">
		<!--                //--><![CDATA[//><!--

                var deafultTxt = '�����������'; //trim($('city_input').value);

                $_$('city_input').onfocus = function() {
                    if ($.trim(this.value) == deafultTxt) {
                        this.value = '';
                        this.style.color = '#000';
                    }
                }

                $_$('city_input').onblur = function() {
                    if ($.trim(this.value) == '') {
                        this.value = deafultTxt;
                        this.style.color = '#ccc';
                    }
                }
                if ($.trim($_$('city_input').value) == deafultTxt) {
                    $_$('city_input').style.color = '#ccc';
                } else {
                    $_$('city_input').style.color = '#000';
                }
                //--><!]]>
            </script>

            <!-- ������������ end -->
        </div>

        <script type="text/javascript"> 
<!--            //--><![CDATA[//><!--
            /**
            * ��̬��
            * ����cookie��¼��
            */
            var CityCookier = {
                init: function() {
                    this.cookieName = 'SINA_WEATHER_CUSTOMIZE_city';
                    this.cookier = new JSCookie();
                    this.expire_time = new Date();
                    this.expire_time.setFullYear(this.expire_time.getFullYear() + 1);
                    this.domain = 'php.weather.sina.com.cn';
                    this.path = '/';

                },
                setCityCookie: function(cityName) {
                    cityName = escape(cityName);
                    return this.cookier.setCookie(this.cookieName, cityName, this.expire_time, this.domain, this.path);
                },
                getCityCookie: function() {
                    return unescape(this.cookier.getCookie(this.cookieName));
                }
            };
            CityCookier.init();

            /**
            * ��̬��
            * ���ж�����
            */
            var Customer = {
                custom: function(city_name) {
                    if (city_name == '') {
                        alert('��ѡ�����');
                        return false;
                    }
                    //���ó���cookie
                    CityCookier.setCityCookie(city_name);
                    //���ظó�������
                    SWHandler.loadWeather(city_name);
                }
            };

            /**
            * ��̬��
            * ������Ϣ������
            */
            var SWHandler = {
                init: function() {
                    this.cityName = '����'; //Ĭ�ϳ���
                    this.defaultCity = '����'; //������Ƶĳ��������� ����ʾ�˳�������
                    var cookieCity = CityCookier.getCityCookie();
                    if (cookieCity) {
                        this.cityName = cookieCity;
                    }
                    this.io = "http://php.weather.sina.com.cn/js2.php?city=@city@" + "&_=@random@";
                    //get tpl
                    this.tpl = [];

                    //ҳ��� ��ʼ����������
                    this.loadWeather(this.cityName, true);
                },
                loadWeather: function(sCityName, bPageOpen) {
                    bPageOpen = !!bPageOpen;
                    var jsloader = new IO.Script();
                    var io = this.io;
                    var random = (new Date()).getTime();
                    io = io.replace(/@city@/g, sCityName);
                    io = io.replace(/@random@/g, random);
                    jsloader.load(io, function() {
                        if (typeof w == 'undefined') {	//δ�ҵ�ָ�����е�������Ϣ �л�����ʾ������
                            if (bPageOpen) {	//ҳ���ʼ��
                                Customer.custom(this.defaultCity);
                            } else {//��Ϊ����
                                alert('�Բ������޳��У�' + sCityName + ' ��������Ϣ');
                                return; //
                            }
                        } else {	//�ҵ���ָ�����е�������Ϣ
                            SWHandler.loadWeatherCallback(sCityName);
                        }

                    } .Bind(this));
                },
                loadWeatherCallback: function(sCityName) {
                    this.drawHtml('sina_w_view_today', 0, sCityName); //����
                    this.drawHtml('sina_w_view_title', 0, sCityName); //���� city
                    this.drawHtml('sina_w_view_tomorrow', 1, sCityName); //����
                    this.drawHtml('sina_w_view_after_tomorrow', 2, sCityName); //����
                    window['w'] = undefined;

                },
                drawHtml: function(elementId, day, sCityName) {
                    var elm = $_$(elementId);
                    //�Ƿ��Ѿ����tpl?
                    var tpl = '';
                    if (typeof this.tpl[elementId] == 'undefined') {
                        this.tpl[elementId] = tpl = elm.innerHTML;
                    } else {
                        tpl = this.tpl[elementId];
                    }
                    //����
                    /*
                    if(typeof w == 'undefined' || typeof w[day] == 'undefined'){
                    var w = [];
                    w[day] = [];
                    city = sCityName;
                    }
                    */
                    var __w = w[day];
                    var Y, m, d, week;
                    /*
                    var now = new Date();			
                    if(typeof year1 == 'undefined'){
                    Y = now.getFullYear();
                    }else{
                    Y = '20' + year1;
                    }
                    if(typeof month1 == 'undefined'){
                    m = now.getMonth()+1;
                    }else{
                    m = month1;
                    }
                    if(typeof day1 == 'undefined'){
                    d = now.getDate();
                    }else{
                    d = day1;
                    }
                    if(typeof week1 == 'undefined'){
                    var weeks = ['��','һ','��','��','��','��','��'];
                    week = '����' + weeks[now.getDay()];
                    }else{
                    week = week1;
                    }
                    */
                    Y = '20' + year1;
                    m = month1;
                    d = day1;
                    week = week1;

                    var figure1 = __w['figure1'] || '';
                    var figure2 = __w['figure2'] || '';
                    var status1 = __w['status1'] || '';
                    var status2 = __w['status2'] || '';
                    var temperature1 = __w['temperature1'] || '';
                    var temperature2 = __w['temperature2'] || '';
                    var power1 = __w['power1'] || '';
                    var power2 = __w['power2'] || '';
                    var chy_l = __w['chy_l'] || '��ȱ'; //����˵��
                    var pollution_l = __w['pollution_l'] || '��ȱ'; //��Ⱦ˵��
                    var fas_l = __w['fas_l'] || '��ȱ'; //��ɹ˵��
                    var xcz_l = __w['xcz_l'] || '��ȱ'; //ϴ��˵��
                    var ssd_l = __w['ssd_l'] || '��ȱ'; //���ʶ�˵��

                    tpl = tpl.replace(/@Y@/g, Y);
                    tpl = tpl.replace(/@m@/g, m);
                    tpl = tpl.replace(/@d@/g, d);
                    tpl = tpl.replace(/@week@/g, week);
                    //tpl = tpl.replace(/@title@/g,title);
                    tpl = tpl.replace(/@city@/g, city);
                    tpl = tpl.replace(/@city@/g, city);
                    //����ͼ��
                    var figure = WeatherProcesser.getSFigure(figure1, figure2, status1, status2);
                    tpl = tpl.replace(/@figure@/g, figure);
                    //��������
                    var status = WeatherProcesser.getStatus(status1, status2);
                    tpl = tpl.replace(/@status@/g, status);
                    //�¶�
                    var temperature = WeatherProcesser.getTemperature(temperature1, temperature2);
                    tpl = tpl.replace(/@temperature@/g, temperature);
                    //����
                    var power = WeatherProcesser.getPower(power1, power2);
                    tpl = tpl.replace(/@power@/g, power);
                    //ָ��
                    tpl = tpl.replace(/@chy_l@/g, chy_l);
                    tpl = tpl.replace(/@pollution_l@/g, pollution_l);
                    tpl = tpl.replace(/@fas_l@/g, fas_l);
                    tpl = tpl.replace(/@xcz_l@/g, xcz_l);
                    tpl = tpl.replace(/@ssd_l@/g, ssd_l);

                    elm.innerHTML = tpl;
                    elm.style.visibility = 'visible';
                }

            };
            SWHandler.init();

            /**
            * ��̬��
            * ��������������
            * ���¶�������form ��Ϊ ���ڱ�ҳ����ʾ�����ĳ���������Ϣ
            */
            var Searcher = {
                //init
                init: function(cityInputId, deafultTxt) {
                    this.io = "http://php.weather.sina.com.cn/js2.php?city=@city@" + "&_=" + (new Date()).getTime();
                    //this.eSearchBtn = $(searchBtnId);	//������ť
                    this.eCityInput = $_$(cityInputId); //����input
                    this.eForm = this.eCityInput.form; //form
                    this.deafultTxt = deafultTxt;

                    this.eForm.onsubmit = function() {
                        var cityName = this.filtCity(this.eCityInput.value);
                        if (this.validateCity(cityName)) {
                            Searcher.loadWeather(cityName);
                        }
                        //���� form ���ύ��ת
                        return false;
                    } .Bind(this);
                },
                //�����������Ŀ���������
                filtCity: function(cityName) {
                    cityName = $.trim(cityName);
                    cityName = $.rtrim(cityName, 'ֱϽ��');
                    cityName = $.rtrim(cityName, '�ؼ���');
                    cityName = $.rtrim(cityName, '��');
                    cityName = $.rtrim(cityName, '�ر�������');
                    cityName = $.rtrim(cityName, '������');
                    cityName = $.rtrim(cityName, '����');
                    cityName = $.rtrim(cityName, '��');

                    return cityName;
                },
                //��֤city input
                validateCity: function(cityName) {
                    cityName = $.trim(cityName);
                    if (cityName == this.deafultTxt || cityName == '') {
                        alert(deafultTxt);
                        return false;
                    }
                    if (!isChinese(cityName)) {//ȫ�Ǻ���?
                        alert('��������ȷ�ĳ�����');
                        this.eCityInput.focus();
                        return false;
                    }
                    return true;
                },
                //����������Ϣ
                loadWeather: function(sCityName) {
                    var jsloader = new IO.Script();
                    var io = this.io;
                    io = io.replace(/@city@/g, sCityName);
                    jsloader.load(io, function() {
                        if (typeof w == 'undefined') {//�ó����Ƿ���������Ϣ ���û�� ��ʾ������
                            //alert('����Ѿ�����һ������');
                            alert('�Բ���δ�ҵ����У�' + sCityName + ' ��������Ϣ����ȷ����������ȷ�ĳ�������');
                            //SWHandler.loadWeather('����');
                            //Customer.custom('����');
                            //agin = true;//����Ѿ�����һ������				
                            return false;
                        }
                        //display weather html
                        SWHandler.loadWeatherCallback(sCityName);
                        //set city cookie
                        CityCookier.setCityCookie(sCityName);
                    });
                }
            };
            Searcher.init('city_input', deafultTxt);

            //--><!]]>
        </script>

    </div>
</asp:Content>
