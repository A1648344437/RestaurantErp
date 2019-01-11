using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantErp.Service
{
    /// <summary>
    /// 基本数据类型
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 获取连接数据库对象
        /// </summary>
        /// <returns></returns>
        protected IDbConnection GetConnection()
        {
            return new SqlConnection(BaseDBConfig.ConnectionString);
        }
    }
}
