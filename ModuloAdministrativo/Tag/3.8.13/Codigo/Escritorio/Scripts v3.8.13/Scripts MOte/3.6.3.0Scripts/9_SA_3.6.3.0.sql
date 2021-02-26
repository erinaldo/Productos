/****** Object:  Table [dbo].[RouteAdmRecorrerIdRuta]    Script Date: 04/11/2010 22:31:02 ******/
SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go

IF (SELECT COUNT(*) FROM SysObjects WHERE Name = 'RouteAdmRecorrerIdRuta')= 0
CREATE TABLE [dbo].[RouteAdmRecorrerIdRuta](
	[Recorrer] [int] NULL
) ON [PRIMARY]

/*go*/go


