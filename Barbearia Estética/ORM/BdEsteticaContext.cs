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

    public virtual DbSet<TbAtendimento> TbAtendimentos { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<ViewAtendimento> ViewAtendimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAB205_2\\SQLEXPRESS;Database= BD_Estetica;User Id=Renato;Password=meubanco;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_100_CI_AI");

        modelBuilder.Entity<TbAtendimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tb_Agendamento");

            entity.ToTable("Tb_Atendimento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");
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

        modelBuilder.Entity<ViewAtendimento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Atendimento");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
