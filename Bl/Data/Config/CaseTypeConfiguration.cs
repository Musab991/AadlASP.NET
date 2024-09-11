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


            builder.Property(p => p.PractitionerTypeId);

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
