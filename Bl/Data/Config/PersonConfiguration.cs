namespace BusinessLib.Data.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<TbPerson>
    {
        public void Configure(EntityTypeBuilder<TbPerson> builder)
        {

            builder.HasKey(x => x.Id);
            builder.ToTable("TbPeople");

            builder
                    .HasOne(e => e.TbCountry)
                    .WithMany()
                    .HasForeignKey(e => e.CountryId)
                    .IsRequired();

        }

    }

}
