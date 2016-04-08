using System.Data.Entity.ModelConfiguration;
using SOLID.Global.Models;

namespace SOLID.Context.Mappings
{
    public class SecondMap : EntityTypeConfiguration<Second>
    {
        public SecondMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.ActiviteitSoortId)
            //    .IsRequired();

            // Table & Column Mappings
            this.ToTable("Second");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");


            // Relationships
        }
    }
}
