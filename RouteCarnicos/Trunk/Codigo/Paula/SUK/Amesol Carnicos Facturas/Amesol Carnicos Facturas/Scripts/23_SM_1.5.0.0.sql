UPDATE Tabla SET Nombre='CentroExpedicion',ConsultaSQL='DECLARE @FechaActual as datetime
set @FechaActual = GETDATE() 
Select * from dbo.FNCentroExpedicion(<u>,<term>,<vrol>,@FechaActual )' WHERE TablaId='2909014331'


DELETE FROM TablaCampo WHERE TablaId='1701121236' AND CampoId='2309100549'
DELETE FROM TablaCampo WHERE TablaId='1701121236' AND CampoId='2509091254'
DELETE FROM TablaCampo WHERE TablaId='1701121236' AND CampoId='1610102648'