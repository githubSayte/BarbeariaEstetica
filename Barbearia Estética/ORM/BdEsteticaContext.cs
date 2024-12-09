using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Barbearia_Estética.ORM;

public partial class BdEsteticaContext : DbContext
{
    public BdEsteticaContext()
    {
    }

    public BdEsteticaContext(DbContextOptions<BdEsteticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAgendamento> TbAgendamentos { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<ViewAgendamento> ViewAgendamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_2\\SQLEXPRESS;Database= BD_Estetica;User Id=Renato;Password=meubanco;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_100_CI_AI");

        modelBuilder.Entity<TbAgendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TbAgenda__3214EC07DED6EB73");

            entity.ToTable("TbAgendamento");

            entity.Property(e => e.DtHoraAgendamento).HasColumnType("datetime");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");

            entity.HasOne(d => d.FkServico).WithMany(p => p.TbAgendamentos)
                .HasForeignKey(d => d.FkServicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAgendamento_Tb_Servico");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.TbAgendamentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAgendamento_TbUsuario");
        });

        modelBuilder.Entity<TbServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Servi__3214EC272978050F");

            entity.ToTable("Tb_Servico");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TipoServico)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TbUsuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewAgendamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewAgendamento");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoServico)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
