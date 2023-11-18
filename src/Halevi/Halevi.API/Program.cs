using Halevi.Core.Application.Implementations;
using Halevi.Core.Application.Interfaces;
using Halevi.Core.Domain.Interfaces.Repositories;
using Halevi.Core.Domain.Interfaces.Repositories.Base;
using Halevi.Infra.DbConfig;
using Halevi.Infra.Implementations.Repositories;
using Halevi.Infra.Implementations.Repositories.Base;

using Microsoft.EntityFrameworkCore;

namespace Halevi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string connString = Environment.GetEnvironmentVariable("ConnectionString");

            if (connString is null)
            {
                Environment.SetEnvironmentVariable("ConnectionString", "Data Source=Halevi.db");
                connString = Environment.GetEnvironmentVariable("ConnectionString");
            }

            builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlite(connString,x => x.MigrationsAssembly("Halevi.Infra"))
            );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DI Container Configuration
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductVariationRepository, ProductVariationRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductVariationService, ProductVariationService>();

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}