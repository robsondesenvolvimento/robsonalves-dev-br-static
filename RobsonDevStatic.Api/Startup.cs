using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RobsonDevStatic.Api.Data;
using RobsonDevStatic.Api.Services;

namespace RobsonDevStatic.Api
{
    public class Startup
    {
        private readonly string _allowRobsonDevOrigin = nameof(_allowRobsonDevOrigin);
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContextData>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RobsonDevStatic.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: _allowRobsonDevOrigin, builder =>
                 {
                     builder.WithOrigins("https://www.robsonalves.dev.br", "https://www.robsonalves.net.br", "http://127.0.0.1:5500");
                 });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors(_allowRobsonDevOrigin);
            }

            app.PeoplesSeedingStart().ConfigureAwait(false);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RobsonDevStatic.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(x => x
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
