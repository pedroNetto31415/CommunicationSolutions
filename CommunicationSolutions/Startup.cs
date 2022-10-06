using CommunicationSolutions.Domain.Interface.Repository;
using CommunicationSolutions.Domain.Interface.Service;
using CommunicationSolutions.Domain.Interface.Util;
using CommunicationSolutions.Domain.Service;
using CommunicationSolutions.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdPay.Utils.Cryptography;

namespace CommunicationSolutions
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "ApiDoc", Version = "v1" }); 
            }); 

            services.AddScoped<IEncryptionUtil, EncryptionUtil>();
            services.AddScoped<IVoucherCardService, VoucherCardService>(); 
            services.AddScoped<IVoucherCardRepository, VoucherCardRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "ApiDoc v1")); 
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
