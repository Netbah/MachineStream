namespace MachineStream
{
    using Configuration;
    using Data.Database;
    using Data.Repository;
    using MediatR;
    using Services;
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Middleware;
    using System.IO;

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
            services
                .AddControllers()
                .AddNewtonsoftJson();
            
            services.AddHostedService<WebSocketConnectionService>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("MachineStream.Handlers"));
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<IEventDataRepository, EventDataRepository>();
            services.Configure<MachineStreamConfiguration>(options => Configuration.GetSection("MachineStreamConfiguration").Bind(options));


            bool.TryParse(Configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);
            if (useInMemory)
            {
                var options = new DbContextOptionsBuilder<MachineContext>()
                    .UseInMemoryDatabase(databaseName: "MachineDatabase")
                    .Options;
                services.AddSingleton(x => new MachineContext(options));
            }
            else
            {
                var options = new DbContextOptionsBuilder<MachineContext>().Options;
                services.AddSingleton(x => new MachineContext(options));
                services.AddDbContext<MachineContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MachineDatabase"));
                });
            }
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MachineStream", Version = "v1" });
                var filePath = Path.Combine(AppContext.BaseDirectory, "MachineStream.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MachineStream v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}