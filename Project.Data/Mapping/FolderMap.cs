﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Model.Models;

namespace Project.Data.Mapping
{
  public class FolderMap : IEntityTypeConfiguration<Folder>
  {
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
      //Primary Key
      builder.HasKey(c => c.Id);

      //Properties
      builder.Property(c => c.Id).HasColumnName("folder_id");
      builder.Property(c => c.ParentId).HasColumnName("parent_id");
      builder.Property(c => c.Name).HasColumnName("folder_name");

      //Table & Column Mapping
      builder.ToTable("content_folder_tbl");

      //HasOptional(f=>f.Parent)
      //    .WithMany(f=>f.Children)
      //    .HasForeignKey(f=>f.ParentId)
      //    .WillCascadeOnDelete(false);
    }
  }
}
