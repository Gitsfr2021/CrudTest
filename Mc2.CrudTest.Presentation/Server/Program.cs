using Mc2.Application.Common.Interfaces;
using Mc2.Application.Services.Customer.Commands;
using Mc2.Application.Services.Customer.Queries;
using Mc2.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            CreateHostBuilder(args).Build().Run();
            app.MapFallbackToFile("index.html");

            //var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddControllersWithViews();
            //builder.Services.AddRazorPages();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseWebAssemblyDebugging();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();

            //app.UseBlazorFrameworkFiles();
            //app.UseStaticFiles();

            //app.UseRouting();


            //app.MapRazorPages();
            //app.MapControllers();

            //app.MapFallbackToFile("index.html");
            //CreateHostBuilder(args).Build().Run();
            //app.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            string connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IDataBaseContext, AppDBContext>();
            services.AddScoped(typeof(IDataBaseContext), typeof(AppDBContext));
            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddScoped(typeof(IAddCustomerService), typeof(AddCustomerService));
            services.AddScoped(typeof(IEditCustomerService), typeof(EditCustomerService));
            services.AddScoped(typeof(IDeleteCustomerService), typeof(DeleteCustomerService));
            services.AddScoped(typeof(IGetAllCustomerService), typeof(GetAllCustomerService));
            services.AddScoped(typeof(IGetCustomerService), typeof(GetCustomerService));

        });
    }
}