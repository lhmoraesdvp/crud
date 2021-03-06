CREATE DATABASE crudFitcard
USE [crudFitcard]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 21/05/2018 23:19:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estabelecimentos]    Script Date: 21/05/2018 23:19:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estabelecimentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cnpj] [nvarchar](18) NOT NULL,
	[razaoSocial] [nvarchar](80) NOT NULL,
	[nomeFantasia] [nvarchar](80) NULL,
	[categoriaId] [int] NOT NULL,
	[status] [bit] NULL,
	[dataCadastro] [date] NULL,
	[ufId] [int] NULL,
	[cidade] [nvarchar](50) NULL,
	[bairro] [nvarchar](50) NULL,
	[cep] [nvarchar](9) NULL,
	[logradouro] [nvarchar](50) NULL,
	[numero] [int] NULL,
	[email] [nvarchar](80) NULL,
	[telefone] [nvarchar](13) NULL,
 CONSTRAINT [PK_Estabelecimento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uf]    Script Date: 21/05/2018 23:19:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uf](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
	[sigla] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_Uf_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Estabelecimentos]  WITH CHECK ADD  CONSTRAINT [FK_Estabelecimento_Categoria] FOREIGN KEY([categoriaId])
REFERENCES [dbo].[Categorias] ([id])
GO
ALTER TABLE [dbo].[Estabelecimentos] CHECK CONSTRAINT [FK_Estabelecimento_Categoria]
GO
ALTER TABLE [dbo].[Estabelecimentos]  WITH CHECK ADD  CONSTRAINT [FK_Estabelecimentos_Uf] FOREIGN KEY([ufId])
REFERENCES [dbo].[Uf] ([id])
GO
ALTER TABLE [dbo].[Estabelecimentos] CHECK CONSTRAINT [FK_Estabelecimentos_Uf]
GO
