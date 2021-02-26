USE [RouteADM]
GO

CREATE TABLE [dbo].[MonedasTemporal](
	[IdMoneda] [varchar](5) NOT NULL,
	[Moneda] [varchar](25) NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_MonedasTemporal] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

Insert into [MonedasTemporal]
select Idmoneda,Moneda,status from Monedas

GO

/****** Object:  Table [dbo].[Monedas]    Script Date: 07/13/2010 22:58:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Monedas]') AND type in (N'U'))
DROP TABLE [dbo].[Monedas]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[Monedas]    Script Date: 07/13/2010 22:58:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Monedas](
	[IdMoneda] [varchar](5) NOT NULL,
	[Moneda] [varchar](25) NULL,
	[Status] [char](1) NULL,
	[Base] [bit] NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

IF (SELECT COUNT(*) FROM MonedasTemporal WHERE idmoneda = 'MXP')>= 1
	begin
		Insert into Monedas
		select Idmoneda,Moneda,status,1 from MonedasTemporal WHERE idmoneda = 'MXP'
	end

Insert into Monedas
select Idmoneda,Moneda,status,0 from MonedasTemporal WHERE idmoneda <> 'MXP'

drop table MonedasTemporal