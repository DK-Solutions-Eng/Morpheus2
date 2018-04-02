CREATE TABLE [dbo].[Log](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[descricao_erro] [varchar](max) NULL,
	[data_execucao] [varchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

