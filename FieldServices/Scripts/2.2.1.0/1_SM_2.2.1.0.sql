IF NOT EXISTS (SELECT * FROM Mensaje WHERE ClaveMensaje = 'MP0033')
	INSERT INTO Mensaje ( ClaveMensaje, Descripcion,Ambiente) VALUES('MP0033','Es necesario enviar los datos capturados en la jornada, antes de solicitar los datos de alguna jornada',3)

