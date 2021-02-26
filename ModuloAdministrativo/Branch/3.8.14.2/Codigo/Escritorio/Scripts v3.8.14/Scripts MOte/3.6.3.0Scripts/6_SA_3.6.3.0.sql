 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_tg_exportCPCManagement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_tg_exportCPCManagement]
/*go*/go

SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go

CREATE PROCEDURE [dbo].[sp_tg_exportCPCManagement] 
	@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS
BEGIN
	SET DATEFORMAT DMY;
	SET XACT_ABORT OFF    
	SET NOCOUNT OFF  
	
	SET ROWCOUNT 0 
	
	
	
	
	declare @ClaveCEDI as varchar(20)
	declare @FechaCursor as datetime
	declare @RUTClave as varchar(20)

	Declare @FechaIniCompara datetime
		SET @FechaIniCompara = convert(datetime,'9999-12-31',102)

declare @maximo as int

	
		DECLARE @CursorVar1 CURSOR  
	SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR 
	SELECT right(A.Clave,2),CONVERT(datetime, AB.MFechaHora,103)
	FROM AbnTrp AB
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor v on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) 
	group by A.Clave,CONVERT(datetime, AB.MFechaHora,103)


	OPEN @CursorVar1

	FETCH NEXT FROM @CursorVar1 INTO @ClaveCEDI, @FechaCursor 

	WHILE @@FETCH_STATUS = 0      
	BEGIN 
	if not exists(select * from routecpc.dbo.movimientos M where M.IdCedis=@ClaveCEDI and M.Fecha=@FechaCursor )
	begin
	insert routecpc.dbo.movimientos
	SELECT right(A.Clave,2),(select isnull(MAX(idmovimiento),0)+1 from routecpc.dbo.movimientos where IdCedis=right(A.Clave,2))
	,CONVERT(datetime, AB.MFechaHora,103),'CT','A',0,'','A','MOVIL',GETDATE()
	FROM AbnTrp AB
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor v on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(datetime, AB.MFechaHora,103)=@FechaCursor
group by A.Clave,CONVERT(datetime, AB.MFechaHora,103)
	
	
	end 
	set @maximo = (select isnull(MAX(idmovimiento),0) from routecpc.dbo.movimientos where IdCedis=@ClaveCEDI and CONVERT(datetime,Fecha,103)=@FechaCursor )
	
	SELECT   Identity(int, 1, 1) AS fila,right(A.Clave,2) as idCedis,T.CFVTipo as IdTipoVenta,
	case when T.Tipo=1 then 'R'+ right(Vis.RUTClave,3) COLLATE DATABASE_DEFAULT when T.FacturaID IS null then  (select SerieFacturasContado from RouteADM.dbo.Configuracion) COLLATE DATABASE_DEFAULT else TDF.Serie COLLATE DATABASE_DEFAULT end as Serie
	,case when T.FacturaID  IS  not null then REPLACE(t.FOLIO,TDF.SERIE,'') ELSE substring(T.Folio,4,len(t.folio)) end as Folio,
	@maximo as IdMovimiento,
	AB.FechaHora as Fecha,
	(select isnull(MAX(IdMovimientoDetalle),0) from routecpc.dbo.MovimientosFacturas where IdCedis=right(A.Clave,2) and IdMovimiento=@maximo)as asumar
	,'CT' as IdDocumento,ABD.TipoPago as idTipoDocumento,ABD.Referencia ,ABD.Referencia as ReferenciaBancos,'A' as CargoAbono,
	ABD.Importe as Subtotal,0 as iva,ABD.Importe as total,'A'  as status,AB.MUsuarioID as login,AB.FechaHora as fechaedicion
	into #TablaTemp
	FROM AbnTrp AB
	inner join TransProd T on T.TransProdID= AB.TransProdID
	inner join Visita Vis on T.VisitaClave= Vis.VisitaClave 
	left join TRPDatoFiscal TDF on T.TransProdID=TDF.TransProdID
	inner join ABNDetalle ABD on AB.ABNId=ABD.ABNId
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor V on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(datetime, AB.MFechaHora,103)=@FechaCursor and T.Tipo in (1,8)
	and CONVERT(datetime, AB.MFechaHora,103)=@FechaCursor
	
	INSERT INTO [RouteCPC].[dbo].[MovimientosFacturas]
           ([IdCedis]
           ,[IdTipoVenta]
           ,[Serie]
           ,[Folio]
           ,[IdMovimiento]
           ,[Fecha]
           ,[IdMovimientoDetalle]
           ,[IdDocumento]
           ,[IdTipoDocumento]
           ,[CargoAbono]
           ,[Referencia]
           ,[ReferenciaBancos]
           ,[Subtotal]
           ,[Iva]
           ,[Status]
           ,[Login]
           ,[FechaEdicion])
	select idcedis,idtipoventa,serie,Folio,idmovimiento,fecha,asumar+fila as idmovimientodetalle,iddocumento,idtipodocumento,CargoAbono,referencia,referenciabancos,subtotal,IVA,status,login ,fechaedicion from #TablaTemp

	drop table #TablaTemp
	
	
	update AbnTrp set TipoFaseIntSal=1 where  AbnTrp.ABNId in (
	select ab.ABNId FROM AbnTrp AB
	inner join TransProd T on T.TransProdID= AB.TransProdID
	inner join Visita Vis on T.VisitaClave= Vis.VisitaClave 
	left join TRPDatoFiscal TDF on T.TransProdID=TDF.TransProdID
	inner join ABNDetalle ABD on AB.ABNId=ABD.ABNId
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor V on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(dateTime, AB.MFechaHora,103)=@FechaCursor and T.Tipo in (1,8)
	and CONVERT(datetime, AB.MFechaHora,103)=@FechaCursor
	)
	
		FETCH NEXT FROM @CursorVar1 INTO @ClaveCEDI, @FechaCursor 


