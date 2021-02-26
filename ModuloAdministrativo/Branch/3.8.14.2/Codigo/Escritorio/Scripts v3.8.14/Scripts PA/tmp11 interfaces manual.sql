select tipo, musuarioid, tipofaseintsal from transprod 
--update transprod set tipofaseintsal = 1
where diaclave = '22/04/2010' and musuarioid  ='10104'



exec sp_tg_exportManagement '9999-12-31T00:00:00','2010-04-22T15:13:36','10099'
exec sp_tg_exportCargaSugerida '9999-12-31T00:00:00','2010-04-22T15:13:36','10099'
exec sp_tg_PreliquidacionManagement '2010-04-21T00:00:00','2010-04-22T15:13:36','10099'

exec sp_tg_exportManagement '9999-12-31T00:00:00','2010-04-22T16:29:00','10104'
exec sp_tg_exportCargaSugerida '9999-12-31T00:00:00','2010-04-22T16:29:00','10104'
exec sp_tg_PreliquidacionManagement '2010-04-22T00:00:00','2010-04-22T16:29:00','10104'

exec sp_tg_exportManagement '9999-12-31T00:00:00','2010-04-22T16:24:39','10115'
exec sp_tg_exportCargaSugerida '9999-12-31T00:00:00','2010-04-22T16:24:39','10115'
exec sp_tg_PreliquidacionManagement '2010-04-22T00:00:00','2010-04-22T16:24:39','10115'
