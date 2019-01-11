using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Model.Table
{
    /// <summary>
    /// Goods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 
        /// </summary>
        public Goods()
        { }
        #region Model
        private int _goodsid;
        private string _goodsname;
        private decimal _goodsprice;
        private string _goodsimg;
        private int _goodstype = 0;
        private bool _ishot = false;
        private DateTime _addtime;
        private string _describe;
        /// <summary>
        /// 主键Id，自增长
        /// </summary>
        public int GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
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
        /// 商品价格
        /// </summary>
        public decimal GoodsPrice
        {
            set { _goodsprice = value; }
            get { return _goodsprice; }
        }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsImg
        {
            set { _goodsimg = value; }
            get { return _goodsimg; }
        }
        /// <summary>
        /// 商品类型（1汉堡 2小吃 3饮料 4套餐）
        /// </summary>
        public int GoodsType
        {
            set { _goodstype = value; }
            get { return _goodstype; }
        }
        /// <summary>
        /// 是否是常用商品
        /// </summary>
        public bool IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
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
        /// 商品描述
        /// </summary>
        public string describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        #endregion Model

    }
}
