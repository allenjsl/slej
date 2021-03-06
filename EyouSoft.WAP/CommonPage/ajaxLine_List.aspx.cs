﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxLine_List : System.Web.UI.Page
    {
        protected int pageindex = 1, pagesize = 8, recordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string isGet = Utils.GetQueryStringValue("isGet");
            pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            if (isGet == "1")
            {
                initList();
            }

        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        protected void initList()
        {

            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
            searchmodel.Xianluzt = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            searchmodel.isNoTour = true;
            string routeName = Utils.GetQueryStringValue("keyword");
            searchmodel.RouteName = routeName == "目的地或关键词" ? "" : routeName;
            searchmodel.TianShu = Utils.GetIntNull(Utils.GetQueryStringValue("days"));
            searchmodel.sPrice = Utils.GetDecimal(Utils.GetQueryStringValue("spri"));
            searchmodel.ePrice = Utils.GetDecimal(Utils.GetQueryStringValue("epri"));
            int areatype = Utils.GetInt(Utils.GetQueryStringValue("type"));
            int areaid = Utils.GetInt(Utils.GetQueryStringValue("area"));
            string source = Utils.GetQueryStringValue("source");
            if (!string.IsNullOrEmpty(source))
            {
                searchmodel.LineSource = (LineSource)Utils.GetInt(source);
            }
            int cityid = Utils.GetInt(Utils.GetQueryStringValue("cityid"));
            if (cityid > 0)
            {
                searchmodel.DepCityIds = new int[] { cityid };
            }
            else
            {
                var citymodel = EyouSoft.Security.Membership.UserProvider.GetCityInfo();
                if (citymodel != null && citymodel.Id > 0)
                {

                    searchmodel.DepCityIds = new int[] { citymodel.Id };
                }
            }
            if (areaid > 0)
            {
                searchmodel.AreaIds = new int[] { areaid };
            }

            if (areatype > 0)
            {
                searchmodel.AreaTypes = new AreaType[] { (AreaType)areatype };
            }
            IList<MXianLuInfo> list = bll.GetXianLus(pagesize, pageindex, ref recordCount, searchmodel);

            int isPage = 0;
            if (recordCount % pagesize != 0)
            {
                isPage = recordCount / pagesize + 1;
            }
            else
            {
                isPage = recordCount / pagesize;
            }
            if (list != null && list.Count > 0)
            {

                if (isPage >= pageindex)
                {
                    rptlist.DataSource = list;
                    rptlist.DataBind();
                }

            }
        }

        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getCityName(object obj)
        {
            int cid = Utils.GetInt(obj.ToString());
            if (cid == 0) return "待定";
            var model = new EyouSoft.BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cid);
            if (model == null) return "待定";
            return model.Name;
        }
        /// <summary>
        /// 获取最近发班日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string getLastDate(object obj)
        {
            List<MXianLuTourInfo> items = (List<MXianLuTourInfo>)obj;

            if (items == null) return "暂无发班信息";
            var lastList = items.OrderBy(j => j.LDate).Where(i => Utils.GetDateTime(i.LDate.ToString("yyyy-MM-dd")) > DateTime.Now).ToList();

            if (lastList == null || lastList.Count == 0) return "暂无发班信息";
            int top = 0;
            System.Text.StringBuilder BackHtml = new System.Text.StringBuilder();
            BackHtml.Append("<span class=\"font_yellow\">");
            for (int i = 0; i < lastList.Count; i++)
            {
                if (i != 0 && (lastList[i].LDate == lastList[0].LDate || lastList[i].LDate == lastList[i - 1].LDate)) continue;
                top++;
                BackHtml.AppendFormat("{0},", lastList[i].LDate.ToString("MM-dd"));
                if (top == 3) break;

            }
            string bkString = BackHtml.ToString().TrimEnd(',').Replace("-", "/").Replace(",", "、");
            //bkString += string.Format("</span><br/><a href=\"/Line_Info.aspx?id={0}&type={1}\">更多团期</a> ", lastList[0].XianLuID, Utils.GetQueryStringValue("type"));
            return bkString;
        }
        /// <summary>
        /// 获取会员等级价格
        /// </summary>
        /// <returns></returns>
        protected string getHYJ(string pType, string t, object tours)
        {
            List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo> list = (List<EyouSoft.Model.XianLuStructure.MXianLuTourInfo>)tours;

            if (list == null || list.Count == 0)
            {
                return "待定";
            }
            var firstModel = list.OrderBy(m => m.JSJCR).First();
            EyouSoft.Model.Enum.FeeTypes type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "3") type = EyouSoft.Model.Enum.FeeTypes.周边线路;
            if (t == "1") type = EyouSoft.Model.Enum.FeeTypes.国内线路;
            if (t == "2") type = EyouSoft.Model.Enum.FeeTypes.国际线路;
            if (pType == "门市")
                return firstModel.CRSCJ.ToString("C0");
            else
                return UtilsCommons.GetGYStijia(type, firstModel.JSJCR, firstModel.CRSCJ, MemberTypes.普通会员).ToString("C0");
        }
        /// <summary>
        /// 返回景区图片
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr, object PID)
        {
            string defaultImg = "/images/line-img001.jpg";
            if (objStr == null) return defaultImg;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return defaultImg;
            return TuPian.F1(src, 320, 240, PID.ToString());
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="lineType"></param>
        /// <returns></returns>
        protected string getSourceJP(object lineType)
        {
            LineSource source = (LineSource)lineType;
            if (source == LineSource.系统) return "JA";
            if (source == LineSource.博客) return "BK";
            if (source == LineSource.光大) return "GD";
            if (source == LineSource.欢途) return "HT";
            if (source == LineSource.省中旅) return "SZL";
            if (source == LineSource.旅游圈) return "LYQ";
            return "JA";
        }
    }
}
