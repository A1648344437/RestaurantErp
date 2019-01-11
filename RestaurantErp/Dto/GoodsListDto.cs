using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Dto
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class GoodsListDto
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
        /// 商品图片
        /// </summary>
        public string goodsImg { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int goodstype { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal price { get; set; }
    }
}
