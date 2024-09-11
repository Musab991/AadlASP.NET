using Microsoft.EntityFrameworkCore;

namespace BusinessLib.Data.Config
{
    public class PractitionerTypeConfiguration : IEntityTypeConfiguration<TbPractitionerType>
    {
        public void Configure(EntityTypeBuilder<TbPractitionerType> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbPractitionerTypes");


            builder.Property(x => x.PractitionerTypeName).HasConversion(
                v => v.ToString(), // Convert enum to string when storing in database
                 v => (PractitionerTypeEnum)Enum.Parse(typeof(PractitionerTypeEnum), v) // Convert string back to enum when retrieving from database
             );

            builder
                .HasMany<TbPractitionerCase>()
               .WithOne()
               .HasForeignKey(e => e.PractitionerTypeId)
               .IsRequired();


            builder
                .HasMany<TbPractitioner>()
               .WithOne()
               .HasForeignKey(e => e.PractitionerTypeId)
               .IsRequired();


            builder
                  .HasMany<TbCaseType>()
                 .WithOne()
                 .HasForeignKey(e => e.PractitionerTypeId)
                 .IsRequired();
        }

    }

}
