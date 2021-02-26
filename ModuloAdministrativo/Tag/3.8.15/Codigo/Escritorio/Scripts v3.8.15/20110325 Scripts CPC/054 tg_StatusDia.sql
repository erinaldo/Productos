USE [RouteADM]
GO

/****** Object:  Trigger [tr_StatusDia]    Script Date: 03/03/2011 12:28:39 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tr_StatusDia]'))
DROP TRIGGER [dbo].[tr_StatusDia]
GO

USE [RouteADM] 
GO

/****** Object:  Trigger [dbo].[tr_StatusDia]    Script Date: 03/03/2011 12:28:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[tr_StatusDia] ON [dbo].[StatusDia] 
FOR INSERT, UPDATE, DELETE 
AS

declare @Tipo as int

set @Tipo = 0
set @Tipo = isnull( (select top 1 IdCedis from inserted ), 0)

if @Tipo = 0 -- deleted 
begin
	insert into StatusDiaDetalle
	select IdCedis, Fecha, getdate(), Status, StatusDesc + ' - D' 
	from Deleted	
end
else  -- inserted
begin
	insert into StatusDiaDetalle
	select IdCedis, Fecha, getdate(), Status, StatusDesc + ' - I/U'
	from Inserted	
end

GO


