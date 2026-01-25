using Microsoft.EntityFrameworkCore;
using System.Text;

using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Factories;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.src.Services;
using SistemaAcademicoProfessorMS.src.Services.Interfaces;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.Domain.Repositories;

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

string connectionString = "Server=professor-db,1433;Database=ProfessorMsDb;User Id=sa;Password=S3nh@Profess0.r;TrustServerCertificate=True";


builder.Services.AddDbContext<ProfessorDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITitulosRepository, TitulosRepository>();
builder.Services.AddScoped<IAtribuicaoAulaRepository, AtribuicaoAulaRepository>();

builder.Services.AddScoped<IProfessorFactory, ProfessorFactory>();
builder.Services.AddScoped<ITitulosFactory, TitulosFactory>();
builder.Services.AddScoped<IAtribuicaoAulaFactory, AtribuicaoAulaFactory>();

builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<ITitulosService, TitulosService>();
builder.Services.AddScoped<IAtribuicaoAulaService, AtribuicaoAulaService>();

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
