﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web
{
    public partial class QianZheng : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 4;
            }
        }
    }
}
