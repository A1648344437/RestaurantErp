using Dapper;
using RestaurantErp.Dto;
using RestaurantErp.Model.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Service
{
    /// <summary>
    /// 订单相关数据操作
    /// </summary>
    public class OrderServer:DataBase
    {
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderInfos"></param>
        /// <returns></returns>
        public bool AddOrder(Order order,IList<OrderInfo> orderInfos)
        {
            string orderSql = @"INSERT INTO [dbo].[Order](OrderPrice,IsMember,OrderType,OrderState,AddTime,describe,OrderCount) VALUES(@OrderPrice,@IsMember,@OrderType,@OrderState,@AddTime,@describe,@OrderCount);SELECT @id=SCOPE_IDENTITY()";
            string orderInfoSql = @"INSERT INTO [dbo].[OrderInfo](OrderId,GoodsId,Count,GoodsName,GoodsType,Price) VALUES(@OrderId,@GoodsId,@Count,@GoodsName,@GoodsType,@Price)";

            int result = 0;
            IDbConnection iDbcon = GetConnection();
            if (iDbcon.State == ConnectionState.Closed)
            {
                iDbcon.Open();
            }

            using(var trans = iDbcon.BeginTransaction())
            {
                try
                {
                    var p = new DynamicParameters();
                    p.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("@OrderPrice", order.OrderPrice);
                    p.Add("@IsMember", order.IsMember);
                    p.Add("@OrderType", order.OrderType);
                    p.Add("@OrderState", order.OrderState);
                    p.Add("@AddTime", order.AddTime);
                    p.Add("@describe", order.describe);
                    p.Add("@OrderCount", order.OrderCount);
                    int orderResult = iDbcon.Execute(orderSql, p, trans);
                    var orderId = p.Get<int>("@ID");//返回主键Id 自增长
                    if (orderResult > 0)
                    {
                        foreach (var item in orderInfos)
                        {
                            item.OrderId = orderId;
                        }

                        result++;
                    }

                    if (iDbcon.Execute(orderInfoSql, orderInfos, trans) > 0) result++;

                    if (result == 2)
                    {
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }

        }

        /// <summary>
        /// 根据订单类型，跟订单状态获取挂单，外卖信息
        /// </summary>
        /// <param name="OrderType">订单类型（1堂食 2外卖）</param>
        /// <param name="OrderState">订单状态（1挂单 2已支付）</param>
        /// <returns></returns>
        public IList<EntryOrderListDto> GetEntryOrderLists(int OrderType,int OrderState)
        {
            string sql = @"SELECT O.OrderId,
	                           O.OrderPrice,
	                           O.OrderType,
	                           O.OrderState,
	                           O.AddTime,
	                           O.OrderCount,
	                           OI.OId,
	                           OI.OrderId AS OrdId,
	                           OI.GoodsId,
	                           OI.Count,
	                           OI.Price,
	                           OI.GoodsName,
	                           OI.GoodsType
                         FROM [dbo].[Order] O LEFT JOIN [dbo].[OrderInfo] OI ON O.OrderId=OI.OrderId 
                         WHERE O.OrderType=@OrderType AND O.OrderState=@OrderState ORDER BY O.AddTime DESC";
            using(var iDbcon = GetConnection())
            {
                try
                {
                    return iDbcon.Query<EntryOrderListDto>(sql, new { OrderType = OrderType, OrderState = OrderState }).ToList();
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 删除订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool DelOrderInfo(int orderId)
        {
            string sql = @"DELETE [dbo].[Order] WHERE OrderId=@OrderId;DELETE [dbo].[OrderInfo] WHERE  OrderId=@OrderId";
            using (var iDbcon = GetConnection())
            {
                try
                {
                    return iDbcon.Execute(sql, new { orderId = orderId }) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool CheckOutOrder(int orderId)
        {
            string sql = @"UPDATE [dbo].[Order] SET OrderState=2 WHERE OrderId=@OrderId";
            using (var iDbcon = GetConnection())
            {
                try
                {
                    return iDbcon.Execute(sql, new { orderId = orderId }) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
