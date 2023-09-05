using BusinessLogic.User_Management.Implementations;
using BusinessLogic.User_Management.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.User_Management.Interfaces;
using Repository.User_Management.Implementations;
using Swashbuckle.AspNetCore.SwaggerGen;

using System.Text;
using System.Xml.XPath;
using Repository.Interfaces.User_Management.Interfaces;
using Repository.Interfaces.User_Management.Implementations;
using Repository.Implementations;
using Repository.Interfaces;

namespace TEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.WebHost.UseKestrel(opt => opt.AddServerHeader = false);

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Server=172.10.10.35;initial catalog=Test_templateAsp;User id=sa;Password=Admin@@2020"),ServiceLifetime.Scoped,ServiceLifetime.Scoped);
            //builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddTransient<IActionRoleRepo, ActionRoleRepo>();
            builder.Services.AddTransient<IActionRoleService, ActionRoleService>();
            builder.Services.AddTransient<IUtilisateurRepo, UtilisateurRepo>();
            builder.Services.AddTransient<IUtilisateurService, UtilisateurService>();
            
            builder.Services.AddTransient<IRoleRepo, RoleRepo>();
            builder.Services.AddTransient<IproduitRepo, ProduitRepo>();
            builder.Services.AddTransient<IAcheterRepo, AcheterRepo>();


            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            //builder.Services.AddDbContext<ApplicationContext>();
            //**************************************SWAGGER*****************************************************************************
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API TEST",
                    Description = "API TEMPLATE"
                });
                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            //**************************************SWAGGER*****************************************************************************

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWTToken:Issuer"],
                    ValidAudience = builder.Configuration["JWTToken:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:Key"]))
                };
            });
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
            //app.UseMiddlewareJWT();
            app.Run();
        }
    }
}