
-- Saldo Anterior
SELECT 3, '20101002', (SUM(PPC.Saldo))
FROM Route2.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route2.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route2.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(3)) + cast(3 as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID

-- Saldo Anterior Cliente
SELECT 3, '20101002', PPC.ClienteClave, ppc.ProductoClave, (SUM(PPC.Saldo))
FROM Route2.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route2.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route2.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(3)) + cast(3 as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave, ppc.ProductoClave

SELECT PPC.* 
FROM Route2.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route2.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route2.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(3)) + cast(3 as varchar(10)) 


-- Saldo Actual
SELECT 3, '20101008', (SUM(PPC.Saldo))
FROM Route.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(3)) + cast(3 as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID

-- Saldo Actual Cliente
SELECT 3, '20101008', PPC.ClienteClave, (SUM(PPC.Saldo))
FROM Route.dbo.ProductoPrestamoCli PPC 
inner join (select distinct RutClave, ClienteClave from Route.dbo.Secuencia) SEC on PPC.ClienteClave = SEC.ClienteClave 
inner join Route.dbo.VenRut VRT on SEC.RUTClave = VRT.RUTClave and VRT.TipoEstado = 1 
where PPC.Saldo <> 0 and SEC.RUTClave = 'R' + replicate('0', 2 - len(3)) + cast(3 as varchar(10)) 
group by SEC.RUTClave, VRT.VendedorID, PPC.ClienteClave

