using RestaurantErp.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Model
{
    /// <summary>
    /// 商品列表信息
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public IList<Goods> GoodsInfo { get; set; }
        /// <summary>
        /// 总的行数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 分页条数
        /// </summary>
        public int PageSize { get; set; }

    }
}
