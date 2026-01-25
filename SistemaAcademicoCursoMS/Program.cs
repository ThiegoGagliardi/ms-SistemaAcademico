using Microsoft.EntityFrameworkCore;
using System.Text;

using SistemaAcademicoCursoMS.src.Data;
using SistemaAcademicoCursoMS.src.Factories;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.src.Services;
using SistemaAcademicoCursoMS.src.Services.Interfaces;
using SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoCursoMS.src.Domain.Repositories;

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

string connectionString = "Server=curso-db,1433;Database=CursoMsDb;User Id=sa;Password=S3nh@Curs.04;TrustServerCertificate=True";

builder.Services.AddDbContext<CursoDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFormacaoRepository, FormacaoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();

builder.Services.AddScoped<ICursoFactory, CursoFactory>();
builder.Services.AddScoped<IDisciplinaFactory, DisciplinaFactory>();
builder.Services.AddScoped<IFormacaoFactory, FormacaoFactory>();
builder.Services.AddScoped<IGradeHorariaFactory, GradeHorariaFactory>();
builder.Services.AddScoped<IHorarioFactory, HorarioFactory>();

builder.Services.AddScoped<IFormacaoService, FormacaoService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<ICursoService, CursoService>();

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