using LibraryCollection.Domain.Abstractions;
using LibraryCollection.Domain.Abstractions.Repository;
using LibraryCollection.Domain.Abstractions.Service;
using LibraryCollection.Infrastructure.DataPersistence;
using LibraryCollection.Infrastructure.DataPersistence.Repository;
using LibraryCollection.Services.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace LibraryCollection
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
            
            SystemInfo systemInfo = new SystemInfo();
            systemInfo.FillSettings();
            services.AddSingleton<ISystemInfo>(systemInfo);

            var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
            optionsBuilder.UseSqlServer(systemInfo.ConnectionString);
            services.AddSingleton(optionsBuilder.Options);
            services.AddDbContext<BookContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddControllers();
            

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000"); // add the allowed origins  
                      });
            });
            services.AddControllers();
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

    }
    internal class SystemInfo : ISystemInfo
    {
        public string ConnectionString { get; set; }
        public string Persistence { get; set; }
        public string DataBase { get; set; }

        IConfigurationRoot root;
        SystemInfo settings;
        private static void GetSettings(out IConfigurationRoot root, out SystemInfo settings)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            root = builder.Build();
            settings = root.GetSection("AppSettings").Get<SystemInfo>();
        }
        public void FillSettings()
        {
            GetSettings(out root, out settings);
            ConnectionString = root.GetConnectionString(settings.Persistence);
            DataBase = settings.DataBase;
            Persistence = settings.Persistence;
        }
    }
}
