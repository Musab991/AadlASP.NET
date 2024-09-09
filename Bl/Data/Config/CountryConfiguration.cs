namespace BusinessLib.Data.Config
{
    public class CountryConfiguration : IEntityTypeConfiguration<TbCountry>
    {
        public void Configure(EntityTypeBuilder<TbCountry> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("TbCounrties");

            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
           
            builder.HasData(
              new TbCountry { Id = 51, Name = "Jordan" },
              new TbCountry { Id = 1, Name = "United States" },
              new TbCountry { Id = 2, Name = "Canada" },
              new TbCountry { Id = 3, Name = "Mexico" },
              new TbCountry { Id = 4, Name = "Brazil" },
              new TbCountry { Id = 5, Name = "Argentina" },
              new TbCountry { Id = 6, Name = "United Kingdom" },
              new TbCountry { Id = 7, Name = "Germany" },
              new TbCountry { Id = 8, Name = "France" },
              new TbCountry { Id = 9, Name = "Italy" },
              new TbCountry { Id = 10, Name = "Spain" },
              new TbCountry { Id = 11, Name = "Russia" },
              new TbCountry { Id = 12, Name = "China" },
              new TbCountry { Id = 13, Name = "Japan" },
              new TbCountry { Id = 14, Name = "South Korea" },
              new TbCountry { Id = 15, Name = "India" },
              new TbCountry { Id = 16, Name = "Australia" },
              new TbCountry { Id = 17, Name = "New Zealand" },
              new TbCountry { Id = 18, Name = "South Africa" },
              new TbCountry { Id = 19, Name = "Egypt" },
              new TbCountry { Id = 20, Name = "Nigeria" },
              new TbCountry { Id = 21, Name = "Kenya" },
              new TbCountry { Id = 22, Name = "Saudi Arabia" },
              new TbCountry { Id = 23, Name = "United Arab Emirates" },
              new TbCountry { Id = 24, Name = "Turkey" },
              new TbCountry { Id = 25, Name = "Iran" },
              new TbCountry { Id = 26, Name = "Israel" },
              new TbCountry { Id = 27, Name = "Pakistan" },
              new TbCountry { Id = 28, Name = "Bangladesh" },
              new TbCountry { Id = 29, Name = "Indonesia" },
              new TbCountry { Id = 30, Name = "Vietnam" },
              new TbCountry { Id = 31, Name = "Thailand" },
              new TbCountry { Id = 32, Name = "Malaysia" },
              new TbCountry { Id = 33, Name = "Singapore" },
              new TbCountry { Id = 34, Name = "Philippines" },
              new TbCountry { Id = 35, Name = "Greece" },
              new TbCountry { Id = 36, Name = "Sweden" },
              new TbCountry { Id = 37, Name = "Norway" },
              new TbCountry { Id = 38, Name = "Denmark" },
              new TbCountry { Id = 39, Name = "Finland" },
              new TbCountry { Id = 40, Name = "Poland" },
              new TbCountry { Id = 41, Name = "Netherlands" },
              new TbCountry { Id = 42, Name = "Belgium" },
              new TbCountry { Id = 43, Name = "Switzerland" },
              new TbCountry { Id = 44, Name = "Austria" },
              new TbCountry { Id = 45, Name = "Portugal" },
              new TbCountry { Id = 46, Name = "Chile" },
              new TbCountry { Id = 47, Name = "Colombia" },
              new TbCountry { Id = 48, Name = "Peru" },
              new TbCountry { Id = 49, Name = "Venezuela" },
              new TbCountry { Id = 50, Name = "Cuba" }
          );

        }

    }

}
