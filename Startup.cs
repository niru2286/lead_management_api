using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pms_api.Abstract;
using pms_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pms_api
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
            services.AddControllers();

            services.AddDbContextPool<pms_api.Model.pms_dbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConStr"));
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<ICall, CallData>();
            services.AddScoped<IContacts, ContactData>();
            services.AddScoped<ILead, LeadData>();
            services.AddScoped<ILeadStatus, LeadStatusData>();
            services.AddScoped<IMembers, MembersData>();
            services.AddScoped<INotes, NoteData>();
            services.AddScoped<IProducts, ProductsData>();
            services.AddScoped<ISource, SourceData>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", p =>
            //    {
            //        p.WithOrigins("*")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            //app.UseCors("AllowAll");

          //  app.UseHttpRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
