using Microsoft.EntityFrameworkCore;
using WebApi8.CadastroAtletasBJJ.Data;
using WebApi8.CadastroAtletasBJJ.Services.Equipe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//RELACIONANDO A INTERFACE DE EQUIPE COM EQUIPE
builder.Services.AddScoped<IEquipeInterface, EquipeService>();

//CONEXÃO COM O BANCO DE DADOS OLHANDO O APPSETTINGS
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.Run();
