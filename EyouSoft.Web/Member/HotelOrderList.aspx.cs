﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;

namespace EyouSoft.Web.Member
{
    public partial class HotelOrderList : ClientModelViewPageBase<EyouSoft.Model.HotelStructure.MHotelOrderSeach>
    {
        EyouSoft.BLL.HotelStructure.BHotelOrder bll = new EyouSoft.BLL.HotelStructure.BHotelOrder();
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        public int isAgency = 0;//判断是否为分销商、免费分销商、员工，1为true
        protected decimal SumMoney = 0;//销售金额
        protected decimal SumAMoney = 0;//分销金额
        protected decimal SumLiRun = 0;
        protected override int PageSize
        {
            get
            {
                return 20;
            }
        }
        public int PageIndex=1;
        public int refcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            mseller = bsells.Get(HuiYuanInfo.UserId);
            if (mseller != null)
            {
                Model.SellerID = mseller.ID;
                isAgency = 1;
            }
            else
            {
                Model.SellerID = "";
            }
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();
            GetOrderList(Model.SellerID);
        }
        public void GetOrderList(string AgencyId)
        {
            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                PageIndex = Convert.ToInt32(Common.Utils.GetQueryStringValue("page"));
            }

            if (HotelName.Value.Trim() != "")
            {
                Model.HotelName = HotelName.Value.Trim();
            }
            if (!string.IsNullOrEmpty(starttime.Value.Trim()) && !string.IsNullOrEmpty(endtime.Value.Trim()))
            {
                if (Convert.ToDateTime(starttime.Value.Trim()) <= Convert.ToDateTime(endtime.Value.Trim()))
                {
                    Model.BeginIssueTime = Convert.ToDateTime(starttime.Value.Trim());
                    Model.EndIssueTime = Convert.ToDateTime(endtime.Value.Trim()).AddDays(1);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(starttime.Value.Trim()))
                {
                    if (Convert.ToDateTime(starttime.Value.Trim()) < DateTime.Now)
                    {
                        Model.BeginIssueTime = Convert.ToDateTime(starttime.Value.Trim());
                        Model.EndIssueTime = DateTime.Now;
                    }
                }
                if (!string.IsNullOrEmpty(endtime.Value.Trim()))
                {
                    if (Convert.ToDateTime(endtime.Value.Trim()) > DateTime.Now)
                    {
                        Model.BeginIssueTime = DateTime.Now;
                        Model.EndIssueTime = Convert.ToDateTime(endtime.Value.Trim());
                    }
                }
            }

            if (AgencyId != "")
            {
                Model.SellerID = AgencyId;
            }
            
