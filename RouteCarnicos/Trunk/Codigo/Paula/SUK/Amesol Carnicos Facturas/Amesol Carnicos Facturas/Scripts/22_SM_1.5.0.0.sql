/****** Object:  UserDefinedFunction [dbo].[FNCentroExpedicion]    Script Date: 04/25/2012 20:15:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FNCentroExpedicion]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FNCentroExpedicion]
/*go*/go


CREATE FUNCTION [dbo].[FNCentroExpedicion](@parsVendedorID as varchar(16), @parsTerminalClave as varchar(25), @parbRol as smallint,@pardFechaActual as datetime)
RETURNS @CentroExpedicion
TABLE(
CentroExpID varchar(16) COLLATE database_default,
CentroExpPadreID varchar(16) COLLATE database_default,
Nombre varchar(60) COLLATE database_default,
Tipo smallint,
SubEmpresaID varchar(16) COLLATE database_default,
NumCertificado varchar(20) COLLATE database_default,
RFC varchar(13) COLLATE database_default,
Calle varchar(64) COLLATE database_default,
NumExt varchar(16) COLLATE database_default, 
NumInt varchar(16) COLLATE database_default,
Colonia varchar(64) COLLATE database_default,
CodigoPostal varchar(16) COLLATE database_default,
ReferenciaDom varchar(100) COLLATE database_default,
Localidad varchar(40) COLLATE database_default,
Municipio varchar(40) COLLATE database_default,
Entidad varchar(40) COLLATE database_default,
Pais varchar(40) COLLATE database_default)
AS  
BEGIN 

DECLARE SubEmpresas_cursor CURSOR LOCAL FOR 
SELECT SubEmpresaID FROM SubEmpresa

OPEN SubEmpresas_cursor 

DECLARE @SubEmpresaID as varchar(16)
DECLARE @FoliosTerminal bit, @ComprobanteDig bit

FETCH NEXT FROM SubEmpresas_cursor INTO @SubEmpresaID
	
WHILE @@FETCH_STATUS = 0 
Begin
	select top 1 @Foliosterminal =FoliosTerminal,@ComprobanteDig=ComprobanteDig from SEMHist where SEMHistFechaInicio <= @pardFechaActual and SubEmpresaId=@SubEmpresaID  order by SEMHistFechaInicio desc
	
	IF (@ComprobanteDig = 1)
	BEGIN
		insert into @CentroExpedicion 
		select distinct CEN.CentroExpID ,CEN.CentroExpPadreID,CEN.Nombre,CEN.Tipo,CEN.SubEmpresaID, CEN.NumCertificado,CEN.RFC,CEN.Calle,CEN.NumExt,
		CEN.NumInt,CEN.Colonia,CEN.CodigoPostal,CEN.ReferenciaDom,CEN.Localidad,CEN.Municipio,
		CEN.Entidad,CEN.Pais
		from Folio FOL 
		inner join FolioDetalle FDE on FOL.FolioId = FDE.FolioId and FDE.TipoEstado = 1
		inner join FolioSolicitado FOS on FOL.FolioId = FOS.FolioId and FOS.CantSolicitada > FOS.Usados
		inner join FOSHist FSH on FSH.FolioId = FOS.FolioId and FSH.FOSId = FOS.FOSId and FSHFechaInicio = (select  max(FSH1.FSHFechaInicio) from FOSHist FSH1 where FSH.FolioId = FSH1.FolioId and FSH.FOSId = FSH1.FOSId and ((FSH.VendedorId = @parsVendedorID and @FoliosTerminal = 0) or (FSH.TerminalClave = @parsTerminalClave and @FoliosTerminal = 1)))
		inner join centroexpedicion CEN on CEN.CentroExpID=FSH.CentroExpID and FSH.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 
		where FOL.ModuloMovDetalleClave in (Select ModuloMovDetalleClave from ModuloMovDetalle inner join ModuloMov on ModuloMovDetalle.ModuloMovClave = ModuloMov.ModuloMovClave inner join ModuloTerm on ModuloTerm.ModuloClave = ModuloMov.ModuloClave WHERE ModuloTerm.TipoIndice = @parbRol and ModuloTerm.TipoEstado = 1 and ModuloTerm.baja = 0 and ModuloMov.TipoEstado = 1 and ModuloMov.baja = 0 and ModuloMovDetalle.TipoEstado = 1 and ModuloMovDetalle.baja = 0 and (ModuloMovDetalle.ModuloMovDetalleClave in (select ModuloMovDetalleClave from MmdMcn) or ModuloTerm.tipo=2))
		and FOL.TipoEstado = 1 and FOL.Fiscal = 1 and FOL.SubEmpresaId = @SubEmpresaID
		UNION
		select distinct  CEN.CentroExpID ,CEN.CentroExpPadreID,CEN.Nombre,CEN.Tipo,CEN.SubEmpresaID,CEN.NumCertificado,CEN.RFC,CEN.Calle,CEN.NumExt,
		CEN.NumInt,CEN.Colonia,CEN.CodigoPostal,CEN.ReferenciaDom,CEN.Localidad,CEN.Municipio,
		CEN.Entidad,CEN.Pais from  centroexpedicion CEN where CEN.centroexpid in 
		(select distinct CEN.CentroExpPadreID
		from Folio FOL 
		inner join FolioDetalle FDE on FOL.FolioId = FDE.FolioId and FDE.TipoEstado = 1
		inner join FolioSolicitado FOS on FOL.FolioId = FOS.FolioId and FOS.CantSolicitada > FOS.Usados
		inner join FOSHist FSH on FSH.FolioId = FOS.FolioId and FSH.FOSId = FOS.FOSId and FSHFechaInicio = (select  max(FSH1.FSHFechaInicio) from FOSHist FSH1 where FSH.FolioId = FSH1.FolioId and FSH.FOSId = FSH1.FOSId and ((FSH.VendedorId = @parsVendedorID and @FoliosTerminal = 0) or (FSH.TerminalClave = @parsTerminalClave and @FoliosTerminal = 1)))
		inner join centroexpedicion CEN on CEN.CentroExpID=FSH.CentroExpID and FSH.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 
		where FOL.ModuloMovDetalleClave in (Select ModuloMovDetalleClave from ModuloMovDetalle inner join ModuloMov on ModuloMovDetalle.ModuloMovClave = ModuloMov.ModuloMovClave inner join ModuloTerm on ModuloTerm.ModuloClave = ModuloMov.ModuloClave WHERE ModuloTerm.TipoIndice = @parbRol and ModuloTerm.TipoEstado = 1 and ModuloTerm.baja = 0 and ModuloMov.TipoEstado = 1 and ModuloMov.baja = 0 and ModuloMovDetalle.TipoEstado = 1 and ModuloMovDetalle.baja = 0 and (ModuloMovDetalle.ModuloMovDetalleClave in (select ModuloMovDetalleClave from MmdMcn) or ModuloTerm.tipo=2))
		and FOL.TipoEstado = 1 and FOL.Fiscal = 1 and FOL.SubEmpresaId = @SubEmpresaID)		 
	END	
	FETCH NEXT FROM SubEmpresas_cursor INTO @SubEmpresaID
End

Close SubEmpresas_cursor 
DEALLOCATE SubEmpresas_cursor

RETURN 

END


/*go*/go


