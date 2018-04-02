CREATE TABLE [dbo].[Receita]
(
	[id] NUMERIC (18)  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[nome] Varchar(50) NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
)
