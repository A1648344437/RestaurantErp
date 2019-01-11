using AutoMapper;
using RestaurantErp.Dto;
using RestaurantErp.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.AutoMapper
{
    /// <summary>
    /// 配置构造函数，用来创建关系映射
    /// </summary>
    public class CustomProfile : Profile
    {
        ///// <summary>
        ///// 配置构造函数，用来创建关系映射
        ///// </summary>
        //public CustomProfile()
        //{
        //    //第一个参数是原对象，第二个是目的对象，所以，要想好，是哪个方向转哪个
        //    CreateMap<BlogArticle, BlogViewModels>();
        //}

        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            //第一个参数是原对象，第二个是目的对象，所以，要想好，是哪个方向转哪个
            CreateMap<AddOrderInfoDto, OrderInfo>()
                .ForMember(entity => entity.GoodsId, opt => opt.MapFrom(src => src.goodsId))
                .ForMember(entity => entity.GoodsName, opt => opt.MapFrom(src => src.goodsName))
                .ForMember(entity => entity.GoodsType, opt => opt.MapFrom(src => src.goodsType))
                .ForMember(entity => entity.Price, opt => opt.MapFrom(src => src.price))
                .ForMember(entity => entity.Count, opt => opt.MapFrom(src => src.count));//添加订单

        }
    }
}
