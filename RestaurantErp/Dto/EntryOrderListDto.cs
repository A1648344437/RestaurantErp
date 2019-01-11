using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Dto
{
    /// <summary>
    /// 挂单 外卖
    /// </summary>
    public class EntryOrderListDto
    {
        /// <summary>
        /// 主订单Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 订单商品总量
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 订单附表Id
        /// </summary>
        public int OId { get; set; }
        /// <summary>
        /// 订单表外键
        /// </summary>
        public int OrdId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int GoodsType { get; set; }
    }
}
