
/****** Object:  Table [dbo].[RouteAdmAlmacenCedis]    Script Date: 04/11/2010 22:28:40 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

SET ANSI_PADDING ON
/*go*/go

IF (SELECT COUNT(*) FROM SysObjects WHERE Name = 'RouteAdmAlmacenCedis')= 0
CREATE TABLE [dbo].[RouteAdmAlmacenCedis](
	[AlmacenId] [varchar](16) NULL,
	[AlmacenClave] [varchar](8) NULL,
	[IdCedis] [bigint] NULL
) ON [PRIMARY]
/*go*/go

SET ANSI_PADDING OFF
/*go*/go


