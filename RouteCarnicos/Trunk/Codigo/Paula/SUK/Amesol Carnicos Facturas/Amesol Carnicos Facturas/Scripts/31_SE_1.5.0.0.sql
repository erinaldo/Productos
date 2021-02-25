
/****** Object:  Table [dbo].[TPDDesProdVendedor]    Script Date: 04/30/2012 23:01:42 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPDDesProdVendedor]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[TPDDesProdVendedor](
		[TransProdID] [varchar](16) NOT NULL,
		[TransProdDetalleID] [varchar](16) NOT NULL,
		[DesPor] [float] NOT NULL,
		[DesImporte] [float] NOT NULL,
		[MFechaHora] [datetime] NOT NULL,
		[MUsuarioID] [varchar](16) NOT NULL
	) ON [PRIMARY]

	SET ANSI_PADDING OFF

	ALTER TABLE [dbo].[TPDDesProdVendedor]  WITH NOCHECK ADD  CONSTRAINT [FK_TPDDesProdVendedor_TransProdDetalle] FOREIGN KEY([TransProdID], [TransProdDetalleID])
	REFERENCES [dbo].[TransProdDetalle] ([TransProdID], [TransProdDetalleID])

	ALTER TABLE [dbo].[TPDDesProdVendedor] CHECK CONSTRAINT [FK_TPDDesProdVendedor_TransProdDetalle]
END

