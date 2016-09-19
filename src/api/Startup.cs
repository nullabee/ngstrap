using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            {
                // Enable CORS
                services.AddCors(options => buildCorsOptions(options));
                //services.Configure<MvcOptions>(options =>
                //{
                //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
                //});
            }

            services.AddMvc();

            services.AddSingleton<ITodoRepository, TodoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            
            // Perform the routing
            app.UseMvc();
        }

        private static void buildCorsOptions(CorsOptions options)
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin();
                });

            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://worldhost:8080")
                           .WithMethods("GET", "POST")
                           .AllowAnyHeader();
                });
        }
    }

}
