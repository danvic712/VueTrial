using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Services.User;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;

namespace Sample
{
    public class Startup
    {
        // Cors 策略名称
        private const string _defaultCorsPolicyName = "Sample.Cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                // 添加跨域请求过滤器
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // 使用小写路由
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // 配置跨域请求访问策略
            services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
                builder => builder.WithOrigins(
                        Configuration["Application:CorsOrigins"]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray()
                    )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));

            // 配置 Swagger 文档信息
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Contact = new Contact
                    {
                        Name = "Danvic Wang",
                        Email = "danvic96@hotmail.com",
                        Url = "https://yuiter.com"
                    },
                    Description = "使用 axios 完成 Vue 与 ASP.NET Core 的前后端交互",
                    Title = "Sample",
                    Version = "v1"
                });

                // 获取程序运行路径
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                var dtoPath = Path.Combine(basePath, "Sample.xml");
                s.IncludeXmlComments(dtoPath, true);
            });

            // 依赖注入
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // 启用 Swagger 文档
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API V1.0");
            });
        }
    }
}