end
end


/*
CREATE PROCEDURE [dbo].[sp_tg_exportCPCManagement] 
	@FechaIn as datetime, @FechaFin as datetime, @vende as varchar(20)
AS
BEGIN
	SET DATEFORMAT DMY;
	SET XACT_ABORT OFF    
	SET NOCOUNT OFF  
	
	SET ROWCOUNT 0 
	
	
	
	
	declare @ClaveCEDI as varchar(20)
	declare @FechaCursor as Date
	declare @RUTClave as varchar(20)

	Declare @FechaIniCompara datetime
		SET @FechaIniCompara = convert(datetime,'9999-12-31',102)

declare @maximo as int

	
		DECLARE @CursorVar1 CURSOR  
	SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR 
	SELECT right(A.Clave,2),CONVERT(date, AB.MFechaHora,103)
	FROM AbnTrp AB
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor v on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) 
	group by A.Clave,CONVERT(date, AB.MFechaHora,103)


	OPEN @CursorVar1

	FETCH NEXT FROM @CursorVar1 INTO @ClaveCEDI, @FechaCursor 

	WHILE @@FETCH_STATUS = 0      
	BEGIN 
	if not exists(select * from routecpc.dbo.movimientos M where M.IdCedis=@ClaveCEDI and M.Fecha=@FechaCursor )
	begin
	insert routecpc.dbo.movimientos
	SELECT right(A.Clave,2),(select isnull(MAX(idmovimiento),0)+1 from routecpc.dbo.movimientos where IdCedis=right(A.Clave,2))
	,CONVERT(date, AB.MFechaHora,103),'CT','A',0,'','A','MOVIL',GETDATE()
	FROM AbnTrp AB
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor v on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(date, AB.MFechaHora,103)=@FechaCursor
group by A.Clave,CONVERT(date, AB.MFechaHora,103)
	
	
	end 
	set @maximo = (select isnull(MAX(idmovimiento),0) from routecpc.dbo.movimientos where IdCedis=@ClaveCEDI and CONVERT(date,Fecha,103)=@FechaCursor )
	
	SELECT   Identity(int, 1, 1) AS fila,right(A.Clave,2) as idCedis,T.CFVTipo as IdTipoVenta,
	case when T.Tipo=1 then 'R'+ right(Vis.RUTClave,3) COLLATE DATABASE_DEFAULT when T.FacturaID IS null then  (select SerieFacturasContado from RouteADM.dbo.Configuracion) COLLATE DATABASE_DEFAULT else TDF.Serie COLLATE DATABASE_DEFAULT end as Serie
	,case when T.FacturaID  IS  not null then REPLACE(t.FOLIO,TDF.SERIE,'') ELSE substring(T.Folio,4,len(t.folio)) end as Folio,
	@maximo as IdMovimiento,
	AB.FechaHora as Fecha,
	(select isnull(MAX(IdMovimientoDetalle),0) from routecpc.dbo.MovimientosFacturas where IdCedis=right(A.Clave,2) and IdMovimiento=@maximo)as asumar
	,'CT' as IdDocumento,ABD.TipoPago as idTipoDocumento,ABD.Referencia ,ABD.Referencia as ReferenciaBancos,'A' as CargoAbono,
	ABD.Importe as Subtotal,0 as iva,ABD.Importe as total,'A'  as status,AB.MUsuarioID as login,AB.FechaHora as fechaedicion
	into #TablaTemp
	FROM AbnTrp AB
	inner join TransProd T on T.TransProdID= AB.TransProdID
	inner join Visita Vis on T.VisitaClave= Vis.VisitaClave 
	left join TRPDatoFiscal TDF on T.TransProdID=TDF.TransProdID
	inner join ABNDetalle ABD on AB.ABNId=ABD.ABNId
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor V on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(date, AB.MFechaHora,103)=@FechaCursor and T.Tipo in (1,8)
	and CONVERT(date, AB.MFechaHora,103)=@FechaCursor
	
	INSERT INTO [RouteCPC].[dbo].[MovimientosFacturas]
           ([IdCedis]
           ,[IdTipoVenta]
           ,[Serie]
           ,[Folio]
           ,[IdMovimiento]
           ,[Fecha]
           ,[IdMovimientoDetalle]
           ,[IdDocumento]
           ,[IdTipoDocumento]
           ,[CargoAbono]
           ,[Refrencia]
           ,[RefrenciaBancos]
           ,[Subtotal]
           ,[Iva]
           ,[Status]
           ,[Login]
           ,[FechaEdicion])
	select idcedis,idtipoventa,serie,Folio,idmovimiento,fecha,asumar+fila as idmovimientodetalle,iddocumento,idtipodocumento,CargoAbono,referencia,referenciabancos,subtotal,IVA,status,login ,fechaedicion from #TablaTemp

	drop table #TablaTemp
	
	
	update AbnTrp set TipoFaseIntSal=1 where  AbnTrp.ABNId in (
	select ab.ABNId FROM AbnTrp AB
	inner join TransProd T on T.TransProdID= AB.TransProdID
	inner join Visita Vis on T.VisitaClave= Vis.VisitaClave 
	left join TRPDatoFiscal TDF on T.TransProdID=TDF.TransProdID
	inner join ABNDetalle ABD on AB.ABNId=ABD.ABNId
	INNER JOIN USUARIO U ON U.USUId = AB.MUsuarioID
	inner join Vendedor V on v.USUId=U.USUId
	inner join VENCentroDistHist VCH on VCH.VendedorId =v.VendedorID and   GETDATE() between  VCH.VCHFechaInicial and  VCH.FechaFinal
	inner join Almacen A on A.AlmacenID =VCH.AlmacenId
	WHERE ((AB.MFechaHora between @FechaIn and @FechaFin) OR (@FechaIn = @FechaIniCompara AND AB.TipoFaseIntSal IN (0,2)))
	AND  (U.clave = @vende) and CONVERT(date, AB.MFechaHora,103)=@FechaCursor and T.Tipo in (1,8)
	and CONVERT(date, AB.MFechaHora,103)=@FechaCursor
	)
	
		FETCH NEXT FROM @CursorVar1 INTO @ClaveCEDI, @FechaCursor 


end
end
*/
