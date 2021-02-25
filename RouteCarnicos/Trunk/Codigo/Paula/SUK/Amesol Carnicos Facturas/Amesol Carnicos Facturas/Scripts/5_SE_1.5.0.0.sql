insert into SEMHist 
select TOP 1 (select top 1 SubEmpresaId from SubEmpresa) as SubEmpresaId,CONHistFechaInicio,ClienteClave,ComprobanteDig,0 as FormatoFactura, FoliosTerminal,DirRepMensual,DirDocXML,DirArchivosFacElec,ContrasenaClave,ArchivoPEM,'',0,0,'','','','', GETDATE() as MFechaHora,MUsuarioID from CONHist order by CONHistFechaInicio desc
