
alter table TipoMerma
add Imputable varchar(1)
GO

update TipoMerma set Imputable  = 'V'
