CREATE TABLE [dbo].[Usuario] (
    [id]       NUMERIC (18) IDENTITY (1, 1) NOT NULL,
    [usuario]  VARCHAR (50) NULL,
    [senha]    VARCHAR (50) NULL,
	[dateinsert] Datetime NULL,
	[dateupdate] Datetime NULL
    PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

