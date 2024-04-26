using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelos.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOCLIENTE",
                columns: table => new
                {
                    IDESTADOC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTADOCLIENTE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTADOCL__EB96EBB946AE2A90", x => x.IDESTADOC);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOP",
                columns: table => new
                {
                    IDESTADOP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTADOP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTADOP__EB96EB8A8FD9DEBB", x => x.IDESTADOP);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOSERVICIO",
                columns: table => new
                {
                    IDESTADOSERVICIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTADOSERVICIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTADOSE__6EE6C45852DE8774", x => x.IDESTADOSERVICIO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOT",
                columns: table => new
                {
                    IDESTADO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTADOT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESTADOT__A93E12E21FE859BE", x => x.IDESTADO);
                });

            migrationBuilder.CreateTable(
                name: "ROL",
                columns: table => new
                {
                    IDROL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROL__A686519EA329115F", x => x.IDROL);
                });

            migrationBuilder.CreateTable(
                name: "SERVICIO",
                columns: table => new
                {
                    IDSERVICIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERVICIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SUBIDA = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PRECIO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    BAJADA = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SERVICIO__ED07F46E52416C78", x => x.IDSERVICIO);
                });

            migrationBuilder.CreateTable(
                name: "TIPOSERVICIO",
                columns: table => new
                {
                    IDTIPOSERVICIOT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPOSERVICIO = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TIPOSERV__EB88F98DE0A0C2BE", x => x.IDTIPOSERVICIOT);
                });

            migrationBuilder.CreateTable(
                name: "TECNICO",
                columns: table => new
                {
                    IDTECNICO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDESTADO = table.Column<int>(type: "int", nullable: false),
                    NOMBRET = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    APELLIDOT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CASOSNUM = table.Column<int>(type: "int", nullable: false),
                    TELEFONOT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TECNICO__1391A383C51AC335", x => x.IDTECNICO);
                    table.ForeignKey(
                        name: "FK__TECNICO__IDESTAD__4316F928",
                        column: x => x.IDESTADO,
                        principalTable: "ESTADOT",
                        principalColumn: "IDESTADO");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDROL = table.Column<int>(type: "int", nullable: false),
                    USUARIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__98242AA90B04BEAD", x => x.IDUSUARIO);
                    table.ForeignKey(
                        name: "FK__USUARIO__IDROL__440B1D61",
                        column: x => x.IDROL,
                        principalTable: "ROL",
                        principalColumn: "IDROL");
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSERVICIO = table.Column<int>(type: "int", nullable: true),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    APELLIDO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DNIC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PAGOPENDIENTE = table.Column<decimal>(type: "numeric(1,0)", nullable: false),
                    INSTALADO = table.Column<decimal>(type: "numeric(1,0)", nullable: false),
                    IDESTADOC = table.Column<int>(type: "int", nullable: false),
                    DIRECCIONC = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TELEFONO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__1EA344C2BF3715C5", x => x.IDCLIENTE);
                    table.ForeignKey(
                        name: "FK__CLIENTE__IDESTAD__3B75D760",
                        column: x => x.IDESTADOC,
                        principalTable: "ESTADOCLIENTE",
                        principalColumn: "IDESTADOC");
                    table.ForeignKey(
                        name: "FK__CLIENTE__IDSERVI__3C69FB99",
                        column: x => x.IDSERVICIO,
                        principalTable: "SERVICIO",
                        principalColumn: "IDSERVICIO");
                });

            migrationBuilder.CreateTable(
                name: "PAGO",
                columns: table => new
                {
                    IDFACTURA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCLIENTE = table.Column<int>(type: "int", nullable: false),
                    IDESTADOP = table.Column<int>(type: "int", nullable: false),
                    FECHA = table.Column<DateTime>(type: "date", nullable: false),
                    FECHAVENCIMIENTO = table.Column<DateTime>(type: "date", nullable: false),
                    FECHAPAGADO = table.Column<DateTime>(type: "date", nullable: true),
                    SERVICIOP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PRECIOTOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PAGO__F7D4C9C70A552A17", x => x.IDFACTURA);
                    table.ForeignKey(
                        name: "FK__PAGO__IDCLIENTE__3D5E1FD2",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE");
                    table.ForeignKey(
                        name: "FK__PAGO__IDESTADOP__3E52440B",
                        column: x => x.IDESTADOP,
                        principalTable: "ESTADOP",
                        principalColumn: "IDESTADOP");
                });

            migrationBuilder.CreateTable(
                name: "SERVICIOTECNICO",
                columns: table => new
                {
                    IDPROBLEMAT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTECNICO = table.Column<int>(type: "int", nullable: true),
                    IDCLIENTE = table.Column<int>(type: "int", nullable: false),
                    IDESTADOSERVICIO = table.Column<int>(type: "int", nullable: false),
                    IDTIPOSERVICIOT = table.Column<int>(type: "int", nullable: false),
                    DESCRIPCIONSERVICIOT = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FECHAINICIO = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SERVICIO__3EFB96B8C1726752", x => x.IDPROBLEMAT);
                    table.ForeignKey(
                        name: "FK__SERVICIOT__IDCLI__3F466844",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE");
                    table.ForeignKey(
                        name: "FK__SERVICIOT__IDEST__403A8C7D",
                        column: x => x.IDESTADOSERVICIO,
                        principalTable: "ESTADOSERVICIO",
                        principalColumn: "IDESTADOSERVICIO");
                    table.ForeignKey(
                        name: "FK__SERVICIOT__IDTEC__412EB0B6",
                        column: x => x.IDTECNICO,
                        principalTable: "TECNICO",
                        principalColumn: "IDTECNICO");
                    table.ForeignKey(
                        name: "FK__SERVICIOT__IDTIP__4222D4EF",
                        column: x => x.IDTIPOSERVICIOT,
                        principalTable: "TIPOSERVICIO",
                        principalColumn: "IDTIPOSERVICIOT");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_IDESTADOC",
                table: "CLIENTE",
                column: "IDESTADOC");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_IDSERVICIO",
                table: "CLIENTE",
                column: "IDSERVICIO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGO_IDCLIENTE",
                table: "PAGO",
                column: "IDCLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_PAGO_IDESTADOP",
                table: "PAGO",
                column: "IDESTADOP");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOTECNICO_IDCLIENTE",
                table: "SERVICIOTECNICO",
                column: "IDCLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOTECNICO_IDESTADOSERVICIO",
                table: "SERVICIOTECNICO",
                column: "IDESTADOSERVICIO");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOTECNICO_IDTECNICO",
                table: "SERVICIOTECNICO",
                column: "IDTECNICO");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICIOTECNICO_IDTIPOSERVICIOT",
                table: "SERVICIOTECNICO",
                column: "IDTIPOSERVICIOT");

            migrationBuilder.CreateIndex(
                name: "IX_TECNICO_IDESTADO",
                table: "TECNICO",
                column: "IDESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IDROL",
                table: "USUARIO",
                column: "IDROL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGO");

            migrationBuilder.DropTable(
                name: "SERVICIOTECNICO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "ESTADOP");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "ESTADOSERVICIO");

            migrationBuilder.DropTable(
                name: "TECNICO");

            migrationBuilder.DropTable(
                name: "TIPOSERVICIO");

            migrationBuilder.DropTable(
                name: "ROL");

            migrationBuilder.DropTable(
                name: "ESTADOCLIENTE");

            migrationBuilder.DropTable(
                name: "SERVICIO");

            migrationBuilder.DropTable(
                name: "ESTADOT");
        }
    }
}
