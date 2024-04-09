using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data;

public class AppDbContext: DbContext
{
    //* Definiendo las Entities:
    public virtual DbSet<Driver> Drivers{ get; set; }
    public virtual DbSet<Achivement> Achivements{ get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
         
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        //* Specifying the relationships between the Entities:
        modelBuilder.Entity<Achivement>(entity => 
        {
            entity.HasOne(d => d.Driver)
                  .WithMany(p => p.Achivements)
                  .HasForeignKey(d => d.DriverId)
                  .OnDelete(deleteBehavior: DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Achivements_Driver");            
        });
    
    
    }


}