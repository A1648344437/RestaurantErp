using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Model.Table
{
    /// <summary>
    /// Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public Order()
        { }
        #region Model
        private int _orderid;
        private decimal _orderprice;
        private bool _ismember = false;
        private int _ordertype = 1;
        private int _orderstate = 0;
        private DateTime _addtime;
        private string _describe;
        private int _ordercount;
        /// <summary>
        /// 主键Id，自增长
        /// </summary>
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 商品总量
        /// </summary>
        public int OrderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice
        {
            set { _orderprice = value; }
            get { return _orderprice; }
        }
        /// <summary>
        /// 是否是会员
        /// </summary>
        public bool IsMember
        {
            set { _ismember = value; }
            get { return _ismember; }
        }
        /// <summary>
        /// 订单类型（1堂食 2外卖）
        /// </summary>
        public int OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 订单状态（1挂单 2已支付）
        /// </summary>
        public int OrderState
        {
            set { _orderstate = value; }
            get { return _orderstate; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 订单描述描述
        /// </summary>
        public string describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        #endregion Model

    }
}
