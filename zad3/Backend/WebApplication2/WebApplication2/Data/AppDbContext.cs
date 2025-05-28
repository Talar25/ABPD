using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>(e =>
        {
            e.HasKey(n => n.IdDoctor);
            e.Property(n => n.FirstName).HasMaxLength(100).IsRequired();
            e.Property(n => n.LastName).HasMaxLength(100).IsRequired();

            e.HasData(new List<Doctor>
            {
                new Doctor { IdDoctor = 1, FirstName = "James", LastName = "Bond", Email = "bondjames@gmail.com" },
                new Doctor
                {
                    IdDoctor = 2, FirstName = "Vladimir", LastName = "Nabukov", Email = "dostoywskiisbad@gmail.com"
                },
                new Doctor { IdDoctor = 3, FirstName = "Humbert", LastName = "Humbert", Email = "lolitaluv@gmail.com" },
                new Doctor { IdDoctor = 4, FirstName = "Dr", LastName = "Evil", Email = "biliongazilion@gmail.com" },
                new Doctor
                {
                    IdDoctor = 5, FirstName = "Donald", LastName = "Trump",
                    Email = "thebiggestthebestcriminal@gmail.com"
                }
            });
        });

        modelBuilder.Entity<Patient>(n =>
        {
            n.HasKey(m => m.IdPatient);
            n.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
            n.Property(m => m.LastName).HasMaxLength(100).IsRequired();
            n.Property(m => m.DateOfBirth).HasMaxLength(100).IsRequired();

            n.HasData(new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1, FirstName = "Tony", LastName = "Stark",
                    DateOfBirth = new DateTime(1990, 1, 1, 8, 0, 0),
                },
                new Patient
                {
                    IdPatient = 2, FirstName = "Frank", LastName = "Sinatra",
                    DateOfBirth = new DateTime(1980, 5, 15, 0, 0, 0),
                },
                new Patient
                {
                    IdPatient = 3, FirstName = "Joe", LastName = "Cocker",
                    DateOfBirth = new DateTime(1975, 7, 20, 0, 0, 0),
                },
                new Patient
                {
                    IdPatient = 4, FirstName = "Rodion", LastName = "Raskolnikov",
                    DateOfBirth = new DateTime(1985, 3, 10, 0, 0, 0),
                },
                new Patient
                {
                    IdPatient = 5, FirstName = "Jozef", LastName = "Pilsudski",
                    DateOfBirth = new DateTime(1880, 12, 5, 0, 0, 0),
                }
            });
        });

        modelBuilder.Entity<Medicament>(n =>
        {
            n.HasKey(m => m.idMedicament);
            n.Property(m => m.Name).HasMaxLength(100).IsRequired();
            n.Property(m => m.Description).HasMaxLength(100).IsRequired();
            n.Property(m => m.Type).HasMaxLength(100).IsRequired();

            n.HasData(new List<Medicament>
            {
                new Medicament
                {
                    idMedicament = 1,
                    Name = "Sertralina",
                    Description = "Antydepresant z grupy SSRI",
                    Type = "Inhibitor wychwytu zwrotnego serotoniny"
                },
                new Medicament
                {
                    idMedicament = 2,
                    Name = "Paracetamol",
                    Description = "Stosowany w leczeniu bólu i gorączki",
                    Type = "Przeciwbólowy i przeciwgorączkowy"
                },
                new Medicament
                {
                    idMedicament = 3,
                    Name = "Amoksycylina",
                    Description = "Antybiotyk penicylinowy",
                    Type = "Antybiotyk"
                },
                new Medicament
                {
                    idMedicament = 4,
                    Name = "Kwas acetylosalicylowy",
                    Description = "Rozrzedza krew i zmniejsza stan zapalny",
                    Type = "Przeciwbólowy i przeciwzapalny"
                },
                new Medicament
                {
                    idMedicament = 5,
                    Name = "Loratadyna",
                    Description = "Łagodzi objawy alergii",
                    Type = "Antyalergiczny"
                },
            });
        });

        modelBuilder.Entity<Prescription>(n =>
        {
            n.HasKey(m => m.IdPrescription);
            n.Property(m => m.Date).IsRequired();
            n.Property(m => m.DueDate).IsRequired();

            n.HasOne(m => m.Doctor)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(m => m.IdDoctor)
                .OnDelete(DeleteBehavior.ClientCascade);

            n.HasOne(m => m.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(m => m.IdPatient)
                .OnDelete(DeleteBehavior.ClientCascade);

            n.HasData(new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2025, 5, 28), // Use a static date
                    DueDate = new DateTime(2025, 6, 28), // Use a static date
                    IdDoctor = 1,
                    IdPatient = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = new DateTime(2025, 5, 28),
                    DueDate = new DateTime(2025, 6, 28),
                    IdDoctor = 2,
                    IdPatient = 2
                },
                new Prescription
                {
                    IdPrescription = 4,
                    Date = new DateTime(2025, 5, 28),
                    DueDate = new DateTime(2025, 6, 28),
                    IdDoctor = 1,
                    IdPatient = 4
                },
                new Prescription
                {
                    IdPrescription = 5,
                    Date = new DateTime(2025, 5, 28),
                    DueDate = new DateTime(2025, 6, 28),
                    IdDoctor = 2,
                    IdPatient = 5
                },
                new Prescription
                {
                    IdPrescription = 6,
                    Date = new DateTime(2025, 5, 28),
                    DueDate = new DateTime(2025, 6, 28),
                    IdDoctor = 4,
                    IdPatient = 5
                }
            });
        });

        modelBuilder.Entity<Prescription_Medicament>(n =>
        {
            n.HasKey(m => new
            {
                m.IdMedicament,
                m.IdPrescription
            });
            n.Property(m => m.Details).IsRequired();
            n.Property(m => m.Dose);

            n.HasOne(e => e.Medicament)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.ClientCascade);
            ;

            n.HasOne(e => e.Prescription)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.ClientCascade);

            n.HasData(new List<Prescription_Medicament>
            {
                new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 10,
                    Details = "1x dziennie"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 2,
                    Details = "2x dziennie"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 4,
                    Dose = 100,
                    Details = "1x dziennie"
                }
            });
        });
    }
}