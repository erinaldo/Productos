declare @IdCedis as bigint, @IdSurtido as bigint, @IdTipoVenta as bigint, @Serie as varchar(5), 
@Folio as bigint, @IdMarca as bigint, @IdRuta as bigint, @Usuario as varchar(10), @SerieN as varchar(5)

declare VentasDet cursor for
	select distinct VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Serie, VentasDetalle.Folio, IdMarca, IdRuta  
	from VentasDetalle 
	inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
	inner join Surtidos on Surtidos.IdCedis = VentasDetalle.IdCedis and  Surtidos.IdSurtido = VentasDetalle.IdSurtido 
	where VentasDetalle.Serie like 'EBQ%' 
	order by VentasDetalle.IdCedis, VentasDetalle.IdSurtido, VentasDetalle.IdTipoVenta, VentasDetalle.Serie, VentasDetalle.Folio 
open VentasDet

fetch next from VentasDet into @IdCedis, @IdSurtido, @IdTipoVenta, @Serie, @Folio, @IdMarca, @IdRuta  
while (@@fetch_status = 0)
begin
	if @IdMarca = 1
	begin
		
		set @Usuario = CAST(@IdCedis as varchar(1)) + REPLICATE('0', 4 -LEN(@IdRuta)) + CAST(@idruta as varchar(5))
		select @SerieN = FS.Serie 
		from Route.dbo.FolioSolicitado  FS
		inner join Route.dbo.FOSHist FH on FH.FolioID = FS.FolioID and FH.FOSId = FS.FOSId 
		where FH.VendedorID = @Usuario and FH.CentroExpID = @IdMarca 
		
		--select @Usuario, @SerieN, @Serie, @IdRuta 

		update VentasDetalle set Serie = @SerieN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio

		update Ventas set Serie = @SerieN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio
	end
	else
	begin
		set @Usuario = CAST(@IdCedis as varchar(1)) + REPLICATE('0', 4 -LEN(@IdRuta)) + CAST(@idruta as varchar(5))
		select @SerieN = FS.Serie 
		from Route.dbo.FolioSolicitado  FS
		inner join Route.dbo.FOSHist FH on FH.FolioID = FS.FolioID and FH.FOSId = FS.FOSId 
		where FH.VendedorID = @Usuario and FH.CentroExpID = @IdMarca 

		--select @Usuario, @SerieN, @Serie, @IdRuta 
		
		update VentasDetalle set Serie = @SerieN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio

		update Ventas set Serie = @SerieN 
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and 
			Serie = @Serie and Folio = @Folio
	end	
	
	fetch next from VentasDet into @IdCedis, @IdSurtido, @IdTipoVenta, @Serie, @Folio, @IdMarca, @IdRuta  
end
close VentasDet
deallocate VentasDet		