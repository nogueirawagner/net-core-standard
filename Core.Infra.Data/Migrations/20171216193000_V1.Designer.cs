using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20171216193000_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Domain.Models.Eventos.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Core.Domain.Models.Eventos.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("EventoId");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EventoId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Core.Domain.Models.Eventos.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoriaId");

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("EnderecoId");

                    b.Property<bool>("Excluido");

                    b.Property<bool>("Gratuito");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Online");

                    b.Property<Guid>("OrganizadorId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Core.Domain.Models.Eventos.Organizador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Organizadores");
                });

            modelBuilder.Entity("Core.Domain.Models.Eventos.Endereco", b =>
                {
                    b.HasOne("Core.Domain.Models.Eventos.Evento", "Evento")
                        .WithOne("Endereco")
                        .HasForeignKey("Core.Domain.Models.Eventos.Endereco", "EventoId");
                });

            modelBuilder.Entity("Core.Domain.Models.Eventos.Evento", b =>
                {
                    b.HasOne("Core.Domain.Models.Eventos.Categoria", "Categoria")
                        .WithMany("Eventos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Core.Domain.Models.Eventos.Organizador", "Organizador")
                        .WithMany("Eventos")
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
