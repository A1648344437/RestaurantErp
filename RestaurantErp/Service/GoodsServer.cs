using RestaurantErp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RestaurantErp.Model;
using RestaurantErp.Model.Table;

namespace RestaurantErp.Service
{
    /// <summary>
    /// 商品数据操作
    /// </summary>
    public class GoodsServer : DataBase
    {
        /// <summary>
        /// 根据Id获取商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Goods GetGoodsById(int Id)
        {
            using (var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.QueryFirstOrDefault<Goods>("SELECT * FROM [dbo].[Goods] WHERE GoodsId=@GoodsId", new { GoodsId = Id });
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取商品列表信息
        /// </summary>
        /// <returns></returns>
        public IList<GoodsListDto> GetGoodsList()
        {
            using (var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.Query<GoodsListDto>("SELECT GoodsId AS goodsId,GoodsImg AS goodsImg,GoodsName AS goodsName,GoodsPrice AS price,GoodsType AS goodstype FROM [dbo].[Goods]").ToList();
                }
                catch
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// 获取所有商品信息 展示页
        /// </summary>
        /// <returns></returns>
        public PagingInfo GetGoodsListAll(int pageSize,int pageIndex,string goodsType)
        {
            string sql =string.Format("SELECT * FROM Goods {0} ORDER BY GoodsId DESC OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", 
                                     (string.IsNullOrWhiteSpace(goodsType)?"": "WHERE GoodsType="+ goodsType),
                                     (pageIndex-1)*pageSize,
                                      pageSize);
            using (var IDbCon = GetConnection())
            {
                try
                {
                    PagingInfo result = new PagingInfo();
                    result.GoodsInfo=IDbCon.Query<Goods>(sql).ToList();
                    result.TotalCount = IDbCon.QueryFirstOrDefault<int>("SELECT COUNT(1) FROM Goods "+ (string.IsNullOrWhiteSpace(goodsType) ? "" : "WHERE GoodsType=" + goodsType));//总的行数
                    result.PageIndex = pageIndex;
                    result.PageSize = pageSize;
                    return result;
                }
                catch
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// 获取常用列表信息
        /// </summary>
        /// <returns></returns>
        public IList<OftenGoodsDto> GetOftenGoodsList()
        {
            using (var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.Query<OftenGoodsDto>("SELECT GoodsId AS goodsId,GoodsName AS goodsName,GoodsPrice AS price,GoodsType AS goodstype FROM [dbo].[Goods] WHERE IsHot=1").ToList();
                }
                catch
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// 插入一条商品数据
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Insert(Goods goods)
        {
            string sql = @"INSERT INTO Goods(GoodsName,GoodsPrice,GoodsImg,GoodsType,IsHot,AddTime,describe) VALUES(@GoodsName,@GoodsPrice,@GoodsImg,@GoodsType,@IsHot,@AddTime,@describe)";
            using (var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.Execute(sql, goods) > 0
;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Update(Goods goods)
        {
            string sql = @"UPDATE Goods SET GoodsName=@GoodsName,GoodsPrice=@GoodsPrice,GoodsImg=@GoodsImg,GoodsType=@GoodsType,IsHot=@IsHot,describe=@describe WHERE GoodsId=@GoodsId";
            using (var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.Execute(sql, goods) > 0
;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            string sql = string.Format(@"DELETE Goods WHERE GoodsId IN ({0})", Id);
            using(var IDbCon = GetConnection())
            {
                try
                {
                    return IDbCon.Execute(sql) > 0;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
