using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class EventMap: IEntityTypeConfiguration<Event>
  {

    public void Map(EntityTypeBuilder<Event> builder)
    {
      //Primary Key
      builder.HasKey(c => c.Id);

      //Properties

      //Table & Column Mapping
      builder.ToTable("event_tbl");

      builder.Property(c => c.Id).HasColumnName("event_id");
      builder.Property(c => c.Complete).HasColumnName("complete");
      builder.Property(c => c.Title).HasColumnName("title");
    }
  }
}
