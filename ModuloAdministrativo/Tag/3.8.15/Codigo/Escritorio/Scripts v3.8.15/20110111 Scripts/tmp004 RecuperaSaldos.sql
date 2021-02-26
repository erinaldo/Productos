declare 
@IdCedis as bigint,
@IdSurtidoN as varchar(20),
@Fecha as datetime,
@Opc as int


				declare  SurtidosSaldosTemp cursor for
					select top 1 Surtidos.IdSurtido, surtidos.fecha
					from Surtidos 
					inner join SurtidosVendedor on Surtidos.IdCedis = SurtidosVendedor.IdCedis and Surtidos.IdSurtido = SurtidosVendedor.IdSurtido and SurtidosVendedor.IdVendedor = 82
					where Surtidos.IdCedis = 2 and Surtidos.Fecha = '20110113'
					order by Surtidos.Fecha desc, Surtidos.IdSurtido desc
				open SurtidosSaldosTemp
				
				fetch next from SurtidosSaldosTemp into @IdSurtidoN, @fecha
				while (@@fetch_status = 0)
				begin

					-- Ejecuta InsertaSaldo
					-- select 2, @IdSurtidoN, 82, @Fecha, 1
					exec up_VendedoresSaldos 2, @IdSurtidoN, 82, @Fecha, 1
		
					fetch next from SurtidosSaldosTemp into @IdSurtidoN, @fecha
				end
				close SurtidosSaldosTemp
				deallocate SurtidosSaldosTemp		

