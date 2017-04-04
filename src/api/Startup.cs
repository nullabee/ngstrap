using api.Data;
using api.Models;
using api.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.IO.Compression;

namespace api
{
    /**
     * ASP.NET Core Reference: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
     */
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            {
                // Enable CORS
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });

                    options.AddPolicy("AllowSpecificOrigin",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:18080")
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });

                    /*
                     * Example below of finer granularity
                     */
                    //options.AddPolicy("AllowSpecificOrigin",
                    //    builder =>
                    //    {
                    //        builder.WithOrigins("http://localhost:18080")
                    //               .WithMethods("GET", "POST")
                    //               .AllowAnyHeader();
                    //    });

                });
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigins"));
                });
            }

            {
                services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });
                services.Configure<GzipCompressionProviderOptions>(options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
            }
            
            {
                // return JSON response in form of Camel Case so that we can sure consume the API in any client.
                // Enable CamelCasePropertyNamesContractResolver in Configure Services.
                //services.AddMvc().AddJsonOptions(
                //    options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
                //);
                services.AddMvc();
                services.Configure<MvcJsonOptions>(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            }

            {   
                // using Dependency Injection for data context
                services.AddTransient<IResource<Task>, TaskResource>();
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, DataContext context)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseCors("AllowSpecificOrigin");
            
            app.UseResponseCompression();

            // Perform the routing
            app.UseMvc();

            // Mock InitializeMockIfEmpty the DB
            MockDataInitialiser.InitializeMockIfEmpty(context);

        }

    }

}