            Model.OperatorId = HuiYuanInfo.UserId;
            var list = bll.GetList(10, PageIndex, ref refcount, Model);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SumAMoney += list[i].AgencyJinE;
                    SumLiRun += list[i].TotalAmount - list[i].AgencyJinE;
                    SumMoney += list[i].TotalAmount;
                }
                Repeater1.DataSource = list;
                Repeater1.DataBind();
                XianShi.Text = null;
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                XianShi.Text = "暂无酒店订单记录!";
            }
        }
        ///// <summary>
        ///// 获取支付链接
        ///// </summary>
        ///// <param name="orderid"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //protected string getZhiFuURL(string orderid, object state)
        //{
        //    EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
        //    switch (type)
        //    {
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
        //            return string.Format("  <span>等待审核</span>");
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
        //            //return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >付款</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货);
        //            return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >付款</a>", orderid, (int)EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, HuiYuanInfo.UserId);
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
        //            return string.Format("<span>等待发货</span>");
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
        //            return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >确认收货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
        //        case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
        //            return string.Format("<span>交易完成</span>");
        //        default:
        //            break;
        //    }
        //    return "";
        //    //if (type != EyouSoft.Model.Enum.OrderState.待付款) return "";
        //    //return string.Format("<a target=\"_blank\" href=\"/Member/OrderPay.aspx?orderid={0}&type={1}&send=send\">支付</a>", orderid, (int)type);
        //}
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId)
        {
            if (string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("  <span style='background-color:#00F;color:#FFF;'>等待审核</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  ><span style='background-color:#906;color:#FFF;'>马上付款</span></a>", orderid, (int)EyouSoft.Model.Enum.DingDanLeiBie.酒店订单, HuiYuanInfo.UserId);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == 1 && Model.SellerID == AgencyId.ToString())
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span style='background-color:#060;color:#FFF;'>订单出货</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                    }
                    else
                    {
                        return string.Format("<span  style='background-color:#060;color:#FFF;'>继续采购</span>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    if (isAgency == 1 && Model.SellerID == AgencyId.ToString())
                    {
                        return string.Format("  <span  style='background-color:#23F111;color:#FFF;'>确认出行</span>");
                    }
                    else
                    {
                        return string.Format("  <a href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  ><span style='background-color:#23F111;color:#FFF;'>确认出行</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format("<a href='/Default.aspx'><span style='background-color:#F00;color:#FFF;'>继续采购</span></a>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("<a href='/Default.aspx'><span style='background-color:#F00;color:#FFF;'>继续采购</span></a>");
                default:
                    break;
            }
            return "";
            //if (type != EyouSoft.Model.Enum.OrderState.待付款) return "";
            //return string.Format("<a target=\"_blank\" href=\"/Member/OrderPay.aspx?orderid={0}&type={1}&send=send\">支付</a>", orderid, (int)type);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="setState"></param>
        /// <returns></returns>
        protected string DeleteUserOrder(string orderid, object setState)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)setState;
            switch (state)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:pageData.setOrder('{0}','{1}');\";  ><span style='background-color:#C00;color:#FFF;'>取消订单</span></a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单);
                default:
                    break;
            }
            return "";
        }
        /// <summary>
        /// 转换订单状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getHuiYuanState(object state)
        {
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return "<span style='color:rgb(0, 0, 255)'>提交成功<br />请等待平台审核</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return "<span style='color:rgb(0, 128, 0)'>审核成功!<br />请在1小时内完成付款</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    return "<span style='color:rgb(0, 128, 0)'>支付成功<br />等待平台出票</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    return "<span style='color:rgb(0, 128, 0)'>出票成功<br />请按短信要求取票</span>";
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                    if (isAgency == 1)
                    {
                        return "<span style='color:rgb(0, 128, 0)'>请待出团后分成<br />合作愉快</span>";
                    }
                    else
                    {
                        return "<span style='color:rgb(0, 128, 0)'>交易完成<br />合作愉快</span>";
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    if (isAgency == 1)
                    {
                        return "<span style='color:rgb(0, 128, 0)'>已提分成<br />合作愉快</span>";
                    }
                    else
                    {
                        return "<span style='color:rgb(0, 128, 0)'>交易完成<br />合作愉快</span>";
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return "<span  style='color:rgb(255, 0, 0)'>取消成功<br />订单已经失效</span>";
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// 设置订单状态
        /// </summary>
        void setOrderState()
        {
            string orderid = Utils.GetQueryStringValue("id");
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetQueryStringValue("state"));

            BHotel bll = new BHotel();
            int result = bll.SheZhiOrderStatus(orderid, state);
            if (result == 1 && state == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成)
            {
                //返利
            }
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));
        }
        /// <summary>
        /// 获取付款方式
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <param name="orderstate">订单状态</param>
        /// <returns></returns>
        protected string GetFuKuangCate(object orderid, object orderstate)
        {
            string FuKuangCate = "<span style=\"color:red;\">暂未付款</span>";
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus state = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)orderstate;
            switch (state)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    FuKuangCate = "<span style=\"color:red;\">暂未付款</span>";
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    FuKuangCate = "<span style=\"color:#00F;\">" + new EyouSoft.BLL.MemberStructure.BMember().GetZhiFuWay(orderid.ToString()) + "</span>";
                    break;
                default:
                    break;
            }

            return FuKuangCate;
        }
    }
}
