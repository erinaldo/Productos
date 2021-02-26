
insert into configuracion values (2, 'SAN JUAN DEL RIO', 1, 'SJ', 1, 'SJA', 1,1, 0, 1,0, '', 'ROUTE', 'REM02', 
'S', 'Piezas', 'Cajas', 'RFC-010101-AAA', 'PRODUCTOS ARACELI S.A. DE C.V.', 'Acceso 3, Nave 20, Bodega 14 No. 14 Parque Industrial Benito Juárez, Querétaro, Querétaro',
'S', 'N', 'S', 'S', 'N', 'N', 12, 0)

update clientesucursal set calle = substring(calle,1,64), callef=substring(callef,1,64)
where idcedis = 2 

update clientesucursal set nombresucursal = nombresucursal where idcedis = 2
