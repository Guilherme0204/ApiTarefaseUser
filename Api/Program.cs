using Api.Data;
using Api.Repositórios;
using Api.Repositórios.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // builder.WebHost.UseUrls("http://localhost:5500");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var stringConexao = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddDbContext<SistemaTarefaDbContext>
            
            (
                options=> options.UseMySql(stringConexao, ServerVersion.Parse("8.0.33 - MariaDb")
            ));
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
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
            app.UseCors(options => options
            .WithOrigins("http://127.0.0.1:5500/")
            .AllowAnyMethod()
            .AllowAnyHeader());
        }
    }
}