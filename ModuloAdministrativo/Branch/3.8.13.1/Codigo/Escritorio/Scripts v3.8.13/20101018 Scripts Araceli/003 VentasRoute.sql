USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasRoute]    Script Date: 10/18/2010 10:51:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasRoute]') AND type in (N'U'))
DROP TABLE [dbo].[VentasRoute]
GO

USE [RouteADM]
GO

/****** Object:  Table [dbo].[VentasRoute]    Script Date: 10/18/2010 10:51:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasRoute](
	[IdCedis] [bigint] NOT NULL,
	[IdSurtido] [bigint] NOT NULL,
	[IdTipoVenta] [int] NOT NULL,
	[Folio] [bigint] NOT NULL,
	[Serie] [varchar](5) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdCliente] [bigint] NULL,
	[IdSucursal] [varchar](16) NULL,
	[Consigna] [bit] NULL,
 CONSTRAINT [PK_VentasRoute] PRIMARY KEY CLUSTERED 
(
	[IdCedis] ASC,
	[IdSurtido] ASC,
	[IdTipoVenta] ASC,
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 10/18/2010 10:52:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasRoute]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasRoute]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasRoute]    Script Date: 10/18/2010 10:52:22 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[sel_VentasRoute] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, IdSucursal, Consigna 
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido 

if @Opc = 2
	select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, Fecha, IdCliente, IdSucursal, Consigna 
	from VentasRoute
	where VentasRoute.IdCedis = @IdCedis and VentasRoute.IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 



GO

