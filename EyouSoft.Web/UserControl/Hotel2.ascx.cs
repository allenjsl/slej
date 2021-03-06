﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.HotelStructure;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Security.Membership;
using EyouSoft.Model.SSOStructure;
using EyouSoft.Common.Page;
using Linq.Bussiness;

namespace EyouSoft.Web.UserControl
{
    public partial class Hotel2 : System.Web.UI.UserControl
    {
        BHotel bll = new BHotel();
        BHotel2 bll2 = new BHotel2();
        protected MUserInfo CurrentUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MUserInfo curUser;
            if (!UserProvider.IsLogin(out curUser))
            {
                curUser = HuiYuanPageBase.GuestUser;
            }
            CurrentUser = curUser;
            //Repeater1.DataSource = bll.GetHotelList(4);
            //Repeater1.DataBind();

            Repeater1.DataSource = bll2.GetHotelList(new MHotelSearchModel1
            {
                CityCode = "HGH",
                MustHasImg = false,
                SearchInfo = new SearchModel { PageInfo = new PageInfo { PageSize = 4, PageIndex = 1 } },
                IsHot = "1",
                IsRecommend = "1",
                RuZhuRiQi = DateTime.Now.Date,
                LiDianRiQi = DateTime.Now.Date.AddDays(1),
            }, true, CurrentUser.UserType, false);
            Repeater1.DataBind();
        }
    }
}