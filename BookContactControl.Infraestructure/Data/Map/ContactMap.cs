using BookContactControl.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;


namespace BookContactControl.Infraestructure.Data.Map
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            ToTable("Contact");

            Property(x => x.Email)
                .HasMaxLength(120)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_EMAIL",1) { IsUnique = true }))                
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(60)
                .IsRequired();    

            Property(x => x.Phone)
                .HasMaxLength(15)
                .IsRequired();

        }
        
    }
}