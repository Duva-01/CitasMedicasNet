using CitasMedicasNet.Models;
using CitasMedicasNet.Repositories.Impl;
using CitasMedicasNet.Repositories;
using CitasMedicasNet.Services.Impl;
using CitasMedicasNet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using CitasMedicasNet.Handlers;
using CitasMedicasNet.Models.CitasMedicasNet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registro de DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios // Meter singleton
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddSingleton<IPacienteService, PacienteService>();
builder.Services.AddSingleton<IRepository<Paciente>, PacienteRepository>();

builder.Services.AddSingleton<IMedicoService, MedicoService>();
builder.Services.AddSingleton<IRepository<Medico>, MedicoRepository>();

builder.Services.AddSingleton<IMedicoPacienteService, MedicoPacienteService>();
builder.Services.AddSingleton<IMedicoPacienteRepository, MedicoPacienteRepository>();

builder.Services.AddSingleton<ICitaService, CitaService>();
builder.Services.AddSingleton<IRepository<Cita>, CitaRepository>();

builder.Services.AddSingleton<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddSingleton<IRepository<Diagnostico>, DiagnosticoRepository>();


// Registro de AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Agrega los controladores y Swagger para la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
