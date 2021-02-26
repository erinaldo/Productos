
insert into bancos values ( 1, 'BANAMEX')
insert into bancos values ( 2, 'BBVBANCOMER')
insert into bancos values ( 3, 'HSBC')
insert into bancos values ( 4, 'SANTANDER SERFIN')
insert into bancos values ( 5, 'BANCO AZTECA')
insert into bancos values ( 6, 'SCOTIABANK INVERLAT')
insert into bancos values ( 7, 'BANORTE')
insert into bancos values ( 8, 'AFIRME')
insert into bancos values ( 9, 'INBURSA')
insert into bancos values ( 10, 'BANREGIO')
insert into bancos values ( 11, 'BANK OF AMERICA')

delete 
from TipoDenominacion 
where IdTipoDenominacion = 'C'

USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoPago]    Script Date: 07/29/2010 17:14:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoPago]') AND type in (N'U'))
DROP TABLE [dbo].[TipoPago]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[TipoPago]    Script Date: 07/29/2010 17:14:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoPago](
	[IdTipoPago] [int] NOT NULL,
	[TipoPago] [varchar](20) NULL,
 CONSTRAINT [PK_TipoPago] PRIMARY KEY CLUSTERED 
(
	[IdTipoPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into TipoPago values ( 1, 'EFECTIVO')
insert into TipoPago values ( 2, 'CHEQUE')
insert into TipoPago values ( 3, 'DEPOSITO')
insert into TipoPago values ( 4, 'TRANSFERENCIA')

