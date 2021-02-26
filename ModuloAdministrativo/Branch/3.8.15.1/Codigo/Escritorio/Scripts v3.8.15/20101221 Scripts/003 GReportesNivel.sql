USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[Gsp_NivelReporte]    Script Date: 12/20/2010 10:55:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gsp_NivelReporte]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Gsp_NivelReporte]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[Gsp_NivelReporte]    Script Date: 12/20/2010 10:55:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[Gsp_NivelReporte]

@ReporteOrigen as int,
@Tipo as int,
@IdCedi as varchar(3),
@FechaInicial as datetime,
@FechaFinal as datetime,
@Filtro as varchar(4000),
@Ordenamiento as varchar(200)

AS

if @ReporteOrigen = 1 			-- Caratula de Venta
begin
	If @Tipo = 1 			-- a nivel de ruta
	begin
		SELECT     distinct SUR.IdRuta as Número, RUT.Ruta
		FROM         Surtidos SUR INNER JOIN
		                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta
		WHERE     (SUR.IdCedis = @IdCedi) and (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY SUR.Fecha, SUR.IdSurtido, SUR.IdRuta, RUT.Ruta
		ORDER BY SUR.IdRuta
	end

	if @Tipo = 10
	begin		
		exec('
			SELECT     SUR.IdCedis, SUR.IdRuta AS IdAgrupa, RUT.Ruta AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, 
			                      PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(SURDET.Surtido) AS Carga, SUM(SURDET.VentaCredito) AS Credito, 
			                      SUM(SURDET.VentaContado) AS Contado, SUM(SURDET.DevBuena) AS [Dev. Buena], SUM(SURDET.DevMala) AS [Dev. Mala], 
			                      SUM(SURDET.Obsequios) AS Obsequios, SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotal, 
			                      SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVA, SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS Total, 
			                      SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) AS CreditoContado, 
					SUM(SURDET.Surtido) * PROD.Conversion AS CargaKlts, SUM(SURDET.DevBuena) * PROD.Conversion AS BuenaKlts, 
					SUM(SURDET.DevMala) * PROD.Conversion AS MalaKlts, SUM(SURDET.Obsequios) * PROD.Conversion AS ObsequiosKlts, 
					SUM(SURDET.VentaContado) * PROD.Conversion AS ContadoKlts, SUM(SURDET.VentaCredito) * PROD.Conversion AS CreditoKlts, 
					(SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion AS CreditoContadoKlts
			FROM         Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia RIGHT OUTER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON ON SURDET.IdCedis = VVENCON.IdCedis AND SURDET.IdSurtido = VVENCON.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto ON PROD.IdProducto = SURDET.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, SUR.IdRuta, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, RUT.Ruta, FAM.Familia, 
			                      FAM.OrdenImpresion

			UNION

			SELECT     SUR.IdCedis, SUR.IdRuta AS IdAgrupa, RUT.Ruta AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, 
			                      PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(REJ.Surtido) AS Carga, 0 AS Credito, 0 AS Contado, SUM(REJ.Devolucion) 
			                      AS [Dev. Buena], 0 AS [Dev. Mala], 0 AS Obsequios, 0 AS SubTotal, 0 AS IVA, 0 AS Total, 0 AS CreditoContado, 0 AS CargaKlts, 0 AS BuenaKlts, 
			                      0 AS MalaKlts, 0 AS ObsequiosKlts, 0 AS ContadoKlts, 0 AS CreditoKlts, 0 AS CreditoContadoKlts
			FROM         Surtidos SUR INNER JOIN
			                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, SUR.IdRuta, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, RUT.Ruta, FAM.Familia, 
			                      FAM.OrdenImpresion
			ORDER BY SUR.IdRuta, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	if @Tipo = 11
	begin			
		exec('
			SELECT    SUR.IdCedis, SUR.IdRuta, CED.Cedis, RUT.Ruta, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, 
			                      	SUM(SURDET.Surtido) AS CargaPzas, SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, 
					SUM(SURDET.VentaCredito) AS CreditoPzas, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					SUM(SURDET.VentaContado) AS ContadoPzas, SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, 
				         	SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as [Credito+ContadoPzas], (SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as [Credito+ContadoKlts], 
					SUM(SURDET.DevBuena) AS DevBuenaPzas, SUM(SURDET.DevBuena) * PROD.Conversion as DevBuenaKlts, 
					SUM(SURDET.DevMala) AS DevMalaPzas, SUM(SURDET.DevMala) * PROD.Conversion as DevMalaKlts,
					SUM(SURDET.Obsequios) AS ObsequiosPzas, SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotalPesos, 
					SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVAPesos, 
					SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS TotalPesos,
				         PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON RIGHT OUTER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
			                      VVENCON.IdProducto = SURDET.IdProducto LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON SURDET.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, SUR.IdRuta, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, RUT.Ruta, FAM.Familia, FAM.OrdenImpresion, 
			                      CED.Cedis

			UNION

			SELECT     SUR.IdCedis, SUR.IdRuta, CED.Cedis as CEDIS, RUT.Ruta, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, 
					SUM(REJ.Surtido) AS CargaPzas, 0 AS CargaKlts, 
					0 AS CreditoPzas, 0 AS CreditoKlts, 
					0 AS ContadoPzas, 0 AS ContadoKlts, 
					0 AS [Credito+ContadoPzas], 0 AS [Credito+ContadoKlts], 
					SUM(REJ.Devolucion) AS DevBuenaPzas, 0 AS DevBuenaKlts, 
					0 AS DevMalaPzas, 0 AS DevMalaKlts, 
					0 AS ObsequiosPzas, 0 AS ObsequiosKlts, 
					0 AS SubTotalPesos, 
					0 AS IVAPesos, 
					0 AS TotalPesos,
				      PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         Surtidos SUR INNER JOIN
			                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, SUR.IdRuta, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, RUT.Ruta, FAM.Familia, FAM.OrdenImpresion, CED.Cedis
			ORDER BY SUR.IdRuta, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	If @Tipo = 2	-- a nivel de vendedor
	begin
		SELECT DISTINCT 
		                      VEN.IdVendedor AS Número, TPVEN.TipoVendedor AS Tipo, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS [Nombre del Vendedor], 
		                      VEN.Nomina
		FROM         Vendedores VEN INNER JOIN
		                      SurtidosVendedor SURVEN INNER JOIN
		                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor ON VEN.IdCedis = SURVEN.IdCedis AND 
		                      VEN.IdVendedor = SURVEN.IdVendedor
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY VEN.IdVendedor, TPVEN.TipoVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina
		ORDER BY TPVEN.TipoVendedor DESC, [Nombre del Vendedor]
	end	

	if @Tipo = 20
	begin			
		exec('
			SELECT     SUR.IdCedis, VEN.IdVendedor AS IdAgrupa, 
			                      TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(SURDET.Surtido) 
			                      AS Carga, SUM(SURDET.VentaCredito) AS Credito, SUM(SURDET.VentaContado) AS Contado, SUM(SURDET.DevBuena) AS [Dev. Buena], 
			                      SUM(SURDET.DevMala) AS [Dev. Mala], SUM(SURDET.Obsequios) AS Obsequios, SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 
			                      0)) AS SubTotal, SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVA, SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) 
			                      AS Total, SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as CreditoContado,
					SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, SUM(SURDET.DevBuena) * PROD.Conversion as BuenaKlts, 
					SUM(SURDET.DevMala) * PROD.Conversion as MalaKlts,	SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					(SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as CreditoContadoKlts 
			FROM         Vendedores VEN INNER JOIN
			                      TipoVendedor TPVEN INNER JOIN
			                      SurtidosVendedor SURVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido ON SURVEN.IdCedis = SUR.IdCedis AND 
			                      SURVEN.IdSurtido = SUR.IdSurtido ON VEN.IdCedis = SURVEN.IdCedis AND VEN.IdVendedor = SURVEN.IdVendedor LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON ON SURDET.IdCedis = VVENCON.IdCedis AND SURDET.IdSurtido = VVENCON.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON SURDET.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, VEN.IdVendedor, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre, PROD.IdFamilia, 
			                      PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion

			UNION

			SELECT     SUR.IdCedis, VEN.IdVendedor AS IdAgrupa, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS DescripcionAgrupa,
			                       PROD.IdFamilia, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, 
			                      SUM(REJ.Surtido) AS Carga, 0 AS Credito, 0 AS Contado, SUM(REJ.Devolucion) AS [Dev. Buena], 0 AS [Dev. Mala], 0 AS Obsequios, 0 AS SubTotal, 
			                      0 AS IVA, 0 AS Total, 0 AS CreditoContado, 0 AS CargaKlts, 0 AS BuenaKlts, 0 AS MalaKlts, 0 AS ObsequiosKlts, 0 AS ContadoKlts, 0 AS CreditoKlts, 
			                      0 AS CreditoContadoKlts
			FROM         Vendedores VEN INNER JOIN
			                      TipoVendedor TPVEN INNER JOIN
			                      SurtidosVendedor SURVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido ON VEN.IdCedis = SURVEN.IdCedis AND 
			                      VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, VEN.IdVendedor, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre, PROD.IdFamilia, 
			                      PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion
			ORDER BY DescripcionAgrupa, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	if @Tipo = 21
	begin			
		exec('
			SELECT     SUR.IdCedis, VEN.IdVendedor, CED.Cedis, VEN.Nomina AS Nómina, 
			                      TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS Vendedor, FAM.Familia, SURDET.IdProducto AS [Cve. Prod.], PROD.Producto, 
			                      	SUM(SURDET.Surtido) AS CargaPzas, SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, 
					SUM(SURDET.VentaCredito) AS CreditoPzas, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					SUM(SURDET.VentaContado) AS ContadoPzas, SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, 
				         	SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as [Credito+ContadoPzas], (SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as [Credito+ContadoKlts], 
					SUM(SURDET.DevBuena) AS DevBuenaPzas, SUM(SURDET.DevBuena) * PROD.Conversion as DevBuenaKlts, 
					SUM(SURDET.DevMala) AS DevMalaPzas, SUM(SURDET.DevMala) * PROD.Conversion as DevMalaKlts,
					SUM(SURDET.Obsequios) AS ObsequiosPzas, SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotalPesos, 
					SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVAPesos, 
					SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS TotalPesos,
				         PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         Vendedores VEN INNER JOIN
			                      TipoVendedor TPVEN INNER JOIN
			                      SurtidosVendedor SURVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido ON SURVEN.IdCedis = SUR.IdCedis AND 
			                      SURVEN.IdSurtido = SUR.IdSurtido ON VEN.IdCedis = SURVEN.IdCedis AND VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 

			                      SURDET.IdCedis = VVENCRED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON ON SURDET.IdCedis = VVENCON.IdCedis AND SURDET.IdSurtido = VVENCON.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON SURDET.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, VEN.IdVendedor, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre, PROD.IdFamilia, 
			                      SURDET.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, CED.Cedis, VEN.Nomina

			UNION

			SELECT     TOP 100 PERCENT SUR.IdCedis, VEN.IdVendedor, CED.Cedis, VEN.Nomina AS Nómina, 
			                      TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS Vendedor, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], 
			                      PROD.Producto, SUM(REJ.Surtido) AS CargaPzas, 0 AS CargaKlts, 0 AS CreditoPzas, 0 AS CreditoKlts, 0 AS ContadoPzas, 0 AS ContadoKlts, 
			                      0 AS [Credito+ContadoPzas], 0 AS [Credito+ContadoKlts], SUM(REJ.Devolucion) AS DevBuenaPzas, 0 AS DevBuenaKlts, 0 AS DevMalaPzas, 
			                      0 AS DevMalaKlts, 0 AS ObsequiosPzas, 0 AS ObsequiosKlts, 0 AS SubTotalPesos, 0 AS IVAPesos, 0 AS TotalPesos, PROD.IdFamilia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         Vendedores VEN INNER JOIN
			                      TipoVendedor TPVEN INNER JOIN
			                      SurtidosVendedor SURVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido ON VEN.IdCedis = SURVEN.IdCedis AND 
			                      VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, VEN.IdVendedor, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre, PROD.IdFamilia, 
			                      PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, CED.Cedis, VEN.Nomina
			ORDER BY Vendedor, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	If @Tipo = 3	-- a nivel de cliente
	begin
		SELECT DISTINCT CTE.IdCliente AS Número, CTE.RazonSocial AS Cliente
		FROM         Surtidos SUR INNER JOIN
		                      Ventas VEN ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
		                      Clientes CTE ON VEN.IdCedis = CTE.IdCedis AND VEN.IdCliente = CTE.IdCliente
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY CTE.IdCliente, CTE.RazonSocial
		ORDER BY Cliente
	end		

	if @Tipo = 30
	begin			--Pendiente por arreglar (agregar una vista que tenga los totales de venta por cliente, credito y contado.... cambiar el reporte)
		exec('	
			SELECT     VSUR.IdCedis, CTE.IdCliente AS IdAgrupa, CTE.RazonSocial AS DescripcionAgrupa, VSUR.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, VSUR.[Cve. Prod.], VSUR.Producto, VSUR.Conversion, VSUR.Carga, VSUR.Credito, VSUR.Contado, 
			                      VSUR.[Dev. Buena], VSUR.[Dev. Mala], VSUR.Obsequios, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
			                      ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total, 
					SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as CreditoContado,
					SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, SUM(SURDET.DevBuena) * PROD.Conversion as BuenaKlts, 
					SUM(SURDET.DevMala) * PROD.Conversion as MalaKlts,	SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					(SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as CreditoContadoKlts 
			FROM         Familias FAM INNER JOIN
			                      Clientes CTE INNER JOIN
			                      Ventas VEN ON CTE.IdCedis = VEN.IdCedis AND CTE.IdCliente = VEN.IdCliente INNER JOIN
			                      VWDetalleSurtidosRuta VSUR INNER JOIN
			                      VentasDetalle VENDET ON VSUR.IdCedis = VENDET.IdCedis AND VSUR.IdSurtido = VENDET.IdSurtido AND VSUR.[Cve. Prod.] = VENDET.IdProducto ON 
			                      VEN.IdCedis = VSUR.IdCedis AND VEN.IdSurtido = VSUR.IdSurtido ON FAM.IdFamilia = VSUR.IdFamilia
			WHERE     (FAM.MostrarImpresion = ''S'') AND (VSUR.IdCedis = ' + @IdCedi + ') AND (VSUR.Carga > 0) AND (VSUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			GROUP BY VSUR.IdCedis, CTE.IdCliente, CTE.RazonSocial, VSUR.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VSUR.[Cve. Prod.], VSUR.Producto, 
			                      VSUR.Conversion, VSUR.Carga, VSUR.Credito, VSUR.Contado, VSUR.[Dev. Buena], VSUR.[Dev. Mala], VSUR.Obsequios
			ORDER BY DescripcionAgrupa, FAM.OrdenImpresion, CAST(VSUR.[Cve. Prod.] AS bigint)')
	end

	if @Tipo = 31
	begin			
		exec('
			SELECT     TOP 100 PERCENT SUR.IdCedis, CED.Cedis, VEN.IdCliente AS Número, CTE.RazonSocial AS Cliente, FAM.Familia, SURDET.IdProducto AS [Cve. Prod.], 
			                      PROD.Producto, 
					SUM(SURDET.Surtido) AS Carga, 					
					SUM(ISNULL(VVENCON.Cantidad, 0) + ISNULL(VVENCRED.Cantidad, 0)) AS [Cantidad Vendida], 
			                      	SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotal, 
					SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVA, 
			                      SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS Total, PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, 
			                      PROD.Conversion
			FROM         Clientes CTE INNER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis INNER JOIN
			                      Ventas VEN ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido ON CTE.IdCedis = VEN.IdCedis AND 
			                      CTE.IdCliente = VEN.IdCliente LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON ON SURDET.IdCedis = VVENCON.IdCedis AND SURDET.IdSurtido = VVENCON.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON SURDET.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, CTE.IdCliente, CTE.RazonSocial, PROD.IdFamilia, SURDET.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, 
			                      FAM.OrdenImpresion, CED.Cedis, VEN.IdCliente, CTE.RazonSocial
			ORDER BY Cliente, FAM.OrdenImpresion, CAST(SURDET.IdProducto AS bigint)')
	end

	If @Tipo = 4	-- a nivel de Marca
	begin
		SELECT DISTINCT MAR.IdMarca AS Número, MAR.Marca
		FROM         Marcas MAR INNER JOIN
		                      Productos PROD ON MAR.IdMarca = PROD.IdMarca INNER JOIN
		                      Surtidos SUR INNER JOIN
		                      SurtidosDetalle SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido ON 
		                      PROD.IdProducto = SURDET.IdProducto
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (MAR.MostrarImpresion = 'S') 
		ORDER BY MAR.Marca
	end		

	if @Tipo = 40
	begin			
		exec('
			SELECT     SUR.IdCedis, PROD.IdMarca AS IdAgrupa, MAR.Marca AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(SURDET.Surtido) 
			                      AS Carga, SUM(SURDET.VentaCredito) AS Credito, SUM(SURDET.VentaContado) AS Contado, SUM(SURDET.DevBuena) AS [Dev. Buena], 
			                      SUM(SURDET.DevMala) AS [Dev. Mala], SUM(SURDET.Obsequios) AS Obsequios, SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 
			                      0)) AS SubTotal, SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVA, SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) 
			                      AS Total, SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as CreditoContado,
					SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, SUM(SURDET.DevBuena) * PROD.Conversion as BuenaKlts, 
					SUM(SURDET.DevMala) * PROD.Conversion as MalaKlts,	SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					(SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as CreditoContadoKlts 
			FROM         Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia INNER JOIN
			                      Marcas MAR ON PROD.IdMarca = MAR.IdMarca RIGHT OUTER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON ON SURDET.IdCedis = VVENCON.IdCedis AND SURDET.IdSurtido = VVENCON.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto ON PROD.IdProducto = SURDET.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdMarca, MAR.Marca, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion
			
			UNION

			SELECT     SUR.IdCedis, PROD.IdMarca AS IdAgrupa, MAR.Marca AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(REJ.Surtido) AS Carga, 
			                      0 AS Credito, 0 AS Contado, SUM(REJ.Devolucion) AS [Dev. Buena], 0 AS [Dev. Mala], 0 AS Obsequios, 0 AS SubTotal, 0 AS IVA, 0 AS Total, 
			                      0 AS CreditoContado, 0 AS CargaKlts, 0 AS BuenaKlts, 0 AS MalaKlts, 0 AS ObsequiosKlts, 0 AS ContadoKlts, 0 AS CreditoKlts, 
			                      0 AS CreditoContadoKlts
			FROM         Surtidos SUR INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia INNER JOIN
			                      Marcas MAR ON PROD.IdMarca = MAR.IdMarca ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdMarca, MAR.Marca, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, 
			                      FAM.OrdenImpresion
			ORDER BY DescripcionAgrupa, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	if @Tipo = 41
	begin			
		exec('
			SELECT     TOP 100 PERCENT SUR.IdCedis, PROD.IdMarca, CED.Cedis, MAR.Marca, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, 
			                      	SUM(SURDET.Surtido) AS CargaPzas, SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, 
					SUM(SURDET.VentaCredito) AS CreditoPzas, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					SUM(SURDET.VentaContado) AS ContadoPzas, SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, 
				         	SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as [Credito+ContadoPzas], (SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as [Credito+ContadoKlts], 
					SUM(SURDET.DevBuena) AS DevBuenaPzas, SUM(SURDET.DevBuena) * PROD.Conversion as DevBuenaKlts, 
					SUM(SURDET.DevMala) AS DevMalaPzas, SUM(SURDET.DevMala) * PROD.Conversion as DevMalaKlts,
					SUM(SURDET.Obsequios) AS ObsequiosPzas, SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotalPesos, 
					SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVAPesos, 
					SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS TotalPesos,
				         PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON RIGHT OUTER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
			                      VVENCON.IdProducto = SURDET.IdProducto LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia INNER JOIN
			                      Marcas MAR ON PROD.IdMarca = MAR.IdMarca ON SURDET.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdMarca, MAR.Marca, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, 
			                      FAM.OrdenImpresion, CED.Cedis
			
			UNION

			SELECT     TOP 100 PERCENT SUR.IdCedis, PROD.IdMarca, CED.Cedis, MAR.Marca, FAM.Familia,  PROD.IdProducto AS [Cve. Prod.], PROD.Producto, SUM(REJ.Surtido) AS CargaPzas, 
			                      0 AS CargaKlts, 0 AS CreditoPzas, 0 AS CreditoKlts, 0 AS ContadoPzas, 0 AS ContadoKlts, 0 AS [Credito+ContadoPzas], 0 AS [Credito+ContadoKlts], 
			                      SUM(REJ.Devolucion) AS DevBuenaPzas, 0 AS DevBuenaKlts, 0 AS DevMalaPzas, 0 AS DevMalaKlts, 0 AS ObsequiosPzas, 0 AS ObsequiosKlts, 
			                      0 AS SubTotalPesos, 0 AS IVAPesos, 0 AS TotalPesos, PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion
			FROM         Surtidos SUR INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia INNER JOIN
			                      Marcas MAR ON PROD.IdMarca = MAR.IdMarca ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdMarca, MAR.Marca, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, CED.Cedis
			ORDER BY MAR.Marca, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	If @Tipo = 5	-- a nivel de Grupo
	begin
		SELECT DISTINCT GPO.IdGrupo as Número, GPO.Grupo, GPO.OrdenImpresion
		FROM         Productos PROD INNER JOIN
		                      Surtidos SUR INNER JOIN
		                      SurtidosDetalle SURDET ON SUR.IdCedis = SURDET.IdCedis AND SUR.IdSurtido = SURDET.IdSurtido ON 

		                      PROD.IdProducto = SURDET.IdProducto INNER JOIN
		                      Grupos GPO ON PROD.IdGrupo = GPO.IdGrupo
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (GPO.MostrarImpresion = 'S') 
		ORDER BY GPO.OrdenImpresion
	end		

	if @Tipo = 50
	begin			
		exec('
			SELECT     TOP 100 PERCENT SUR.IdCedis, PROD.IdGrupo AS IdAgrupa, GPO.Grupo AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, 

			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(SURDET.Surtido) 
			                      AS Carga, SUM(SURDET.VentaCredito) AS Credito, SUM(SURDET.VentaContado) AS Contado, SUM(SURDET.DevBuena) AS [Dev. Buena], 
			                      SUM(SURDET.DevMala) AS [Dev. Mala], SUM(SURDET.Obsequios) AS Obsequios, SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 
			                      0)) AS SubTotal, SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVA, SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) 
			                      AS Total, GPO.OrdenImpresion AS GpoOrdenImpresion, SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as CreditoContado,
					SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, SUM(SURDET.DevBuena) * PROD.Conversion as BuenaKlts, 
					SUM(SURDET.DevMala) * PROD.Conversion as MalaKlts,	SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					(SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as CreditoContadoKlts 
			FROM         Grupos GPO INNER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON GPO.IdGrupo = PROD.IdGrupo RIGHT OUTER JOIN
			                      FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON RIGHT OUTER JOIN
			                      SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido LEFT OUTER JOIN
			                      FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
			                      SURDET.IdCedis = VVENCRED.IdCedis ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
			                      VVENCON.IdProducto = SURDET.IdProducto ON PROD.IdProducto = SURDET.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
				AND (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, PROD.IdGrupo, 
			                      GPO.Grupo, GPO.OrdenImpresion
			
			UNION

			SELECT     SUR.IdCedis, PROD.IdGrupo AS IdAgrupa, GPO.Grupo AS DescripcionAgrupa, PROD.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, PROD.Conversion, SUM(REJ.Surtido) AS Carga, 
			                      0 AS Credito, 0 AS Contado, SUM(REJ.Devolucion) AS [Dev. Buena], 0 AS [Dev. Mala], 0 AS Obsequios, 0 AS SubTotal, 0 AS IVA, 0 AS Total, 
			                      GPO.OrdenImpresion AS GpoOrdenImpresion, 0 AS CreditoContado, 0 AS CargaKlts, 0 AS BuenaKlts, 0 AS MalaKlts, 0 AS ObsequiosKlts, 
			                      0 AS ContadoKlts, 0 AS CreditoKlts, 0 AS CreditoContadoKlts
			FROM         Surtidos SUR INNER JOIN
			                      Rejas REJ ON SUR.IdCedis = REJ.IdCedis AND SUR.IdSurtido = REJ.IdSurtido AND SUR.IdRuta = REJ.IdRuta LEFT OUTER JOIN
			                      Grupos GPO INNER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON GPO.IdGrupo = PROD.IdGrupo ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
				AND (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, PROD.IdGrupo, GPO.Grupo, 
			                      GPO.OrdenImpresion
			ORDER BY GPO.OrdenImpresion, DescripcionAgrupa, FAM.OrdenImpresion, [Cve. Prod.]')
	end

	if @Tipo = 51
	begin			
		exec('
			SELECT     TOP 100 PERCENT SUR.IdCedis, PROD.IdGrupo, CED.Cedis, GPO.Grupo, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, 
			                      	SUM(SURDET.Surtido) AS CargaPzas, SUM(SURDET.Surtido) * PROD.Conversion as CargaKlts, 
					SUM(SURDET.VentaCredito) AS CreditoPzas, SUM(SURDET.VentaCredito) * PROD.Conversion as CreditoKlts,
					SUM(SURDET.VentaContado) AS ContadoPzas, SUM(SURDET.VentaContado) * PROD.Conversion as ContadoKlts, 
				         	SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado) as [Credito+ContadoPzas], (SUM(SURDET.VentaCredito) + SUM(SURDET.VentaContado)) * PROD.Conversion as [Credito+ContadoKlts], 
					SUM(SURDET.DevBuena) AS DevBuenaPzas, SUM(SURDET.DevBuena) * PROD.Conversion as DevBuenaKlts, 
					SUM(SURDET.DevMala) AS DevMalaPzas, SUM(SURDET.DevMala) * PROD.Conversion as DevMalaKlts,
					SUM(SURDET.Obsequios) AS ObsequiosPzas, SUM(SURDET.Obsequios) * PROD.Conversion as ObsequiosKlts, 
					SUM(ISNULL(VVENCON.Subtotal, 0) + ISNULL(VVENCRED.Subtotal, 0)) AS SubTotalPesos, 
					SUM(ISNULL(VVENCON.IVA, 0) + ISNULL(VVENCRED.IVA, 0)) AS IVAPesos, 
					SUM(ISNULL(VVENCON.Total, 0) + ISNULL(VVENCRED.Total, 0)) AS TotalPesos,
					PROD.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion, GPO.OrdenImpresion
			FROM         Grupos GPO INNER JOIN
					Familias FAM INNER JOIN
					Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON GPO.IdGrupo = PROD.IdGrupo RIGHT OUTER JOIN
					FN_ProductoVentaContado (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCON RIGHT OUTER JOIN
					SurtidosDetalle SURDET INNER JOIN
					Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
					Cedis CED ON SUR.IdCedis = CED.IdCedis LEFT OUTER JOIN
					FN_ProductoVentaCredito (' + @IdCedi +', ''' + @FechaInicial + ''', ''' + @FechaFinal +''')  VVENCRED ON SURDET.IdProducto = VVENCRED.IdProducto AND SURDET.IdSurtido = VVENCRED.IdSurtido AND 
					SURDET.IdCedis = VVENCRED.IdCedis ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
					VVENCON.IdProducto = SURDET.IdProducto ON PROD.IdProducto = SURDET.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, CED.Cedis, 
			      		PROD.IdGrupo, GPO.Grupo, GPO.OrdenImpresion

			UNION

			SELECT     TOP 100 PERCENT SUR.IdCedis, PROD.IdGrupo, CED.Cedis, GPO.Grupo, FAM.Familia, PROD.IdProducto AS [Cve. Prod.], PROD.Producto, 
			                      SUM(REJ.Surtido) AS CargaPzas, 0 AS CargaKlts, 0 AS CreditoPzas, 0 AS CreditoKlts, 0 AS ContadoPzas, 0 AS ContadoKlts, 
			                      0 AS [Credito+ContadoPzas], 0 AS [Credito+ContadoKlts], SUM(REJ.Devolucion) AS DevBuenaPzas, 0 AS DevBuenaKlts, 0 AS DevMalaPzas, 
			                      0 AS DevMalaKlts, 0 AS ObsequiosPzas, 0 AS ObsequiosKlts, 0 AS SubTotalPesos, 0 AS IVAPesos, 0 AS TotalPesos, PROD.IdFamilia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PROD.Conversion, GPO.OrdenImpresion
			FROM         Rejas REJ INNER JOIN
			                      Surtidos SUR INNER JOIN
			                      Cedis CED ON SUR.IdCedis = CED.IdCedis ON REJ.IdCedis = SUR.IdCedis AND REJ.IdSurtido = SUR.IdSurtido AND 
			                      REJ.IdRuta = SUR.IdRuta LEFT OUTER JOIN
			                      Grupos GPO INNER JOIN
			                      Familias FAM INNER JOIN
			                      Productos PROD ON FAM.IdFamilia = PROD.IdFamilia ON GPO.IdGrupo = PROD.IdGrupo ON REJ.IdProducto = PROD.IdProducto
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (REJ.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + '  
					AND (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S''))
			GROUP BY SUR.IdCedis, PROD.IdFamilia, PROD.IdProducto, PROD.Producto, PROD.Conversion, FAM.Familia, FAM.OrdenImpresion, CED.Cedis, PROD.IdGrupo, 
			                      GPO.Grupo, GPO.OrdenImpresion
			ORDER BY GPO.OrdenImpresion, GPO.Grupo, FAM.OrdenImpresion, [Cve. Prod.]')
	end
end

if @ReporteOrigen = 2 			-- Kardex de Inventario
begin

	If @Tipo = 1 or @Tipo = 3 or @Tipo = 5 or @Tipo = 7		-- a nivel de Marca
	begin
		SELECT DISTINCT MAR.IdMarca as Número, MAR.Marca
		FROM         Marcas MAR INNER JOIN
		                      Productos PROD ON MAR.IdMarca = PROD.IdMarca INNER JOIN
		                      InventarioKardex INVKAR ON PROD.IdProducto = INVKAR.IdProducto
		WHERE     (MAR.MostrarImpresion = 'S') AND (INVKAR.IdCedis = @IdCedi) AND (INVKAR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		ORDER BY MAR.Marca
	end

	If @Tipo = 2 or @Tipo = 4 or @Tipo = 6 or @Tipo = 8 		-- a nivel de Grupo
	begin
		SELECT DISTINCT GPO.IdGrupo as Número, GPO.Grupo AS Grupo, GPO.OrdenImpresion
		FROM         InventarioKardex INVKAR INNER JOIN
		                      Productos PRO ON INVKAR.IdProducto = PRO.IdProducto INNER JOIN
		                      Grupos GPO ON PRO.IdGrupo = GPO.IdGrupo
		WHERE     (INVKAR.IdCedis = @IdCedi) AND (INVKAR.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (GPO.MostrarImpresion = 'S')
		ORDER BY GPO.OrdenImpresion
	end		

	if @Tipo = 10		--Reporte a nivel marca en piezas
	begin
		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca as IdAgrupa, INVKAR.IdGrupo, INVKAR.IdFamilia, CED.Cedis, INVKAR.Fecha, MAR.Marca as DescripcionAgrupa, GPO.Grupo, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], 
			                      INVKAR.Producto, INVKAR.Conversion, INVKAR.Inicial, INVKAR.Entradas, INVKAR.Salidas, INVKAR.Surtido, INVKAR.DevBuena AS [Dev. Buena], INVKAR.DevMala AS [Dev. Mala], 
			                      INVKAR.Obsequios, INVKAR.Contado, INVKAR.Credito, INVKAR.Teorico, INVKAR.Fisico, INVKAR.Diferencia, INVKAR.PrecioActual, 
			                      isnull(PREPRO.PrecioPromedio,0) as PrecioPromedio, isnull(VENCON.Total,0) AS VentaContadoPesos, isnull(VENCRED.Total,0) AS VentaCreditoPesos
			FROM         FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON RIGHT OUTER JOIN
			                      FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis ON VENCON.IdCedis = INVKAR.IdCedis AND VENCON.Fecha = INVKAR.Fecha AND 
			                      VENCON.IdProducto = INVKAR.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND 
			                      INVKAR.IdProducto = VENCRED.IdProducto
			WHERE        (MAR.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			ORDER BY   INVKAR.IdCedis, INVKAR.Fecha, INVKAR.IdMarca, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	end

	if @Tipo = 20		--Reporte a nivel grupo en piezas
	begin
		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca, INVKAR.IdGrupo as IdAgrupa, INVKAR.IdFamilia, CED.Cedis, INVKAR.Fecha, MAR.Marca, GPO.Grupo as DescripcionAgrupa, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], 
			                      INVKAR.Producto, INVKAR.Conversion, INVKAR.Inicial, INVKAR.Entradas, INVKAR.Salidas, INVKAR.Surtido, INVKAR.DevBuena AS [Dev. Buena], INVKAR.DevMala AS [Dev. Mala], 
			                      INVKAR.Obsequios, INVKAR.Contado, INVKAR.Credito, INVKAR.Teorico, INVKAR.Fisico, INVKAR.Diferencia, INVKAR.PrecioActual, 
			                      isnull(PREPRO.PrecioPromedio,0) as PrecioPromedio, isnull(VENCON.Total,0) AS VentaContadoPesos, isnull(VENCRED.Total,0) AS VentaCreditoPesos
			FROM         FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON RIGHT OUTER JOIN
			                      FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis ON VENCON.IdCedis = INVKAR.IdCedis AND VENCON.Fecha = INVKAR.Fecha AND 
			                      VENCON.IdProducto = INVKAR.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND 
			                      INVKAR.IdProducto = VENCRED.IdProducto
			WHERE        (GPO.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			ORDER BY   INVKAR.IdCedis, INVKAR.Fecha, INVKAR.IdMarca, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	end

	if @Tipo = 30		--Reporte a nivel marca en pesos
	begin
		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca as IdAgrupa, INVKAR.IdGrupo, INVKAR.IdFamilia, CED.Cedis, INVKAR.Fecha, MAR.Marca as DescripcionAgrupa, GPO.Grupo, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], 
			                      INVKAR.Producto, INVKAR.Conversion, INVKAR.Inicial * isnull(PREPRO.PrecioPromedio,0) as Inicial, INVKAR.Entradas * isnull(PREPRO.PrecioPromedio,0) as Entradas, 
			                      INVKAR.Salidas * isnull(PREPRO.PrecioPromedio,0) as Salidas, INVKAR.Surtido * isnull(PREPRO.PrecioPromedio,0) as Surtido, INVKAR.DevBuena * isnull(PREPRO.PrecioPromedio,0) AS [Dev. Buena], 
				         INVKAR.DevMala * isnull(PREPRO.PrecioPromedio,0) AS [Dev. Mala], INVKAR.Obsequios * isnull(PREPRO.PrecioPromedio,0) as Obsequios, isnull(VENCON.Total,0) AS Contado, 
				         isnull(VENCRED.Total,0) AS Credito, INVKAR.Teorico * isnull(INVKAR.PrecioActual,0) as Teorico, INVKAR.Fisico * isnull(INVKAR.PrecioActual,0) as Fisico, 
			 	         INVKAR.Diferencia * isnull(INVKAR.PrecioActual,0) as Diferencia, isnull(INVKAR.PrecioActual,0) as PrecioActual, isnull(PREPRO.PrecioPromedio,0) as PrecioPromedio
			FROM         FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON RIGHT OUTER JOIN
			                      FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis ON VENCON.IdCedis = INVKAR.IdCedis AND VENCON.Fecha = INVKAR.Fecha AND 
			                      VENCON.IdProducto = INVKAR.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND 
			                      INVKAR.IdProducto = VENCRED.IdProducto
			WHERE        (MAR.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			ORDER BY   INVKAR.IdCedis, INVKAR.Fecha, INVKAR.IdMarca, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	end


	if @Tipo = 40		--Reporte a nivel grupo en pesos
	begin
		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca, INVKAR.IdGrupo as IdAgrupa, INVKAR.IdFamilia, CED.Cedis, INVKAR.Fecha, MAR.Marca, GPO.Grupo as DescripcionAgrupa, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], 
			                      INVKAR.Producto, INVKAR.Conversion, INVKAR.Inicial * isnull(PREPRO.PrecioPromedio,0) as Inicial, INVKAR.Entradas * isnull(PREPRO.PrecioPromedio,0) as Entradas, 
			                      INVKAR.Salidas * isnull(PREPRO.PrecioPromedio,0) as Salidas, INVKAR.Surtido * isnull(PREPRO.PrecioPromedio,0) as Surtido, INVKAR.DevBuena * isnull(PREPRO.PrecioPromedio,0) AS [Dev. Buena], 
				         INVKAR.DevMala * isnull(PREPRO.PrecioPromedio,0) AS [Dev. Mala], INVKAR.Obsequios * isnull(PREPRO.PrecioPromedio,0) as Obsequios, isnull(VENCON.Total,0) AS Contado, 
				         isnull(VENCRED.Total,0) AS Credito, INVKAR.Teorico * isnull(INVKAR.PrecioActual,0) as Teorico, INVKAR.Fisico * isnull(INVKAR.PrecioActual,0) as Fisico, 
			 	         INVKAR.Diferencia * isnull(INVKAR.PrecioActual,0) as Diferencia, isnull(INVKAR.PrecioActual,0) as PrecioActual, isnull(PREPRO.PrecioPromedio,0) as PrecioPromedio
			FROM         FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON RIGHT OUTER JOIN
			                      FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis ON VENCON.IdCedis = INVKAR.IdCedis AND VENCON.Fecha = INVKAR.Fecha AND 
			                      VENCON.IdProducto = INVKAR.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND 
			                      INVKAR.IdProducto = VENCRED.IdProducto
			WHERE        (GPO.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			ORDER BY   INVKAR.IdCedis, INVKAR.Fecha, INVKAR.IdMarca, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	end

	if @Tipo = 50		--Reporte de Arrastre  a nivel Marca en Piezas 
	begin

		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca AS IdAgrupa, INVKAR.IdFamilia, FAM.OrdenImpresion, CED.Cedis, MAR.Marca AS DescripcionAgrupa, FAM.Familia, 
			                      INVKAR.IdProducto AS [Cve. Prod.], INVKAR.Producto, INVKAR.Conversion,
					ISNULL(INVINI.Inicial, 0) AS Inicial, SUM(INVKAR.Entradas) AS Entradas, SUM(INVKAR.Salidas) AS Salidas, SUM(INVKAR.Surtido) AS Surtido, 
					SUM(INVKAR.DevBuena) AS [Dev. Buena], SUM(INVKAR.DevMala) AS [Dev. Mala], SUM(INVKAR.Obsequios) AS Obsequios, 
					ISNULL(SUM(INVKAR.Contado), 0) AS Contado, ISNULL(SUM(INVKAR.Credito), 0) AS Credito, ISNULL(INVTEO.Teorico, 0) AS Teorico, 
					ISNULL(INVFIN.Fisico, 0) AS Fisico, ISNULL(INVFIN.Fisico, 0) - ISNULL(INVTEO.Teorico, 0) AS Diferencia, 
					ISNULL(INVKAR.PrecioActual, 0) AS PrecioActual, ISNULL(AVG(PREPRO.PrecioPromedio), 0) AS PrecioPromedio
			FROM         FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_KardexInventarioTeoricoPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVTEO ON INVKAR.IdCedis = INVTEO.IdCedis AND 
			                      INVKAR.IdProducto = INVTEO.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioFinalPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVFIN ON INVKAR.IdCedis = INVFIN.IdCedis AND 
			                      INVKAR.IdProducto = INVFIN.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioInicialPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVINI ON INVKAR.IdCedis = INVINI.IdCedis AND 
			                      INVKAR.IdProducto = INVINI.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON ON INVKAR.IdCedis = VENCON.IdCedis AND INVKAR.Fecha = VENCON.Fecha AND 
			                      INVKAR.IdProducto = VENCON.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND
			                       INVKAR.IdProducto = VENCRED.IdProducto
			WHERE     (MAR.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVKAR.IdCedis, INVKAR.IdMarca, INVKAR.IdFamilia, CED.Cedis, MAR.Marca, FAM.Familia, INVKAR.IdProducto, INVKAR.Producto, INVKAR.Conversion,
			                       INVKAR.PrecioActual, FAM.OrdenImpresion, INVINI.Inicial, INVFIN.Fisico, INVTEO.Teorico
			ORDER BY INVKAR.IdCedis, INVKAR.IdMarca, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	End

	if @Tipo = 60		--Reporte de Arrastre  a nivel Grupo en Piezas 
	begin

		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdGrupo AS IdAgrupa, GPO.OrdenImpresion, INVKAR.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, CED.Cedis, 
			                      GPO.Grupo AS DescripcionAgrupa, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], INVKAR.Producto, INVKAR.Conversion, 
					ISNULL(INVINI.Inicial, 0) AS Inicial, SUM(INVKAR.Entradas) AS Entradas, SUM(INVKAR.Salidas) AS Salidas, SUM(INVKAR.Surtido) AS Surtido, 
					SUM(INVKAR.DevBuena) AS [Dev. Buena], SUM(INVKAR.DevMala) AS [Dev. Mala], SUM(INVKAR.Obsequios) AS Obsequios, 
					ISNULL(SUM(INVKAR.Contado), 0) AS Contado, ISNULL(SUM(INVKAR.Credito), 0) AS Credito, ISNULL(INVTEO.Teorico, 0) AS Teorico, 
					ISNULL(INVFIN.Fisico, 0) AS Fisico, ISNULL(INVFIN.Fisico, 0) - ISNULL(INVTEO.Teorico, 0) AS Diferencia, 
					ISNULL(INVKAR.PrecioActual, 0) AS PrecioActual, ISNULL(AVG(PREPRO.PrecioPromedio), 0) AS PrecioPromedio
			FROM         FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_KardexInventarioTeoricoPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVTEO ON INVKAR.IdCedis = INVTEO.IdCedis AND 
			                      INVKAR.IdProducto = INVTEO.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioFinalPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVFIN ON INVKAR.IdCedis = INVFIN.IdCedis AND 
			                      INVKAR.IdProducto = INVFIN.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioInicialPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVINI ON INVKAR.IdCedis = INVINI.IdCedis AND 
			                      INVKAR.IdProducto = INVINI.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON ON INVKAR.IdCedis = VENCON.IdCedis AND INVKAR.Fecha = VENCON.Fecha AND 
			                      INVKAR.IdProducto = VENCON.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND
			                       INVKAR.IdProducto = VENCRED.IdProducto
			WHERE     (GPO.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVKAR.IdCedis, INVKAR.IdGrupo, INVKAR.IdFamilia, CED.Cedis, GPO.Grupo, FAM.Familia, INVKAR.IdProducto, INVKAR.Producto, INVKAR.Conversion, 
			                      INVKAR.PrecioActual, GPO.OrdenImpresion, FAM.OrdenImpresion, PREPRO.PrecioPromedio, INVINI.Inicial, INVFIN.Fisico, INVTEO.Teorico
			ORDER BY INVKAR.IdCedis, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	End

	if @Tipo = 70		--Reporte de Arrastre a nivel Marca en Pesos
	begin

		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdMarca AS IdAgrupa, INVKAR.IdFamilia, FAM.OrdenImpresion, CED.Cedis, MAR.Marca AS DescripcionAgrupa, FAM.Familia, 
			                      INVKAR.IdProducto AS [Cve. Prod.], INVKAR.Producto, INVKAR.Conversion,
				ISNULL(INVINI.Inicial, 0) * ISNULL(PREPRO.PrecioPromedio, 0) AS Inicial, SUM(INVKAR.Entradas) * ISNULL(PREPRO.PrecioPromedio, 0) AS Entradas, 
				SUM(INVKAR.Salidas) * ISNULL(PREPRO.PrecioPromedio, 0) AS Salidas, SUM(INVKAR.Surtido) * ISNULL(PREPRO.PrecioPromedio, 0) AS Surtido, 
				SUM(INVKAR.DevBuena) * ISNULL(PREPRO.PrecioPromedio, 0) AS [Dev. Buena], SUM(INVKAR.DevMala) * ISNULL(PREPRO.PrecioPromedio, 0) AS [Dev. Mala], 	
				SUM(INVKAR.Obsequios) * ISNULL(PREPRO.PrecioPromedio, 0) AS Obsequios, ISNULL(SUM(VENCON.Total), 0) AS Contado, ISNULL(SUM(VENCRED.Total), 0) AS Credito, 
				ISNULL(INVTEO.Teorico, 0) * ISNULL(INVKAR.PrecioActual, 0) AS Teorico, ISNULL(INVFIN.Fisico, 0) * ISNULL(INVKAR.PrecioActual, 0) AS Fisico, 
				(ISNULL(INVFIN.Fisico, 0) - ISNULL(INVTEO.Teorico, 0)) * ISNULL(INVKAR.PrecioActual, 0) AS Diferencia, 
				ISNULL(INVKAR.PrecioActual, 0) AS PrecioActual, ISNULL(AVG(PREPRO.PrecioPromedio), 0) AS PrecioPromedio
			FROM         FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Marcas MAR ON INVKAR.IdMarca = MAR.IdMarca INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_KardexInventarioTeoricoPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVTEO ON INVKAR.IdCedis = INVTEO.IdCedis AND 
			                      INVKAR.IdProducto = INVTEO.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioFinalPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVFIN ON INVKAR.IdCedis = INVFIN.IdCedis AND 
			                      INVKAR.IdProducto = INVFIN.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioInicialPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVINI ON INVKAR.IdCedis = INVINI.IdCedis AND 
			                      INVKAR.IdProducto = INVINI.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON ON INVKAR.IdCedis = VENCON.IdCedis AND INVKAR.Fecha = VENCON.Fecha AND 
			                      INVKAR.IdProducto = VENCON.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND
			                       INVKAR.IdProducto = VENCRED.IdProducto
			WHERE     (MAR.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVKAR.IdCedis, INVKAR.IdMarca, INVKAR.IdFamilia, CED.Cedis, MAR.Marca, FAM.Familia, INVKAR.IdProducto, INVKAR.Producto, INVKAR.Conversion,
			                       INVKAR.PrecioActual, FAM.OrdenImpresion, PREPRO.PrecioPromedio, INVINI.Inicial, INVFIN.Fisico, INVTEO.Teorico
			ORDER BY INVKAR.IdCedis, INVKAR.IdMarca, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	End

	if @Tipo = 80		--Reporte de Arrastre a nivel Grupo en Pesos
	begin

		exec('
			SELECT     INVKAR.IdCedis, INVKAR.IdGrupo AS IdAgrupa, GPO.OrdenImpresion, INVKAR.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, CED.Cedis, 
			                      GPO.Grupo AS DescripcionAgrupa, FAM.Familia, INVKAR.IdProducto AS [Cve. Prod.], INVKAR.Producto, INVKAR.Conversion, 
				ISNULL(INVINI.Inicial, 0) * ISNULL(PREPRO.PrecioPromedio, 0) AS Inicial, SUM(INVKAR.Entradas) * ISNULL(PREPRO.PrecioPromedio, 0) AS Entradas, 
				SUM(INVKAR.Salidas) * ISNULL(PREPRO.PrecioPromedio, 0) AS Salidas, SUM(INVKAR.Surtido) * ISNULL(PREPRO.PrecioPromedio, 0) AS Surtido, 
				SUM(INVKAR.DevBuena) * ISNULL(PREPRO.PrecioPromedio, 0) AS [Dev. Buena], SUM(INVKAR.DevMala) * ISNULL(PREPRO.PrecioPromedio, 0) AS [Dev. Mala], 	
				SUM(INVKAR.Obsequios) * ISNULL(PREPRO.PrecioPromedio, 0) AS Obsequios, ISNULL(SUM(VENCON.Total), 0) AS Contado, ISNULL(SUM(VENCRED.Total), 0) AS Credito, 
				ISNULL(INVTEO.Teorico, 0) * ISNULL(INVKAR.PrecioActual, 0) AS Teorico, ISNULL(INVFIN.Fisico, 0) * ISNULL(INVKAR.PrecioActual, 0) AS Fisico, 
				(ISNULL(INVFIN.Fisico, 0) - ISNULL(INVTEO.Teorico, 0)) * ISNULL(INVKAR.PrecioActual, 0) AS Diferencia, 
				ISNULL(INVKAR.PrecioActual, 0) AS PrecioActual, ISNULL(AVG(PREPRO.PrecioPromedio), 0) AS PrecioPromedio
			FROM         FN_KardexDetalle(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVKAR INNER JOIN
			                      Grupos GPO ON INVKAR.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Familias FAM ON INVKAR.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON INVKAR.IdCedis = CED.IdCedis LEFT OUTER JOIN
			                      FN_KardexInventarioTeoricoPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVTEO ON INVKAR.IdCedis = INVTEO.IdCedis AND 
			                      INVKAR.IdProducto = INVTEO.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioFinalPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVFIN ON INVKAR.IdCedis = INVFIN.IdCedis AND 
			                      INVKAR.IdProducto = INVFIN.IdProducto LEFT OUTER JOIN
			                      FN_KardexInventarioInicialPeriodo(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') INVINI ON INVKAR.IdCedis = INVINI.IdCedis AND 
			                      INVKAR.IdProducto = INVINI.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 2) VENCON ON INVKAR.IdCedis = VENCON.IdCedis AND INVKAR.Fecha = VENCON.Fecha AND 
			                      INVKAR.IdProducto = VENCON.IdProducto LEFT OUTER JOIN
			                      FN_KardexPrecioPromedio(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') PREPRO ON INVKAR.IdCedis = PREPRO.IdCedis AND 
			                      INVKAR.IdProducto = PREPRO.IdProducto LEFT OUTER JOIN
			                      FN_KardexVentaPesos(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''', 1) VENCRED ON INVKAR.IdCedis = VENCRED.IdCedis AND INVKAR.Fecha = VENCRED.Fecha AND
			                       INVKAR.IdProducto = VENCRED.IdProducto
			WHERE     (GPO.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVKAR.IdCedis, INVKAR.IdGrupo, INVKAR.IdFamilia, CED.Cedis, GPO.Grupo, FAM.Familia, INVKAR.IdProducto, INVKAR.Producto, INVKAR.Conversion, 
			                      INVKAR.PrecioActual, GPO.OrdenImpresion, FAM.OrdenImpresion, PREPRO.PrecioPromedio, INVINI.Inicial, INVFIN.Fisico, INVTEO.Teorico
			ORDER BY INVKAR.IdCedis, GPO.OrdenImpresion, FAM.OrdenImpresion, CAST(INVKAR.IdProducto AS bigint)')
	End

end

if @ReporteOrigen = 3 			-- Comisiones
begin

	If @Tipo = 1 or @Tipo = 2	-- Por vendedor

	begin
		SELECT DISTINCT 
		                      VEN.IdVendedor AS Número, TPVEN.TipoVendedor AS Tipo, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS [Nombre del Vendedor], 
		                      VEN.Nomina
		FROM         Vendedores VEN INNER JOIN
		                      SurtidosVendedor SURVEN INNER JOIN
		                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor ON VEN.IdCedis = SURVEN.IdCedis AND 
		                      VEN.IdVendedor = SURVEN.IdVendedor
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY VEN.IdVendedor, TPVEN.TipoVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina
		ORDER BY TPVEN.TipoVendedor DESC, [Nombre del Vendedor]
	end

	if @Tipo = 10 or @Tipo = 11		--Reporte 
	begin			
			exec( '	select ''' + @FechaFinal + ''' as Fecha, IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma,
					ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						abs(VS.SaldoActual) < (isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0))
						order by VS.Fecha desc, VS.IdSurtido),0) as SaldoVendedor,
					SUM(Pago) + SUM(AbonoMerma) + SUM(AbonoVolumen) - SUM(CargoMerma) + 
					ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						abs(VS.SaldoActual) < (isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0))
						order by VS.Fecha desc, VS.IdSurtido desc),0) as TotalPago,
					ISNULL((select top 1 VS.SaldoActual 
						from VendedoresSaldos VS
						where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS Saldo, 
					ISNULL((select top 1 isnull(SUM(VSFD.Monto),0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS Financiamientos, 
					ISNULL((select top 1 isnull(VSV.Creditos,0) 
						from VendedoresSaldos VS
						left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
						left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
						where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
						group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha, VS.IdSurtido 
						order by VS.Fecha desc, VS.IdSurtido desc),0) AS CreditosInformales
				from FN_ComisionesDetalleFecha(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') 
				where IdVendedor <> 0 ' + @Filtro + ' 
				group by IdVendedor, Nomina, Vendedor
				order by Vendedor ' )		
	end

	if @Tipo = 20 or @Tipo = 21		--Reporte 
	begin			
			exec( '	select FN_ComisionesDetalleFecha.Fecha, IdVendedor, Nomina, Vendedor, SUM(VentaTotal) as VentaTotal, SUM(Pago) as Comision, SUM(AbonoMerma) as AbonoMerma, SUM(AbonoVolumen) as AbonoVolumen, SUM(CargoMerma) as CargoMerma,
				ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
					from VendedoresSaldos VS
					left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
					left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
					where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
					group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
					having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
					order by VS.Fecha desc),0) as SaldoVendedor,
				SUM(Pago) + SUM(AbonoMerma) + SUM(AbonoVolumen) - SUM(CargoMerma) + 
				ISNULL((select top 1 VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) 
					from VendedoresSaldos VS
					left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
					left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
					where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
					group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
					having VS.SaldoActual + isnull(SUM(VSFD.Monto),0) + isnull(VSV.Creditos,0) < 0
					order by VS.Fecha desc),0) as TotalPago,
				ISNULL((select top 1 isnull(SUM(VSFD.Monto),0) 
					from VendedoresSaldos VS
					left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
					left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
					where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
					group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
					order by VS.Fecha desc),0) AS Financiamientos, 
				ISNULL((select top 1 isnull(VSV.Creditos,0) 
					from VendedoresSaldos VS
					left outer join VendedoresSaldosValida VSV on VS.IdCedis = VSV.IdCedis and VS.IdSurtido = VSV.IdSurtido and VS.IdVendedor = VSV.IdVendedor 
					left outer join VendedoresSaldosFinanciaD VSFD on VSFD.IdCedis = VS.IdCedis and VS.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha  
					where VS.IdCedis = ' + @IdCedi + ' and VS.IdVendedor = FN_ComisionesDetalleFecha.IdVendedor and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 		
					group by VS.IdVendedor, VS.SaldoActual, VSV.Creditos, VS.Fecha 
					order by VS.Fecha desc),0) AS CreditosInformales	
				from FN_ComisionesDetalleFecha(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal + ''') 
				where IdVendedor <> 0 ' + @Filtro + ' 
				group by IdVendedor, Nomina, Vendedor, Fecha
				order by FN_ComisionesDetalleFecha.Fecha, Vendedor ' )		
	end

end

if @ReporteOrigen = 4 			-- Carga de Producto
begin

	If @Tipo = 1 			-- a nivel de ruta
	begin
		SELECT     distinct SUR.IdRuta as Número, RUT.Ruta
		FROM         Surtidos SUR INNER JOIN
		                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta
		WHERE     (SUR.IdCedis = @IdCedi) and (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY SUR.Fecha, SUR.IdSurtido, SUR.IdRuta, RUT.Ruta
		ORDER BY SUR.IdRuta
	end

	if @Tipo = 10
	begin			
		exec('
			SELECT     SUR.IdCedis, SUR.IdSurtido, SUR.Fecha, SUR.IdRuta, Rutas.Ruta, SURVEN.IdVendedor, VEN.Nomina AS Nómina, 
			                      VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS [Nombre del Vendedor], TPVEN.TipoVendedor AS Perfil, 
			                      CASE SUR.Status WHEN ''C'' THEN ''Carga Aplicada'' WHEN ''P'' THEN ''En Proceso'' WHEN ''A'' THEN ''Aplicado'' WHEN ''B'' THEN ''Baja'' END AS Estatus
			FROM         SurtidosVendedor SURVEN INNER JOIN
			                      Vendedores VEN ON VEN.IdCedis = SURVEN.IdCedis AND VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Rutas ON SUR.IdCedis = Rutas.IdCedis AND SUR.IdRuta = Rutas.IdRuta
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SURVEN.IdTipoVendedor = 1) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			ORDER BY SURVEN.Fecha, SUR.IdRuta')
	end
/*
	If @Tipo = 2	-- a nivel de vendedor
	begin

		SELECT DISTINCT 
		                      VEN.IdVendedor AS Número, TPVEN.TipoVendedor AS Tipo, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS [Nombre del Vendedor], 
		                      VEN.Nomina
		FROM         Vendedores VEN INNER JOIN
		                      SurtidosVendedor SURVEN INNER JOIN
		                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor ON VEN.IdCedis = SURVEN.IdCedis AND 
		                      VEN.IdVendedor = SURVEN.IdVendedor
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY VEN.IdVendedor, TPVEN.TipoVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina
		ORDER BY TPVEN.TipoVendedor DESC, [Nombre del Vendedor]

	end	

	if @Tipo = 20
	begin			

	end
*/
end

if @ReporteOrigen = 5 			-- Hoja de Liquidacion
begin

	If @Tipo = 1 			-- a nivel de ruta
	begin
		SELECT     distinct SUR.IdRuta as Número, RUT.Ruta
		FROM         Surtidos SUR INNER JOIN
		                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta
		WHERE     (SUR.IdCedis = @IdCedi) and (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY SUR.Fecha, SUR.IdSurtido, SUR.IdRuta, RUT.Ruta
		ORDER BY SUR.IdRuta

	end


	if @Tipo = 10
	begin			
		exec('
			SELECT     SUR.IdCedis, SUR.Fecha, SUR.IdSurtido, SUR.IdRuta, RUT.Ruta, SURDET.IdProducto AS ''Cve. Prod.'', PROD.Producto AS Producto, 
			                      SURDET.Surtido AS Carga, SURDET.VentaCredito AS Credito, SURDET.VentaContado AS Contado, SURDET.DevBuena AS ''Dev. Buena'', 
			                      SURDET.DevMala AS ''Dev. Mala'', SURDET.Obsequios AS Obsequios, SURDET.Precio AS Precio, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
			                      ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total, 
                      			      CASE SUR.Status WHEN ''C'' THEN ''Carga Aplicada'' WHEN ''P'' THEN ''En Proceso'' WHEN ''A'' THEN ''Aplicado'' WHEN ''B'' THEN ''Baja'' END AS Estatus
			FROM         SurtidosDetalle SURDET INNER JOIN
			                      Surtidos SUR ON SURDET.IdCedis = SUR.IdCedis AND SURDET.IdSurtido = SUR.IdSurtido INNER JOIN
			                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
			                      Productos PROD ON SURDET.IdProducto = PROD.IdProducto LEFT OUTER JOIN
			                      VentasDetalle VENDET ON SURDET.IdCedis = VENDET.IdCedis AND SURDET.IdSurtido = VENDET.IdSurtido AND 
			                      SURDET.IdProducto = VENDET.IdProducto
			WHERE     (SURDET.IdCedis = ' + @IdCedi + ') AND (SURDET.Surtido > 0) AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ') 
			GROUP BY SURDET.IdProducto, PROD.Producto, SURDET.Surtido, SURDET.VentaCredito, SURDET.VentaContado, SURDET.DevBuena, SURDET.DevMala, 
			                      SURDET.Obsequios, SURDET.Precio, SUR.IdCedis, SUR.IdSurtido, SUR.Fecha, RUT.Ruta, SUR.IdRuta, SUR.Status
			ORDER BY SUR.Fecha, SUR.IdRuta, SUR.IdSurtido, CAST(SURDET.IdProducto AS bigint)')
	end

	If @Tipo = 2	-- a nivel de vendedor
	begin
		SELECT DISTINCT 
		                      VEN.IdVendedor AS Número, TPVEN.TipoVendedor AS Tipo, VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre AS [Nombre del Vendedor], 
		                      VEN.Nomina
		FROM         Vendedores VEN INNER JOIN
		                      SurtidosVendedor SURVEN INNER JOIN

		                      Surtidos SUR ON SURVEN.IdCedis = SUR.IdCedis AND SURVEN.IdSurtido = SUR.IdSurtido INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor ON VEN.IdCedis = SURVEN.IdCedis AND 
		                      VEN.IdVendedor = SURVEN.IdVendedor
		WHERE     (SUR.IdCedis = @IdCedi) AND (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		GROUP BY VEN.IdVendedor, TPVEN.TipoVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina
		ORDER BY TPVEN.TipoVendedor DESC, [Nombre del Vendedor]
	end	

	if @Tipo = 20
	begin			
		exec('
			SELECT     VSUR.IdCedis, VEN.IdVendedor AS IdAgrupa, 
			                      TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre AS DescripcionAgrupa, VSUR.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, VSUR.[Cve. Prod.], VSUR.Producto, VSUR.Conversion, VSUR.Carga, VSUR.Credito, VSUR.Contado, 
			                      VSUR.[Dev. Buena], VSUR.[Dev. Mala], VSUR.Obsequios, ISNULL(SUM(VENDET.Subtotal), 0) AS SubTotal, 
			                      ISNULL(SUM(VENDET.Cantidad * VENDET.Precio * VENDET.Iva), 0) AS Iva, ISNULL(SUM(VENDET.Total), 0) AS Total
			FROM         Familias FAM INNER JOIN
			                      SurtidosVendedor SURVEN INNER JOIN
			                      Vendedores VEN ON SURVEN.IdCedis = VEN.IdCedis AND SURVEN.IdVendedor = VEN.IdVendedor INNER JOIN
			                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor INNER JOIN
			                      VWDetalleSurtidosRuta VSUR ON SURVEN.IdCedis = VSUR.IdCedis AND SURVEN.IdSurtido = VSUR.IdSurtido INNER JOIN
			                      VentasDetalle VENDET ON VSUR.IdCedis = VENDET.IdCedis AND VSUR.IdSurtido = VENDET.IdSurtido AND VSUR.[Cve. Prod.] = VENDET.IdProducto ON 
			                      FAM.IdFamilia = VSUR.IdFamilia
			WHERE     (FAM.MostrarImpresion = ''S'') AND (VSUR.IdCedis = ' + @IdCedi + ') AND (VSUR.Carga > 0) AND (VSUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			GROUP BY VSUR.IdCedis, VEN.IdVendedor, TPVEN.TipoVendedor + '' - '' + VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre, VSUR.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion, VSUR.[Cve. Prod.], VSUR.Producto, VSUR.Conversion, VSUR.Carga, VSUR.Credito, VSUR.Contado, VSUR.[Dev. Buena], 
			                      VSUR.[Dev. Mala], VSUR.Obsequios
			ORDER BY DescripcionAgrupa, FAM.OrdenImpresion, CAST(VSUR.[Cve. Prod.] AS bigint)')
	end
end

if @ReporteOrigen = 6 			-- Corte de Caja
begin


	If @Tipo = 1 			-- a nivel de surtido por dia
	begin
		SELECT     SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido AS Surtido, RUT.Ruta, ISNULL(VVTACONT.Subtotal, 0) AS [Venta Contado], ISNULL(VVTACONT.IVA, 
		                      0) AS Iva, ISNULL(VVTACONT.Total, 0) AS [Total Contado], ISNULL(VVTACRED.Subtotal, 0) AS [Venta Crédito], ISNULL(VVTACRED.IVA, 0) AS Iva, 
		                      ISNULL(VVTACRED.Total, 0) AS [Total Crédito]
		FROM         Surtidos SUR INNER JOIN
		                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
		                      VWSurtidoVentaCredito VVTACRED ON SUR.IdCedis = VVTACRED.IdCedis AND SUR.IdSurtido = VVTACRED.IdSurtido LEFT OUTER JOIN
		                      VWSurtidoVentaContado VVTACONT ON SUR.IdCedis = VVTACONT.IdCedis AND SUR.IdSurtido = VVTACONT.IdSurtido
		WHERE     (SUR.IdCedis = @IdCedi) and (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		ORDER BY SUR.IdCedis, SUR.Fecha, SUR.IdRuta
	end


	if @Tipo = 10		-- tambien se usa para excel
	begin			
		exec('

			SELECT     SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido AS Surtido, RUT.Ruta, ISNULL( VVTACONT.Total, 0) AS [Venta Contado], 
				ISNULL(( select SUM(SD.Cantidad * SD.IdDenominacion * isnull(TC1.TipoCambio, 1))
				from SurtidosDenominacion SD LEFT OUTER JOIN 
				TipoDeCambio TC1 on TC1.IdMoneda = SD.IdMoneda and TC1.Fecha = SUR.Fecha 
				where SD.IdCedis = SUR.IdCedis AND SD.IdSurtido = SUR.IdSurtido ), 0)
				+ ISNULL(( select SUM(SCH.Importe * isnull(TC2.TipoCambio, 1))
				from SurtidosCheque SCH LEFT OUTER JOIN
				TipoDeCambio TC2 on TC2.IdMoneda = SCH.IdMoneda and TC2.Fecha = SUR.Fecha
				where SCH.IdCedis = SUR.IdCedis and SCH.IdSurtido = SUR.IdSurtido ), 0) AS [Efectivo], 		
				ISNULL(( select SUM(SD.Cantidad * SD.IdDenominacion * isnull(TC1.TipoCambio, 1))
				from SurtidosDenominacion SD LEFT OUTER JOIN 
				TipoDeCambio TC1 on TC1.IdMoneda = SD.IdMoneda and TC1.Fecha = SUR.Fecha 
				where SD.IdCedis = SUR.IdCedis AND SD.IdSurtido = SUR.IdSurtido ), 0)
				+ ISNULL(( select SUM(SCH.Importe * isnull(TC2.TipoCambio, 1))
				from SurtidosCheque SCH LEFT OUTER JOIN
				TipoDeCambio TC2 on TC2.IdMoneda = SCH.IdMoneda and TC2.Fecha = SUR.Fecha
				where SCH.IdCedis = SUR.IdCedis and SCH.IdSurtido = SUR.IdSurtido ), 0)  
				- ISNULL( VVTACONT.Total, 0) AS [Diferencia], 						
						ISNULL(VVTACRED.Subtotal, 0) AS [Venta Crédito], ISNULL(VVTACRED.IVA, 0) 
								  AS [Iva Crédito], ISNULL(VVTACRED.Total, 0) AS [Total Crédito],
									  isnull((SELECT     TOP 1  VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre
										FROM          SurtidosVendedor SURVEN INNER JOIN
															   Vendedores VEN ON SURVEN.IdCedis = VEN.IdCedis AND SURVEN.IdVendedor = VEN.IdVendedor
										WHERE      SUR.IdCedis = SURVEN.idcedis AND SUR.IdSurtido = SURVEN.IdSurtido
										ORDER BY SURVEN.idtipovendedor), ''Vendedor no asignado'') AS [Nombre del Vendedor]
			FROM         Surtidos SUR INNER JOIN
								  Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
								  VWSurtidoVentaCredito VVTACRED ON SUR.IdCedis = VVTACRED.IdCedis AND SUR.IdSurtido = VVTACRED.IdSurtido LEFT OUTER JOIN
								  VWSurtidoVentaContado VVTACONT ON SUR.IdCedis = VVTACONT.IdCedis AND SUR.IdSurtido = VVTACONT.IdSurtido LEFT OUTER JOIN
								  SurtidosDenominacion SD ON SD.IdCedis = SUR.IdCedis AND SD.IdSurtido = SUR.IdSurtido 
			WHERE     (SUR.IdCedis = ' + @IdCedi + ') AND (SUR.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')  
			GROUP BY SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido, RUT.Ruta, VVTACRED.Subtotal, VVTACRED.Iva, VVTACRED.Total, VVTACONT.Total
			ORDER BY SUR.IdCedis, SUR.Fecha, SUR.IdRuta')
	end
end

if @ReporteOrigen = 7 			-- Corte por Producto
begin
	If @Tipo = 1 			-- a nivel de surtido por dia
	begin
		SELECT     SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido AS Surtido, RUT.Ruta, ISNULL(VVTACONT.Subtotal, 0) AS [Venta Contado], ISNULL(VVTACONT.IVA, 
		                      0) AS Iva, ISNULL(VVTACONT.Total, 0) AS [Total Contado], ISNULL(VVTACRED.Subtotal, 0) AS [Venta Crédito], ISNULL(VVTACRED.IVA, 0) AS Iva, 
		                      ISNULL(VVTACRED.Total, 0) AS [Total Crédito]
		FROM         Surtidos SUR INNER JOIN
		                      Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
		                      VWSurtidoVentaCredito VVTACRED ON SUR.IdCedis = VVTACRED.IdCedis AND SUR.IdSurtido = VVTACRED.IdSurtido LEFT OUTER JOIN
		                      VWSurtidoVentaContado VVTACONT ON SUR.IdCedis = VVTACONT.IdCedis AND SUR.IdSurtido = VVTACONT.IdSurtido
		WHERE     (SUR.IdCedis = @IdCedi) and (SUR.Fecha BETWEEN @FechaInicial AND @FechaFinal)
		ORDER BY SUR.IdCedis, SUR.Fecha, SUR.IdRuta
	end

	If @Tipo = 10 			-- por surtido
	begin
		exec('
			SELECT     SURDET.IdProducto AS IdProducto, PROD.Producto AS Producto, ISNULL(SUM(VVENCON.Cantidad), 0) AS PiezasContado, 
			                      ISNULL(AVG(VVENCON.Precio), 0) AS PrecioContado, ISNULL(SUM(VVENCON.Total), 0) AS TotalContado, ISNULL(SUM(VVENCRED.Cantidad), 0) 
			                      AS PiezasCredito, ISNULL(AVG(VVENCRED.Precio), 0) AS PrecioCredito, ISNULL(SUM(VVENCRED.Total), 0) AS TotalCredito, FAM.IdFamilia, FAM.Familia,
			                       FAM.OrdenImpresion, SURDET.Fecha
			FROM         SurtidosDetalle SURDET INNER JOIN
			                      Productos PROD ON PROD.IdProducto = SURDET.IdProducto INNER JOIN
			                      Familias FAM ON PROD.IdFamilia = FAM.IdFamilia LEFT OUTER JOIN
			                      VWVentasContadoRep VVENCON ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto LEFT OUTER JOIN
			                      VWVentasCreditoRep VVENCRED ON VVENCRED.IdCedis = SURDET.IdCedis AND VVENCRED.IdSurtido = SURDET.IdSurtido AND 
			                      SURDET.IdProducto = VVENCRED.IdProducto
			WHERE     (FAM.MostrarImpresion = ''S'') AND (SURDET.IdCedis = ' + @IdCedi + ') AND (SURDET.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')

			GROUP BY SURDET.IdProducto, PROD.Producto, FAM.IdFamilia, FAM.Familia, FAM.OrdenImpresion, SURDET.Fecha
			ORDER BY SURDET.Fecha, FAM.OrdenImpresion, CAST(SURDET.IdProducto AS int)')
	end

	If @Tipo = 11 			-- por surtido para XLS
	begin
		exec('
			SELECT     SURDET.Fecha, FAM.Familia, SURDET.IdProducto AS [Cve. Prod.], PROD.Producto AS Producto, ISNULL(SUM(VVENCON.Cantidad), 0) 
			                      AS [Cantidad Contado], ISNULL(AVG(VVENCON.Precio), 0) AS [Precio Contado], ISNULL(SUM(VVENCON.Total), 0) AS [Total Contado], 
			                      ISNULL(SUM(VVENCRED.Cantidad), 0) AS [Cantidad Crédito], ISNULL(AVG(VVENCRED.Precio), 0) AS [Precio Crédito], ISNULL(SUM(VVENCRED.Total), 0) 
			                      AS [Total Crédito], FAM.IdFamilia, FAM.OrdenImpresion
			FROM         SurtidosDetalle SURDET INNER JOIN
			                      Productos PROD ON PROD.IdProducto = SURDET.IdProducto INNER JOIN
			                      Familias FAM ON PROD.IdFamilia = FAM.IdFamilia LEFT OUTER JOIN
			                      VWVentasContadoRep VVENCON ON VVENCON.IdCedis = SURDET.IdCedis AND VVENCON.IdSurtido = SURDET.IdSurtido AND 
			                      SURDET.IdProducto = VVENCON.IdProducto LEFT OUTER JOIN
			                      VWVentasCreditoRep VVENCRED ON VVENCRED.IdCedis = SURDET.IdCedis AND VVENCRED.IdSurtido = SURDET.IdSurtido AND 
			                      SURDET.IdProducto = VVENCRED.IdProducto
			WHERE     (FAM.MostrarImpresion = ''S'') AND (SURDET.IdCedis = ' + @IdCedi + ') AND (SURDET.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			GROUP BY SURDET.IdProducto, PROD.Producto, FAM.IdFamilia, FAM.Familia, FAM.OrdenImpresion, SURDET.Fecha
			ORDER BY SURDET.Fecha, FAM.OrdenImpresion, CAST(SURDET.IdProducto AS int)')
	end
end


if @ReporteOrigen = 8 			-- RESUMEN DE PRECIOS
begin
	If @Tipo = 1 			-- Por Cedis
	begin
		select IdCedis, Cedis from Cedis where IdCedis = @IdCedi
	end

	If @Tipo = 10 			-- Por Tipo de Lista
	begin
		exec(' Select IdTipoLista, TipoLista from TipoLista order by IdTipoLista ')
	end

	If @Tipo = 11 			-- Por tipo de lista, para excel.
	begin

		SELECT     0 AS Orden, 'Por CEDIS' AS Tipo, precioslistacedis.idcedis AS [Número], cedis AS Nombre, 
		                      CASE tipolista WHEN 'BA' THEN 'BASE' WHEN 'CL' THEN 'CLIENTE' WHEN 'RU' THEN 'RUTA' END AS [Tipo de Lista], 
		                      precioslistacedis.idlista AS [Número de Lista], descripcion AS [Descripción]
		FROM         precioslistacedis INNER JOIN
		                      cedis ON cedis.idcedis = precioslistacedis.idcedis INNER JOIN
		                      precioslista ON precioslistacedis.idlista = precioslista.idlista
		WHERE     precioslistacedis.idcedis = @IdCedi
		UNION
		SELECT     1 AS Orden, 'Por Cliente', precioslistacliente.idcliente, razonsocial, 
		                      CASE tipolista WHEN 'BA' THEN 'BASE' WHEN 'CL' THEN 'CLIENTE' WHEN 'RU' THEN 'RUTA' END, precioslistacliente.idlista, 
		                      descripcion
		FROM         precioslistacliente INNER JOIN
		                      clientes ON clientes.idcliente = precioslistacliente.idcliente INNER JOIN
		                      precioslista ON precioslistacliente.idlista = precioslista.idlista
		WHERE     precioslistacliente.idcedis = @IdCedi
		UNION
		SELECT     2, 'Por Ruta', precioslistaruta.idruta, ruta, 
		                      CASE tipolista WHEN 'BA' THEN 'BASE' WHEN 'CL' THEN 'CLIENTE' WHEN 'RU' THEN 'RUTA' END, precioslistaruta.idlista, 
		                      descripcion
		FROM         precioslistaruta INNER JOIN
		                      rutas ON rutas.idruta = precioslistaruta.idruta INNER JOIN
		                      precioslista ON precioslistaruta.idlista = precioslista.idlista
		WHERE     precioslistaruta.idcedis = @IdCedi
		ORDER BY Orden, [Tipo de Lista], Nombre

	end
end

if @ReporteOrigen = 9 			-- SALDOS DE CANASTILLA

begin
	If @Tipo = 2 			-- para vendedores y ayudantes acumulado
	begin
		SELECT     SURVEN.IdVendedor AS [No. Vend.], LTRIM(RTRIM(VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre)) AS Nombre, 
		                      VEN.Nomina AS [No. Nómina], TPVEN.TipoVendedor
		FROM         Rejas REJ INNER JOIN
		                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
		                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor
		WHERE     (REJ.IdCedis = @IdCedi) AND (REJ.Fecha BETWEEN @FechaInicial and @FechaFinal)
		GROUP BY SURVEN.IdVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina, TPVEN.TipoVendedor
		ORDER BY TPVEN.TipoVendedor desc, Nombre
	end

	If @Tipo = 20 			-- para vendedores y ayudantes acumulado
	begin
		exec ('
			SELECT     REJ.IdCedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre + '' ('' + TPVEN.TipoVendedor + '')'')) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], 
			                      PRO.Producto, REJ.Surtido, REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''') ' + @Filtro + ' 
			ORDER BY TPVEN.TipoVendedor DESC, Nombre, REJ.Fecha, REJ.IdProducto
		')
	end

	If @Tipo = 21 			-- para vendedores y ayudantes acumulado (reporte XLS)
	begin
		exec(' 
			SELECT     REJ.IdCedis, CED.Cedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre)) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], PRO.Producto, REJ.Surtido, 
			                      REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Cedis CED ON REJ.IdCedis = CED.IdCedis
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			ORDER BY CED.Cedis, Nombre, REJ.Fecha, REJ.IdProducto')
	end

	If @Tipo = 3 			-- solo para vendedores
	begin
		SELECT     SURVEN.IdVendedor AS [No. Vend.], LTRIM(RTRIM(VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre)) AS Nombre, 
		                      VEN.Nomina AS [No. Nómina], TPVEN.TipoVendedor
		FROM         Rejas REJ INNER JOIN
		                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
		                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor
		WHERE     (REJ.IdCedis = @IdCedi) AND (TPVEN.IdTipoVendedor = 1) AND (REJ.Fecha BETWEEN @FechaInicial and @FechaFinal)
		GROUP BY SURVEN.IdVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina, TPVEN.TipoVendedor
		ORDER BY Nombre
	end

	If @Tipo = 30 			-- solo para vendedores
	begin
		exec ('
			SELECT     REJ.IdCedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre + '' ('' + TPVEN.TipoVendedor + '')'')) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], 
			                      PRO.Producto, REJ.Surtido, REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (TPVEN.IdTipoVendedor = 1) AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''') ' + @Filtro + ' 
			ORDER BY TPVEN.TipoVendedor DESC, Nombre, REJ.Fecha, REJ.IdProducto
		')
	end

	If @Tipo = 31 			-- Solo para vendedores (reporte XLS)
	begin
		exec(' 
			SELECT     REJ.IdCedis, CED.Cedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre)) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], PRO.Producto, REJ.Surtido, 
			                      REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Cedis CED ON REJ.IdCedis = CED.IdCedis
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (TPVEN.IdTipoVendedor = 1) AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			ORDER BY CED.Cedis, Nombre, REJ.Fecha, REJ.IdProducto')
	end

	If @Tipo = 4 			-- solo para ayudantes
	begin
		SELECT     SURVEN.IdVendedor AS [No. Vend.], LTRIM(RTRIM(VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre)) AS Nombre, 
		                      VEN.Nomina AS [No. Nómina], TPVEN.TipoVendedor
		FROM         Rejas REJ INNER JOIN
		                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
		                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
		                      TipoVendedor TPVEN ON SURVEN.IdTipoVendedor = TPVEN.IdTipoVendedor
		WHERE     (REJ.IdCedis = @IdCedi) AND (TPVEN.IdTipoVendedor = 2) AND (REJ.Fecha BETWEEN @FechaInicial and @FechaFinal)
		GROUP BY SURVEN.IdVendedor, VEN.ApPaterno, VEN.ApMaterno, VEN.Nombre, VEN.Nomina, TPVEN.TipoVendedor
		ORDER BY Nombre
	end

	If @Tipo = 40 			-- solo para ayudantes
	begin
		exec ('
			SELECT     REJ.IdCedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre + '' ('' + TPVEN.TipoVendedor + '')'')) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], 
			                      PRO.Producto, REJ.Surtido, REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (TPVEN.IdTipoVendedor = 2) AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''') ' + @Filtro + ' 
			ORDER BY TPVEN.TipoVendedor DESC, Nombre, REJ.Fecha, REJ.IdProducto
		')
	end

	If @Tipo = 41 			-- Solo para ayudantes (reporte XLS)
	begin
		exec(' 
			SELECT     REJ.IdCedis, CED.Cedis, REJ.Fecha, REJ.IdSurtido, SURVEN.IdVendedor AS [No. Vend.], 
			                      LTRIM(RTRIM(VEN.ApPaterno + '' '' + VEN.ApMaterno + '' '' + VEN.Nombre)) AS Nombre, VEN.Nomina, REJ.IdProducto AS [Cve. Prod.], PRO.Producto, REJ.Surtido, 
			                      REJ.Devolucion, REJ.Devolucion - REJ.Surtido AS Saldo, TPVEN.TipoVendedor
			FROM         Rejas REJ INNER JOIN
			                      Productos PRO ON PRO.IdProducto = REJ.IdProducto INNER JOIN
			                      SurtidosVendedor SURVEN ON SURVEN.IdCedis = REJ.IdCedis AND SURVEN.IdSurtido = REJ.IdSurtido INNER JOIN
			                      TipoVendedor TPVEN ON TPVEN.IdTipoVendedor = SURVEN.IdTipoVendedor INNER JOIN
			                      Vendedores VEN ON VEN.IdVendedor = SURVEN.IdVendedor INNER JOIN
			                      Cedis CED ON REJ.IdCedis = CED.IdCedis
			WHERE     (REJ.IdCedis = ' + @IdCedi + ') AND (TPVEN.IdTipoVendedor = 2) AND (REJ.Fecha BETWEEN ''' + @FechaInicial + ''' AND ''' + @FechaFinal +''' ' + @Filtro + ')
			ORDER BY CED.Cedis, Nombre, REJ.Fecha, REJ.IdProducto')
	end

end


if @ReporteOrigen = 10 			-- FACTURA GLOBAL DE CONTADO
begin
	If @Tipo = 1			-- por día
	begin
		execute sel_VentasContado @IdCedi, @FechaInicial, 1
	end

	If @Tipo = 10 			-- por surtido
	begin
		execute sel_VentasContado @IdCedi, @FechaInicial, 2
	end
end

if @ReporteOrigen = 11 			-- FACTURAS DE CRÉDITO
begin
	If @Tipo = 1 or @Tipo = 2			-- por fecha
	begin
		select 'Ventas de Crédito del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 20			-- acumulado
	begin
		execute sel_VentasCredito @IdCedi, 0, 0, 0, @FechaInicial, @FechaFinal, 1
	end

	If @Tipo = 11					--XLS Facturas
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente AS [Número de Cliente], CTE.RazonSocial AS Nombre, SUR.IdRuta AS Ruta, VEN.Serie, VEN.Folio, 
		                      VEN.Subtotal AS [Subtotal Factura], VEN.Iva AS [IVA Factura], VEN.Total AS [Total Factura]
		FROM         Ventas VEN INNER JOIN
		                      Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
		                      Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente INNER JOIN
		                      Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE     (VEN.IdCedis = @IdCedi) AND (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (VEN.IdTipoVenta IN
		                          (SELECT     IdTipoVenta
		                            FROM          VentasTipo
		                            WHERE      Tipo = 1))
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, VEN.Serie, VEN.Folio
	end

	If @Tipo = 21					--XLS Facturas a Detalle
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente AS [Número de Cliente], CTE.RazonSocial AS Nombre, SUR.IdRuta AS Ruta, VEN.Serie, VEN.Folio, 
		                      VEN.Subtotal AS [Subtotal Factura], VEN.Iva AS [IVA Factura], VEN.Total AS [Total Factura], VENDET.IdProducto AS [Clave Producto], PRO.Producto, 
		                      VENDET.Cantidad, VENDET.Precio, VENDET.Subtotal AS [Subtotal Detalle], VENDET.Cantidad * VENDET.Precio * VENDET.Iva AS [IVA Detalle], 
		                      VENDET.Total AS [Total Detalle]
		FROM         Ventas VEN INNER JOIN
		                      VentasDetalle VENDET ON VENDET.IdCedis = VEN.IdCedis AND VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
		                      VENDET.Folio = VEN.Folio INNER JOIN
		                      Productos PRO ON PRO.IdProducto = VENDET.IdProducto INNER JOIN
		                      Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
		                      Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente INNER JOIN
		                      Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE     (VEN.IdCedis = @IdCedi) AND (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (VEN.IdTipoVenta IN
		                          (SELECT     IdTipoVenta
		                            FROM          VentasTipo
		                            WHERE      Tipo = 1))
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, VEN.Serie, VEN.Folio
	end
end

if @ReporteOrigen = 12 			-- LISTAS DE PRECIOS
begin
	If @Tipo = 1 or @Tipo = 2 or @Tipo = 3		-- por lista
	begin
		set @Tipo = @Tipo +3 
		execute sel_PreciosListasRep @IdCedi, @Tipo 
	end


	If @Tipo = 10 or @Tipo = 20 or @Tipo = 30		-- por lista
	begin
		exec ('select PreciosDetalle.IdLista, PreciosLista.Descripcion, Productos.IdFamilia, Familia, PreciosDetalle.IdProducto, Producto, Precio, Iva, Precio * (1+iva) as Total
		from PreciosDetalle
		inner join PreciosLista on PreciosDetalle.IdLista = PreciosLista.IdLista
		inner join Productos on PreciosDetalle.IdProducto = Productos.IdProducto
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		where PreciosDetalle.Precio <> 0 and ' + @Filtro + ' 
		order by PreciosDetalle.IdLista, Productos.IdFamilia, PreciosDetalle.IdProducto')
	end

	If @Tipo = 11		-- por lista a XLS
	begin
		-- if ltrim( rtrim( @Filtro ) ) = '' set @
		exec ('
			SELECT     PreciosDetalle.IdLista, Productos.IdFamilia, PreciosLista.Descripcion as Lista, Familias.Familia, PreciosDetalle.IdProducto as [Clave de Producto], Productos.Producto, 
			                      PreciosDetalle.Precio, Productos.Iva, PreciosDetalle.Precio * (1 + Productos.Iva) AS Total
			FROM         PreciosDetalle INNER JOIN
			                      PreciosLista ON PreciosDetalle.IdLista = PreciosLista.IdLista INNER JOIN
			                      Productos ON PreciosDetalle.IdProducto = Productos.IdProducto INNER JOIN
			                      Familias ON Familias.IdFamilia = Productos.IdFamilia
			WHERE  PreciosDetalle.Precio <> 0 and ' + @Filtro + ' 			
			ORDER BY PreciosDetalle.IdLista, Familias.OrdenImpresion, PreciosDetalle.IdProducto')
	end
end

if @ReporteOrigen = 14 			-- FACTURAS DE CONTADO
begin
	If @Tipo = 1 or @Tipo = 2			-- por fecha
	begin
		select 'Ventas de Contado del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 20			-- acumulado
	begin
		execute sel_VentasContadoReporte @IdCedi, 0, 0, 0, @FechaInicial, @FechaFinal, 1
	end

	If @Tipo = 11 					-- por factura Detallada
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente AS [Número de Cliente], CTE.RazonSocial AS Nombre, SUR.IdRuta AS Ruta, VEN.Serie, VEN.Folio, 
		                      VEN.Subtotal AS [Subtotal Factura], VEN.Iva AS [IVA Factura], VEN.Total AS [Total Factura]
		FROM         Ventas VEN INNER JOIN
		                      Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
		                      Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente INNER JOIN
		                      Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE     (VEN.IdCedis = @IdCedi) AND (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (VEN.IdTipoVenta IN
		                          (SELECT     IdTipoVenta
		                            FROM          VentasTipo
		                            WHERE      Tipo = 2))
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, VEN.Serie, VEN.Folio
	end

	If @Tipo = 21 					-- por factura Detallada
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente AS [Número de Cliente], CTE.RazonSocial AS Nombre, SUR.IdRuta AS Ruta, VEN.Serie, VEN.Folio, 
		                      VEN.Subtotal AS [Subtotal Factura], VEN.Iva AS [IVA Factura], VEN.Total AS [Total Factura], VENDET.IdProducto AS [Clave Producto], PRO.Producto, 
		                      VENDET.Cantidad, VENDET.Precio, VENDET.Subtotal AS [Subtotal Detalle], VENDET.Cantidad * VENDET.Precio * VENDET.Iva AS [IVA Detalle], 
		                      VENDET.Total AS [Total Detalle]
		FROM         Ventas VEN INNER JOIN
		                      VentasDetalle VENDET ON VENDET.IdCedis = VEN.IdCedis AND VENDET.IdSurtido = VEN.IdSurtido AND VENDET.IdTipoVenta = VEN.IdTipoVenta AND 
		                      VENDET.Folio = VEN.Folio INNER JOIN
		                      Productos PRO ON PRO.IdProducto = VENDET.IdProducto INNER JOIN
		                      Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
		                      Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente INNER JOIN
		                      Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE     (VEN.IdCedis = @IdCedi) AND (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND (VEN.IdTipoVenta IN
		                          (SELECT     IdTipoVenta
		                            FROM          VentasTipo
		                            WHERE      Tipo = 2))
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, VEN.Serie, VEN.Folio
	end



end

if @ReporteOrigen = 15 			-- Movimientos de Almacen
begin
	If @Tipo = 1 		-- a Nivel de Movimiento
	begin
		SELECT DISTINCT MOV.IdMovimiento, MOV.Fecha, MOV.IdMovimiento as Número, MOV.Folio as Folio
		FROM         FN_MovimientosAlmacen(@IdCedi, @FechaInicial, @FechaFinal) MOV INNER JOIN
		                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
		ORDER BY  MOV.Fecha, Número	
	end

	If @Tipo = 10
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, SUM(MOV.Cantidad) 
			                      AS cantidad, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, TPMOV.EntradaSalida, SUM(PRO.Conversion * MOV.Cantidad) 
			                      AS CantidadKlts, MOV.Fecha, MOV.IdMovimiento as IdAgrupa, cast(MOV.IdMovimiento as varchar(10)) + '' / '' + MOV.Folio + '' / '' + MOV.Observaciones as DescripcionAgrupa
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, MOV.Fecha, MOV.IdMovimiento, MOV.Folio, MOV.Observaciones
			ORDER BY MOV.Fecha, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, MOV.IdMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 11		--XLS
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PRO.Conversion, CED.Cedis, MOV.Fecha, 
			                      TPMOV.EntradaSalida AS [Entrada/Salida], TPMOV.TipoMovimiento AS [Tipo de Movimiento], MOV.IdMovimiento AS [Número de Movimiento], 
			                      MOV.Folio, MOV.Observaciones, FAM.Familia, MOV.IdProducto AS [Clave de Producto], PRO.Producto, SUM(MOV.Cantidad) AS [Cantidad (Pzas)], 
			                      SUM(PRO.Conversion * MOV.Cantidad) AS [Cantidad (Klts)]

			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON MOV.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, MOV.Fecha, MOV.IdMovimiento, MOV.Folio, MOV.Observaciones, CED.Cedis
			ORDER BY CED.Cedis, MOV.Fecha, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, MOV.IdMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 2  		-- a Nivel de Fecha 
	begin
		SELECT DISTINCT 
		                      MOV.IdTipoMovimiento, CASE TPMOV.EntradaSalida WHEN 'E' THEN 'Entrada' ELSE 'Salida' END AS [Clasificación], 
		                      TPMOV.TipoMovimiento as [Tipo de Movimiento]
		FROM         FN_MovimientosAlmacen(@IdCedi, @FechaInicial, @FechaFinal) MOV INNER JOIN
		                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
		ORDER BY [Clasificación], [Tipo de Movimiento]
	end

	If @Tipo = 20
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, SUM(MOV.Cantidad) 
			                      AS cantidad, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, TPMOV.EntradaSalida, SUM(PRO.Conversion * MOV.Cantidad) 
			                      AS CantidadKlts, MOV.Fecha as IdAgrupa, MOV.Fecha as DescripcionAgrupa
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, MOV.Fecha
			ORDER BY MOV.Fecha, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 21		-- XLS
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PRO.Conversion, CED.Cedis, MOV.Fecha, 
			                      TPMOV.EntradaSalida AS [Entrada/Salida], TPMOV.TipoMovimiento AS [Tipo de Movimiento], FAM.Familia, MOV.IdProducto AS [Clave de Producto], 
			                      PRO.Producto, SUM(MOV.Cantidad) AS [Cantidad (Pzas)], SUM(PRO.Conversion * MOV.Cantidad) AS [Cantidad (Klts)]
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON MOV.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, MOV.Fecha, CED.Cedis
			ORDER BY CED.Cedis, MOV.Fecha, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 3 		-- a Nivel de Tipo de Movimiento
	begin
		SELECT DISTINCT 
		                      TPMOV.EntradaSalida as Tipo, CASE TPMOV.EntradaSalida WHEN 'E' THEN 'Entrada' ELSE 'Salida' END AS [Clasificación]
		FROM         FN_MovimientosAlmacen(@IdCedi, @FechaInicial, @FechaFinal) MOV INNER JOIN
		                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento
		ORDER BY Tipo
	end

	If @Tipo = 30
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, SUM(MOV.Cantidad) 
			                      AS cantidad, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, TPMOV.EntradaSalida AS IdAgrupa, 
			                      CASE TPMOV.EntradaSalida WHEN ''E'' THEN ''Entrada'' ELSE ''Salida'' END AS DescripcionAgrupa, SUM(PRO.Conversion * MOV.Cantidad) 
			                      AS CantidadKlts
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida
			ORDER BY TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end
	
	If @Tipo = 31		--XLS
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, TPMOV.EntradaSalida, PRO.IdFamilia, FAM.OrdenImpresion AS FamOrdenImpresion, PRO.Conversion, 
			                      CED.Cedis, CASE TPMOV.EntradaSalida WHEN ''E'' THEN ''Entrada'' ELSE ''Salida'' END AS [Entrada/Salida], 
			                      TPMOV.TipoMovimiento AS [Tipo de Movimiento], FAM.Familia, MOV.IdProducto AS [Clave de Producto], PRO.Producto, SUM(MOV.Cantidad) 
			                      AS [Cantidad (Pzas)], SUM(PRO.Conversion * MOV.Cantidad) AS [Cantidad (Klts)]
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Cedis CED ON MOV.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, CED.Cedis
			ORDER BY CED.Cedis, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 4 		-- a Nivel de Marca de Productos
	begin
		SELECT DISTINCT PRO.IdMarca as [Número], MAR.Marca, MAR.OrdenImpresion AS MarOrdenImpresion
		FROM         FN_MovimientosAlmacen(@IdCedi, @FechaInicial, @FechaFinal) MOV INNER JOIN
		                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
		                      Marcas MAR ON PRO.IdMarca = MAR.IdMarca
		ORDER BY MarOrdenImpresion
	end


	If @Tipo = 40
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, SUM(MOV.Cantidad) 
			                      AS cantidad, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, TPMOV.EntradaSalida, SUM(PRO.Conversion * MOV.Cantidad) 
			                      AS CantidadKlts, PRO.IdMarca as IdAgrupa, MAR.Marca as DescripcionAgrupa, MAR.OrdenImpresion AS MarOrdenImpresion
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Marcas MAR ON PRO.IdMarca = MAR.IdMarca
			WHERE     (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, PRO.IdMarca, MAR.Marca, MAR.OrdenImpresion
			ORDER BY MarOrdenImpresion, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 41		--XLS
	begin
		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdMarca, MAR.OrdenImpresion AS MarOrdenImpresion, PRO.IdFamilia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PRO.Conversion, CED.Cedis, MAR.Marca, TPMOV.EntradaSalida AS [Entrada/Salida], 
			                      TPMOV.TipoMovimiento AS [Tipo de Movimiento], FAM.Familia, MOV.IdProducto AS [Clave de Producto], PRO.Producto, SUM(MOV.Cantidad) 
			                      AS [Cantidad (Pzas)], SUM(PRO.Conversion * MOV.Cantidad) AS [Cantidad (Klts)]
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Marcas MAR ON PRO.IdMarca = MAR.IdMarca INNER JOIN
			                      Cedis CED ON MOV.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') AND (MAR.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, PRO.IdMarca, MAR.Marca, MAR.OrdenImpresion, CED.Cedis
			ORDER BY CED.Cedis, MarOrdenImpresion, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 5 		-- a Nivel de Grupo de Productos
	begin
		SELECT DISTINCT PRO.IdGrupo as [Número], GPO.Grupo, GPO.OrdenImpresion AS GpoOrdenImpresion
		FROM         FN_MovimientosAlmacen(@IdCedi, @FechaInicial, @FechaFinal) MOV INNER JOIN
		                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
		                      Grupos GPO ON PRO.IdGrupo = GPO.IdGrupo
		ORDER BY GpoOrdenImpresion
	end


	If @Tipo = 50
	begin

		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, SUM(MOV.Cantidad) 
			                      AS cantidad, FAM.Familia, FAM.OrdenImpresion AS FamOrdenImpresion, TPMOV.EntradaSalida, PRO.IdGrupo as IdAgrupa, GPO.Grupo as DescripcionAgrupa, 
			                      GPO.OrdenImpresion AS GpoOrdenImpresion, SUM(PRO.Conversion * MOV.Cantidad) AS CantidadKlts
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Grupos GPO ON PRO.IdGrupo = GPO.IdGrupo
			WHERE     (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, PRO.IdGrupo, GPO.Grupo, GPO.OrdenImpresion
			ORDER BY GpoOrdenImpresion, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end

	If @Tipo = 51
	begin

		exec('
			SELECT     MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdGrupo, GPO.OrdenImpresion AS GpoOrdenImpresion, PRO.IdFamilia, 
			                      FAM.OrdenImpresion AS FamOrdenImpresion, PRO.Conversion, CED.Cedis, GPO.Grupo, TPMOV.EntradaSalida AS [Entrada/Salida], 
			                      TPMOV.TipoMovimiento AS [Tipo de Movimiento], FAM.Familia, MOV.IdProducto AS [Clave de Producto], PRO.Producto, SUM(MOV.Cantidad) 
			                      AS [Cantidad (Pzas)], SUM(PRO.Conversion * MOV.Cantidad) AS [Cantidad (Klts)]
			FROM         FN_MovimientosAlmacen(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') MOV INNER JOIN
			                      TipoMovimiento TPMOV ON MOV.IdCedis = TPMOV.IdCedis AND MOV.IdTipoMovimiento = TPMOV.IdTipoMovimiento INNER JOIN
			                      Productos PRO ON MOV.IdProducto = PRO.IdProducto INNER JOIN
			                      Familias FAM ON PRO.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Grupos GPO ON PRO.IdGrupo = GPO.IdGrupo INNER JOIN
			                      Cedis CED ON MOV.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') AND (GPO.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY MOV.IdCedis, MOV.IdTipoMovimiento, PRO.IdFamilia, MOV.IdProducto, PRO.Conversion, TPMOV.TipoMovimiento, PRO.Producto, FAM.Familia, 
			                      FAM.OrdenImpresion, TPMOV.EntradaSalida, PRO.IdGrupo, GPO.Grupo, GPO.OrdenImpresion, CED.Cedis
			ORDER BY CED.Cedis, GpoOrdenImpresion, TPMOV.EntradaSalida, TPMOV.TipoMovimiento, FamOrdenImpresion, MOV.IdProducto')
	end
end

if @ReporteOrigen = 16 			-- Ventas por Cliente
begin
	If @Tipo = 1 or @Tipo = 2 or @Tipo = 3		-- a Nivel de Totales por cliente, Por Tipo de Venta y por Factura
	begin
		SELECT DISTINCT VENCTE.IdCliente as [Número], CTE.RazonSocial as [Razón Social]
		FROM         FN_VentasPorClientePorFactura(@IdCedi, @FechaInicial, @FechaFinal) VENCTE INNER JOIN
		                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente
		ORDER BY CTE.RazonSocial
	end

	If @Tipo = 10
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, 
			                      FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, SUM(VENCTE.Cantidad) AS Cantidad, SUM(VENCTE.Conversion * VENCTE.Cantidad) 
			                      AS CantidadKlts, SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) AS Total, 0 AS IdAgrupa, 
					''Total de la Venta (crédito + contado)'' AS DescripcionAgrupa
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, 
			                      VENCTE.Conversion
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 11			--XLS
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdFamilia, FAM.OrdenImpresion, VENCTE.Conversion, CED.Cedis, VENCTE.IdCliente AS [Número de Cliente], 
			                      CTE.RazonSocial AS [Razón Social], FAM.Familia, VENCTE.IdProducto AS [Clave de Producto], VENCTE.Producto, SUM(VENCTE.Cantidad) 
			                      AS [Cantidad (Pzas)], SUM(VENCTE.Conversion * VENCTE.Cantidad) AS [Cantidad (Klts)], SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.IVA) AS IVA, 
			                      SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      Cedis CED ON VENCTE.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, 
			                      VENCTE.Conversion, CED.Cedis
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 20
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdTipoVenta as IdAgrupa, VENTIP.TipoVenta as DescripcionAgrupa, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto,
			                       VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, SUM(VENCTE.Cantidad) AS Cantidad, 
			                      SUM(VENCTE.Conversion * VENCTE.Cantidad) AS CantidadKlts, SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) 
			                      AS Total
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, 
			                      VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, VENCTE.IdTipoVenta, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 21			--XLS
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdFamilia, FAM.OrdenImpresion, VENCTE.Conversion, VENCTE.IdTipoVenta, CED.Cedis, VENTIP.TipoVenta AS [Tipo de Venta],
			                       VENCTE.IdCliente AS [Número de Cliente], CTE.RazonSocial AS [Razón Social], FAM.Familia, VENCTE.IdProducto AS [Clave de Producto], 
			                      VENCTE.Producto, SUM(VENCTE.Cantidad) AS [Cantidad (Pzas)], SUM(VENCTE.Conversion * VENCTE.Cantidad) AS [Cantidad (Klts)], SUM(VENCTE.IVA) 
			                      AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      Cedis CED ON VENCTE.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '

			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, 
			                      VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, CED.Cedis
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, VENCTE.IdTipoVenta, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 30
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.Serie + cast(VENCTE.Folio as varchar(15)) as IdAgrupa, 
					VENCTE.Serie + '' '' + cast(VENCTE.Folio as varchar(15)) + '' ('' +  VENTIP.TipoVenta + '')'' as DescripcionAgrupa, VENCTE.Fecha, VENCTE.IdCliente, CTE.RazonSocial,                       
					VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, 
					SUM(VENCTE.Cantidad) AS Cantidad, SUM(VENCTE.Conversion * VENCTE.Cantidad) AS CantidadKlts, 
					SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.Serie, VENCTE.Folio,  VENCTE.Fecha, VENCTE.IdCliente, CTE.RazonSocial,                       
					VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, VENCTE.Fecha, IdAgrupa, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 31
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdTipoVenta, VENCTE.IdFamilia, FAM.OrdenImpresion, VENCTE.Conversion, CED.Cedis, 
			                      VENCTE.IdCliente AS [Número de Cliente], CTE.RazonSocial AS [Razón Social], VENTIP.TipoVenta AS [Tipo de Venta], VENCTE.Serie, VENCTE.Folio, 
			                      VENCTE.Fecha, FAM.Familia, VENCTE.IdProducto AS [Clave de Producto], VENCTE.Producto, SUM(VENCTE.Cantidad) AS [Cantidad (Pzas)], 
			                      SUM(VENCTE.Conversion * VENCTE.Cantidad) AS [Cantidad (Klts)], SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Total) 
			                      AS Total
			FROM         FN_VentasPorClientePorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      Cedis CED ON VENCTE.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.Serie, VENCTE.Folio, VENCTE.Fecha, VENCTE.IdCliente, CTE.RazonSocial, 
			                      VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, CED.Cedis
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, VENCTE.IdTipoVenta, VENCTE.Fecha, VENCTE.Serie, VENCTE.Folio, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

end

if @ReporteOrigen = 17 			-- Ventas por Sucursal de Cliente
begin
	If @Tipo = 1 or @Tipo = 2 or @Tipo = 3		-- a Nivel de Totales por cliente, Por Tipo de Venta y por Factura
	begin
		SELECT DISTINCT VENCTE.IdCliente as [Número], CTE.RazonSocial as [Razón Social]
		FROM         FN_VentasPorSucursalPorFactura(@IdCedi, @FechaInicial, @FechaFinal) VENCTE INNER JOIN
		                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente
		ORDER BY CTE.RazonSocial
	end

	If @Tipo = 10
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdSucursal, CTESUC.TDA_GLN, CTESUC.NombreSucursal, VENCTE.IdProducto, 
			                      VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, SUM(VENCTE.Cantidad) AS Cantidad, 
			                      SUM(VENCTE.Conversion * VENCTE.Cantidad) AS CantidadKlts, SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) 
			                      AS Total, 0 AS IdAgrupa, ''Total de la Venta (crédito + contado)'' AS DescripcionAgrupa
			FROM         FN_VentasPorSucursalPorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      ClienteSucursal CTESUC ON VENCTE.IdCedis = CTESUC.IdCedis AND VENCTE.IdCliente = CTESUC.IdCliente AND 
			                      VENCTE.IdSucursal = CTESUC.IdSucursal
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, 
			                      VENCTE.Conversion, VENCTE.IdSucursal, CTESUC.TDA_GLN, CTESUC.NombreSucursal
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, CTESUC.NombreSucursal, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 11			--XLS
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdSucursal, VENCTE.IdFamilia, FAM.OrdenImpresion, VENCTE.Conversion, CED.Cedis, 
					VENCTE.IdCliente AS [Número de Cliente], CTE.RazonSocial AS [Razón Social], CTESUC.TDA_GLN as [TDA/GLN], 
					CTESUC.NombreSucursal as [Sucursal], FAM.Familia, VENCTE.IdProducto AS [Clave de Producto], 
					VENCTE.Producto, SUM(VENCTE.Cantidad) AS [Cantidad (Pzas)], SUM(VENCTE.Conversion * VENCTE.Cantidad) AS [Cantidad (Klts)], 
					SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorSucursalPorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      ClienteSucursal CTESUC ON VENCTE.IdCedis = CTESUC.IdCedis AND VENCTE.IdCliente = CTESUC.IdCliente AND 
			                      VENCTE.IdSucursal = CTESUC.IdSucursal INNER JOIN
			                      Cedis CED ON VENCTE.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, 
			                      VENCTE.Conversion, VENCTE.IdSucursal, CTESUC.TDA_GLN, CTESUC.NombreSucursal, CED.Cedis
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, CTESUC.NombreSucursal, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 20
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdTipoVenta AS IdAgrupa, VENTIP.TipoVenta AS DescripcionAgrupa, VENCTE.IdCliente, VENCTE.IdSucursal, 
			                      CTESUC.TDA_GLN, CTESUC.NombreSucursal, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, VENCTE.IdFamilia, FAM.Familia, 
			                      FAM.OrdenImpresion, VENCTE.Conversion, SUM(VENCTE.Cantidad) AS Cantidad, SUM(VENCTE.Conversion * VENCTE.Cantidad) AS CantidadKlts, 
			                      SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorSucursalPorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      ClienteSucursal CTESUC ON VENCTE.IdCedis = CTESUC.IdCedis AND VENCTE.IdCliente = CTESUC.IdCliente AND 
			                      VENCTE.IdSucursal = CTESUC.IdSucursal
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, 
			                      VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, VENCTE.IdSucursal, CTESUC.TDA_GLN, CTESUC.NombreSucursal
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, CTESUC.NombreSucursal, VENCTE.IdTipoVenta, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

	If @Tipo = 21			--XLS
	begin
		exec('
			SELECT     VENCTE.IdCedis, VENCTE.IdSucursal, VENCTE.IdFamilia, FAM.OrdenImpresion, VENCTE.Conversion, VENCTE.IdTipoVenta, CED.Cedis, 
			                      VENTIP.TipoVenta AS [Tipo de Venta], VENCTE.IdCliente AS [Número de Cliente], CTE.RazonSocial AS [Razón Social], CTESUC.TDA_GLN AS [TDA/GLN], 
			                      CTESUC.NombreSucursal AS Sucursal, FAM.Familia, VENCTE.IdProducto AS [Clave de Producto], VENCTE.Producto, SUM(VENCTE.Cantidad) 
			                      AS [Cantidad (Pzas)], SUM(VENCTE.Conversion * VENCTE.Cantidad) AS [Cantidad (Klts)], SUM(VENCTE.IVA) AS IVA, SUM(VENCTE.Subtotal) AS SubTotal, 
			                      SUM(VENCTE.Total) AS Total
			FROM         FN_VentasPorSucursalPorFactura(' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaFinal +''') VENCTE INNER JOIN
			                      Familias FAM ON VENCTE.IdFamilia = FAM.IdFamilia INNER JOIN
			                      VentasTipo VENTIP ON VENCTE.IdTipoVenta = VENTIP.IdTipoVenta INNER JOIN
			                      Clientes CTE ON VENCTE.IdCedis = CTE.IdCedis AND VENCTE.IdCliente = CTE.IdCliente INNER JOIN
			                      ClienteSucursal CTESUC ON VENCTE.IdCedis = CTESUC.IdCedis AND VENCTE.IdCliente = CTESUC.IdCliente AND 
			                      VENCTE.IdSucursal = CTESUC.IdSucursal INNER JOIN
			                      Cedis CED ON VENCTE.IdCedis = CED.IdCedis
			WHERE     (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY VENCTE.IdCedis, VENCTE.IdTipoVenta, VENTIP.TipoVenta, VENCTE.IdCliente, CTE.RazonSocial, VENCTE.IdProducto, VENCTE.Producto, 
			                      VENCTE.IdFamilia, FAM.Familia, FAM.OrdenImpresion, VENCTE.Conversion, VENCTE.IdSucursal, CTESUC.TDA_GLN, CTESUC.NombreSucursal, 
			                      CED.Cedis
			ORDER BY VENCTE.IdCedis, CTE.RazonSocial, CTESUC.NombreSucursal, VENCTE.IdTipoVenta, FAM.OrdenImpresion, VENCTE.IdProducto')
	end

end

if @ReporteOrigen = 18 			-- Reporte de Inventarios Fisicos
begin

	If @Tipo = 1 		-- a nivel de Marca
	begin
		SELECT DISTINCT MAR.IdMarca as Número, MAR.Marca
		FROM         Marcas MAR INNER JOIN
		                      Productos PROD ON MAR.IdMarca = PROD.IdMarca INNER JOIN
		                      InventarioFisico INVFIS ON PROD.IdProducto = INVFIS.IdProducto
		WHERE     (MAR.MostrarImpresion = 'S') AND (INVFIS.IdCedis = @IdCedi) AND (INVFIS.Fecha = @FechaFinal)
		ORDER BY MAR.Marca
	end

	If @Tipo = 2  		-- a nivel de Grupo
	begin
		SELECT DISTINCT GPO.IdGrupo as Número, GPO.Grupo AS Grupo, GPO.OrdenImpresion
		FROM         InventarioFisico INVFIS INNER JOIN
		                      Productos PRO ON INVFIS.IdProducto = PRO.IdProducto INNER JOIN
		                      Grupos GPO ON PRO.IdGrupo = GPO.IdGrupo
		WHERE     (INVFIS.IdCedis = @IdCedi) AND (INVFIS.Fecha = @FechaFinal) AND (GPO.MostrarImpresion = 'S')
		ORDER BY GPO.OrdenImpresion
	end		

	if @Tipo = 10		--Reporte a nivel marca en piezas
	begin
		exec('
			SELECT     INVFIS.IdCedis, PROD.IdMarca as IdAgrupa, PROD.IdFamilia, CED.Cedis, INVFIS.Fecha, MAR.Marca as DescripcionAgrupa, FAM.Familia, INVFIS.IdProducto, PROD.Producto, 
			                      PROD.Conversion, SUM(INVFIS.Cantidad) AS Cantidad, SUM(PROD.Conversion * INVFIS.Cantidad) AS CantidadKlts, 
			                      MAR.OrdenImpresion AS MarOrdenImpresion, FAM.OrdenImpresion AS FamOrdenImpresion
			FROM         InventarioFisico INVFIS INNER JOIN
			                      Productos PROD ON PROD.IdProducto = INVFIS.IdProducto INNER JOIN
			                      Cedis CED ON CED.IdCedis = INVFIS.IdCedis INNER JOIN
			                      Familias FAM ON PROD.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Marcas MAR ON PROD.IdMarca = MAR.IdMarca
			WHERE     (INVFIS.Fecha = ''' + @FechaFinal + ''') AND (INVFIS.IdCedis = ' + @IdCedi + ') AND (MAR.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVFIS.IdCedis, PROD.IdMarca, PROD.IdFamilia, CED.Cedis, INVFIS.Fecha, MAR.Marca, FAM.Familia, INVFIS.IdProducto, PROD.Producto, 
			                      PROD.Conversion, MAR.OrdenImpresion, FAM.OrdenImpresion
			ORDER BY INVFIS.IdCedis, INVFIS.Fecha, MAR.OrdenImpresion, FAM.OrdenImpresion, INVFIS.IdProducto')
	end

	if @Tipo = 20		--Reporte a nivel grupo en piezas
	begin
		exec('
			SELECT     INVFIS.IdCedis, PROD.IdGrupo as IdAgrupa, PROD.IdFamilia, CED.Cedis, INVFIS.Fecha, GPO.Grupo as DescripcionAgrupa, FAM.Familia, INVFIS.IdProducto, PROD.Producto, 
			                      PROD.Conversion, SUM(INVFIS.Cantidad) AS Cantidad, SUM(PROD.Conversion * INVFIS.Cantidad) AS CantidadKlts, 
			                      GPO.OrdenImpresion AS GpoOrdenImpresion, FAM.OrdenImpresion AS FamOrdenImpresion
			FROM         InventarioFisico INVFIS INNER JOIN
			                      Productos PROD ON PROD.IdProducto = INVFIS.IdProducto INNER JOIN
			                      Cedis CED ON CED.IdCedis = INVFIS.IdCedis INNER JOIN
			                      Familias FAM ON PROD.IdFamilia = FAM.IdFamilia INNER JOIN
			                      Grupos GPO ON PROD.IdGrupo = GPO.IdGrupo
			WHERE     (INVFIS.Fecha = ''' + @FechaFinal + ''') AND (INVFIS.IdCedis = ' + @IdCedi + ') AND (GPO.MostrarImpresion = ''S'') AND (FAM.MostrarImpresion = ''S'') ' + @Filtro + '
			GROUP BY INVFIS.IdCedis, PROD.IdGrupo, PROD.IdFamilia, CED.Cedis, INVFIS.Fecha, GPO.Grupo, FAM.Familia, INVFIS.IdProducto, PROD.Producto, 
			                      PROD.Conversion, GPO.OrdenImpresion, FAM.OrdenImpresion
			ORDER BY INVFIS.IdCedis, INVFIS.Fecha, GPO.OrdenImpresion, FAM.OrdenImpresion, INVFIS.IdProducto')
	end

end

if @ReporteOrigen = 19 			-- Reporte de Mermas por Ruta y por Tipo
begin

	If @Tipo = 1 		-- por Ruta
	begin
		select Surtidos.IdRuta, Ruta
		from Surtidos
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta
		where Surtidos.IdCedis = @IdCedi and Fecha between @FechaInicial and @FechaFinal
		group by Surtidos.IdCedis, Surtidos.IdRuta, Ruta
		order by Surtidos.IdCedis, Surtidos.IdRuta
	end


	if @Tipo = 10		--Reporte a nivel ruta
	begin

		exec( 'select Surtidos.IdCedis, Surtidos.IdRuta, Ruta, SurtidosMerma.IdTipoMerma, isnull( TipoMerma, ''No Definido'') as TipoMerma, 
		SurtidosMerma.IdProducto, Producto, sum(Cantidad) as Piezas, sum(Cantidad * Conversion) as KiloLitros
		from Surtidos
		inner join SurtidosMerma on Surtidos.IdCedis = SurtidosMerma.IdCedis and Surtidos.IdSurtido = SurtidosMerma.IdSurtido 
		left outer join TipoMerma on TipoMerma.IdTipoMerma = SurtidosMerma.IdTipoMerma
		inner join Productos on Productos.IdProducto = SurtidosMerma.IdProducto
		inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Surtidos.IdRuta = Rutas.IdRuta
		where Surtidos.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''   ' + @Filtro + '
		group by Surtidos.IdCedis, Surtidos.IdRuta, Ruta, SurtidosMerma.IdTipoMerma, TipoMerma, SurtidosMerma.IdProducto, Producto, IdFamilia
		order by Surtidos.IdRuta, SurtidosMerma.IdTipoMerma, IdFamilia, SurtidosMerma.IdProducto' )

	end

end

if @ReporteOrigen = 20			-- Cambios Físicos
begin

	If @Tipo = 1 		-- Grupo
	begin
		select Productos.IdGrupo, Grupo
		from Surtidos
		inner join SurtidosCambios on Surtidos.IdCedis = SurtidosCambios.IdCedis and Surtidos.IdSurtido = SurtidosCambios.IdSurtido 
		inner join Productos on Productos.IdProducto = SurtidosCambios.IdProducto 
		inner join Grupos on Grupos.IdGrupo = Productos.IdGrupo
		inner join Familias on Familias.IdFamilia = Productos.IdFamilia
		where Surtidos.IdCedis = @IdCedi and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by Productos.IdGrupo, Grupo
		order by Productos.IdGrupo, Grupo
	end

	If @Tipo = 2 		-- Ruta
	begin
		select distinct Surtidos.IdRuta as 'Número', 'Ruta ' + cast(Surtidos.IdRuta as varchar(4)) as Ruta
		from Surtidos
		inner join SurtidosCambios on Surtidos.IdCedis = SurtidosCambios.IdCedis and Surtidos.IdSurtido = SurtidosCambios.IdSurtido 
		where Surtidos.IdCedis = @IdCedi and Surtidos.Fecha between @FechaInicial and @FechaFinal
		group by Surtidos.IdRuta
		order by Surtidos.IdRuta
	end

	if @Tipo = 10 or @Tipo = 11 		--Reporte a nivel grupo
	begin

		exec( 'select Surtidos.IdCedis, Productos.IdGrupo, Grupo, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto, isnull(sum(Entrada),0) as Entrada, isnull(sum(Salida),0) as Salida
			from Surtidos
			inner join SurtidosCambios on Surtidos.IdCedis = SurtidosCambios.IdCedis and Surtidos.IdSurtido = SurtidosCambios.IdSurtido 
			inner join Productos on Productos.IdProducto = SurtidosCambios.IdProducto 
			inner join Grupos on Grupos.IdGrupo = Productos.IdGrupo
			inner join Familias on Familias.IdFamilia = Productos.IdFamilia
			where Surtidos.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''   ' + @Filtro + '
			group by Surtidos.IdCedis, Productos.IdGrupo, Grupo, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto
			order by Surtidos.IdCedis, Productos.IdGrupo, Grupo, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto')
	end

	if @Tipo = 20 or @Tipo = 21	--Reporte a nivel ruta
	begin

		exec( 'select Surtidos.IdCedis, Surtidos.IdRuta as IdGrupo, ''Ruta '' + cast(Surtidos.IdRuta as varchar(4)) as Grupo, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto, isnull(sum(Entrada),0) as Entrada, isnull(sum(Salida),0) as Salida
			from Surtidos
			inner join SurtidosCambios on Surtidos.IdCedis = SurtidosCambios.IdCedis and Surtidos.IdSurtido = SurtidosCambios.IdSurtido 
			inner join Productos on Productos.IdProducto = SurtidosCambios.IdProducto 
			inner join Grupos on Grupos.IdGrupo = Productos.IdGrupo
			inner join Familias on Familias.IdFamilia = Productos.IdFamilia
			where Surtidos.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''   ' + @Filtro + '
			group by Surtidos.IdCedis, Surtidos.IdRuta, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto
			order by Surtidos.IdCedis, Surtidos.IdRuta, Productos.IdFamilia, Familia, SurtidosCambios.IdProducto, Producto')
	end
end

if @ReporteOrigen = 21			-- Libros de Ruta
begin

	If @Tipo = 1 		-- Ruta
	begin

		select distinct Rutas.IdRuta, Rutas.Ruta
		from Rutas
		inner join Cedis on Cedis.IdCedis = Rutas.IdCedis
		inner join Route.dbo.Secuencia as Secuencia on Secuencia.RutClave = cast( Rutas.IdCedis as varchar(10) ) + replicate('0', 4 - len( Rutas.IdRuta ) ) + cast( Rutas.IdRuta as varchar(10) )
		where Rutas.IdCedis = cast( @IdCedi as bigint)
		order by Rutas.IdRuta	
	end

	if @Tipo = 10 or @Tipo = 11 		--Reporte a nivel Ruta
	begin
		exec( 'select Rutas.IdCedis, Cedis, Rutas.IdRuta, Rutas.Ruta,
		Secuencia.FrecuenciaClave, Descripcion, Secuencia.Orden, Secuencia.ClienteClave,
		NombreSucursal, Calle + '' '' + NumExterior + '' '' + NumInterior + '' '' + Colonia + '' '' + Localidad + '' '' + Poblacion + '' '' + Entidad as Domicilio
		from Rutas
		inner join Cedis on Cedis.IdCedis = Rutas.IdCedis
		inner join Route.dbo.Secuencia as Secuencia on Secuencia.RutClave = cast( Rutas.IdCedis as varchar(10) ) + replicate(''0'', 4 - len( Rutas.IdRuta ) ) + cast( Rutas.IdRuta as varchar(10) )
		inner join Route.dbo.Frecuencia as Frecuencia on Frecuencia.FrecuenciaClave = Secuencia.FrecuenciaClave
		inner join ClienteSucursal on ClienteSucursal.IdCedis = Rutas.IdCedis and ClienteSucursal.IdSucursal = Secuencia.ClienteClave
		where Rutas.IdCedis = ' + @IdCedi + '  ' + @Filtro + ' 
		order by Rutas.IdRuta, Secuencia.FrecuenciaClave, Secuencia.Orden')
	end

end

if @ReporteOrigen = 22			-- Saldos de Vendedores
begin

	If @Tipo = 1 		-- Vendedor
	begin
		select VS.IdVendedor, V.ApPaterno + ' ' + V.ApMaterno + ' ' + V.Nombre as Nombre
		from VendedoresSaldos as VS
		--left outer join Surtidos as S on S.IdCedis = VS.IdCedis and S.IdSurtido = VS.IdSurtido
		left outer join Vendedores V on V.IdCedis = VS.IdCedis and V.IdVendedor = VS.IdVendedor
		where VS.IdCedis = @IdCedi and VS.Fecha between @FechaInicial and @FechaFinal 
		group by VS.IdVendedor, V.ApPaterno, V.ApMaterno, V.Nombre
		order by V.ApPaterno, V.ApMaterno, V.Nombre
	end

	if @Tipo = 10 or @Tipo = 11 		--Reporte a nivel Vendedor
	begin
		exec( 'select VS.IdCedis, VS.IdSurtido, VS.Fecha, case VS.IdTipoSaldo 
					when ''EF'' then ''Efectivo''
					when ''EN'' then ''Envase''
					when ''CL'' then ''Clientes''
				end as TipoSaldo, 
				VS.IdVendedor, 
				S.IdRuta, V.ApPaterno + '' '' + V.ApMaterno + '' '' + V.Nombre as Nombre,
				SaldoAnterior, Saldo as SaldoActual, Otros, SaldoActual as SaldoTotal, 
				isnull(VSF.MontoFinanciar,0) as Financiado, isnull(VSF.Frecuencia, 0) as Frecuencia, 
				isnull(VSF.Pagos,0) as Monto, 
				isnull((select SUM(VSFD.Monto) 
						from VendedoresSaldosFinanciaD VSFD 
						inner join VendedoresSaldosFinancia VSF1 on VSF1.IdCedis = VSFD.IdCedis and VSF1.IdCorto = VSFD.IdCorto 
							and VSF1.FechaInicio <= VS.Fecha 
						where VSF.IdCedis = VSFD.IdCedis and VSF.IdVendedor = VSFD.IdVendedor and VSFD.Fecha > VS.Fecha ),0) as NoVencido
				from VendedoresSaldos as VS
				left outer join Surtidos as S on S.IdCedis = VS.IdCedis and S.IdSurtido = VS.IdSurtido
				left outer join Vendedores V on V.IdCedis = VS.IdCedis and V.IdVendedor = VS.IdVendedor
				left outer join VendedoresSaldosFinancia VSF on VS.IdCedis = VSF.IdCedis 
					and VS.IdVendedor = VSF.IdVendedor and VSF.FechaInicio = VS.Fecha 
				where VS.IdCedis = ' + @IdCedi + ' and VS.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + '''   ' + @Filtro + '  
				order by V.ApPaterno, V.ApMaterno, V.Nombre, VS.Fecha ')
	end

end

if @ReporteOrigen = 23			-- Póliza Araceli
begin

	If @Tipo = 1 		-- Fecha
	begin
		select Ventas.IdCedis, Ventas.Fecha
		from Ventas 
		where Ventas.IdCedis = @IdCedi and Ventas.Fecha between @FechaInicial and @FechaInicial
		group by Ventas.IdCedis, Ventas.Fecha
	end


	if @Tipo = 10 or @Tipo = 11 		--Reporte por Fecha
	begin
		exec( 'select Ventas.IdCedis, Ventas.Fecha
		from Ventas 
		where Ventas.IdCedis = ' + @IdCedi + ' and Ventas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaInicial + ''' ' + @Filtro + ' 
		group by Ventas.IdCedis, Ventas.Fecha')
	end
end

if @ReporteOrigen = 24			-- Póliza Modelo de Oriente
begin

	If @Tipo = 1 		-- Fecha
	begin
		select Ventas.IdCedis, Ventas.Fecha
		from Ventas 
		where Ventas.IdCedis = @IdCedi and Ventas.Fecha between @FechaInicial and @FechaInicial
		group by Ventas.IdCedis, Ventas.Fecha
	end


	if @Tipo = 10 or @Tipo = 11 		--Reporte por Fecha
	begin
		exec( 'exec sel_PolizaModeloOriente ' + @IdCedi + ', ''' + @FechaInicial + ''', ''' + @FechaInicial + ''', 1')
	end
end

if @ReporteOrigen = 25			-- Reporte de Entradas y Salidas Modelo de Oriente
begin

	If @Tipo = 1 		-- Fecha
	begin
		select Ventas.IdCedis, Ventas.Fecha
		from Ventas 
		where Ventas.IdCedis = @IdCedi and Ventas.Fecha between @FechaInicial and @FechaInicial
		group by Ventas.IdCedis, Ventas.Fecha
	end


	if @Tipo = 10 or @Tipo = 11 		--Reporte por Fecha
	begin
		exec( 'exec sel_ModeloOrienteES ' + @IdCedi + ', ''' + @FechaInicial + ''' ')
	end
end

if @ReporteOrigen = 26			-- Reporte de Envase Modelo de Oriente
begin

	If @Tipo = 1 		-- Fecha
	begin
		exec ( 'select Ventas.Fecha
		from Ventas 
		inner join Cedis on Cedis.IdCedis = Ventas.IdCedis 
		where Ventas.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaInicial + ''' 
		group by Ventas.Fecha')
	end


	if @Tipo = 10 or @Tipo = 11 		--Reporte por Fecha
	begin
		exec( 'exec sel_ModeloOrienteEnvase ' + @IdCedi + ', ''' + @FechaInicial + ''', '''' ')
	end
end

if @ReporteOrigen = 27 			-- Efectivo y Documentos
begin
	If @Tipo = 1 or @Tipo = 2 
	begin
		select 'Efectivo y Documentos del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 11			-- acumulado
	begin
		exec(  'select SurtidosDenominacion.IdCedis, Surtidos.Fecha, 0 + TipoDenominacion.IdTipoDenominacion as Orden, ''Efectivo '' + TipoDenominacion.TipoDenominacion as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
			sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) * ISNULL(TipoCambio,1) as Importe
			from SurtidosDenominacion
			inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
			inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
			inner join TipoDenominacion on TipoDenominacion.IdTipoDenominacion = SurtidosDenominacion.TipoDenominacion 
			inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
			left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
			where SurtidosDenominacion.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 
			group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda, 
				TipoDenominacion.IdTipoDenominacion, TipoDenominacion.TipoDenominacion, TipoCambio
				
			union

			select SurtidosCheque.IdCedis, Surtidos.Fecha, 100 as Orden, ''Documentos'' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
			SurtidosCheque.IdCheque as Cantidad, Nombre + '' - '' + Referencia as Descripcion, SurtidosCheque.Importe * ISNULL(TipoCambio,1) as Importe
			from SurtidosCheque
			inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
			inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
			inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
			left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
			where SurtidosCheque.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 

			order by Surtidos.Fecha, Monedas.Moneda, Orden, Descripcion ')
			
/*		
		exec( '
			select SurtidosDenominacion.IdCedis, Surtidos.Fecha, 0 as Orden, ''Efectivo'' as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
			sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) as Importe
			from SurtidosDenominacion
			inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
			inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
			inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
			where SurtidosDenominacion.IdCedis = 1 and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 
			group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda
				
			union

			select SurtidosCheque.IdCedis, Surtidos.Fecha, 1 as Orden, ''Documentos'' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
			SurtidosCheque.IdCheque as Cantidad, Nombre + '' - '' + Referencia as Descripcion, SurtidosCheque.Importe as Importe
			from SurtidosCheque
			inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
			inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
			inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
			where SurtidosCheque.IdCedis = 1 and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 

			order by Surtidos.Fecha, Monedas.Moneda, Orden, Descripcion ')*/
	end

	if @Tipo = 20 or @Tipo = 21
	begin
		exec(  'select SurtidosDenominacion.IdCedis, Surtidos.Fecha, SurtidosDenominacion.IdCajero, ApPaterno + '' '' + ApMaterno + '' '' + Usuarios.Nombre as Cajero,
			0 + TipoDenominacion.IdTipoDenominacion as Orden, ''Efectivo '' + TipoDenominacion.TipoDenominacion as Concepto, Monedas.IdMoneda, Monedas.Moneda, 
			sum(SurtidosDenominacion.Cantidad) as Cantidad, Denominacion as Descripcion, sum(SurtidosDenominacion.Cantidad * Denominaciones.IdDenominacion) * ISNULL(TipoCambio,1) as Importe
			from SurtidosDenominacion
			inner join Surtidos on Surtidos.IdCedis = SurtidosDenominacion.IdCedis and Surtidos.IdSurtido = SurtidosDenominacion.IdSurtido 
			inner join Denominaciones on SurtidosDenominacion.IdDenominacion = Denominaciones.IdDenominacion and SurtidosDenominacion.TipoDenominacion = Denominaciones.TipoDenominacion and SurtidosDenominacion.IdMoneda = Denominaciones.IdMoneda 
			inner join TipoDenominacion on TipoDenominacion.IdTipoDenominacion = SurtidosDenominacion.TipoDenominacion 
			inner join Monedas on Monedas.IdMoneda = Denominaciones.IdMoneda 
			left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
			left outer join Usuarios on Usuarios.Login = SurtidosDenominacion.IdCajero
			where SurtidosDenominacion.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 
			group by SurtidosDenominacion.IdCedis, Surtidos.Fecha, SurtidosDenominacion.IdCajero, ApPaterno, ApMaterno, Usuarios.Nombre, 
				Denominaciones.Denominacion, Monedas.IdMoneda, Monedas.Moneda, 
				TipoDenominacion.IdTipoDenominacion, TipoDenominacion.TipoDenominacion, TipoCambio
				
			union

			select SurtidosCheque.IdCedis, Surtidos.Fecha, SurtidosCheque.IdCajero, ApPaterno + '' '' + ApMaterno + '' '' + Usuarios.Nombre as Cajero, 
			100 as Orden, ''Documentos'' as Concepto,  Monedas.IdMoneda, Monedas.Moneda, 
			SurtidosCheque.IdCheque as Cantidad, Bancos.Nombre + '' - '' + Referencia as Descripcion, SurtidosCheque.Importe * ISNULL(TipoCambio,1) as Importe
			from SurtidosCheque
			inner join Surtidos on Surtidos.IdCedis = SurtidosCheque.IdCedis and Surtidos.IdSurtido = SurtidosCheque.IdSurtido 
			inner join Bancos on SurtidosCheque.IdBanco = Bancos.IdBanco 
			inner join Monedas on Monedas.IdMoneda = SurtidosCheque.IdMoneda 
			left outer join TipoDeCambio on TipoDeCambio.IdMoneda = Monedas.IdMoneda and TipoDeCambio.Fecha = Surtidos.Fecha 
			left outer join Usuarios on Usuarios.Login = SurtidosCheque.IdCajero
			where SurtidosCheque.IdCedis = ' + @IdCedi + ' and Surtidos.Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' 

			order by Surtidos.Fecha, IdCajero, Monedas.Moneda, Orden, Descripcion ')
	end
end


if @ReporteOrigen = 28 			-- VENTAS CONTADO Y CRÉDITO POR MARCA
begin
	If @Tipo = 1 or @Tipo = 2			-- por fecha
	begin
		select 1, 'Ventas de Contado del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
		union
		select 2, 'Ventas de Crédito del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 11	or @Tipo = 20 or @Tipo = 21		-- acumulado
	begin
		exec( 'SELECT  distinct   CED.IdCedis, CED.Cedis, VEN.Fecha, Marcas.IdMarca, Marcas.Marca, VEN.IdTipoVenta, case VEN.IdTipoVenta when ''1'' then ''Contado'' else ''Crédito'' end as TipoVenta, VEN.IdCliente AS [Número de Cliente], CTE.RazonSocial AS Nombre, SUR.IdRuta AS Ruta, VEN.Serie, VEN.Folio, 
								  VEN.Subtotal, VEN.Iva, VEN.Total, CS.IdSucursal, CS.NombreSucursal as Sucursal,
								 VENDET.IdProducto, PROD.Producto, SUM(VENDET.Cantidad) as Cantidad, 
								 SUM(VENDET.Subtotal) as SubTotalD, SUM(VENDET.Iva) as IvaD, SUM(VENDET.Total) as TotalD
			FROM         Ventas VEN INNER JOIN
								  Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido INNER JOIN
								  Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente and CTE.IdCliente <> 9 INNER JOIN
								  Cedis CED ON VEN.IdCedis = CED.IdCedis INNER JOIN
								  VentasDetalle VENDET ON VENDET.IdCedis = VEN.IdCedis and VENDET.IdSurtido = VEN.IdSurtido and VENDET.IdTipoVenta = VEN.IdTipoVenta and VENDET.Folio = VEN.Folio INNER JOIN
								ClienteSucursal CS on CS.IdCedis = VEN.IdCedis and CS.IdSucursal = VEN.IdSucursal INNER JOIN 
								Productos PROD on PROD.IdProducto = VENDET.IdProducto INNER JOIN
								Marcas ON Marcas.IdMarca = PROD.IdMarca                     
			WHERE     (VEN.IdCedis = ' + @IdCedi + ') AND VEN.Fecha BETWEEN ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Filtro + ' 
			GROUP BY CED.IdCedis, CED.Cedis, VEN.Fecha, Marcas.IdMarca, Marcas.Marca, VEN.IdTipoVenta, VENDET.IdProducto, PROD.Producto, VEN.IdCliente, CTE.RazonSocial, SUR.IdRuta, VEN.Serie, VEN.Folio, 
								  VEN.Subtotal, VEN.Iva, VEN.Total, CS.IdSucursal, CS.NombreSucursal 
			ORDER BY CED.IdCedis, VEN.Fecha, Marcas.IdMarca, VEN.IdTipoVenta, VEN.IdCliente, VEN.Serie, VEN.Folio, VENDET.IdProducto, PROD.Producto')
	
	end
end

if @ReporteOrigen = 29 			-- VENTAS POR PRODUCTO A PRECIO BASE
begin
	If @Tipo = 1	-- por fecha
	begin
		select 1, 'Ventas de Contado del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
		union
		select 2, 'Ventas de Crédito del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 11	-- acumulado
	begin
		exec (' select VEN.IdCedis, Cedis.Cedis, VEN.Fecha, Productos.IdMarca, Marca, VEN.IdTipoVenta, case VEN.IdTipoVenta when ''1'' then ''Contado'' else ''Crédito'' end as TipoVenta, 
				Productos.IdFamilia, Familia, VEND.IdProducto, Producto, SUM(Cantidad) as Cantidad, PreciosDetalle.Precio as Precio, SUM(VEND.Cantidad * PreciosDetalle.Precio * (1+(Productos.Iva))) as TotalD
				from Ventas VEN
				inner join VentasDetalle VEND on VEN.IdCedis = VEND.IdCedis and VEN.IdTipoVenta = VEND.IdTipoVenta 
					and VEN.IdSurtido = VEND.IdSurtido and VEN.Folio = VEND.Folio 
				inner join Productos on Productos.IdProducto = VEND.IdProducto 
				inner join Marcas on Marcas.IdMarca = Productos.IdMarca 
				inner join Familias on Familias.IdFamilia = Productos.IdFamilia 
				inner join PreciosDetalle on PreciosDetalle.IdProducto = VEND.IdProducto and IdLista in ( select IdLista 
					from PreciosLista where TipoLista = ''BA'')
				inner join Cedis on Cedis.IdCedis = VEN.IdCedis
				where VEN.IdCedis = ' + @IdCedi + ' and Fecha between ''' + @FechaInicial + ''' and ''' + @FechaFinal + ''' ' + @Filtro + ' 
				group by VEN.IdCedis, Cedis.Cedis, VEN.Fecha, Productos.IdMarca, Marca, VEN.IdTipoVenta, Productos.IdFamilia, Familia, VEND.IdProducto, Producto, PreciosDetalle.Precio
				order by VEN.IdCedis, Cedis.Cedis, VEN.Fecha, Productos.IdMarca, Marca, VEN.IdTipoVenta, Productos.IdFamilia, Familia, VEND.IdProducto, Producto, PreciosDetalle.Precio')
	end

end

if @ReporteOrigen = 30 			-- VENTAS ACREDITADAS
begin
	If @Tipo = 1 or @Tipo = 2			-- por fecha
	begin
		select 'Ventas de Crédito del ' + cast( convert( datetime, @FechaInicial, 103)  as varchar (11)) + ' al ' + cast( convert( datetime, @FechaFinal, 103) as varchar (11))		
	end

	If @Tipo = 10 or @Tipo = 11 -- POR FECHA
	begin
		SELECT     CED.IdCedis, CED.Cedis, VEN.Fecha, VEN.IdCliente, CTE.RazonSocial AS Cliente, SUR.IdRuta, VEN.Serie, VEN.Folio, VEN.Serie + ' ' + cast(VEN.Folio as varchar(15)) as SerieFolio,
			VEN.IdSucursal, NombreSucursal, VEN.Subtotal AS [SubtotalF], VEN.Iva AS [IVAF], VEN.Total AS [TotalF],
			VACR.FechaAcredita, VACR.FechaEntrega, isnull(VACR.FolioEntrega, '-Sin Acreditar-') as FolioEntrega, 
			VACR.FolioCliente, VACR.Remision, VACR.Factura, VACR.Status, VACR.Observaciones 
		FROM Ventas VEN 
		left outer join VentasAcredita VACR on VACR.IdCedis = VEN.IdCedis and VACR.IdSurtido = VEN.IdSurtido 
			and VEN.Serie = VACR.Serie and VEN.Folio = VACR.Folio  
		INNER JOIN Surtidos SUR ON SUR.IdCedis = VEN.IdCedis AND SUR.IdSurtido = VEN.IdSurtido 
		INNER JOIN Clientes CTE ON CTE.IdCedis = VEN.IdCedis AND VEN.IdCliente = CTE.IdCliente 
		inner join ClienteSucursal on ClienteSucursal.IdCedis = VEN.IdCedis and ClienteSucursal.IdSucursal = VEN.IdSucursal
		INNER JOIN Cedis CED ON VEN.IdCedis = CED.IdCedis
		WHERE (VEN.IdCedis = @IdCedi) AND (VEN.Fecha BETWEEN @FechaInicial AND @FechaFinal) AND VEN.IdTipoVenta = 2
		ORDER BY CED.IdCedis, VEN.Fecha, VEN.IdCliente, ClienteSucursal.IdSucursal, VEN.Serie, VEN.Folio
	end

end



GO


