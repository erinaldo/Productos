USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasOxxo]    Script Date: 03/31/2011 17:38:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_FacturasOxxo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_FacturasOxxo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_FacturasOxxo]    Script Date: 03/31/2011 17:38:00 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_FacturasOxxo] 
@IdCedis as varchar(1000),
@Mes as int,
@Serie as varchar(10),
@IdCadena as varchar(100),
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1 --- datos de facturas no aplicadas
	execute ('select Ventas.IdCedis, Serie, Folio, Fecha, Total,  Cargos, Abonos, Saldo, 
	case Status
		when ''G'' then ''Generada''
		else ''Pendiente'' end as Status, Login, FechaEdicion, 
	Subtotal, Iva, IdTipoVenta, 
	( select isnull( count(*) , 0) from FacturasOxxo where FacturasOxxo.IdCedisOX = Ventas.IDCedis and FacturasOxxo.IdTipoVentaOX = Ventas.IdTipoVenta
		and FacturasOxxo.SerieOX = Ventas.Serie and FacturasOxxo.FolioOX = Ventas.Folio )  as NoFacturas

	from Ventas 
	where Ventas.IdCedis in ( ' + @IdCedis + ') and month(Fecha) = ' + @Mes + ' and Serie = ''' + @Serie + ''' 
		and ( Ventas.Login = ''' + @Login + ''' or Ventas.Login in (select LoginD from UsuariosLogin where Login = ''' + @Login + ''' )) 
		and IdCliente in (select IdCadena from Clientes where IdCliente = Ventas.IdCliente and IdCadena = ' + @IdCadena + ')
	order by Fecha desc, Folio')

GO


