using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ti224_prova2.Context;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
var mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TI224 - Prova 2 - API",
        Version = "v1.0.0",
        Description = "API de Catálogo de Produtos e Categorias",
        Contact = new OpenApiContact
        {
            Name = "Vinícius Andrade",
            Email = "vinicius_andrade2010@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/viniciusdsandrade/"),
        },
        License = new OpenApiLicense
        {
            Name = "Github",
            Url = new Uri("https://github.com/viniciusdsandrade")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();