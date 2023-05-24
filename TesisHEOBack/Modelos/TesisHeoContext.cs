using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TesisHEOBack.Modelos;

public partial class TesisHeoContext : DbContext
{
    public TesisHeoContext()
    {
    }

    public TesisHeoContext(DbContextOptions<TesisHeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Estadocliente> Estadoclientes { get; set; }

    public virtual DbSet<Estadop> Estadops { get; set; }

    public virtual DbSet<Estadoservicio> Estadoservicios { get; set; }

    public virtual DbSet<Estadot> Estadots { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Serviciotecnico> Serviciotecnicos { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    public virtual DbSet<Tiposervicio> Tiposervicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TesisHEO;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__CLIENTE__1EA344C2F2C98EB6");

            entity.ToTable("CLIENTE", tb => tb.HasTrigger("generar_pago_pendiente"));

            entity.HasIndex(e => e.Idcliente, "CLIENTE_PK").IsUnique();

            entity.HasIndex(e => e.Idservicio, "RELATION_24_FK");

            entity.HasIndex(e => e.Idestadoc, "RELATION_324_FK");

            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Direccionc)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCIONC");
            entity.Property(e => e.Dnic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DNIC");
            entity.Property(e => e.Idestadoc).HasColumnName("IDESTADOC");
            entity.Property(e => e.Idservicio).HasColumnName("IDSERVICIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Pagopendiente)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("PAGOPENDIENTE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdestadocNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idestadoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENTE__IDESTAD__35BCFE0A");

            entity.HasOne(d => d.IdservicioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idservicio)
                .HasConstraintName("FK__CLIENTE__IDSERVI__34C8D9D1");
        });

        modelBuilder.Entity<Estadocliente>(entity =>
        {
            entity.HasKey(e => e.Idestadoc).HasName("PK__ESTADOCL__EB96EBB9C260B106");

            entity.ToTable("ESTADOCLIENTE");

            entity.HasIndex(e => e.Idestadoc, "ESTADOCLIENTE_PK").IsUnique();

            entity.Property(e => e.Idestadoc).HasColumnName("IDESTADOC");
            entity.Property(e => e.Estadocliente1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ESTADOCLIENTE");
        });

        modelBuilder.Entity<Estadop>(entity =>
        {
            entity.HasKey(e => e.Idestadop).HasName("PK__ESTADOP__EB96EB8A5705F2DD");

            entity.ToTable("ESTADOP");

            entity.HasIndex(e => e.Idestadop, "ESTADOP_PK").IsUnique();

            entity.Property(e => e.Idestadop).HasColumnName("IDESTADOP");
            entity.Property(e => e.Estadop1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOP");
        });

        modelBuilder.Entity<Estadoservicio>(entity =>
        {
            entity.HasKey(e => e.Idestadoservicio).HasName("PK__ESTADOSE__6EE6C458546BFABB");

            entity.ToTable("ESTADOSERVICIO");

            entity.HasIndex(e => e.Idestadoservicio, "ESTADOSERVICIO_PK").IsUnique();

            entity.Property(e => e.Idestadoservicio).HasColumnName("IDESTADOSERVICIO");
            entity.Property(e => e.Estadoservicio1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOSERVICIO");
        });

        modelBuilder.Entity<Estadot>(entity =>
        {
            entity.HasKey(e => e.Idestado).HasName("PK__ESTADOT__A93E12E2C2835D22");

            entity.ToTable("ESTADOT");

            entity.HasIndex(e => e.Idestado, "ESTADOT_PK").IsUnique();

            entity.Property(e => e.Idestado).HasColumnName("IDESTADO");
            entity.Property(e => e.Estadot1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOT");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Idfactura).HasName("PK__PAGO__F7D4C9C7D072721B");

            entity.ToTable("PAGO");

            entity.HasIndex(e => e.Idfactura, "PAGO_PK").IsUnique();

            entity.HasIndex(e => e.Idcliente, "RELATION_55_FK");

            entity.HasIndex(e => e.Idestadop, "RELATION_57_FK");

            entity.Property(e => e.Idfactura).HasColumnName("IDFACTURA");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("FECHA");
            entity.Property(e => e.Fechapagado)
                .HasColumnType("date")
                .HasColumnName("FECHAPAGADO");
            entity.Property(e => e.Fechavencimiento)
                .HasColumnType("date")
                .HasColumnName("FECHAVENCIMIENTO");
            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Idestadop).HasColumnName("IDESTADOP");
            entity.Property(e => e.Preciototal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIOTOTAL");
            entity.Property(e => e.Serviciop)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SERVICIOP");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PAGO__IDCLIENTE__38996AB5");

            entity.HasOne(d => d.IdestadopNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Idestadop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PAGO__IDESTADOP__398D8EEE");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__ROL__A686519E6CE78990");

            entity.ToTable("ROL");

            entity.HasIndex(e => e.Idrol, "ROL_PK").IsUnique();

            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROL");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicio).HasName("PK__SERVICIO__ED07F46ED1E3C88B");

            entity.ToTable("SERVICIO");

            entity.HasIndex(e => e.Idservicio, "SERVICIO_PK").IsUnique();

            entity.Property(e => e.Idservicio).HasColumnName("IDSERVICIO");
            entity.Property(e => e.Bajada)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("BAJADA");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Servicio1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SERVICIO");
            entity.Property(e => e.Subida)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SUBIDA");
        });

        modelBuilder.Entity<Serviciotecnico>(entity =>
        {
            entity.HasKey(e => e.Idproblemat).HasName("PK__SERVICIO__3EFB96B83E32BF3C");

            entity.ToTable("SERVICIOTECNICO");

            entity.HasIndex(e => e.Idtiposerviciot, "RELATION_261_FK");

            entity.HasIndex(e => e.Idtecnico, "RELATION_65_FK");

            entity.HasIndex(e => e.Idcliente, "RELATION_66_FK");

            entity.HasIndex(e => e.Idestadoservicio, "RELATION_73_FK");

            entity.HasIndex(e => e.Idproblemat, "SERVICIOTECNICO_PK").IsUnique();

            entity.Property(e => e.Idproblemat).HasColumnName("IDPROBLEMAT");
            entity.Property(e => e.Descripcionserviciot)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIONSERVICIOT");
            entity.Property(e => e.Fechainicio)
                .HasColumnType("date")
                .HasColumnName("FECHAINICIO");
            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Idestadoservicio).HasColumnName("IDESTADOSERVICIO");
            entity.Property(e => e.Idtecnico).HasColumnName("IDTECNICO");
            entity.Property(e => e.Idtiposerviciot).HasColumnName("IDTIPOSERVICIOT");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Serviciotecnicos)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICIOT__IDCLI__3D5E1FD2");

            entity.HasOne(d => d.IdestadoservicioNavigation).WithMany(p => p.Serviciotecnicos)
                .HasForeignKey(d => d.Idestadoservicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICIOT__IDEST__3E52440B");

            entity.HasOne(d => d.IdtecnicoNavigation).WithMany(p => p.Serviciotecnicos)
                .HasForeignKey(d => d.Idtecnico)
                .HasConstraintName("FK__SERVICIOT__IDTEC__3C69FB99");

            entity.HasOne(d => d.IdtiposerviciotNavigation).WithMany(p => p.Serviciotecnicos)
                .HasForeignKey(d => d.Idtiposerviciot)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICIOT__IDTIP__3F466844");
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Idtecnico).HasName("PK__TECNICO__1391A383D7D55BC7");

            entity.ToTable("TECNICO");

            entity.HasIndex(e => e.Idestado, "RELATION_36_FK");

            entity.HasIndex(e => e.Idtecnico, "TECNICO_PK").IsUnique();

            entity.Property(e => e.Idtecnico).HasColumnName("IDTECNICO");
            entity.Property(e => e.Apellidot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOT");
            entity.Property(e => e.Casosnum).HasColumnName("CASOSNUM");
            entity.Property(e => e.Idestado).HasColumnName("IDESTADO");
            entity.Property(e => e.Nombret)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRET");
            entity.Property(e => e.Telefonot)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONOT");

            entity.HasOne(d => d.IdestadoNavigation).WithMany(p => p.Tecnicos)
                .HasForeignKey(d => d.Idestado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TECNICO__IDESTAD__31EC6D26");
        });

        modelBuilder.Entity<Tiposervicio>(entity =>
        {
            entity.HasKey(e => e.Idtiposerviciot).HasName("PK__TIPOSERV__EB88F98DFE03C163");

            entity.ToTable("TIPOSERVICIO");

            entity.HasIndex(e => e.Idtiposerviciot, "TIPOSERVICIO_PK").IsUnique();

            entity.Property(e => e.Idtiposerviciot).HasColumnName("IDTIPOSERVICIOT");
            entity.Property(e => e.Tiposervicio1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TIPOSERVICIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__USUARIO__98242AA9329ED134");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Idrol, "RELATION_86_FK");

            entity.HasIndex(e => e.Idusuario, "USUARIO_PK").IsUnique();

            entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");
            entity.Property(e => e.Idrol).HasColumnName("IDROL");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIO__IDROL__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
