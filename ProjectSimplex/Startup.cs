using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace ProjectSimplex
{
    public class Server
    {
        MySqlConnection sqlConnection;
        
        Server(string address)
        {
            sqlConnection
            sqlConnection = new MySqlConnection();


        }
    }
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.Run(ResponseHandler);
            
        }

        public async Task ResponseHandler (HttpContext context)
        {
            await context.Response.WriteAsync(context.Request.Path.Value);
            var cookies = context.Request.Cookies.ToList();

            string userid = null;

            foreach (var item in cookies)
            {
                if (item.Key == "userid")
                {
                    userid = item.Value;
                    break;
                }
            }

            //if (userid == null) context.Response.StatusCode = 500;
            
            
            
        }
    }
}
