-- DROP SCHEMA [sm-local];

CREATE SCHEMA [sm-local];
-- [sm-desenvolvimento].[sm-local].Agendamento definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Agendamento;

CREATE TABLE [sm-desenvolvimento].[sm-local].Agendamento (
	Id bigint IDENTITY(1,1) NOT NULL,
	PacienteId bigint NULL,
	[Data] date NULL,
	MedicoId bigint NULL,
	Hora datetime NULL,
	Observacao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Plano int NULL
);


-- [sm-desenvolvimento].[sm-local].Anamnese definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Anamnese;

CREATE TABLE [sm-desenvolvimento].[sm-local].Anamnese (
	Id bigint IDENTITY(0,1) NOT NULL,
	AntecedenteFamiliar varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TemperaturaPulsoRespiracao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	QueixaPrincipal varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	HistoricoDoencaAtual varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);


-- [sm-desenvolvimento].[sm-local].Atendimentos definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Atendimentos;

CREATE TABLE [sm-desenvolvimento].[sm-local].Atendimentos (
	Id bigint IDENTITY(0,1) NOT NULL,
	DataHora datetime NULL,
	PacienteId bigint NULL,
	MedicoId bigint NULL,
	Plano varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);


-- [sm-desenvolvimento].[sm-local].Consulta definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Consulta;

CREATE TABLE [sm-desenvolvimento].[sm-local].Consulta (
	Id bigint IDENTITY(0,1) NOT NULL,
	DataHora datetime NULL,
	PacienteId bigint NULL,
	MedicoId bigint NULL,
	AnamneseId bigint NULL,
	Observacao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);


-- [sm-desenvolvimento].[sm-local].Endereco definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Endereco;

CREATE TABLE [sm-desenvolvimento].[sm-local].Endereco (
	Id bigint IDENTITY(0,1) NOT NULL,
	Logradouro varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CidadeId bigint NULL,
	Bairro varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Numero int NULL
);


-- [sm-desenvolvimento].[sm-local].Funcionario definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Funcionario;

CREATE TABLE [sm-desenvolvimento].[sm-local].Funcionario (
	Id bigint IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UsuarioId bigint NULL
);


-- [sm-desenvolvimento].[sm-local].HistoriaPatologicaPregressa definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].HistoriaPatologicaPregressa;

CREATE TABLE [sm-desenvolvimento].[sm-local].HistoriaPatologicaPregressa (
	Id bigint IDENTITY(0,1) NOT NULL,
	HistoriaPregressa varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	HistoricoFamiliar varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	HistoriaSocial varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);


-- [sm-desenvolvimento].[sm-local].Medico definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Medico;

CREATE TABLE [sm-desenvolvimento].[sm-local].Medico (
	Id bigint IDENTITY(1,1) NOT NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CRM varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Situacao int NULL,
	AreaDeAtuacao varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UsuarioId bigint NULL
);


-- [sm-desenvolvimento].[sm-local].Paciente definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Paciente;

CREATE TABLE [sm-desenvolvimento].[sm-local].Paciente (
	Id bigint NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CPF varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	EnderecoId bigint NULL,
	Sexo int NULL,
	DataNascimento date NULL,
	Telefone varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Naturalidade varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UsuarioId bigint NULL,
	Imagem bit NULL
);


-- [sm-desenvolvimento].[sm-local].Pessoa definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Pessoa;

CREATE TABLE [sm-desenvolvimento].[sm-local].Pessoa (
	Id bigint NULL,
	Nome varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CPF varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	EnderecoId bigint NULL,
	Sexo int NULL,
	TipoFuncao int NULL,
	DataNascimento date NULL,
	Telefone varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Naturalidade varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UsuarioId bigint NULL,
	Imagem bit NULL
);


-- [sm-desenvolvimento].[sm-local].Prontuario definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Prontuario;

CREATE TABLE [sm-desenvolvimento].[sm-local].Prontuario (
	Id bigint IDENTITY(0,1) NOT NULL,
	HistoriaPatologicaPregressaId bigint NULL,
	PacienteId bigint NULL,
	Observacoes varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);


-- [sm-desenvolvimento].[sm-local].Usuario definition

-- Drop table

-- DROP TABLE [sm-desenvolvimento].[sm-local].Usuario;

CREATE TABLE [sm-desenvolvimento].[sm-local].Usuario (
	Id bigint IDENTITY(1,1) NOT NULL,
	[User] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Password varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Categoria int NULL
);