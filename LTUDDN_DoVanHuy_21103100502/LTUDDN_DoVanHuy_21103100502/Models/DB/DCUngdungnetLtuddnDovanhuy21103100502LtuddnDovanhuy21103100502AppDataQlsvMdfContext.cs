using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LTUDDN_DoVanHuy_21103100502.Models.DB;

public partial class DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext : DbContext
{
    public DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext()
    {
    }

    public DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext(DbContextOptions<DCUngdungnetLtuddnDovanhuy21103100502LtuddnDovanhuy21103100502AppDataQlsvMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\c#\\UngDungNet\\LTUDDN_DoVanHuy_21103100502\\LTUDDN_DoVanHuy_21103100502\\App_data\\qlsv.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diem>(entity =>
        {
            entity.HasKey(e => new { e.Masv, e.Tenmh }).HasName("PK__Diem__55964B306BE7735F");

            entity.ToTable("Diem");

            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("masv");
            entity.Property(e => e.Tenmh)
                .HasMaxLength(50)
                .HasColumnName("tenmh");
            entity.Property(e => e.Diem1).HasColumnName("diem");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__masv__29572725");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__SinhVien__7A21767C27090C8B");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("masv");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Namsinh).HasColumnName("namsinh");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
