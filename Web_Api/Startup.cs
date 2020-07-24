using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Web_Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
            // Adiciona o MVC ao projeto
            .AddMvc()
            .AddJsonOptions(options => {
                   // Ignora valores nulos ao fazer junções nas consultas
                   options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   // Ignora os loopings nas consultas
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })

            // Define a versão do .NET Core
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            // Documentação Swagger

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ws_Tower_WebApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Quem está solicitando
                        ValidateIssuer = true,

                        // Quem está validando
                        ValidateAudience = true,

                        // Definindo o tempo de expiração
                        ValidateLifetime = true,

                        // Forma de criptografia
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WsTower-chave-autenticacao")),

                        // Tempo de expiração do token
                        ClockSkew = TimeSpan.FromHours(2),

                        // Nome da issuer, de onde está vindo
                        ValidIssuer = "WsTower.WebApi",

                        // Nome da audience, de onde está vindo
                        ValidAudience = "WsTower.WebApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ws_Tower_WebApi");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthentication();
            // Define o uso do MVC
            app.UseMvc();

        }
    }
}
