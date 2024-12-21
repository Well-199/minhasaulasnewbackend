using Microsoft.EntityFrameworkCore;

namespace minhasaulasnewbackend.Models;

public partial class MinhasaulasContext : DbContext
{
    public MinhasaulasContext()
    {
    }

    public MinhasaulasContext(DbContextOptions<MinhasaulasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Fechamento> Fechamentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql($"Host={Environment.GetEnvironmentVariable("DB_HOST")};Username={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASS")};Database={Environment.GetEnvironmentVariable("DB_NAME")};");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aulas_pk");

            entity.ToTable("aulas", "minhasaulas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('aulas_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Conteudo)
                .HasColumnType("character varying")
                .HasColumnName("conteudo");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created");
            entity.Property(e => e.Data)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data");
            entity.Property(e => e.Escola)
                .HasColumnType("character varying")
                .HasColumnName("escola");
            entity.Property(e => e.HoraFinal).HasColumnName("hora_final");
            entity.Property(e => e.HoraInicial).HasColumnName("hora_inicial");
            entity.Property(e => e.Modified)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified");
            entity.Property(e => e.TotalHoras)
                .HasDefaultValueSql("0")
                .HasColumnType("character varying")
                .HasColumnName("total_horas");
            entity.Property(e => e.Turma)
                .HasColumnType("character varying")
                .HasColumnName("turma");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Valor)
                .HasPrecision(12, 2)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Fechamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carteira_pk");

            entity.ToTable("fechamentos", "minhasaulas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('carteira_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created");
            entity.Property(e => e.DataFinal)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_final");
            entity.Property(e => e.DataInicial)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_inicial");
            entity.Property(e => e.Modified)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified");
            entity.Property(e => e.Quantidade)
                .HasDefaultValue(0)
                .HasColumnName("quantidade");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Valor)
                .HasPrecision(12, 2)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pk");

            entity.ToTable("usuarios", "minhasaulas");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('usuarios_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.CodCli)
                .HasMaxLength(8)
                .HasDefaultValueSql("0")
                .HasColumnName("cod_cli");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created");
            entity.Property(e => e.Device)
                .HasColumnType("character varying")
                .HasColumnName("device");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Modified)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified");
            entity.Property(e => e.Nome)
                .HasColumnType("character varying")
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasColumnType("character varying")
                .HasColumnName("senha");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
            entity.Property(e => e.ValorHora)
                .HasPrecision(12, 2)
                .HasColumnName("valor_hora");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
