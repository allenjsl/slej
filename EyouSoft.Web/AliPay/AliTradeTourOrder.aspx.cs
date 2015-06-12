/*using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using EyouSoft.Common;

namespace WEB.AliPay
{
    /// <summary>
    /// ֧����֧����ҳ��
    /// </summary>
    public partial class AliTradeTourOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tmpOrderId = Request.QueryString["OrderId"];  //��Ϊ�������ID,���Զ��ŷָ�            
            var orderType = (EyouSoft.Model.OrderType)Utils.GetInt(Utils.GetQueryStringValue("OrderType"));   //��������
            string Pay = "alipay";

            string[] arrstrOrderId = tmpOrderId.Split(',');

            decimal totalfee = 0.0m;
            string subject = "";  //����
            string body = ""; //����
            var orderList = new List<string>();

            string strErr;

            switch (orderType)
            {
                case EyouSoft.Model.OrderType.Tour://��·����
                    strErr = this.GetXianLuDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.Spot://��������
                    strErr = this.GetJingQuDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.Hotel://�Ƶ궩��
                    strErr = this.GetJiuDianDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.QianZheng://ǩ֤����
                    strErr = this.GetQianZhengDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                case EyouSoft.Model.OrderType.JiPiao:
                    strErr = GetJiPiaoDingDan(arrstrOrderId, ref subject, ref body, ref totalfee, orderList);
                    break;
                default:
                    strErr = "�������ʹ���";
                    break;
            }

            if (!string.IsNullOrEmpty(strErr))
            {
                Response.Write(strErr);
                Response.End();
            }
            if (totalfee <= 0)
            {
                Response.Write("֧�����������0����֧����");
                Response.End();
            }
            if (arrstrOrderId.Length > 1)  //��������1ʱ����ʡ�Ժ���ʾ
            {
                subject += "......";
                body += "......";
            }

            //��ʼ֧��
            string url = "";
            switch (Pay)
            {
                case "alipay":
                    url = this.InitAliPay(orderList, subject, body, totalfee, (int)orderType);
                    break;
            }
            if (!string.IsNullOrEmpty(url))
                Response.Redirect(url);
        }

        /// <summary>
        /// ����Ƶ궩��֧����Ϣ
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJiuDianDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "Ҫ֧���Ķ��������ڣ�";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(strId);

                if (info == null) continue;

                if (info.PaymentState != EyouSoft.Model.Enum.PaymentState.δ֧��) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "�Ƶ����ƣ�" + info.HotelName + " " + info.RoomName;
                    body = "�Ƶ����ƣ�" + info.HotelName + " " + info.RoomName + "���ܽ�" + info.TotalAmount + " Ԫ";
                }

                totalfee += info.TotalAmount;

                orderList.Add(strId);  //����ID
            }

            return string.Empty;
        }

        /// <summary>
        /// ���쾰������֧����Ϣ
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJingQuDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "Ҫ֧���Ķ��������ڣ�";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(strId);

                if (info == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.δ����) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "�������ƣ�" + info.ScenicName + " " + info.TypeName;
                    body = "�������ƣ�" + info.ScenicName + " " + info.TypeName + "���ܽ�" + info.Price + " Ԫ";
                }

                totalfee += info.Price;

                orderList.Add(strId);  //����ID
            }

            return string.Empty;
        }

        /// <summary>
        /// ������·����֧����Ϣ
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetXianLuDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "Ҫ֧���Ķ��������ڣ�";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                EyouSoft.Model.XianLuStructure.MOrderInfo info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(strId);

                if (info == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.δ����) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "��·���ƣ�" + info.XianLuName;
                    body = "��·���ƣ�" + info.XianLuName + "���ܽ�" + info.JinE + " Ԫ";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //����ID
            }

            return string.Empty;
        }

        /// <summary>
        /// ����ǩ֤����֧����Ϣ
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetQianZhengDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "Ҫ֧���Ķ��������ڣ�";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(strId);

                if (info == null) continue;

                var guoJiaInfo = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia().GetInfo(info.QianZhengGuoJiaId);
                if (guoJiaInfo == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.δ����) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "ǩ֤���ƣ�" + info.QianZhengName + "�����ң�" + guoJiaInfo.Name1 + "�������ţ�" + info.DingDanHao;
                    body = "ǩ֤���ƣ�" + info.QianZhengName + "�����ң�" + guoJiaInfo.Name1 + "�������ţ�" + info.DingDanHao + "���ܽ�" + info.JinE + " Ԫ";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //����ID
            }

            return string.Empty;
        }

        /// <summary>
        /// �����Ʊ����֧����Ϣ
        /// </summary>
        /// <param name="arrstrOrderId"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="totalfee"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        private string GetJiPiaoDingDan(string[] arrstrOrderId, ref string subject, ref string body, ref decimal totalfee
            , List<string> orderList)
        {
            if (arrstrOrderId == null || arrstrOrderId.Length <= 0) return "Ҫ֧���Ķ��������ڣ�";

            if (orderList == null) orderList = new List<string>();

            foreach (string strId in arrstrOrderId)
            {
                if (string.IsNullOrEmpty(strId)) continue;

                var info = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetInfo(strId);

                if (info == null) continue;

                var hangBanInfo = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetHangBanInfo(info.HangBanId);
                if (hangBanInfo == null) continue;
                var depcity = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoSanZiMa().GetSanZiMaInfo(hangBanInfo.DepAirportCode);
                var arrcity = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoSanZiMa().GetSanZiMaInfo(hangBanInfo.ArrAirportCode);
                if (depcity == null || arrcity == null) continue;

                if (info.FuKuanStatus != EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.δ����) continue;

                if (string.IsNullOrEmpty(subject))
                {
                    subject = "" + depcity.CityName + "��" + arrcity.CityName + "�������ţ�" + info.DingDanHao;
                    body = "" + depcity.CityName + "��" + arrcity.CityName + "�������ţ�" + info.DingDanHao + "���ܽ�" + info.JinE + " Ԫ";
                }

                totalfee += info.JinE;

                orderList.Add(strId);  //����ID
            }

            return string.Empty;
        }

        /// <summary>
        /// ��ʼ��֧����֧��url
        /// </summary>
        /// <param name="orderList">����idlist</param>
        /// <param name="Subject">����</param>
        /// <param name="Body">����</param>
        /// <param name="Totalfee">�ܽ��</param>
        /// <param name="OrderType">��������</param>
        /// <returns></returns>
        private string InitAliPay(List<string> orderList, string Subject, string Body, decimal Totalfee, int OrderType)
        {
            PayAPI.Model.Ali.AliPayTrade trade = new PayAPI.Model.Ali.AliPayTrade();
            trade.OrderInfo.OrderID = orderList;
            trade.OrderInfo.Subject = Subject;
            trade.OrderInfo.Body = Body;
            trade.Totalfee = Totalfee;
            trade.IsRoyalty = false;
            trade.RoyaltyType = PayAPI.Model.Ali.RoyaltyType.ƽ������;

            //PayAPI.Model.Ali.Royalty roy1 = new PayAPI.Model.Ali.Royalty();
            //roy1.Account = PayAPI.Ali.Core.AliPaySystem.Account;  //�����˺�
            //if ((decimal)PayAPI.Ali.Core.AliPaySystem.ServiceFeePercent == 0)
            //    roy1.Price = trade.Totalfee * 0.005m;
            //else
            //    roy1.Price = trade.Totalfee * (decimal)PayAPI.Ali.Core.AliPaySystem.ServiceFeePercent;
            //roy1.Remark = "��ȡ��������";
            //trade.RoyaltyList.Add(roy1);
            trade.SellerAccount = new EyouSoft.BLL.OtherStructure.BOnLinePay().GetAlipayAccount();   //�����˺�           
            trade.ShowUrl = "";  //չʾҳ��
            PayAPI.Model.Attach attach = new PayAPI.Model.Attach();
            attach.Key = "OrderType";
            attach.Value = OrderType.ToString();
            trade.AttachList.Add(attach);
            //����url
            return PayAPI.Ali.Alipay.Create.Create_url(trade);
        }
    }
}
*/