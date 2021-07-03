using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { set; get; }
    public DbSet<Patient> Patients { set; get; }
    public DbSet<IntakeForm> IntakeForms { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(@"server=localhost;username=root;password=123456789;database=Clinic",
            ServerVersion.Parse("8.0.23-mysql")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor()
            {
                Id = 1,
                Name = "Brown"
            },
            new Doctor()
            {
                Id = 2,
                Name = "Red"
            },
            new Doctor()
            {
                Id = 3,
                Name = "Orange"
            }
            );

        modelBuilder.Entity<Patient>().HasData(
            new Patient()
            {
                Id = 1,
                Name = "Broccoli",
                DateOfBirth = DateTime.Now,
                HealthNumber = 6436843,
                Address = "1, Test, dr",
                PhoneNumber = "+1 233 12326"
            },
            new Patient()
            {
                Id = 2,
                Name = "Carrot",
                DateOfBirth = DateTime.Now,
                HealthNumber = 6969420,
                Address = "2 Test, Dr",
                PhoneNumber = "+11 1111 11111"
            },
            new Patient()
            {
                Id = 3,
                Name = "Cabbage Patch Girls",
                DateOfBirth = DateTime.Now,
                HealthNumber = 777888999,
                Address = "rum dr, Oklahoma",
                PhoneNumber = "+12 1212 123422"
            }
            );

        modelBuilder.Entity<IntakeForm>().HasData(
           new IntakeForm()
           {
               Id = 1,
               Ailment = "Lost Arm",
               DoctorId = 2,
               PatientId = 1
           },
           new IntakeForm()
           {
               Id = 2,
               Ailment = "Lost Leg",
               DoctorId = 1,
               PatientId = 2
           },
           new IntakeForm()
           {
               Id = 3,
               Ailment = "Crippling Depression",
               DoctorId = 3,
               PatientId = 3
           }
           );

        base.OnModelCreating(modelBuilder);

    }
}