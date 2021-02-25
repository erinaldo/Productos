SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go




ALTER PROCEDURE [dbo].[sp_Importar_MDI]
	@ClaveMaterial [varchar](20) ,
	@Antena  bit,
	@Control bit,
	@Fuente bit

AS
BEGIN
	SET NOCOUNT ON;
		DECLARE @Err int
	set @Err = 0


	IF (@ClaveMaterial is null) or (RTrim(LTrim(@ClaveMaterial)) = '')
	BEGIN
		RAISERROR ('ClaveMaterial.Atributo Requerido.', 16, 2)
		set @Err = @@ERROR

	END
	ELSE IF (NOT EXISTS(SELECT * FROM Material WHERE ClaveMaterial=@ClaveMaterial AND ESTado=1))
	BeGIN 
	RAISERROR ('ClaveMaterial.No existe Material o está Inactivo.', 16, 2)
		set @Err = @@ERROR
	END
	
	
	IF (@Antena is null) or (RTrim(LTrim(@Antena)) = '')
	BEGIN
		RAISERROR ('Antena.Atributo Requerido.', 16, 2)
		set @Err = @@ERROR

	END
	
	IF (@Control is null) or (RTrim(LTrim(@Control)) = '')
	BEGIN
		RAISERROR ('Control.Atributo Requerido.', 16, 2)
		set @Err = @@ERROR

	END
	
	IF (@Fuente is null) or (RTrim(LTrim(@Fuente)) = '')
	BEGIN
		RAISERROR ('Fuente.Atributo Requerido.', 16, 2)
		set @Err = @@ERROR

	END
	
		IF (@Err  <> 0)
	BEGIN
		RETURN
	END
	
if( exists(select * from MaterialDigital where ClaveMaterial=@ClaveMaterial))
begin
update  MaterialDigital set Antena=@Antena , Control=@Control, Fuente=@Fuente where ClaveMaterial=@ClaveMaterial
end
else
begin
insert MaterialDigital  values (@ClaveMaterial,@Antena,@Control,@Fuente)

end


end

/*go*/go

