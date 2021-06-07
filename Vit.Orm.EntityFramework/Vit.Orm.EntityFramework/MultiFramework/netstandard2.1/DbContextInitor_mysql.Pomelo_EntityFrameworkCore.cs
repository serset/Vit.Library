﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Vit.Orm.EntityFramework.DbContextInitor
{
    public partial class DbContextInitor_mysql
    {
        public void AddDbContext<TContext>(IServiceCollection data, ConnectionInfo info) where TContext : DbContext
        {
            //使用mysql数据库

            // for Pomelo.EntityFrameworkCore
            data.AddDbContext<TContext>(opt =>
            {
                opt.UseMySql(info.ConnectionString, ServerVersion.AutoDetect(info.ConnectionString));
            });
        }
    }
}