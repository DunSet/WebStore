using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllersWithViews(); //���������� �������������� MVC
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //��� ������ � static �������
            app.UseDefaultFiles(); //��� ������ � ������-�� ��� �������)

            app.UseRouting();

                   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync(Configuration["CustomGreetings"]);
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{cotroller}/{action=Index}/{id?}" //controller ��������������� � ����� � �����������, ������� ��� ������������ � �������� ��� �������� � ����������
                    //Id '?' - �������� ���������� (�� ����������), Index - �� ��������� ��� �������� ����� ����
                    //Home - ���� �� ������ ������ ����������, �� �� ��������� Homme
                    );
            });
        }
    }
}
