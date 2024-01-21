/* using System; */
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.EntityFrameworkCore.Metadata;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class NoteMap : IEntityTypeConfiguration<Note>
  {
    public void Configure(EntityTypeBuilder<Note> builder)
    {
      //Primary Key
      builder.HasKey(c => new { c.Id, c.UserId });

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
      builder.Property(c => c.Archived).HasColumnName("archived");
      builder.Property(c => c.ArchivedDate).HasColumnName("archived_date").HasDefaultValueSql("NULL");
      builder.Property(c => c.Active).HasColumnName("active");
      builder.Property(c => c.DateCreated).HasColumnName("date_created").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
      builder.Property(c => c.PinOrder).HasColumnName("pin_order").HasDefaultValueSql("NULL");

      builder.Property<DateTime>(c => c.DateModified).HasColumnName("date_modified");
      // builder.Property<DateTime>(c => c.DateModified).ValueGeneratedOnAddOrUpdate();
      // builder.Property(c => c.DateModified).HasComputedColumnSql("date_modified");
      // builder.Property(c => c.DateModified).HasDefaultValueSql("current_timestamp()");
      // builder.Property<DateTime>(c => c.DateModified).HasColumnType("datetime");
      // builder.Property(c => c.DateModified).Metadata.AddAnnotation("MySql:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
      // builder.Property<DateTime>(c => c.DateModified).HasDefaultValueSql("current_timestamp() ON UPDATE current_timestamp()");
      // builder.Property<DateTime>(c => c.DateModified).HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
      builder.Property<DateTime>(c => c.DateModified).HasDefaultValueSql("CURRENT_TIMESTAMP");
      // builder.Property(c => c.DateModified).IsConcurrencyToken();
      // builder.Property<DateTime>(c => c.DateModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Save);
      // builder.Property<DateTime>(c => c.DateModified).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
      // builder.Property<DateTime>(c => c.DateModified).ValueGeneratedOnAddOrUpdate();
      
      //Table & Column Mapping
      builder.ToTable("note_tbl");
    }
  }
}
