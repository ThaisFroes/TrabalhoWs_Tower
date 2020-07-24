using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api.Models
{
    public partial class WSTower_appContext : DbContext
    {
        public WSTower_appContext()
        {
        }

        public WSTower_appContext(DbContextOptions<WSTower_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraIngressos> CompraIngressos { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public virtual DbSet<IngressosVendidos> IngressosVendidos { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Times> Times { get; set; }
        public virtual DbSet<TipoDeIngresso> TipoDeIngresso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OEOULMOC\\SQLEXPRESS;Database=WSTower_app;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CompraIngressos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.IdFormaDePagamentoNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdFormaDePagamento)
                    .HasConstraintName("FK__CompraIng__IdFor__34C8D9D1");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK__CompraIng__IdJog__37A5467C");

                entity.HasOne(d => d.IdTipoDeIngressoNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdTipoDeIngresso)
                    .HasConstraintName("FK__CompraIng__IdTip__36B12243");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CompraIngressos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CompraIng__IdUsu__35BCFE0A");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaDePagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaDePagamento)
                    .HasName("PK__FormaDeP__12144A7F690FD8DC");

                entity.Property(e => e.FormaDePagamento1)
                    .IsRequired()
                    .HasColumnName("Forma_de_Pagamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IngressosVendidos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NumeroDoIngresso)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.IngressosVendidos)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK__Ingressos__IdCom__3A81B327");
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Campeonato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Detalhes).HasColumnType("text");

                entity.Property(e => e.Horario).HasColumnType("datetime");

                entity.HasOne(d => d.IdEstadioNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdEstadio)
                    .HasConstraintName("FK__Jogos__IdEstadio__31EC6D26");

                entity.HasOne(d => d.IdTimeCasaNavigation)
                    .WithMany(p => p.JogosIdTimeCasaNavigation)
                    .HasForeignKey(d => d.IdTimeCasa)
                    .HasConstraintName("FK__Jogos__IdTimeCas__30F848ED");

                entity.HasOne(d => d.IdTimeVisitanteNavigation)
                    .WithMany(p => p.JogosIdTimeVisitanteNavigation)
                    .HasForeignKey(d => d.IdTimeVisitante)
                    .HasConstraintName("FK__Jogos__IdTimeVis__300424B4");
            });

            modelBuilder.Entity<Times>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bandeira).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDeIngresso>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeIngresso)
                    .HasName("PK__TipoDeIn__F2745ADFC93626B9");

                entity.Property(e => e.TipoDeIngresso1)
                    .IsRequired()
                    .HasColumnName("Tipo_de_Ingresso")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.NomeUsuario)
                    .HasName("UQ__Usuario__06940B9A5102F6C3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
