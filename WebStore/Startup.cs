using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public class Startup
    {

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt => 
            {
                //opt.Filters.Add<>();
                //opt.Conventions //����������
                //opt.Conventions.Add();
             }).AddRazorRuntimeCompilation();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();//��������� ������ ��� ������ ���������� IEmployeesData ������ ����� ��������� InMemoryEmployeesData
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //��������� ������� ��������� ������ ��������
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//���������� ������
                app.UseBrowserLink();//��������� ���� � ������� ���
            }

            app.UseStaticFiles();//�������� ��������
            app.UseDefaultFiles();

            app.UseWelcomePage("/MVC");

           /* app.Use(async (context, next) =>
            {
                Debug.WriteLine($"Request to, {context.Request.Path}");
                await next();
            });*/
            //app.UseMiddleware<>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
