using ApiCatalog.Context;
using ApiCatalog.Filters;
using ApiCatalog.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
//using ApiCatalog.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); // com isso ignora um erro que tava dando ao fazer chamada que se repetiam 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MySqlConnectio = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql
(MySqlConnectio, ServerVersion.AutoDetect(MySqlConnectio)));

builder.Services.AddTransient<IMeuServico, MeuServico>(); // adicionando o serviço
builder.Services.AddScoped<ApiLoggingFilter>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())// midware sao definidios aqui usando APP
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();



app.UseAuthentication(); // altenticação antes do autorização

app.UseAuthorization(); // autorização 

app.Use(async (context, next) =>
{
    //codigo antes do request
    await next(context);
    //adicionar codigo depois do request
});

app.MapControllers();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Final");
//});

app.Run();
