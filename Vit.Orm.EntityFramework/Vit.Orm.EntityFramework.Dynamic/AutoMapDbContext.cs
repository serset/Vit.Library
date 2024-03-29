﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Vit.Db.Module.Schema;
using Vit.Extensions.Linq_Extensions;

namespace Vit.Orm.EntityFramework.Dynamic
{
    /// <summary>
    /// 自动对数据库中未映射的表创建模型实体代码并映射 
    /// </summary>
    public partial class AutoMapDbContext : DbContext
    {
        Vit.Db.Util.Data.ConnectionInfo connInfo;
        public AutoMapDbContext(DbContextOptions<AutoMapDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 通过调用AutoGenerateEntity方法生成的实体对应数据表的结构
        /// </summary>
        public List<TableSchema> AutoGeneratedEntity_schema { get; protected set; }

        /// <summary>
        /// 通过调用AutoGenerateEntity方法生成的实体的类型
        /// </summary>
        public Type[] AutoGeneratedEntity_types { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //(x.1)
            base.OnModelCreating(modelBuilder);


            //(x.2)对数据库中未映射的表创建模型实体代码并映射
            (AutoGeneratedEntity_schema, AutoGeneratedEntity_types) = this.AutoGenerateEntity(connInfo,model: modelBuilder.Model);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            foreach (var item in optionsBuilder.Options.Extensions)
            {
                if (item is Microsoft.EntityFrameworkCore.Infrastructure.RelationalOptionsExtension relation)
                {
                    connInfo = new Vit.Db.Util.Data.ConnectionInfo
                    {
                        type = IDbConnection_GetDbType_Extensions.GetDbTypeFromTypeName(relation)?.ToString(),
                        ConnectionString = relation.ConnectionString
                    };
                    return;
                }


//                if (item is Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal.SqliteOptionsExtension sqlite)
//                {
//                    connInfo = new Vit.Db.Util.Data.ConnectionInfo { type = "sqlite", ConnectionString = sqlite.ConnectionString };
//                }
//                else if (item is Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension mssql)
//                {
//                    connInfo = new Vit.Db.Util.Data.ConnectionInfo { type = "mssql", ConnectionString = mssql.ConnectionString };
//                }
//#if NETSTANDARD2_0
//                else if (item is MySql.Data.EntityFrameworkCore.Infraestructure.MySQLOptionsExtension mysql)
//                {
//                    connInfo = new Vit.Db.Util.Data.ConnectionInfo { type = "mysql", ConnectionString = mysql.ConnectionString };
//                }
//#endif

//#if NETSTANDARD2_1
//                else if (item is Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal.MySqlOptionsExtension pomelo)
//                {
//                    connInfo = new Vit.Db.Util.Data.ConnectionInfo { type = "mysql", ConnectionString = pomelo.ConnectionString };
//                }
//#endif

            }


        }





    }
}