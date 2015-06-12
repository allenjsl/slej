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
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net;
using Adpost.Common;

namespace WEB.AliPay
{
    /// <summary>
    /// ֧�������غ�Ľ���������
    /// </summary>
    public partial class Alipay_Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PayAPI.Model.Ali.AliPayTradeNotify notify = PayAPI.Ali.Alipay.Create.GetNotifyAsync();//֧�����ķ���֪ͨʵ��
            if (notify.IsTradeSuccess)
            {
                var model = new EyouSoft.Model.OnLinePayRecord();//����֧��ʵ��
                var onlinepay = new EyouSoft.BLL.OtherStructure.BOnLinePay();//����֧��BLL
                foreach (var item in notify.OrderInfo.OrderID)
                {
                    model.OrderId = item;//����ID
                    model.OrderType = (EyouSoft.Model.OrderType)Convert.ToInt32(notify.AttachList["OrderType"].Value);//��������
                    bool ispay = onlinepay.IsPaySuccess(model.OrderId, model.OrderType);//��ȡ����֧��״̬���ɹ�/ʧ�ܣ�
                    if (ispay == false)
                    {
                        model.OutTradeNo = notify.OutTradeNo;//��ˮ��
                        model.TradeNo = notify.TradeNo;//֧����ˮ��
                        model.Totalfee = notify.Totalfee;//֧�����
                        model.PayType = EyouSoft.Model.PayType.Alipay;//֧����ʽ
                        model.IsPay = true;//�Ƿ���֧��
                        model.SuccessTime = DateTime.Now;//֧��ʱ��
                        bool isAdd = onlinepay.Add(model);//���֧����¼
                        if (isAdd)
                        {
                            //ʵ�������������� 
                            switch (model.OrderType)
                            {
                                case EyouSoft.Model.OrderType.Tour:
                                    this.HandleXianluDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.Spot:
                                    this.HandleJingDianDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.Hotel:
                                    this.HandleJiuDianDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.QianZheng:
                                    this.HandleQianZhengDingDan(model.OrderId);
                                    break;
                                case EyouSoft.Model.OrderType.JiPiao:
                                    this.HandleJiPiaoDingDan(model.OrderId);
                                    break;
                            }
                        }
                    }
                }
                onlinepay = null; model = null;
            }
            //֧���ӿڻص�֪ͨ
            Response.Write(notify.PayAPICallBackMsg);
            Response.End();
        }

        /// <summary>
        /// ����Ƶ궩����Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleJiuDianDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            var info = new EyouSoft.BLL.HotelStructure.BHotelOrder().GetModel(orderId);

            if (info == null) return;

            new EyouSoft.BLL.HotelStructure.BHotelOrder().UpdatePaymentState(
                EyouSoft.Model.Enum.PaymentState.��֧��, orderId);

            SaveTotal(info.TotalAmount, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.�Ƶ�);
        }

        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleJingDianDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            var info = new EyouSoft.BLL.ScenicStructure.BScenicArea().GetScenicAreaOrderModel(orderId);

            if (info == null) return;

            new EyouSoft.BLL.ScenicStructure.BScenicArea().SheZhiFuKuanStatus(
                orderId, info.OperatorId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.�Ѹ���);

            SaveTotal(info.Price, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.��Ʊ);
        }

        /// <summary>
        /// ������·������Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        private void HandleXianluDingDan(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;

            EyouSoft.Model.XianLuStructure.MOrderInfo info = new EyouSoft.BLL.XianLuStructure.BOrder().GetInfo(orderId);
            if (info != null)
            {
                var history = new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo
                    {
                        BeiZhu = string.Empty,
                        LeiXing = EyouSoft.Model.Enum.XianLuStructure.OrderHistoryLeiXing.���ø���״̬,
                        OperatorLeiXing = EyouSoft.Model.Enum.OperatorLeiXing.��Ա,
                        OrderId = orderId,
                        Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.������
                    };

                int result=new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiFuKuanStatus(orderId, info.OperatorId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.�Ѹ���, history);

                if (result == 1)
                {
                    new EyouSoft.BLL.XianLuStructure.BOrder().SheZhiOrderStatus(orderId,  EyouSoft.Model.Enum.XianLuStructure.OrderStatus.��������, history);
                }

                SaveTotal(info.JinE, info.OperatorId, info.OrderId, EyouSoft.Model.Enum.OrderClass.��·);
            }
        }

        /// <summary>
        /// ����ǩ֤����
        /// </summary>
        /// <param name="dingDanId">�������</param>
        void HandleQianZhengDingDan(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return;
            var info = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().GetInfo(dingDanId);
            if (info == null) return;

            new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiFuKuanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.�Ѹ���);
            new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan().SheZhiDingDanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.��������);

            SaveTotal(info.JinE, info.XiaDanRenId, info.DingDanId, EyouSoft.Model.Enum.OrderClass.ǩ֤);
        }

        /// <summary>
        /// �����Ʊ����
        /// </summary>
        /// <param name="dingDanId">�������</param>
        void HandleJiPiaoDingDan(string dingDanId)
        {
            if (string.IsNullOrEmpty(dingDanId)) return;
            var info = new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().GetInfo(dingDanId);
            if (info == null) return;

            new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().SheZhiFuKuanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.�Ѹ���);
            new EyouSoft.BLL.JiPiaoStructure.BJiPiaoDingDan().SheZhiDingDanStatus(dingDanId, info.XiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.��������);

            SaveTotal(info.JinE, info.XiaDanRenId, info.DingDanId, EyouSoft.Model.Enum.OrderClass.��Ʊ);
        }

        /// <summary>
        /// ������ȡ����
        /// </summary>
        bool SaveTotal(decimal money, string OperatorId, string OrderId, EyouSoft.Model.Enum.OrderClass orderClass)
        {
            if (!(new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(OrderId, OperatorId)))
            {
                var model = new EyouSoft.BLL.OtherStructure.BKV().GetCompanySetting();
                int tatol = 0;
                if (model == null)
                    tatol = Convert.ToInt32(Math.Round(money));
                else
                {
                    int jf = 0;

                    if (orderClass == EyouSoft.Model.Enum.OrderClass.�Ƶ�)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.HotelTatol.Trim());
                    if (orderClass == EyouSoft.Model.Enum.OrderClass.��Ʊ)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.ScenicTatol.Trim());
                    if (orderClass == EyouSoft.Model.Enum.OrderClass.��·)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.RouteTatol.Trim());
                    if(orderClass== EyouSoft.Model.Enum.OrderClass.ǩ֤)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.QianZhengDingDanJiFenPeiZhi.Trim());
                    if(orderClass== EyouSoft.Model.Enum.OrderClass.��Ʊ)
                        jf = EyouSoft.Toolkit.Utils.GetInt(model.JiPiaoDingDanJiFenPeiZhi.Trim());

                    tatol = Convert.ToInt32(Math.Round(money / (jf == 0 ? 1 : jf)));
                }
                if (tatol > 0)
                {
                    EyouSoft.Model.OtherStructure.MMemberTotal addTotal = new EyouSoft.Model.OtherStructure.MMemberTotal();
                    addTotal.MemberID = OperatorId;
                    addTotal.OrderId = OrderId;
                    addTotal.OrderType = orderClass;
                    addTotal.Total = tatol;
                    return new EyouSoft.BLL.OtherStructure.BTatolProduct().AddMemberTotal(addTotal);
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
*/