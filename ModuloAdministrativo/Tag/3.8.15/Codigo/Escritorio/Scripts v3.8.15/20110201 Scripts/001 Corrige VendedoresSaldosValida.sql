
use RouteADM 


select *
from VendedoresSaldosValida 
where Financiado is null

/*
update VendedoresSaldosValida set Financiado = 0, SaldoVencido = Saldo, Resultado = Saldo + Bolsa + Ajuste 
where Financiado is null
*/


