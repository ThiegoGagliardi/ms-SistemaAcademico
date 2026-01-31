using Microsoft.EntityFrameworkCore;
using System.Text;

using SistemaAcademicoAlunoMS.src.Data;
using SistemaAcademicoAlunoMS.src.Factories;
using SistemaAcademicoAlunoMS.src.Factories.Interfaces;
using SistemaAcademicoAlunoMS.src.Services;
using SistemaAcademicoAlunoMS.src.Services.Interfaces;
using SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoAlunoMS.src.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers().AddJsonOptions(x => {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

string connectionString = "Server=sqlserver-aluno-db,1433;Database=AlunoMsDB;User Id=sa;Password=S3nhA4luno.0;TrustServerCertificate=True"; 

var dockerConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (!string.IsNullOrEmpty(dockerConnectionString))
{
    connectionString = dockerConnectionString;
}

builder.Services.AddDbContext<AlunoDbContext>(options => options.UseSqlServer(connectionString,
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<INotasAlunoRepository,NotasAlunoRepository>();

builder.Services.AddScoped<IAlunoFactory, AlunoFactory>();
builder.Services.AddScoped<INotasAlunoFactory,NotasAlunoFactory>();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<INotasAlunoService, NotasAlunoService>();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<IAlunoRepository, AlunoRepository>(client =>
{
    client.BaseAddress = new Uri("http://cursoapp_container:8060/api/Curso/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
