using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseDetail> CourseDetails { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Credential> Credentials { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connString = @"Server=DESKTOP-J65MPJ3;Database=YukngodingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasIndex(trainee =>  trainee.Email).IsUnique();
            entity.HasIndex(trainee =>  trainee.PhoneNumber).IsUnique();
            entity.HasIndex(trainee =>  trainee.Nik).IsUnique();
        });
    }
}