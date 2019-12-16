using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class ContentsMap : IEntityTypeConfiguration<Content>
  {
    public void Map(EntityTypeBuilder<Content> builder)
    {
      //Primary Key
      //HasKey(c => c.Id);

      //Properties


      //Table & Column Mapping
      builder.ToTable("content");
      builder.Property(c => c.Id).HasColumnName("content_id").IsRequired();
      builder.Property(c => c.Title).HasColumnName("content_title");
      builder.Property(c => c.Html).HasColumnName("content_html");
      builder.Property(c => c.Summary).HasColumnName("content_teaser");
      builder.Property(c => c.XmlConfigId).HasColumnName("xml_config_id");
      builder.Property(c => c.FolderId).HasColumnName("folder_id"); /*.IsOptional();*/
      //builder.HasOptional(c => c.Folder);
    }
  }
}
