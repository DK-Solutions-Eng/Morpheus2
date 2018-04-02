CREATE TABLE [dbo].[Configuracao] (
    [id]                   NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [porta_arduino] VARCHAR (50) NULL,
	[baud_rate] int NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
);
GO

