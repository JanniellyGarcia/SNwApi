using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace WebApi.Configuration
{
    public static class DatabaseConfig
    {
        public static StreamWriter _logStream =  new StreamWriter("C:\\loger\\loger.txt", append:true);

        public static void AddDatabaseConfig (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConexaoDB"))
                            .LogTo(_logStream.WriteLine));


        }
        
    }
}
