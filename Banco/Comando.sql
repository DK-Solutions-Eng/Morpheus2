CREATE TABLE [dbo].[Comando] (
    [id]             NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [codigo_comando] VARCHAR (50) NULL,
    [descricao_comando]  VARCHAR (50)  NULL,
	[tipo] INT NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
);
