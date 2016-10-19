USE [Trabalho]
GO

CREATE TABLE [dbo].[categorias](
	[IdCategoria] [int] IDENTITY NOT NULL,
	[Descricao] [varchar](50) NULL,
	[Valor] [decimal](18, 0) NULL,
	[qtdeVeiculos] [int] NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [Clientes](
	[IdCliente] [int] IDENTITY  NOT NULL,
	[Nome] [varchar](100) NULL,
	[CNH] [varchar](50) NULL,
	[RG] [varchar](50) NULL,
	[CPF] [varchar](50) NULL,
	[Rua] [varchar](50) NULL,
	[Numero] [varchar](50) NULL,
	[Bairro] [varchar](50) NULL,
	[Cidade] [varchar](50) NULL,
	[Estado] [varchar](50) NULL
	CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [Locacaos](
	[IdLocacao] [int] IDENTITY NOT NULL,
	[IdCliente] [varchar](50) NULL,
	[IdVeiculo] [varchar](50) NULL,
	[Data_locacao] [varchar](50) NULL,
	[Data_devolucao] [varchar](50) NULL,
	[Valor_total] [decimal](18, 0) NULL,
   CONSTRAINT [PK_Locacaos] PRIMARY KEY CLUSTERED 
(	[IdLocacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [Tables](
	[IdDevolucao] [int] IDENTITY NOT NULL,
	[IdCliente] [int] NULL,
	[IdVeiculo] [int] NULL,
	[Data_devolucao] [datetime] NULL
   CONSTRAINT [Tables] PRIMARY KEY CLUSTERED 
(	[IdDevolucao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [Veiculos](
	[IdVeiculo] [int] NOT IDENTITY NULL,
	[Placa] [varchar](50) NULL,
	[Renavam] [varchar](50) NULL,
	[Cor] [varchar](50) NULL,
	[Categoria] [int] NULL
   CONSTRAINT [T[Veiculo] PRIMARY KEY CLUSTERED 
(	[IdVeiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [Login](
	[IdLogin] [int] IDENTITY  NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Senha] [varchar](50) NULL,

   CONSTRAINT [Login] PRIMARY KEY CLUSTERED 
(	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

SET ANSI_PADDING OFF
GO


