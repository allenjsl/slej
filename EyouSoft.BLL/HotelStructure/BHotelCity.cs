﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Toolkit;
namespace EyouSoft.BLL.HotelStructure
{
    public class BHotelCity
    {
        private readonly EyouSoft.IDAL.HotelStructure.IHotelCity dal = new EyouSoft.DAL.HotelStructure.DHotelCity();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MHotelCity model)
        {
            if (model != null && !string.IsNullOrEmpty(model.CityName))
                return dal.Add(model);
            return false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MHotelCity model)
        {
            if (model != null && model.ID > 0 && !string.IsNullOrEmpty(model.CityName))
                return dal.Update(model);
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(params int[] Ids)
        {
            if (Ids != null && Ids.Length > 0)
                return dal.Delete(Ids);
            return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public MHotelCity GetModel(int ID)
        {
            if (ID > 0)
                return dal.GetModel(ID);
            return null;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<MHotelCity> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            if (!Utils.ValidPaging(PageSize, PageIndex))
                return null;
            return dal.GetList(PageSize, PageIndex, ref RecordCount);
        }

        /// <summary>
        /// 获得前几行数据(top<=0取所有数据)
        /// </summary>
        public IList<MHotelCity> GetList(int Top)
        {
            return dal.GetList((Top < 0 ? 0 : Top));
        }
        /// <summary>
        /// 获得城市三字码
        /// </summary>
        public IList<MHotelCityAreas> GetCitySZMList(string ProviceName)
        {
            return dal.GetCitySZMList(ProviceName);
        }
        public IList<MHotelCityAreas> GetHoteCityList(string SZM)
        {
            return dal.GetHoteCityList(SZM);
        }
    }
}
