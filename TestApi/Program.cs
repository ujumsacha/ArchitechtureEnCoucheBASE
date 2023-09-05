using TestRepository;

namespace TestApi
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
            builder.WebHost.UseKestrel(opt => opt.AddServerHeader = false);

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Server=172.10.10.35;initial catalog=Test_templateAsp;User id=sa;Password=Admin@@2020"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            //builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddTransient<IActionRoleRepo, ActionRoleRepo>();
            builder.Services.AddTransient<IActionRoleService, ActionRoleService>();
            builder.Services.AddTransient<IUtilisateurRepo, UtilisateurRepo>();
            builder.Services.AddTransient<IUtilisateurService, UtilisateurService>();

            builder.Services.AddTransient<IRoleRepo, RoleRepo>();
            builder.Services.AddTransient<IproduitRepo, ProduitRepo>();
            builder.Services.AddTransient<IAcheterRepo, AcheterRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}