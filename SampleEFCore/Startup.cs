using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace SampleEFCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            this.ConfigureApplicationDBContext(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BaseContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // automatically migrate data
            // manually we would do Add-Migrations and Update-Database
            dbContext.Database.Migrate();
        }

        private void ConfigureApplicationDBContext(IServiceCollection services)
        {
            var dbConfig = Configuration.GetSection("MySQLConfig");
            var host = dbConfig["db_host"] ?? "localhost";
            var port = dbConfig["db_port"] ?? "3306";
            var password = dbConfig["db_password"] ?? "admin";

            services.AddDbContext<BaseContext>(options =>
            {
                options.UseMySql($"Server={host};Port={port};User=root;Password={password};Database=SampleDB;");
            });
        }
    }
}
