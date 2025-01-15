using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infra.data.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Plate);
        builder.Property(x => x.Model).IsRequired();
        
        builder.HasOne(x => x.Person)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}