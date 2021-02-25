/****** Object:  Table [dbo].[TRPVtaAcreditada]    Script Date: 05/02/2012 14:07:18 ******/
IF  NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[TRPVtaAcreditada]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TRPVtaAcreditada](
		[TransProdID] [varchar](16) NOT NULL,
		[FolioEntrega] [varchar](16) NULL,
		[FolioCliente] [varchar](16) NULL,
		[Remision] [varchar](16) NULL,
		[PedidoAdicional] [varchar](10) NULL,
		[MFechaHora] [datetime] NOT NULL,
		[MUsuarioID] [varchar](16) NOT NULL,
	 CONSTRAINT [PK_TRPVtaAcreditada] PRIMARY KEY CLUSTERED 
	(
		[TransProdID] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [dbo].[TRPVtaAcreditada]  WITH NOCHECK ADD  CONSTRAINT [FK_TRPVtaAcreditada_TransProd] FOREIGN KEY([TransProdID])
	REFERENCES [dbo].[TransProd] ([TransProdID])
	
	ALTER TABLE [dbo].[TRPVtaAcreditada] CHECK CONSTRAINT [FK_TRPVtaAcreditada_TransProd]
END

