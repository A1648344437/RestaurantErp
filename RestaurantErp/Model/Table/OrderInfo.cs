using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Model.Table
{
    /// <summary>
    /// OrderInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderInfo()
        { }
        #region Model
        private int _oid;
        private int _orderid;
        private int _goodsid;
        private int _count;
        private decimal _price;
        private string _goodsname;
        private int _goodstype;
        /// <summary>
        /// 主键Id，自增长
        /// </summary>
        public int OId
        {
            set { _oid = value; }
            get { return _oid; }
        }
        /// <summary>
        /// 订单表外键Id
        /// </summary>
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int GoodsType
        {
            set { _goodstype = value; }
            get { return _goodstype; }
        }
        #endregion Model

    }
}
