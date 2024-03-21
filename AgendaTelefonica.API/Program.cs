using AgendaTelefonica.API.Persistence;
using AgendaTelefonica.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IContatoRepository, ContatoRespository>();

builder.Services.AddControllers();

//Habilitar para qualquer requisição
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            // builder.WithOrigins("http://127.0.0.1:5500") // apenas esse ip faz req
            builder.AllowAnyOrigin() // qualquer um faz req
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); // Adicione esta linha

app.UseAuthorization();

app.MapControllers();

app.Run();
