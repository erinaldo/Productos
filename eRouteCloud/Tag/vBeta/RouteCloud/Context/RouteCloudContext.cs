using Microsoft.EntityFrameworkCore;
using RouteCloud.Models;

namespace RouteCloud.Context
{
    public partial class RouteCloudContext : DbContext
    {
        public RouteCloudContext()
        {
        }

        public RouteCloudContext(DbContextOptions<RouteCloudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<IntPer> IntPer { get; set; }
        public virtual DbSet<IntUsu> IntUsu { get; set; }
        public virtual DbSet<Interfaz> Interfaz { get; set; }
        public virtual DbSet<Mendetalle> Mendetalle { get; set; }
        public virtual DbSet<Mensaje> Mensaje { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ValorReferencia> ValorReferencia { get; set; }
        public virtual DbSet<Varvalor> Varvalor { get; set; }
        public virtual DbSet<Vavdescripcion> Vavdescripcion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.Actid);

                entity.Property(e => e.Actid)
                    .HasColumnName("ACTId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.MendescripcionClave)
                    .IsRequired()
                    .HasColumnName("MENDescripcionClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MennombreClave)
                    .IsRequired()
                    .HasColumnName("MENNombreClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.MendescripcionClaveNavigation)
                    .WithMany(p => p.ActividadMendescripcionClaveNavigation)
                    .HasForeignKey(d => d.MendescripcionClave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividad_MensajeDescripcion");

                entity.HasOne(d => d.MennombreClaveNavigation)
                    .WithMany(p => p.ActividadMennombreClaveNavigation)
                    .HasForeignKey(d => d.MennombreClave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actividad_MensajeNombre");
            });

            modelBuilder.Entity<IntPer>(entity =>
            {
                entity.HasKey(e => new { e.Actid, e.InttipoInterfaz, e.Perclave });

                entity.Property(e => e.Actid)
                    .HasColumnName("ACTId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InttipoInterfaz).HasColumnName("INTTipoInterfaz");

                entity.Property(e => e.Perclave)
                    .HasColumnName("PERClave")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modid)
                    .IsRequired()
                    .HasColumnName("MODId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Permiso)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.IntPer)
                    .HasForeignKey(d => d.Modid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntPer_Modulo");

                entity.HasOne(d => d.PerclaveNavigation)
                    .WithMany(p => p.IntPer)
                    .HasForeignKey(d => d.Perclave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntPer_Perfil");

                entity.HasOne(d => d.Interfaz)
                    .WithMany(p => p.IntPer)
                    .HasForeignKey(d => new { d.Actid, d.InttipoInterfaz })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntPer_Interfaz");
            });

            modelBuilder.Entity<IntUsu>(entity =>
            {
                entity.HasKey(e => new { e.Actid, e.InttipoInterfaz, e.Usuid });

                entity.Property(e => e.Actid)
                    .HasColumnName("ACTId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InttipoInterfaz).HasColumnName("INTTipoInterfaz");

                entity.Property(e => e.Usuid)
                    .HasColumnName("USUId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modid)
                    .HasColumnName("MODId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Permiso)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.IntUsu)
                    .HasForeignKey(d => d.Modid)
                    .HasConstraintName("FK_IntUsu_Modulo");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.IntUsu)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntUsu_Usuario");

                entity.HasOne(d => d.Interfaz)
                    .WithMany(p => p.IntUsu)
                    .HasForeignKey(d => new { d.Actid, d.InttipoInterfaz })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntUsu_Interfaz");
            });

            modelBuilder.Entity<Interfaz>(entity =>
            {
                entity.HasKey(e => new { e.Actid, e.InttipoInterfaz });

                entity.Property(e => e.Actid)
                    .HasColumnName("ACTId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InttipoInterfaz).HasColumnName("INTTipoInterfaz");

                entity.Property(e => e.Clase)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Componente)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FolioId)
                    .HasColumnName("FolioID")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modid)
                    .IsRequired()
                    .HasColumnName("MODId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloMovDetalleClave)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Permiso)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Procedimiento)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Act)
                    .WithMany(p => p.Interfaz)
                    .HasForeignKey(d => d.Actid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interfaz_Actividad");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.Interfaz)
                    .HasForeignKey(d => d.Modid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Interfaz_Modulo");
            });

            modelBuilder.Entity<Mendetalle>(entity =>
            {
                entity.HasKey(e => new { e.Menclave, e.MedtipoLenguaje });

                entity.ToTable("MENDetalle");

                entity.Property(e => e.Menclave)
                    .HasColumnName("MENClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MedtipoLenguaje)
                    .HasColumnName("MEDTipoLenguaje")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.MenclaveNavigation)
                    .WithMany(p => p.Mendetalle)
                    .HasForeignKey(d => d.Menclave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENDetalle_Mensaje");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.Menclave);

                entity.Property(e => e.Menclave)
                    .HasColumnName("MENClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TipoAplicacion).HasDefaultValueSql("(1)");

                entity.Property(e => e.TipoMensaje)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.Modid);

                entity.Property(e => e.Modid)
                    .HasColumnName("MODId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.MendescripcionClave)
                    .IsRequired()
                    .HasColumnName("MENDescripcionClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MennombreClave)
                    .IsRequired()
                    .HasColumnName("MENNombreClave")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modid1)
                    .HasColumnName("MODId1")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.MendescripcionClaveNavigation)
                    .WithMany(p => p.ModuloMendescripcionClaveNavigation)
                    .HasForeignKey(d => d.MendescripcionClave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulo_MensajeDescripcion");

                entity.HasOne(d => d.MennombreClaveNavigation)
                    .WithMany(p => p.ModuloMennombreClaveNavigation)
                    .HasForeignKey(d => d.MennombreClave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modulo_MensajeNombre");

                entity.HasOne(d => d.Modid1Navigation)
                    .WithMany(p => p.InverseModid1Navigation)
                    .HasForeignKey(d => d.Modid1)
                    .HasConstraintName("FK_Modulo_Modulo");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.Perclave);

                entity.Property(e => e.Perclave)
                    .HasColumnName("PERClave")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Usuid);

                entity.HasIndex(e => e.Clave)
                    .HasName("AKUsuario")
                    .IsUnique();

                entity.Property(e => e.Usuid)
                    .HasColumnName("USUId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AlmacenId)
                    .IsRequired()
                    .HasColumnName("AlmacenID")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveAcceso)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Perclave)
                    .IsRequired()
                    .HasColumnName("PERClave")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PoliticaId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PerclaveNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Perclave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Perfil");
            });

            modelBuilder.Entity<ValorReferencia>(entity =>
            {
                entity.HasKey(e => e.Varcodigo);

                entity.Property(e => e.Varcodigo)
                    .HasColumnName("VARCodigo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioId")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDato)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Varvalor>(entity =>
            {
                entity.HasKey(e => new { e.Varcodigo, e.Vavclave });

                entity.ToTable("VARValor");

                entity.Property(e => e.Varcodigo)
                    .HasColumnName("VARCodigo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Vavclave)
                    .HasColumnName("VAVClave")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveSat)
                    .HasColumnName("ClaveSAT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioID")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.VarcodigoNavigation)
                    .WithMany(p => p.Varvalor)
                    .HasForeignKey(d => d.Varcodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VARValor_ValorReferencia");
            });

            modelBuilder.Entity<Vavdescripcion>(entity =>
            {
                entity.HasKey(e => new { e.Varcodigo, e.Vavclave, e.VadtipoLenguaje });

                entity.ToTable("VAVDescripcion");

                entity.Property(e => e.Varcodigo)
                    .HasColumnName("VARCodigo")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Vavclave)
                    .HasColumnName("VAVClave")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.VadtipoLenguaje)
                    .HasColumnName("VADTipoLenguaje")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSat)
                    .HasColumnName("DescripcionSAT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MfechaHora)
                    .HasColumnName("MFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MusuarioId)
                    .IsRequired()
                    .HasColumnName("MUsuarioID")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Va)
                    .WithMany(p => p.Vavdescripcion)
                    .HasForeignKey(d => new { d.Varcodigo, d.Vavclave })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VAVDescripcion_VARValor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
