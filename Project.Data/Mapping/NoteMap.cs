/* using System; */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class NoteMap : IEntityTypeConfiguration<Note>
  {
    public void Configure(EntityTypeBuilder<Note> builder)
    {
      //Primary Key
      builder.HasKey(c => c.Id);

      //Properties
      builder.Property(c => c.Id).HasColumnName("note_id");
      builder.Property(c => c.UserId).HasColumnName("user_id");
      builder.Property(c => c.Height).HasColumnName("height");
      builder.Property(c => c.Width).HasColumnName("width");
      builder.Property(c => c.Top).HasColumnName("top");
      builder.Property(c => c.Left).HasColumnName("left");
      builder.Property(c => c.Colour).HasColumnName("colour");
      builder.Property(c => c.Text).HasColumnName("text");
      builder.Property(c => c.Header).HasColumnName("header");

      //Table & Column Mapping
      builder.ToTable("note_tbl");
    }
  }
}
