CREATE TABLE [dbo].[TipoRele]
(
    [id] NUMERIC (18)  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [nome]  VARCHAR (50)  NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
)

