﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesisHEOBack.Modelos;

#nullable disable

namespace Modelos.Migrations
{
    [DbContext(typeof(TesisHeoContext))]
    partial class TesisHeoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TesisHEOBack.Modelos.Cliente", b =>
                {
                    b.Property<int>("Idcliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDCLIENTE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("APELLIDO");

                    b.Property<string>("Direccionc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DIRECCIONC");

                    b.Property<string>("Dnic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("DNIC");

                    b.Property<int>("Idestadoc")
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOC");

                    b.Property<int?>("Idservicio")
                        .HasColumnType("int")
                        .HasColumnName("IDSERVICIO");

                    b.Property<decimal>("Instalado")
                        .HasColumnType("numeric(1, 0)")
                        .HasColumnName("INSTALADO");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.Property<decimal>("Pagopendiente")
                        .HasColumnType("numeric(1, 0)")
                        .HasColumnName("PAGOPENDIENTE");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TELEFONO");

                    b.HasKey("Idcliente")
                        .HasName("PK__CLIENTE__1EA344C2BF3715C5");

                    b.HasIndex("Idestadoc");

                    b.HasIndex("Idservicio");

                    b.ToTable("CLIENTE", null, t =>
                        {
                            t.HasTrigger("tr_generar_pago_pendiente");
                        });
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadocliente", b =>
                {
                    b.Property<int>("Idestadoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idestadoc"));

                    b.Property<string>("Estadocliente1")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ESTADOCLIENTE");

                    b.HasKey("Idestadoc")
                        .HasName("PK__ESTADOCL__EB96EBB946AE2A90");

                    b.ToTable("ESTADOCLIENTE", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadop", b =>
                {
                    b.Property<int>("Idestadop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idestadop"));

                    b.Property<string>("Estadop1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ESTADOP");

                    b.HasKey("Idestadop")
                        .HasName("PK__ESTADOP__EB96EB8A8FD9DEBB");

                    b.ToTable("ESTADOP", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadoservicio", b =>
                {
                    b.Property<int>("Idestadoservicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOSERVICIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idestadoservicio"));

                    b.Property<string>("Estadoservicio1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ESTADOSERVICIO");

                    b.HasKey("Idestadoservicio")
                        .HasName("PK__ESTADOSE__6EE6C45852DE8774");

                    b.ToTable("ESTADOSERVICIO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadot", b =>
                {
                    b.Property<int>("Idestado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDESTADO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idestado"));

                    b.Property<string>("Estadot1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ESTADOT");

                    b.HasKey("Idestado")
                        .HasName("PK__ESTADOT__A93E12E21FE859BE");

                    b.ToTable("ESTADOT", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Pago", b =>
                {
                    b.Property<int>("Idfactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDFACTURA");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idfactura"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("FECHA");

                    b.Property<DateTime?>("Fechapagado")
                        .HasColumnType("date")
                        .HasColumnName("FECHAPAGADO");

                    b.Property<DateTime>("Fechavencimiento")
                        .HasColumnType("date")
                        .HasColumnName("FECHAVENCIMIENTO");

                    b.Property<int>("Idcliente")
                        .HasColumnType("int")
                        .HasColumnName("IDCLIENTE");

                    b.Property<int>("Idestadop")
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOP");

                    b.Property<decimal>("Preciototal")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PRECIOTOTAL");

                    b.Property<string>("Serviciop")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SERVICIOP");

                    b.HasKey("Idfactura")
                        .HasName("PK__PAGO__F7D4C9C70A552A17");

                    b.HasIndex("Idcliente");

                    b.HasIndex("Idestadop");

                    b.ToTable("PAGO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Rol", b =>
                {
                    b.Property<int>("Idrol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDROL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idrol"));

                    b.Property<string>("Rol1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ROL");

                    b.HasKey("Idrol")
                        .HasName("PK__ROL__A686519EA329115F");

                    b.ToTable("ROL", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Servicio", b =>
                {
                    b.Property<int>("Idservicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDSERVICIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idservicio"));

                    b.Property<string>("Bajada")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("BAJADA");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PRECIO");

                    b.Property<string>("Servicio1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SERVICIO");

                    b.Property<string>("Subida")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("SUBIDA");

                    b.HasKey("Idservicio")
                        .HasName("PK__SERVICIO__ED07F46E52416C78");

                    b.ToTable("SERVICIO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Serviciotecnico", b =>
                {
                    b.Property<int>("Idproblemat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPROBLEMAT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idproblemat"));

                    b.Property<string>("Descripcionserviciot")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPCIONSERVICIOT");

                    b.Property<DateTime>("Fechainicio")
                        .HasColumnType("date")
                        .HasColumnName("FECHAINICIO");

                    b.Property<int>("Idcliente")
                        .HasColumnType("int")
                        .HasColumnName("IDCLIENTE");

                    b.Property<int>("Idestadoservicio")
                        .HasColumnType("int")
                        .HasColumnName("IDESTADOSERVICIO");

                    b.Property<int?>("Idtecnico")
                        .HasColumnType("int")
                        .HasColumnName("IDTECNICO");

                    b.Property<int>("Idtiposerviciot")
                        .HasColumnType("int")
                        .HasColumnName("IDTIPOSERVICIOT");

                    b.HasKey("Idproblemat")
                        .HasName("PK__SERVICIO__3EFB96B8C1726752");

                    b.HasIndex("Idcliente");

                    b.HasIndex("Idestadoservicio");

                    b.HasIndex("Idtecnico");

                    b.HasIndex("Idtiposerviciot");

                    b.ToTable("SERVICIOTECNICO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Tecnico", b =>
                {
                    b.Property<int>("Idtecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDTECNICO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idtecnico"));

                    b.Property<string>("Apellidot")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("APELLIDOT");

                    b.Property<int>("Casosnum")
                        .HasColumnType("int")
                        .HasColumnName("CASOSNUM");

                    b.Property<int>("Idestado")
                        .HasColumnType("int")
                        .HasColumnName("IDESTADO");

                    b.Property<string>("Nombret")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRET");

                    b.Property<string>("Telefonot")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TELEFONOT");

                    b.HasKey("Idtecnico")
                        .HasName("PK__TECNICO__1391A383C51AC335");

                    b.HasIndex("Idestado");

                    b.ToTable("TECNICO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Tiposervicio", b =>
                {
                    b.Property<int>("Idtiposerviciot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDTIPOSERVICIOT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idtiposerviciot"));

                    b.Property<string>("Tiposervicio1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TIPOSERVICIO");

                    b.HasKey("Idtiposerviciot")
                        .HasName("PK__TIPOSERV__EB88F98DE0A0C2BE");

                    b.ToTable("TIPOSERVICIO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Usuario", b =>
                {
                    b.Property<int>("Idusuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDUSUARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idusuario"));

                    b.Property<int>("Idrol")
                        .HasColumnType("int")
                        .HasColumnName("IDROL");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Usuario1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("USUARIO");

                    b.HasKey("Idusuario")
                        .HasName("PK__USUARIO__98242AA90B04BEAD");

                    b.HasIndex("Idrol");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Cliente", b =>
                {
                    b.HasOne("TesisHEOBack.Modelos.Estadocliente", "IdestadocNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("Idestadoc")
                        .IsRequired()
                        .HasConstraintName("FK__CLIENTE__IDESTAD__3B75D760");

                    b.HasOne("TesisHEOBack.Modelos.Servicio", "IdservicioNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("Idservicio")
                        .HasConstraintName("FK__CLIENTE__IDSERVI__3C69FB99");

                    b.Navigation("IdestadocNavigation");

                    b.Navigation("IdservicioNavigation");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Pago", b =>
                {
                    b.HasOne("TesisHEOBack.Modelos.Cliente", "IdclienteNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("Idcliente")
                        .IsRequired()
                        .HasConstraintName("FK__PAGO__IDCLIENTE__3D5E1FD2");

                    b.HasOne("TesisHEOBack.Modelos.Estadop", "IdestadopNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("Idestadop")
                        .IsRequired()
                        .HasConstraintName("FK__PAGO__IDESTADOP__3E52440B");

                    b.Navigation("IdclienteNavigation");

                    b.Navigation("IdestadopNavigation");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Serviciotecnico", b =>
                {
                    b.HasOne("TesisHEOBack.Modelos.Cliente", "IdclienteNavigation")
                        .WithMany("Serviciotecnicos")
                        .HasForeignKey("Idcliente")
                        .IsRequired()
                        .HasConstraintName("FK__SERVICIOT__IDCLI__3F466844");

                    b.HasOne("TesisHEOBack.Modelos.Estadoservicio", "IdestadoservicioNavigation")
                        .WithMany("Serviciotecnicos")
                        .HasForeignKey("Idestadoservicio")
                        .IsRequired()
                        .HasConstraintName("FK__SERVICIOT__IDEST__403A8C7D");

                    b.HasOne("TesisHEOBack.Modelos.Tecnico", "IdtecnicoNavigation")
                        .WithMany("Serviciotecnicos")
                        .HasForeignKey("Idtecnico")
                        .HasConstraintName("FK__SERVICIOT__IDTEC__412EB0B6");

                    b.HasOne("TesisHEOBack.Modelos.Tiposervicio", "IdtiposerviciotNavigation")
                        .WithMany("Serviciotecnicos")
                        .HasForeignKey("Idtiposerviciot")
                        .IsRequired()
                        .HasConstraintName("FK__SERVICIOT__IDTIP__4222D4EF");

                    b.Navigation("IdclienteNavigation");

                    b.Navigation("IdestadoservicioNavigation");

                    b.Navigation("IdtecnicoNavigation");

                    b.Navigation("IdtiposerviciotNavigation");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Tecnico", b =>
                {
                    b.HasOne("TesisHEOBack.Modelos.Estadot", "IdestadoNavigation")
                        .WithMany("Tecnicos")
                        .HasForeignKey("Idestado")
                        .IsRequired()
                        .HasConstraintName("FK__TECNICO__IDESTAD__4316F928");

                    b.Navigation("IdestadoNavigation");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Usuario", b =>
                {
                    b.HasOne("TesisHEOBack.Modelos.Rol", "IdrolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("Idrol")
                        .IsRequired()
                        .HasConstraintName("FK__USUARIO__IDROL__440B1D61");

                    b.Navigation("IdrolNavigation");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Cliente", b =>
                {
                    b.Navigation("Pagos");

                    b.Navigation("Serviciotecnicos");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadocliente", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadop", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadoservicio", b =>
                {
                    b.Navigation("Serviciotecnicos");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Estadot", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Servicio", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Tecnico", b =>
                {
                    b.Navigation("Serviciotecnicos");
                });

            modelBuilder.Entity("TesisHEOBack.Modelos.Tiposervicio", b =>
                {
                    b.Navigation("Serviciotecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}
