﻿// <auto-generated />
using System;
using CSACVM.AccesoDatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    [DbContext(typeof(CSACVMContext))]
    partial class CSACVMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CSACVM.Modelos.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDepartamento");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("CSACVM.Modelos.Entrada", b =>
                {
                    b.Property<int>("IdEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntrada"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Editada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoEntrada")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Lenguaje")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("NumRespuestas")
                        .HasColumnType("int");

                    b.Property<bool>("Resuelta")
                        .HasColumnType("bit");

                    b.Property<string>("TituloIssue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEntrada");

                    b.HasIndex("IdProyecto");

                    b.HasIndex("IdTipoEntrada");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("CSACVM.Modelos.EntradaCV", b =>
                {
                    b.Property<int>("IdEntradaCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEntradaCV"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmpresaAsociada")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreTitulacion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEntradaCV");

                    b.HasIndex("IdUsuario");

                    b.ToTable("EntradaCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.EventosUsuario", b =>
                {
                    b.Property<int>("IdEventoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEventoUsuario"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdEventoUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("EventosUsuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.ExtraCV", b =>
                {
                    b.Property<int>("IdExtraCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExtraCV"), 1L, 1);

                    b.Property<int>("IdTipoExtraCV")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdExtraCV");

                    b.HasIndex("IdTipoExtraCV");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ExtraCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.ExtraEntradasCV", b =>
                {
                    b.Property<int>("IdExtraEntradaCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExtraEntradaCV"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdExtraCV")
                        .HasColumnType("int");

                    b.HasKey("IdExtraEntradaCV");

                    b.HasIndex("IdExtraCV");

                    b.ToTable("ExtraEntradasCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.FormacionCV", b =>
                {
                    b.Property<int>("IdFormacionCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormacionCV"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFormacionCV");

                    b.HasIndex("IdUsuario");

                    b.ToTable("FormacionCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.Grupo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGrupo"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdGrupo");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("CSACVM.Modelos.Idioma", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIdioma"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdIdioma");

                    b.ToTable("Idioma");
                });

            modelBuilder.Entity("CSACVM.Modelos.IdiomaCV", b =>
                {
                    b.Property<int>("IdIdiomaCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIdiomaCV"), 1L, 1);

                    b.Property<string>("Centro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdIdioma")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdIdiomaCV");

                    b.HasIndex("IdIdioma");

                    b.HasIndex("IdUsuario");

                    b.ToTable("IdiomaCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.NotasUsuario", b =>
                {
                    b.Property<int>("IdNotaUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotaUsuario"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdNotaUsuario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("NotasUsuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacion"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipoNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("Leido")
                        .HasColumnType("bit");

                    b.HasKey("IdNotificacion");

                    b.HasIndex("IdTipoNotificacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Notificacion");
                });

            modelBuilder.Entity("CSACVM.Modelos.Proyecto", b =>
                {
                    b.Property<int>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProyecto"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProyecto");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("CSACVM.Modelos.Respuesta", b =>
                {
                    b.Property<int>("IdRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRespuesta"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEntrada")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UpVotes")
                        .HasColumnType("int");

                    b.HasKey("IdRespuesta");

                    b.HasIndex("IdEntrada");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("CSACVM.Modelos.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("CSACVM.Modelos.TipoEntrada", b =>
                {
                    b.Property<int>("IdTipoEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoEntrada"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoEntrada");

                    b.ToTable("TipoEntrada");
                });

            modelBuilder.Entity("CSACVM.Modelos.TipoExtraCV", b =>
                {
                    b.Property<int>("IdTipoExtraCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoExtraCV"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoExtraCV");

                    b.ToTable("TipoExtraCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.TipoNotificacion", b =>
                {
                    b.Property<int>("IdTipoNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoNotificacion"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoNotificacion");

                    b.ToTable("TipoNotificacion");
                });

            modelBuilder.Entity("CSACVM.Modelos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAdmin")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdGrupo");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.UsuarioCV", b =>
                {
                    b.Property<int>("IdUsuarioCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuarioCV"), 1L, 1);

                    b.Property<string>("Apellido1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnlaceContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profesion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioCV");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuarioCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.Entrada", b =>
                {
                    b.HasOne("CSACVM.Modelos.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.TipoEntrada", "TipoEntrada")
                        .WithMany()
                        .HasForeignKey("IdTipoEntrada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("TipoEntrada");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.EntradaCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.EventosUsuario", b =>
                {
                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.ExtraCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.TipoExtraCV", "TipoExtraCV")
                        .WithMany()
                        .HasForeignKey("IdTipoExtraCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoExtraCV");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.ExtraEntradasCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.ExtraCV", "ExtraCV")
                        .WithMany()
                        .HasForeignKey("IdExtraCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraCV");
                });

            modelBuilder.Entity("CSACVM.Modelos.FormacionCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.IdiomaCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.Idioma", "Idioma")
                        .WithMany()
                        .HasForeignKey("IdIdioma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idioma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.NotasUsuario", b =>
                {
                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.Notificacion", b =>
                {
                    b.HasOne("CSACVM.Modelos.TipoNotificacion", "TipoNotificacion")
                        .WithMany()
                        .HasForeignKey("IdTipoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoNotificacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.Respuesta", b =>
                {
                    b.HasOne("CSACVM.Modelos.Entrada", "Entrada")
                        .WithMany()
                        .HasForeignKey("IdEntrada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Entrada");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CSACVM.Modelos.Usuario", b =>
                {
                    b.HasOne("CSACVM.Modelos.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSACVM.Modelos.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Grupo");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("CSACVM.Modelos.UsuarioCV", b =>
                {
                    b.HasOne("CSACVM.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
