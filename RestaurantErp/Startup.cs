using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using RestaurantErp.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace RestaurantErp
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            #region Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion

            #region CORS跨域

            //跨域方式一
            //services.AddCors();

            //跨域方式二
            services.AddCors(c =>
            {
                //一般采用这种方法
                c.AddPolicy("LimitRequests", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:49381", "http://192.168.0.251:9529", "http://localhost:8080", "http://192.168.0.251:8080")//支持多个域名端口
                    //.WithMethods("GET", "POST", "PUT", "DELETE")//请求方法添加到策略
                    .AllowAnyMethod()
                    //.WithHeaders("authorization")//标头添加到策略
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Simon Chueng接口文档",
                    Description = "高岭脚幻影文档--Simon",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Simon", Email = "1648344437@qq.com", Url = "" }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "RestaurantErp.xml");
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            //数据库连接字符串注入
            BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:SqlServer:SqlServerConnection").Value;

            //依赖注入
            services.AddScoped<GoodsServer, GoodsServer>();
            services.AddScoped<OrderServer, OrderServer>();
        }

        /// <summary>
        /// 管道设置
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //跨域方式一
            //app.UseCors(builder =>
            //{
            //    builder.AllowAnyHeader();
            //    builder.AllowAnyMethod();
            //    builder.AllowAnyOrigin();
            //    builder.AllowCredentials();
            //});


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "高岭脚幻影科技接口文档");
            });

            //跨域方式二
            app.UseCors("LimitRequests");//将cors中间件添加到web应用程序管线中，以允许跨域请求。有的不加也是可以的，官方建议加上

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
