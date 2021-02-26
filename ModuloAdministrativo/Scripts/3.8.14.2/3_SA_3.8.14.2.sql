USe Route
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FNValidarCancelacionVentaADM]'))
drop Function [dbo].[FNValidarCancelacionVentaADM]
/*go*/go 

Create function [dbo].[FNValidarCancelacionVentaADM](
@Folio varchar(16),
@Serie varchar(16),
@Fecha as DateTime,
@IdRuta as bigint) returns bit
as Begin
		declare @UsuID as varchar(16)
		declare @TransprodID as varchar(16)
		declare @ClienteClave as varchar(16)
		declare @CFVTipo as smallint
		declare @CobrarVentas as bit
		declare @PagoAutomatico as bit
		declare @ClientePagoID as smallint
		declare @Total as float
		declare @Saldo as float
		declare @Puntos as float
		declare @EsFactura as bit
		set @TransprodID= null


		set @TransprodID=null
		set @EsFactura=0

		if(exists(select * from FolioSolicitado where Serie=@Serie))
		begin
		set @EsFactura=1
		end

		select top 1 @CobrarVentas=CobrarVentas,@PagoAutomatico=PagoAutomatico from CONHist order by CONHist.CONHistFechaInicio desc

		if(@EsFactura=1)
		begin 
				declare @FormatoFolio as varchar(16)
				select top 1 @FormatoFolio=fd.Formato from FolioSolicitado  fs
				inner join Foliodetalle fd on fd.FolioID=fs.FolioID
				where Usados<CantSolicitada and Serie =@Serie
				order by Usados desc

				
				set @Folio = @Serie+ RIGHT(@FormatoFolio +@folio,LEN(@FormatoFolio))
				
				--select @TransprodID=t.TransprodID,@CFVTipo=CFVTipo  ,@Total=Total,   @ClienteClave=V.ClienteClave,@ClientePagoID=ClientePagoID         ,@Saldo=Saldo    from transprod  t                                                         inner join Dia D on D.DiaClave=t.DiaClave inner join Visita V on V.VisitaClave=T.VisitaClave and T.DiaClave=V.DiaClave where   Folio=@Folio and   Tipo=8 and D.FechaCaptura=@Fecha
				select @TransprodID=t.TransprodID,@CFVTipo=t.CFVTipo,@Total=t.Total, @ClienteClave=V.ClienteClave,@ClientePagoID=max(ven.ClientePagoID),@Saldo=t.Saldo  from transprod  t inner join TransProd ven on t.TransProdID=ven.FacturaID inner join Dia D on D.DiaClave=t.DiaClave inner join Visita V on V.VisitaClave=T.VisitaClave and T.DiaClave=V.DiaClave where t.Folio=@Folio and t.Tipo=8 and D.FechaCaptura=@Fecha group by t.TransprodID,t.CFVTipo,t.Total,V.ClienteClave,t.Saldo
				

										if(@CFVTipo=2)
														begin
															if(@CobrarVentas=0)
															begin
																if(exists(select * from AbnTrp where TransProdID=@TransprodID))
																	return 1
																
															end
															else
															begin
																return 1
															end
														end

														if(@CFVTipo=1 and @CobrarVentas=0 and (@ClientePagoID<>1 or @PagoAutomatico<>1))
														begin
															if(exists(select * from AbnTrp where TransProdID=@TransprodID))
																	return 1	
														end
										
														if(@CFVTipo=1 and  @CobrarVentas=1 and(@ClientePagoID<>1  or @PagoAutomatico<>1))
														begin
															if(exists(select * from AbnTrp   inner join transprod  on  transprod.transprodid=AbnTrp.transprodid where Facturaid=@TransprodID))
																	return 1
														end
				
						
		end
		else
		begin
			
			Set @Folio= RIGHT('10000' +@IdRuta,5) +'-'+ RIGHT('00000' +rtrim(ltrim(str(@Folio))),5 )
			select @TransprodID=t.TransprodID,@CFVTipo=CFVTipo,@Total=Total,@ClienteClave=V.ClienteClave,@ClientePagoID=ClientePagoID,@Saldo=Saldo  from transprod  t inner join Dia D on D.DiaClave=t.DiaClave inner join Visita V on V.VisitaClave=T.VisitaClave and T.DiaClave=V.DiaClave where Folio=@Folio and Tipo=1 and D.FechaCaptura=@Fecha

						if(not @TransprodID is null)
						begin
							
									if(@CFVTipo=2)--Credito
									begin
										if(@CobrarVentas=1)
										begin
										
											if(exists(select * from AbnTrp where TransProdID=@TransprodID))
												return 1

										
										end
									end
									else
									begin
										if( @CobrarVentas=1 and( @ClientePagoID<>1 or @PagoAutomatico<>1))
										begin
											
											if(exists(select * from AbnTrp where TransProdID=@TransprodID))
												return 1
												
										
										
										end
									end
							
						end
						
		end
		return 0
end

