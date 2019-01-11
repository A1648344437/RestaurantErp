using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Model
{
    /// <summary>
    /// 添加订单，请求参数
    /// </summary>
    public class AddOrderRequest
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public string GoodsList { get; set; }
        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 订单类型（1堂食 2外卖）
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 订单状态（1挂单 2已支付）
        /// </summary>
        public int OrderState { get; set; }
    }
}
