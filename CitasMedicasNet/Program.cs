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

// Registro de servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IRepository<Paciente>, PacienteRepository>();

builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IRepository<Medico>, MedicoRepository>();

builder.Services.AddScoped<IMedicoPacienteService, MedicoPacienteService>();
builder.Services.AddScoped<IMedicoPacienteRepository, MedicoPacienteRepository>();

builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IRepository<Cita>, CitaRepository>();

builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddScoped<IRepository<Diagnostico>, DiagnosticoRepository>();


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
