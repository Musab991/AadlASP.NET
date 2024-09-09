using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BusinessLib.Data.Config
{
    public class CaseTypeConfiguration : IEntityTypeConfiguration<TbCaseType>
    {
        public void Configure(EntityTypeBuilder<TbCaseType> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbCaseTypes");


            builder.Property(p => p.PractitionerType)

             .HasConversion(
                v => v.ToString(), // Convert enum to string when storing in database
                 v => (PractitionerTypeEnum)Enum.Parse(typeof(PractitionerTypeEnum), v) // Convert string back to enum when retrieving from database
             );



            //practitioner ----- bridge ----- case type
             builder
             .HasMany<TbPractitionerCase>()
             .WithOne(x => x.TbCaseType)
             .HasForeignKey(x => x.CaseId)
              .IsRequired();


            builder
           .HasMany<TbPractitionerCase>()
           .WithOne(x => x.TbCaseType)
           .HasForeignKey(x => x.PractitionerId)
            .IsRequired();

        }

    }


}
