UPDATE TransProd set SubEmpresaID=(select top 1 SubEmpresaID  from SubEmpresa)
where SubEmpresaID is null and ((tipo=1) or (tipo=8 and TransProdID in (select TransProdID  from TRPDatoFiscal))   )