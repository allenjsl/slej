﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;
using System.Text;

namespace EyouSoft.Web
{
    public partial class XianLu : Common.Page.WebPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        protected string toplist = string.Empty;//轮播广告
        protected string dianlist = string.Empty;//确认个数
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            PageInit();
            InitAd();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        private void PageInit()
        {

            var chufalist = new EyouSoft.BLL.XianLuStructure.BXianLu().getChuFaCitys();
            StringBuilder strChuFa = new StringBuilder();
            if (chufalist.Any())
            {
                foreach (var item in chufalist)
                {
                    strChuFa.AppendFormat(" <a class=\"city_a\" data-cityid=\"{0}\" href=\"javascript:;\">{1}</a>", item.Id, item.Name);
                }
            }
            ltrChuFas.Text = strChuFa.ToString();

            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
            searchmodel.Xianluzt = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            searchmodel.isNoTour = true;
            searchmodel.RouteName = Utils.GetQueryStringValue("keyword");
            searchmodel.SLDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("stime"));
            searchmodel.ELDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("etime"));
            searchmodel.TianShu = Utils.GetIntNull(Utils.GetQueryStringValue("days"));
            searchmodel.sPrice = Utils.GetDecimal(Utils.GetQueryStringValue("sprice"));
            searchmodel.ePrice = Utils.GetDecimal(Utils.GetQueryStringValue("eprice"));
            string source = Utils.GetQueryStringValue("source");
            if (!string.IsNullOrEmpty(source))
            {
                searchmodel.LineSource = (LineSource)Utils.GetInt(source);
            }
            string cityid = Utils.GetQueryStringValue("cityid");
            if (!string.IsNullOrEmpty(cityid))
            {
                searchmodel.DepCityIds = new int[] { Utils.GetInt(cityid) };
            }
            int areatype = Utils.GetInt(Utils.GetQueryStringValue("type"));
            int areaid = Utils.GetInt(Utils.GetQueryStringValue("area"));
            if (areatype == 3) ((EyouSoft.Web.MasterPage.Front)(base.Master)).HeadMenuIndex = 12;
            if (areatype == 1) ((EyouSoft.Web.MasterPage.Front)(base.Master)).HeadMenuIndex = 2;
            if (areatype == 2) ((EyouSoft.Web.MasterPage.Front)(base.Master)).HeadMenuIndex = 3;

            if (areaid > 0)
            {
                searchmodel.AreaIds = new int[] { areaid };
            }

            if (areatype > 0)
            {
                searchmodel.AreaTypes = new AreaType[] { (AreaType)areatype };
            }


            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);


            var arealist = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaList(10000, new EyouSoft.Model.MSysArea() { RouteType = (AreaType)areatype });
            System.Text.StringBuilder strbu = new System.Text.StringBuilder();
            if (arealist != null && arealist.Count > 0)
            {
                for (int i = 0; i < arealist.Count; i++)
                {
                    if (arealist[i].ID == areaid)
                    {
                        strbu.AppendFormat("<li><a href=\"/xianlu.aspx?area={0}&type={2}\" class=\"on\">{1}</a></li>", arealist[i].ID, arealist[i].AreaName, areatype);
                    }
                    else
                    {
                        strbu.AppendFormat("<li><a href=\"/xianlu.aspx?area={0}&type={2}\">{1}</a></li>", arealist[i].ID, arealist[i].AreaName, areatype);
                    }

                }
            }
            litFenlei.Text = strbu.ToString();

            IList<MXianLuInfo> list = bll.GetXianLus(pageSize, pageIndex, ref recordCount, searchmodel);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);

            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));

        }
        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            int areatype = Utils.GetInt(Utils.GetQueryStringValue("type"), 1);
            switch (areatype)
            {
                case 1://国内长线
                    areatype = 7;
                    break;
                case 2://国际长线
                    areatype = 8;
                    break;
                case 3://周边短线
                    areatype = 6;
                    break;

            }
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            var top = bll.GetList(5, (EyouSoft.Model.Enum.AdvArea)areatype);
            if (top != null && top.Count > 0)
            {
                for (int i = 0; i < top.Count; i++)
                {
                    if (i != top.Count - 1)
                    {
                        toplist += "<li style='position: absolute; left: " + (830 * i) + "px; display: block;'>"
                            + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                    }
                    else
                    {
                        toplist += "<li style='position: absolute; left: -830px; display: block;'>"
                            + "<a target='_blank' href='" + top[i].AdvLink + "'><img src='" + top[i].ImgPath + "'></a></li>";
                    }
                    dianlist += "<li><a href='#'>" + (i + 1) + "</a></li>";
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
            bkString += string.Format("</span><br/><a href=\"/XianLuYuDing.aspx?id={0}&type={1}\">更多团期</a> ", lastList[0].XianLuID, Utils.GetQueryStringValue("type"));
            return bkString;
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
                return firstModel.CRSCJ.ToString("F0");
            else
                return UtilsCommons.GetGYStijia(type, firstModel.JSJCR, firstModel.CRSCJ, MemberTypes.普通会员).ToString("F0");
        }


    }
}
