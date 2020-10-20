using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BGStudio.BLL.Authetication;
using BGStudio.BLL.Login;
using BGStudio.BLL.Masters;
using BGStudio.DAL.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BGStudio.App
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BGStudioAppContext>
                (options => options.UseMySQL(_configuration.GetConnectionString("DBDefaultConnection")));
            var authOptionsConfiguration = _configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);
            services.AddTransient<ILoginAppService, LoginAppService>();
            services.AddTransient<IMastersAppService,MastersAppService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptionsConfiguration.Get<AuthOptions>().Issuer,

                        ValidateAudience = true,
                        ValidAudience = authOptionsConfiguration.Get<AuthOptions>().Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = authOptionsConfiguration.Get<AuthOptions>().GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,

                    };
                });

            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
