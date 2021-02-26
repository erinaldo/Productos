 SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CancelarVentas]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CancelarVentas]
/*go*/go

SET QUOTED_IDENTIFIER OFF 
/*go*/go
SET ANSI_NULLS ON 
/*go*/go



CREATE Procedure [dbo].[SP_CancelarVentas]
@IdCedis as bigint,
@IdSurtido as bigint,
@Fecha as datetime,
@IdRuta as bigint,
@ClaveUsuario varchar(16)
AS begin
			declare @UsuID as varchar(16)
			declare @Folio as varchar(20)
			DECLARE @CursorVar1 CURSOR     
			declare @TransprodID as varchar(16)
			declare @ClienteClave as varchar(16)
			declare @Total as float
			declare @CobrarVentas as bit
			declare @PagoAutomatico as bit
			declare @ClientePagoID as smallint
			declare @Saldo as float
			declare @Puntos as float
			declare @CFVTipo as smallint
			declare @Serie varchar(16)
			declare @ABNId as varchar(16)
				
				if(exists(Select * from Usuario where Clave=@ClaveUsuario))
					BEGIN
						Select @UsuID=USUId from Usuario where Clave=@ClaveUsuario
					end
				ELSE
					begin
						set @UsuID='Interfaz'
				END


			select top 1 @CobrarVentas=CobrarVentas,@PagoAutomatico=PagoAutomatico from CONHist order by CONHist.CONHistFechaInicio desc


			SET @CursorVar1 = CURSOR SCROLL DYNAMIC FOR   
							select Folio,Serie from RouteADM.DBO.Ventas where IdCedis = @IdCedis and IdSurtido = @IdSurtido
			OPEN @CursorVar1  
			FETCH NEXT FROM @CursorVar1 INTO @Folio,@Serie

			WHILE @@FETCH_STATUS = 0      
				BEGIN 

							declare @EsFactura as bit
							set @EsFactura=0
							
							
						if(exists(select * from FolioSolicitado where Serie=@Serie))
						begin
						set @EsFactura=1
						end
									
							--******************************************************************
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
																update Cliente set SaldoEfectivo=SaldoEfectivo-@Saldo,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
															end
														end

														if(@CFVTipo=1 and @ClientePagoID=1 and @CobrarVentas=0 and @PagoAutomatico=1)
														begin
															SELECT @ABNId= ABNId FROM AbnTrp WHERE AbnTrp.TransProdID=@TransprodID
														end
										
														if(@CFVTipo=1 and @ClientePagoID=1 and @CobrarVentas=1 and @PagoAutomatico=1)
														begin
															SELECT @ABNId= ABNId 
															FROM AbnTrp 
															inner join TransProd on TransProd.TransProdID=AbnTrp.TransProdID 
															WHERE TransProd.FacturaID=@TransprodID															
														end
										
													DELETE ABNDetalle WHERE ABNId = @ABNId
													delete AbnTrp WHERE ABNId = @ABNId
													delete Abono WHERE ABNId = @ABNId
													
													if(@CobrarVentas= 0)
														Update TransProd Set Saldo =Total where TransProdID=@TransprodID													
													else
														Update TransProd Set Saldo =Total where FacturaId=@TransprodID													
	

													delete ProductoNegado From ProductoNegado P inner join TransProd T on T.TransProdID=P.TransProdID where not PromocionClave is null and T.FacturaID =@TransprodID
													delete TpdDesVendedor From TpdDesVendedor D inner join TransProd T on T.TransProdID=D.TransProdID where T.FacturaID =@TransprodID
														
													select @Puntos=isnull(sum(isnull(Puntos,0)),0)  from TpdPun P inner join Transprod  t on T.TransProdId =P.TransprodID where T.FacturaID=@TransprodID
													update Punto set Saldo=Saldo-@Puntos,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
														
										
										--CancelaFactura
										Update TransProd Set TipoFase=0,MUsuarioID=@UsuID,MFechaHora=GETDATE(),FechaCancelacion=GETDATE() From TransProd where TransProdID=@TransprodID
										--CancelaVentas
										Update TransProd Set TipoFase=0,MUsuarioID=@UsuID,MFechaHora=GETDATE(),FechaCancelacion=GETDATE(),FacturaID =null,FechaFacturacion=null From TransProd where FacturaID=@TransprodID
								end
								else
								begin
									
									Set @Folio= RIGHT('10000' +@IdRuta,5) +'-'+ RIGHT('00000' +rtrim(ltrim(str(@Folio))),5 )
									select @TransprodID=t.TransprodID,@CFVTipo=CFVTipo,@Total=Total,@ClienteClave=V.ClienteClave,@ClientePagoID=ClientePagoID,@Saldo=Saldo  from transprod  t inner join Dia D on D.DiaClave=t.DiaClave inner join Visita V on V.VisitaClave=T.VisitaClave and T.DiaClave=V.DiaClave where Folio=@Folio and Tipo=1 and D.FechaCaptura=@Fecha

												if(not @TransprodID is null)
												begin
													
													Update TransProd Set TipoFase=0,MUsuarioID=@UsuID,MFechaHora=GETDATE(),FechaCancelacion=GETDATE() From TransProd where TransProdID=@TransprodID
														
													delete ProductoNegado where not PromocionClave is null and TransProdId =@TransprodID
													delete TpdDesVendedor where TransProdId =@TransprodID
														
													select @Puntos=isnull(sum(Puntos),0)  from TpdPun where TransProdId =@TransprodID
													update Punto set Saldo=Saldo-@Puntos,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
														
														
													if(@CFVTipo=2)--Credito
													begin
														if(@CobrarVentas=1)
														begin
															update Cliente set SaldoEfectivo=SaldoEfectivo-@Saldo,MFechaHora=GETDATE(),MUsuarioID=@UsuID where ClienteClave=@ClienteClave
														end
													end
													else
													begin
														if(@ClientePagoID=1 and @CobrarVentas=1 and @PagoAutomatico=1)
														begin
															SELECT @ABNId= ABNId 
															FROM AbnTrp 
															inner join TransProd on TransProd.TransProdID=AbnTrp.TransProdID 
															WHERE TransProd.FacturaID=@TransprodID															

															DELETE ABNDetalle WHERE ABNId = @ABNId
															delete AbnTrp WHERE ABNId = @ABNId
															delete Abono WHERE ABNId = @ABNId
															Update TransProd Set Saldo =Total where FacturaId=@TransprodID
														
														end
													end
													
												end
												
								end
							--	***************************************************************		
							




					FETCH NEXT FROM @CursorVar1 INTO @Folio,@Serie
				end

			CLOSE @CursorVar1  
			DEALLOCATE @CursorVar1  


end

