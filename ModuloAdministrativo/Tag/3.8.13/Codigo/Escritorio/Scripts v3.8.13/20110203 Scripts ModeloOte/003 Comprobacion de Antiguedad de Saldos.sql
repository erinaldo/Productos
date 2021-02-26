
select SUM(SaldoEfectivo) SaldoRoute, 
	ISNULL((select SUM(Saldo)
	from Route.dbo.TransProd TRPC
	where TRPC.Tipo = 24 and Saldo > 0),0) SaldoConsignas, 
	
	SUM(SaldoEfectivo) - ISNULL((select SUM(Saldo)
	from Route.dbo.TransProd TRPC
	where TRPC.Tipo = 24 and Saldo > 0),0) SaldoRoute, 	
	
	ISNULL((select SUM(Saldo)
	from Ventas
	where login not in ('SNoReg')),0) SaldoADM
from Route.dbo.Cliente 

select SUM(Saldo)
from Route.dbo.TransProd TRPC
where TRPC.Tipo = 1 and Saldo > 0 and TipoFase > 0





--select top 100 *
--from Route.dbo.TransProd TRPC
--inner join Route.dbo.TrpTpd TPD on TPD.TransProdID1 = TRPC.TransProdID 
--inner join Route.dbo.TransProd TRP on TPD.TransProdID = TRP.TransProdID 
--inner join Route.dbo.Dia Dia on TRP.DiaClave = Dia.DiaClave
--inner join Route.dbo.Visita VIS on TRP.VisitaClave = VIS.VisitaClave
--where TRPC.Tipo = 24



