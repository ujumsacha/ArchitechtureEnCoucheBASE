using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.BdFolder;

namespace ArchitechtureEnCoucheBASE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //***********************Add configuration setting recuperation **********************
            builder.Services.AddSingleton<IAppConfigSetting, AppConfigSetting>();
            builder.Services.AddDbContext<Repository.BdFolder.ApplicationContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("OnlineConnection"))

            );
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
            app.JwtMiddleware();
            app.Run();
        }
    }
}