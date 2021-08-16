using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Dal.Implementations;
using Explorer_GED_V1.Service.Contracts;
using Explorer_GED_V1.Service.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explorer_GED_V1_Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Explorer_GED_V1_Api", Version = "v1" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ExplorerContext>(options => options.UseSqlServer(
                    this.Configuration.GetConnectionString("ExplorerConnection"), sql =>
                    {
                        sql.EnableRetryOnFailure();
                        sql.UseRelationalNulls();
                        sql.CommandTimeout(1000);
                    }));

            this.bootstrap(services);
        }

        private void bootstrap(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthDal, AuthDal>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IAgentDal, AgentDal>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IProvinceDal, ProvinceDal>();
            services.AddScoped<ICommuneService, CommuneService>();
            services.AddScoped<ICommuneDal, CommuneDal>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentDal, DocumentDal>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentDal, PaymentDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Explorer_GED_V1_Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
