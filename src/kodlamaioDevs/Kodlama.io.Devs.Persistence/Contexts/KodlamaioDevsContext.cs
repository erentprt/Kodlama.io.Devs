using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts;

public class KodlamaioDevsContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

    public KodlamaioDevsContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(
        dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(a =>
        {
            a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            a.Property(pl => pl.Id).HasColumnName("Id");
            a.Property(pl => pl.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<ProgrammingLanguageTechnology>(a =>
        {
            a.ToTable("ProgrammingLanguageTechnologies").HasKey(k => k.Id);
            a.Property(plt => plt.Id).HasColumnName("Id");
            a.Property(plt => plt.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            a.Property(plt => plt.Name).HasColumnName("Name");
            a.HasOne(plt => plt.ProgrammingLanguage);
        });


        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C"), new(2, "C++"), new(3, "C#") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        ProgrammingLanguageTechnology[] programmingLanguageTechnologiesEntitySeeds =
            { new(1, "React", 4), new(2, "Angular", 4), new(3, "Spring", 5) };
        modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologiesEntitySeeds);
    }
}