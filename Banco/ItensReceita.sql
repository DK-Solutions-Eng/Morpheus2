CREATE TABLE [dbo].[ItensReceita]
(
	[id] NUMERIC (18)  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[id_receita] INT NOT NULL,
	[objetivo] VARCHAR(50) NULL,
	[valor] VARCHAR(50) NULL,
	[corte] VARCHAR(50) NULL,
    [acao] VARCHAR(50) NULL,
	[parametro1] VARCHAR(50) NULL,
	[parametro2] VARCHAR(50) NULL,
	[tipo_limite] VARCHAR(50) NULL,
	[valor_limite] VARCHAR(50) NULL,
	[sequencia] INT NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
)
