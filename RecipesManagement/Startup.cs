using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecipesManagement.Models;

namespace RecipesManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("RecipeDBConnection")));

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IRecipeRepository, SQLRecipeRepository>();
            //services.AddTransient<IRecipeRepository, MokeRecipeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller = Home}/{action = Details}/{id}");
            //});

            app.Run(async (context) =>
            {
                await context.Response.
                  WriteAsync("Hello World!");
                //    //    //throw new Exception("Some error processing the request");
                //    //    //await context.Response.WriteAsync("MW3: Request handeled and response produced");
                //    //    //logger.LogInformation("MW3: Request handeled and response produced");
                //    //    //await context.Response.WriteAsync("Hello from 2nd Middleware");
                //    //    //.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //    //    //.WriteAsync(_config["MyKey"]);
            });


        }
    }
}
