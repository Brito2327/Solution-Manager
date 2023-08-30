﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ManagerSolution.DAO;

namespace ManagerSolution.Migrations
{
    [DbContext(typeof(ConecaoContext))]
    [Migration("20190904203207_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagerSolution.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicoId");

                    b.Property<int>("PacienteId");

                    b.Property<string>("Plano");

                    b.Property<DateTime>("data");

                    b.Property<string>("hora");

                    b.Property<string>("observacao");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("ManagerSolution.Models.Anamnese", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Antecedentes");

                    b.Property<string>("Diagnostico");

                    b.Property<string>("ExameFisico");

                    b.Property<string>("HDA");

                    b.Property<string>("QP");

                    b.Property<string>("TPR");

                    b.Property<string>("componentePrescrito");

                    b.HasKey("ID");

                    b.ToTable("Anamnese");
                });

            modelBuilder.Entity("ManagerSolution.Models.Atendente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Atendente");
                });

            modelBuilder.Entity("ManagerSolution.Models.Atendimentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicoId");

                    b.Property<int>("PacienteId");

                    b.Property<string>("Plano");

                    b.Property<DateTime>("data");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("ManagerSolution.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Atendente");

                    b.Property<bool>("Medico");

                    b.Property<bool>("Paciente");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ManagerSolution.Models.Componente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("ID");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("ManagerSolution.Models.Componente_Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Componente");

                    b.Property<int>("PacienteId");

                    b.HasKey("ID");

                    b.HasIndex("PacienteId");

                    b.ToTable("Componente_Paciente");
                });

            modelBuilder.Entity("ManagerSolution.Models.Componente_Remedio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Componente");

                    b.Property<int>("PacienteId");

                    b.HasKey("ID");

                    b.HasIndex("PacienteId");

                    b.ToTable("Componente_RemediosContext");
                });

            modelBuilder.Entity("ManagerSolution.Models.Consulta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnamneseId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("MedicoId");

                    b.Property<string>("Observacao");

                    b.Property<int>("PacienteId");

                    b.HasKey("ID");

                    b.HasIndex("AnamneseId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("ManagerSolution.Models.Endereco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Numero");

                    b.Property<string>("rua");

                    b.HasKey("ID");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ManagerSolution.Models.Funcionario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ManagerSolution.Models.HistoriaPatologicaPregressa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HF");

                    b.Property<string>("HPP");

                    b.Property<string>("HistoriaSocial");

                    b.HasKey("ID");

                    b.ToTable("HistoriaPatologicaPregressaContext");
                });

            modelBuilder.Entity("ManagerSolution.Models.Medico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaDeAtuacao");

                    b.Property<string>("CRM");

                    b.Property<string>("Situacao");

                    b.Property<int>("UsuarioId");

                    b.Property<string>("nome");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("ManagerSolution.Models.Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Naturalidade");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.Property<int>("UsuarioId");

                    b.Property<DateTime>("data");

                    b.Property<byte[]>("imagem");

                    b.Property<string>("sexo");

                    b.HasKey("ID");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("ManagerSolution.Models.Prontuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HistoriaPatologicaPregressaId");

                    b.Property<string>("Observacoes");

                    b.Property<int>("PacienteId");

                    b.HasKey("ID");

                    b.HasIndex("HistoriaPatologicaPregressaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Prontuario");
                });

            modelBuilder.Entity("ManagerSolution.Models.Remedio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<string>("PrincipioAtivo");

                    b.HasKey("ID");

                    b.ToTable("Remedio");
                });

            modelBuilder.Entity("ManagerSolution.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Password");

                    b.Property<string>("User");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ManagerSolution.Models.Agendamento", b =>
                {
                    b.HasOne("ManagerSolution.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Atendente", b =>
                {
                    b.HasOne("ManagerSolution.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Atendimentos", b =>
                {
                    b.HasOne("ManagerSolution.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Componente_Paciente", b =>
                {
                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Componente_Remedio", b =>
                {
                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Consulta", b =>
                {
                    b.HasOne("ManagerSolution.Models.Anamnese", "Anamnese")
                        .WithMany()
                        .HasForeignKey("AnamneseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Funcionario", b =>
                {
                    b.HasOne("ManagerSolution.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Medico", b =>
                {
                    b.HasOne("ManagerSolution.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Paciente", b =>
                {
                    b.HasOne("ManagerSolution.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Prontuario", b =>
                {
                    b.HasOne("ManagerSolution.Models.HistoriaPatologicaPregressa", "HistoriaPatologicaPregressa")
                        .WithMany()
                        .HasForeignKey("HistoriaPatologicaPregressaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagerSolution.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagerSolution.Models.Usuario", b =>
                {
                    b.HasOne("ManagerSolution.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
