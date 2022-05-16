using Project.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Project.Data.Mapping
{
  public class CategoryMap : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      //Primary Key
      builder.HasKey(c => c.Id);

      //Properties
      builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
      builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
      builder.Property(c => c.SubCategoryId).HasColumnName("SubCategory_Id");/*.IsOptional();*/
      //builder.HasOptional(c => c.SubCategory);

      //Table & Column Mapping
      builder.ToTable("Categories");
    }
  }
}
