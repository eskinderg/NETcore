using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class EventMap : IEntityTypeConfiguration<Event>
  {
    public void Configure(EntityTypeBuilder<Event> builder)
    {
      //Primary Key
      builder.HasKey(c => new { c.Id, c.UserID });

      //Table & Column Mapping
      builder.ToTable("event_tbl");

      //Properties
      builder.Property(c => c.Id).HasColumnName("event_id");
      builder.Property(c => c.Complete).HasColumnName("complete");
      builder.Property(c => c.Title).HasColumnName("title");
      builder.Property(c => c.UserID).HasColumnName("user_id");
    }
  }
}
