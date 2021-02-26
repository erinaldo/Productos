
declare @IdCedis as bigint, @Fecha as datetime, @IdRuta as bigint, @Actualiza as bit

set @IdCedis = 2
set @Fecha = '20101007'
set @IdRuta = 2
set @Actualiza = 0


if @Actualiza = 1
begin
	update Route.dbo.ProductoPrestamoCli
	set Saldo = PPC2.Saldo
	from Route.dbo.ProductoPrestamoCli PPC, Route2.dbo.ProductoPrestamoCli PPC2
	where PPC.ClienteClave = PPC2.ClienteClave and PPC.ProductoClave = PPC2.ProductoClave 
	and PPC.ClienteClave in (
		SELECT distinct PPC3.ClienteClave 
		FROM Route.dbo.ProductoPrestamoCli PPC3 
		inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC3.ClienteClave = SEC.ClienteClave 
		inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
		where SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta)) + cast(@IdRuta as varchar(10)) )
end

-- Saldo Anterior
SELECT 3, '20101008', (SUM(PPC.Saldo))
FROM Route2.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route2.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route2.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta)) + cast(@IdRuta as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID 

-- Saldo Anterior Cliente
SELECT 3, '20101008', PPC.ClienteClave, PPC.ProductoClave, (SUM(PPC.Saldo))
FROM Route2.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route2.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route2.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta)) + cast(@IdRuta as varchar(10)) 
	--and PPC.ClienteClave = '030002'
group by SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave, PPC.ProductoClave
order by PPC.ClienteClave

-- Saldo Actual
SELECT 3, '20101008', (SUM(PPC.Saldo))
FROM Route.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta)) + cast(@IdRuta as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID

-- Saldo Actual Cliente
SELECT 3, '20101008', PPC.ClienteClave, PPC.ProductoClave, (SUM(PPC.Saldo))
FROM Route.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(@IdRuta)) + cast(@IdRuta as varchar(10)) 
	--and PPC.ClienteClave = '030002'
group by SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave, PPC.ProductoClave
order by PPC.ClienteClave

--select *
--from Route.dbo.ProductoPrestamoCli 
--where ClienteClave = '030012'
