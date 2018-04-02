CREATE TABLE [dbo].[Rele]
(
    [id] NUMERIC (18)  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [codigo] VARCHAR (50) NULL,
    [nome]  VARCHAR (50)  NULL,
	[tipo]  int NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
)
