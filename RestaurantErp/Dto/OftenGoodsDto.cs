using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Dto
{
    /// <summary>
    /// 常用商品
    /// </summary>
    public class OftenGoodsDto
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int goodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int goodstype { get; set; }
    }
}
