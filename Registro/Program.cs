using Microsoft.EntityFrameworkCore;
using Registro.Components;
using Registro.DAL;
using Registro.Models;
using Registro.Services;

namespace Registro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddBlazorBootstrap();
			builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

            builder.Services.AddScoped<TecnicosService>();

            builder.Services.AddScoped<ClientesService>();

            builder.Services.AddScoped<CiudadesService>();

            builder.Services.AddScoped<TicketsService>();

            builder.Services.AddScoped<SistemasService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
