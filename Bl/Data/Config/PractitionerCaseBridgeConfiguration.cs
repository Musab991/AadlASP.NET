namespace BusinessLib.Data.Config
{
    public class PractitionerCaseBridgeConfiguration : IEntityTypeConfiguration<TbPractitionerCase>
    {
        public void Configure(EntityTypeBuilder<TbPractitionerCase> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbPractitionersCases");

            builder.Property(p => p.PractitionerTypeId)
                .HasColumnName("PractitionerTypeId").HasColumnType("INT").IsRequired();

        

        }

    }


}
