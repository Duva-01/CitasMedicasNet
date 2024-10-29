using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CitasMedicasNet.Models
{
    using global::CitasMedicasNet.Models.CitasMedicasNet.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<MedicoPaciente> MedicoPacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario");

            modelBuilder.Entity<Paciente>()
                .ToTable("Paciente")
                .HasOne<Usuario>()
                .WithOne()
                .HasForeignKey<Paciente>(p => p.id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medico>()
                .ToTable("Medico")
                .HasOne<Usuario>()
                .WithOne()
                .HasForeignKey<Medico>(m => m.id)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación MedicoPaciente con Medico y Paciente
            modelBuilder.Entity<MedicoPaciente>()
                .ToTable("Medico_Paciente")
                .HasKey(mp => mp.id);

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.medico)
                .WithMany(m => m.medicoPacientes)
                .HasForeignKey(mp => mp.medico_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.paciente)
                .WithMany(p => p.medicoPacientes)
                .HasForeignKey(mp => mp.paciente_id)
                .OnDelete(DeleteBehavior.NoAction);

            // Relación Cita con Medico y Paciente
            modelBuilder.Entity<Cita>()
                .ToTable("Cita")
                .HasKey(c => c.id);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.medico)
                .WithMany(m => m.citas)
                .HasForeignKey(c => c.medico_id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.paciente)
                .WithMany(p => p.citas)
                .HasForeignKey(c => c.paciente_id)
                .OnDelete(DeleteBehavior.NoAction);

            // Relación Diagnostico con Cita
            modelBuilder.Entity<Diagnostico>()
                .ToTable("Diagnostico")
                .HasKey(d => d.id);

            modelBuilder.Entity<Diagnostico>()
                .HasOne(d => d.cita)
                .WithOne(c => c.diagnostico)
                .HasForeignKey<Diagnostico>(d => d.cita_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
