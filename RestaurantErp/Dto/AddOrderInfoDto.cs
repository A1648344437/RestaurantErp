using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Dto
{
    /// <summary>
    /// 添加订单信息dto
    /// </summary>
    public class AddOrderInfoDto
    {
        /// <summary>
        /// 商品量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int goodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int goodsType { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal price { get; set; }
    }
}
