 declare @SaldoAnterior as bigint 

 update ProductoPrestamoCli 
	set Saldo = PPC.Saldo
from Route2.dbo.ProductoPrestamoCli PPC 
where ProductoPrestamoCli.ClienteClave = PPC.ClienteClave and ProductoPrestamoCli.ProductoClave = PPC.ProductoClave 
and ProductoPrestamoCli.ClienteClave in ('030001', '030002', '030025')

 update ProductoPrestamoCli set Saldo = Saldo + 1 where ClienteClave = '030001' and ProductoClave = '33'

 update ProductoPrestamoCli set Saldo = Saldo + 40 where ClienteClave = '030002' and ProductoClave = '32'
 update ProductoPrestamoCli set Saldo = Saldo + 8 where ClienteClave = '030002' and ProductoClave = '33'
 update ProductoPrestamoCli set Saldo = Saldo + 24 where ClienteClave = '030002' and ProductoClave = '35'
 update ProductoPrestamoCli set Saldo = Saldo + 11 where ClienteClave = '030002' and ProductoClave = '36'

 update ProductoPrestamoCli set Saldo = Saldo + 2 where ClienteClave = '030025' and ProductoClave = '30'
 update ProductoPrestamoCli set Saldo = Saldo + 1 where ClienteClave = '030025' and ProductoClave = '35'
 update ProductoPrestamoCli set Saldo = Saldo + 10 where ClienteClave = '030025' and ProductoClave = '36'


 update ProductoPrestamoCli set Saldo = Saldo + 20 where ClienteClave = '030002' and ProductoClave = '30'
 update ProductoPrestamoCli set Saldo = Saldo + 60 where ClienteClave = '030002' and ProductoClave = '32'
 update ProductoPrestamoCli set Saldo = Saldo + 18 where ClienteClave = '030002' and ProductoClave = '33'
 update ProductoPrestamoCli set Saldo = Saldo + 46 where ClienteClave = '030002' and ProductoClave = '35'
 update ProductoPrestamoCli set Saldo = Saldo + 17 where ClienteClave = '030002' and ProductoClave = '36'


 update ProductoPrestamoCli set Saldo = Saldo - 30 where ClienteClave = '030002' and ProductoClave = '30'
 update ProductoPrestamoCli set Saldo = Saldo - 55 where ClienteClave = '030002' and ProductoClave = '32'
 update ProductoPrestamoCli set Saldo = Saldo - 13 where ClienteClave = '030002' and ProductoClave = '33'
 update ProductoPrestamoCli set Saldo = Saldo - 40 where ClienteClave = '030002' and ProductoClave = '35'
 update ProductoPrestamoCli set Saldo = Saldo - 10 where ClienteClave = '030002' and ProductoClave = '36'


 update ProductoPrestamoCli set Saldo = Saldo - 24 where ClienteClave = '030002' and ProductoClave = '30'
 update ProductoPrestamoCli set Saldo = Saldo - 28 where ClienteClave = '030002' and ProductoClave = '32'
 update ProductoPrestamoCli set Saldo = Saldo - 1 where ClienteClave = '030002' and ProductoClave = '33'
 update ProductoPrestamoCli set Saldo = Saldo - 31 where ClienteClave = '030002' and ProductoClave = '35'


 update ProductoPrestamoCli set Saldo = Saldo - 3 where ClienteClave = '030025' and ProductoClave = '30'
 update ProductoPrestamoCli set Saldo = Saldo - 0 where ClienteClave = '030025' and ProductoClave = '35'
 update ProductoPrestamoCli set Saldo = Saldo - 10 where ClienteClave = '030025' and ProductoClave = '36'
