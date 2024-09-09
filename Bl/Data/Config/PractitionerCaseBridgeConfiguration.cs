namespace BusinessLib.Data.Config
{
    public class PractitionerCaseBridgeConfiguration : IEntityTypeConfiguration<TbPractitionerCase>
    {
        public void Configure(EntityTypeBuilder<TbPractitionerCase> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbPractitionersCases");

            builder.Property(p => p.PractitionerType)

             .HasConversion(
                v => v.ToString(), // Convert enum to string when storing in database
                 v => (PractitionerTypeEnum)Enum.Parse(typeof(PractitionerTypeEnum), v) // Convert string back to enum when retrieving from database
             );

        }

    }


}
