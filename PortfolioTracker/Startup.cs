using System;
using System.Collections.Generic;
using System.Linq;
using Radzen;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioTracker.Services;
using PortfolioTracker.DatabaseConnect;
using PortfolioTracker.Database.DataModels;
using PortfolioTracker.Database.Repositories;
using PortfolioTracker.Database.Services;

namespace PortfolioTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient<IStockDataService, StockDataService>(client =>
                {
                    client.BaseAddress = new Uri("https://finnhub.io/api/v1/");
            });
            //register Database
            services.AddDatabaseRepositories(Configuration).GetAwaiter().GetResult();
            //Radzen dialog service
            services.AddScoped<DialogService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedTestData(app);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private void SeedTestData(IApplicationBuilder app)
        {
            var tickerRepo = app.ApplicationServices.GetService<IRepository<Equity>>();
            var authorizedTenants = tickerRepo.GetList().GetAwaiter().GetResult();
            if (!authorizedTenants.Any())
            {
                tickerRepo.AddUpdate(new Equity() {Name = "Apple", Symbol = "AAPL", Quantity = 18, CostPerShare = 113.44, CurrentPrice = 118.72, IsSold = false, Sector = "Technology", Industry = "Consumer Electronics", Id = Guid.NewGuid().ToString() }).GetAwaiter().GetResult();
            }
        }
    }
}
