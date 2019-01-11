using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantErp.Common;
using RestaurantErp.Dto;
using RestaurantErp.Model;
using RestaurantErp.Model.Table;
using RestaurantErp.Service;

namespace RestaurantErp.Controllers
{
    /// <summary>
    /// 订单信息
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("LimitRequests")]//就是这里 允许跨域
    public class OrderController : ControllerBase
    {
        private readonly GoodsServer _goodsServer;
        private readonly IMapper _mapper;
        private readonly OrderServer _orderServer;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="goodsServer"></param>
        /// <param name="mapper"></param>
        /// <param name="orderServer"></param>
        public OrderController(GoodsServer goodsServer, IMapper mapper, OrderServer orderServer)
        {
            _goodsServer = goodsServer;
            _mapper = mapper;
            _orderServer = orderServer;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("OrderInfo")]
        public bool AddOrder([FromBody]AddOrderRequest orderRequest)
        {
            if (!string.IsNullOrWhiteSpace(orderRequest.GoodsList))
            {
                List<AddOrderInfoDto> list = SerializeHelper.Deserialize<List<AddOrderInfoDto>>(orderRequest.GoodsList);//序列化

                List<OrderInfo> orderInfos = _mapper.Map<List<OrderInfo>>(list);//AtuoMapper对象映射

                return _orderServer.AddOrder(
                    new Order {
                        OrderCount =orderRequest.TotalCount,
                        OrderPrice =orderRequest.TotalMoney,
                        IsMember =false,
                        OrderType=orderRequest.OrderType,
                        OrderState = orderRequest.OrderState,
                        AddTime=DateTime.Now,
                        describe=""
                    }, orderInfos);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取挂单跟外卖的列表信息
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="OrderState"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EntryOrderList")]
        public IList<EntryOrderListDto> GetEntryOrderLists(int OrderType, int OrderState)
        {
          return  _orderServer.GetEntryOrderLists(OrderType, OrderState);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _orderServer.DelOrderInfo(id);
        }

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckOut")]
        public bool CheckOut(int id)
        {
            return _orderServer.CheckOutOrder(id);
        }
    }
}
