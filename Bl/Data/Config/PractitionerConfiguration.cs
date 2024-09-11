

using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace BusinessLib.Data.Config
{
    public class PractitionerConfiguration : IEntityTypeConfiguration<TbPractitioner>
    {
        public void Configure(EntityTypeBuilder<TbPractitioner> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbPractitioners");


            builder.Property(p => p.PractitionerTypeId).IsRequired();


            builder.HasOne(e => e.TbPerson)
                   .WithOne()
                   .HasForeignKey<TbPractitioner>("PersonId")
                   .IsRequired();


            builder.HasOne(e => e.TbPractitionerSpec)
                   .WithOne()
                   .HasForeignKey<TbPractitionerSpec>("PractitionerId")
                   .IsRequired();

            //Constraint uniuqe names... 

        


        }

    }
}
