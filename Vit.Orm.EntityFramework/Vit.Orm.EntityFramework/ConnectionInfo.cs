﻿
 

namespace Vit.Orm.EntityFramework
{
    public class ConnectionInfo/*: Core.Util.Extensible.Extensible*/
    {
        /// <summary>
        ///  数据库类型，可为  mysql mssql sqlite
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
