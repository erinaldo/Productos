/****** Object:  Table [dbo].[TpdPun]    Script Date: 04/30/2012 22:44:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TpdPun]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TpdPun](
		[TransProdId] [varchar](16) NOT NULL,
		[TransProdDetalleId] [varchar](16) NOT NULL,
		[PromocionClave] [varchar](10) NOT NULL,
		[Puntos] [float] NOT NULL,
		[MFechaHora] [datetime] NOT NULL,
		[MUsuarioId] [varchar](16) NOT NULL,
	 CONSTRAINT [PK_TpdPun] PRIMARY KEY CLUSTERED 
	(
		[TransProdId] ASC,
		[TransProdDetalleId] ASC,
		[PromocionClave] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	SET ANSI_PADDING OFF

	ALTER TABLE [dbo].[TpdPun]  WITH CHECK ADD  CONSTRAINT [FK_TpdPun_Promocion] FOREIGN KEY([PromocionClave])
	REFERENCES [dbo].[Promocion] ([PromocionClave])

	ALTER TABLE [dbo].[TpdPun] CHECK CONSTRAINT [FK_TpdPun_Promocion]

	ALTER TABLE [dbo].[TpdPun]  WITH NOCHECK ADD  CONSTRAINT [FK_TpdPun_TransProdDetalle] FOREIGN KEY([TransProdId], [TransProdDetalleId])
	REFERENCES [dbo].[TransProdDetalle] ([TransProdID], [TransProdDetalleID])

	ALTER TABLE [dbo].[TpdPun] CHECK CONSTRAINT [FK_TpdPun_TransProdDetalle]
END

