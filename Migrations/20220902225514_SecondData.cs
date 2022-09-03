using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    public partial class SecondData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb903"), null, "Actividades laborales", 70 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb910"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb911"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb912"), new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb903"), null, new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2664), 2, "Terminar Reporte" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb912"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb903"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb910"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 17, 26, 55, 343, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb911"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 17, 26, 55, 343, DateTimeKind.Local).AddTicks(9193));
        }
    }
}
