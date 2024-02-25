using FMT.Areas.Identity.Data;
using FMT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMT.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<User>
{
   
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<MailTracker> MailTrackers { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Department> Departments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.Property(x => x.FirstName).HasMaxLength(100);
        //builder.Property(x => x.LastName).HasMaxLength(100);
    }
}