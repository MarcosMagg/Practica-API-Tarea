using Microsoft.EntityFrameworkCore;
using PracticaAPI.Repository;
using PracticaAPI.Service.Interface;


public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddDbContext<ToDoContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ITareaService, TareaService>();
        //gracias a este contenedor de dependencias no tengo que crear un new  y depender de una interfasz


        var app = builder.Build();




    // Configure the HTTP request pipeline.
    /*if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }*/






    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();

    app.Run();
    }   
}