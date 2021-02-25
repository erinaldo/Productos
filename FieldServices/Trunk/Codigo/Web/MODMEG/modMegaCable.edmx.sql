
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2010 00:23:07
-- Generated from EDMX file: C:\Proyectos\Megacable\MODMEG\modMegaCable.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MegaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Actividad_Modulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividad] DROP CONSTRAINT [FK_Actividad_Modulo];
GO
IF OBJECT_ID(N'[dbo].[FK_Actividad_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividad] DROP CONSTRAINT [FK_Actividad_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadPerfil_Actividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActividadPerfil] DROP CONSTRAINT [FK_ActividadPerfil_Actividad];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadPerfil_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActividadPerfil] DROP CONSTRAINT [FK_ActividadPerfil_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivoFijo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivoFijo] DROP CONSTRAINT [FK_ActivoFijo_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Arqueo_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Arqueo] DROP CONSTRAINT [FK_Arqueo_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_AuditoriaRecepcion_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuditoriaRecepcion] DROP CONSTRAINT [FK_AuditoriaRecepcion_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_AuditoriaRecepcion_Sucursal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuditoriaRecepcion] DROP CONSTRAINT [FK_AuditoriaRecepcion_Sucursal];
GO
IF OBJECT_ID(N'[dbo].[FK_CarreteCable_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarreteCable] DROP CONSTRAINT [FK_CarreteCable_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_CarreteCable_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarreteCable] DROP CONSTRAINT [FK_CarreteCable_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteServicio_Suscriptor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteServicio] DROP CONSTRAINT [FK_ClienteServicio_Suscriptor];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteServicio_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteServicio] DROP CONSTRAINT [FK_ClienteServicio_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteServicio_ValorReferencia1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteServicio] DROP CONSTRAINT [FK_ClienteServicio_ValorReferencia1];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteServicio_Visita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteServicio] DROP CONSTRAINT [FK_ClienteServicio_Visita];
GO
IF OBJECT_ID(N'[dbo].[FK_Configuracion_Sucursal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuracion] DROP CONSTRAINT [FK_Configuracion_Sucursal];
GO
IF OBJECT_ID(N'[dbo].[FK_Configuracion_ValorConfiguracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuracion] DROP CONSTRAINT [FK_Configuracion_ValorConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoCableTrabajo_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoCableTrabajo] DROP CONSTRAINT [FK_ConsumoCableTrabajo_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoCableTrabajo_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoCableTrabajo] DROP CONSTRAINT [FK_ConsumoCableTrabajo_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoCableTrabajo_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoCableTrabajo] DROP CONSTRAINT [FK_ConsumoCableTrabajo_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoTrabajo_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoTrabajo] DROP CONSTRAINT [FK_ConsumoTrabajo_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoTrabajo_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoTrabajo] DROP CONSTRAINT [FK_ConsumoTrabajo_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_ConsumoTrabajo_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsumoTrabajo] DROP CONSTRAINT [FK_ConsumoTrabajo_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuadrilla_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuadrilla] DROP CONSTRAINT [FK_Cuadrilla_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_DiferenciaInventario_Jornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiferenciaInventario] DROP CONSTRAINT [FK_DiferenciaInventario_Jornada];
GO
IF OBJECT_ID(N'[dbo].[FK_DiferenciaInventario_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiferenciaInventario] DROP CONSTRAINT [FK_DiferenciaInventario_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_Encuesta_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encuesta] DROP CONSTRAINT [FK_Encuesta_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_EncuestaAplicada_Suscriptor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EncuestaAplicada] DROP CONSTRAINT [FK_EncuestaAplicada_Suscriptor];
GO
IF OBJECT_ID(N'[dbo].[FK_Incidencias_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidencias] DROP CONSTRAINT [FK_Incidencias_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_Inventario_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventario] DROP CONSTRAINT [FK_Inventario_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_Inventario_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventario] DROP CONSTRAINT [FK_Inventario_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_InventarioActivosFijos_ActivoFijo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventarioActivosFijos] DROP CONSTRAINT [FK_InventarioActivosFijos_ActivoFijo];
GO
IF OBJECT_ID(N'[dbo].[FK_InventarioActivosFijos_Jornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InventarioActivosFijos] DROP CONSTRAINT [FK_InventarioActivosFijos_Jornada];
GO
IF OBJECT_ID(N'[dbo].[FK_Jornada_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jornada] DROP CONSTRAINT [FK_Jornada_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_Jornada_Terminal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jornada] DROP CONSTRAINT [FK_Jornada_Terminal];
GO
IF OBJECT_ID(N'[dbo].[FK_Jornada_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jornada] DROP CONSTRAINT [FK_Jornada_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Material_MaterialDigital]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialDigital] DROP CONSTRAINT [FK_Material_MaterialDigital];
GO
IF OBJECT_ID(N'[dbo].[FK_Material_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Material] DROP CONSTRAINT [FK_Material_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Material_ValorReferencia1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Material] DROP CONSTRAINT [FK_Material_ValorReferencia1];
GO
IF OBJECT_ID(N'[dbo].[FK_Material_ValorReferencia2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Material] DROP CONSTRAINT [FK_Material_ValorReferencia2];
GO
IF OBJECT_ID(N'[dbo].[FK_Mensaje_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mensaje] DROP CONSTRAINT [FK_Mensaje_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_NivelesSenial_NumeroSerieEquipoDigital]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NivelesSenial] DROP CONSTRAINT [FK_NivelesSenial_NumeroSerieEquipoDigital];
GO
IF OBJECT_ID(N'[dbo].[FK_NivelesSenial_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NivelesSenial] DROP CONSTRAINT [FK_NivelesSenial_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_NumeroSerieEquipoDigital_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NumeroSerieEquipoDigital] DROP CONSTRAINT [FK_NumeroSerieEquipoDigital_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_NumeroSerieEquipoDigital_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NumeroSerieEquipoDigital] DROP CONSTRAINT [FK_NumeroSerieEquipoDigital_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_NumeroSerieEquipoDigital_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NumeroSerieEquipoDigital] DROP CONSTRAINT [FK_NumeroSerieEquipoDigital_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_Suscriptor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_Suscriptor];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_Trabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_Trabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_ValorReferencia1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_ValorReferencia1];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_ValorReferencia2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_ValorReferencia2];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajo_Visita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajo] DROP CONSTRAINT [FK_OrdenTrabajo_Visita];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajoEquipoDigital_NumeroSerieEquipoDigital]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajoEquipoDigital] DROP CONSTRAINT [FK_OrdenTrabajoEquipoDigital_NumeroSerieEquipoDigital];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenTrabajoEquipoDigital_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenTrabajoEquipoDigital] DROP CONSTRAINT [FK_OrdenTrabajoEquipoDigital_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregunta_Encuesta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregunta] DROP CONSTRAINT [FK_Pregunta_Encuesta];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregunta_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregunta] DROP CONSTRAINT [FK_Pregunta_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_PreguntaOpcion_Pregunta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreguntaOpcion] DROP CONSTRAINT [FK_PreguntaOpcion_Pregunta];
GO
IF OBJECT_ID(N'[dbo].[FK_RecuperacionEquipo_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecuperacionEquipo] DROP CONSTRAINT [FK_RecuperacionEquipo_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_Region_Ciudad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ciudad] DROP CONSTRAINT [FK_Region_Ciudad];
GO
IF OBJECT_ID(N'[dbo].[FK_Requisicion_Jornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requisicion] DROP CONSTRAINT [FK_Requisicion_Jornada];
GO
IF OBJECT_ID(N'[dbo].[FK_Requisicion_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requisicion] DROP CONSTRAINT [FK_Requisicion_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_RespuestaEncuesta_EncuestaAplicada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RespuestaEncuesta] DROP CONSTRAINT [FK_RespuestaEncuesta_EncuestaAplicada];
GO
IF OBJECT_ID(N'[dbo].[FK_RespuestaEncuesta_Pregunta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RespuestaEncuesta] DROP CONSTRAINT [FK_RespuestaEncuesta_Pregunta];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiciosAdicionales_OrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiciosAdicionales] DROP CONSTRAINT [FK_ServiciosAdicionales_OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiciosAdicionales_Trabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiciosAdicionales] DROP CONSTRAINT [FK_ServiciosAdicionales_Trabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_Sucursal_Ciudad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sucursal] DROP CONSTRAINT [FK_Sucursal_Ciudad];
GO
IF OBJECT_ID(N'[dbo].[FK_Sucursal_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuadrilla] DROP CONSTRAINT [FK_Sucursal_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_Sucursal_Region]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sucursal] DROP CONSTRAINT [FK_Sucursal_Region];
GO
IF OBJECT_ID(N'[dbo].[FK_SuscriptorVisitado_Suscriptor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SuscriptorVisitado] DROP CONSTRAINT [FK_SuscriptorVisitado_Suscriptor];
GO
IF OBJECT_ID(N'[dbo].[FK_SuscriptorVisitado_Visita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SuscriptorVisitado] DROP CONSTRAINT [FK_SuscriptorVisitado_Visita];
GO
IF OBJECT_ID(N'[dbo].[FK_Terminal_Sucursal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Terminal] DROP CONSTRAINT [FK_Terminal_Sucursal];
GO
IF OBJECT_ID(N'[dbo].[FK_Terminal_ValorReferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Terminal] DROP CONSTRAINT [FK_Terminal_ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_TiempoMuerto_Jornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TiempoMuerto] DROP CONSTRAINT [FK_TiempoMuerto_Jornada];
GO
IF OBJECT_ID(N'[dbo].[FK_TrabajoMaterial_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrabajoMaterial] DROP CONSTRAINT [FK_TrabajoMaterial_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_TrabajoMaterial_Trabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrabajoMaterial] DROP CONSTRAINT [FK_TrabajoMaterial_Trabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Cuadrilla]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_Usuario_Sucursal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Usuario_Sucursal];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_Sucursal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculo] DROP CONSTRAINT [FK_Vehiculo_Sucursal];
GO
IF OBJECT_ID(N'[dbo].[FK_Visita_Jornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visita] DROP CONSTRAINT [FK_Visita_Jornada];
GO
IF OBJECT_ID(N'[dbo].[FK_Visita_Suscriptor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visita] DROP CONSTRAINT [FK_Visita_Suscriptor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Actividad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actividad];
GO
IF OBJECT_ID(N'[dbo].[ActividadPerfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActividadPerfil];
GO
IF OBJECT_ID(N'[dbo].[ActivoFijo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivoFijo];
GO
IF OBJECT_ID(N'[dbo].[Arqueo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arqueo];
GO
IF OBJECT_ID(N'[dbo].[AuditoriaRecepcion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuditoriaRecepcion];
GO
IF OBJECT_ID(N'[dbo].[BitacoraActividad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BitacoraActividad];
GO
IF OBJECT_ID(N'[dbo].[CarreteCable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarreteCable];
GO
IF OBJECT_ID(N'[dbo].[Ciudad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ciudad];
GO
IF OBJECT_ID(N'[dbo].[ClienteServicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteServicio];
GO
IF OBJECT_ID(N'[dbo].[Configuracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Configuracion];
GO
IF OBJECT_ID(N'[dbo].[ConsumoCableTrabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsumoCableTrabajo];
GO
IF OBJECT_ID(N'[dbo].[ConsumoTrabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsumoTrabajo];
GO
IF OBJECT_ID(N'[dbo].[Cuadrilla]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuadrilla];
GO
IF OBJECT_ID(N'[dbo].[DiferenciaInventario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiferenciaInventario];
GO
IF OBJECT_ID(N'[dbo].[Encuesta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Encuesta];
GO
IF OBJECT_ID(N'[dbo].[EncuestaAplicada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EncuestaAplicada];
GO
IF OBJECT_ID(N'[dbo].[Incidencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incidencias];
GO
IF OBJECT_ID(N'[dbo].[Inventario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventario];
GO
IF OBJECT_ID(N'[dbo].[InventarioActivosFijos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventarioActivosFijos];
GO
IF OBJECT_ID(N'[dbo].[Jornada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jornada];
GO
IF OBJECT_ID(N'[dbo].[Material]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Material];
GO
IF OBJECT_ID(N'[dbo].[MaterialDigital]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialDigital];
GO
IF OBJECT_ID(N'[dbo].[Mensaje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mensaje];
GO
IF OBJECT_ID(N'[dbo].[Modulo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modulo];
GO
IF OBJECT_ID(N'[dbo].[NivelesSenial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NivelesSenial];
GO
IF OBJECT_ID(N'[dbo].[NumeroSerieEquipoDigital]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NumeroSerieEquipoDigital];
GO
IF OBJECT_ID(N'[dbo].[OrdenTrabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[OrdenTrabajoEquipoDigital]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenTrabajoEquipoDigital];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[Pregunta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregunta];
GO
IF OBJECT_ID(N'[dbo].[PreguntaOpcion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreguntaOpcion];
GO
IF OBJECT_ID(N'[dbo].[RecuperacionEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecuperacionEquipo];
GO
IF OBJECT_ID(N'[dbo].[Region]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Region];
GO
IF OBJECT_ID(N'[dbo].[Requisicion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requisicion];
GO
IF OBJECT_ID(N'[dbo].[RespuestaEncuesta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RespuestaEncuesta];
GO
IF OBJECT_ID(N'[dbo].[ServiciosAdicionales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiciosAdicionales];
GO
IF OBJECT_ID(N'[dbo].[Sucursal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sucursal];
GO
IF OBJECT_ID(N'[dbo].[Suscriptor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suscriptor];
GO
IF OBJECT_ID(N'[dbo].[SuscriptorVisitado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SuscriptorVisitado];
GO
IF OBJECT_ID(N'[dbo].[Terminal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terminal];
GO
IF OBJECT_ID(N'[dbo].[TiempoMuerto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiempoMuerto];
GO
IF OBJECT_ID(N'[dbo].[Trabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trabajo];
GO
IF OBJECT_ID(N'[dbo].[TrabajoMaterial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrabajoMaterial];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[ValorConfiguracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValorConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[ValorReferencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValorReferencia];
GO
IF OBJECT_ID(N'[dbo].[Vehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculo];
GO
IF OBJECT_ID(N'[dbo].[Visita]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visita];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actividad'
CREATE TABLE [dbo].[Actividad] (
    [ClaveActividad] varchar(50)  NOT NULL,
    [ClaveModulo] varchar(20)  NULL,
    [TipoIndice] smallint  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'ActivoFijo'
CREATE TABLE [dbo].[ActivoFijo] (
    [ClaveActivo] varchar(20)  NOT NULL,
    [ClaveUsuario] varchar(20)  NOT NULL,
    [Descripcion] varchar(50)  NOT NULL,
    [NumeroSerie] varchar(150)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Arqueo'
CREATE TABLE [dbo].[Arqueo] (
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Cantidad] decimal(9,2)  NOT NULL
);
GO

-- Creating table 'AuditoriaRecepcion'
CREATE TABLE [dbo].[AuditoriaRecepcion] (
    [ClaveSucursal] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [HoraAgenda] datetime  NOT NULL,
    [HoraSincronizacion] datetime  NULL
);
GO

-- Creating table 'BitacoraActividad'
CREATE TABLE [dbo].[BitacoraActividad] (
    [ClaveUsuario] varchar(20)  NOT NULL,
    [OrdenBitacora] smallint  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [ClaveActividad] varchar(20)  NOT NULL
);
GO

-- Creating table 'CarreteCable'
CREATE TABLE [dbo].[CarreteCable] (
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [SerieCarreteInicio] varchar(20)  NOT NULL,
    [SerieCarreteFin] varchar(20)  NOT NULL
);
GO

-- Creating table 'Ciudad'
CREATE TABLE [dbo].[Ciudad] (
    [ClaveCiudad] varchar(20)  NOT NULL,
    [ClaveRegion] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'ClienteServicio'
CREATE TABLE [dbo].[ClienteServicio] (
    [ClaveSuscriptor] varchar(20)  NOT NULL,
    [IdVisita] uniqueidentifier  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Edad] tinyint  NOT NULL,
    [Referencia] smallint  NOT NULL,
    [DescRef] varchar(50)  NULL,
    [TipoIdentificacion] smallint  NULL,
    [FolioIdentificacion] varchar(50)  NULL,
    [IdImagenIdent] uniqueidentifier  NULL,
    [IdImagenFirma] uniqueidentifier  NULL
);
GO

-- Creating table 'Configuracion'
CREATE TABLE [dbo].[Configuracion] (
    [ClaveSucursal] varchar(20)  NOT NULL,
    [Parametro] varchar(20)  NOT NULL,
    [Valor] varchar(250)  NULL
);
GO

-- Creating table 'ConsumoCableTrabajo'
CREATE TABLE [dbo].[ConsumoCableTrabajo] (
    [FolioOrden] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [SerieCarreteInicio] varchar(20)  NOT NULL,
    [SerieCarreteFin] varchar(20)  NOT NULL,
    [SerieInicio] varchar(20)  NOT NULL,
    [SerieFin] varchar(20)  NOT NULL,
    [CantidadUtilizada] decimal(9,2)  NOT NULL,
    [Motivo] smallint  NULL,
    [IdImagenIni] uniqueidentifier  NULL,
    [IdImagenFin] uniqueidentifier  NULL
);
GO

-- Creating table 'ConsumoTrabajo'
CREATE TABLE [dbo].[ConsumoTrabajo] (
    [FolioOrden] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [CantidadUtilizada] decimal(9,2)  NOT NULL,
    [Motivo] smallint  NULL
);
GO

-- Creating table 'Cuadrilla'
CREATE TABLE [dbo].[Cuadrilla] (
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [ClaveSucursal] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [TipoCuadrilla] smallint  NOT NULL,
    [Estado] bit  NOT NULL,
    [ClaveUsuario] varchar(20)  NOT NULL
);
GO

-- Creating table 'DiferenciaInventario'
CREATE TABLE [dbo].[DiferenciaInventario] (
    [IdJornada] uniqueidentifier  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Cantidad] decimal(9,2)  NOT NULL
);
GO

-- Creating table 'Encuesta'
CREATE TABLE [dbo].[Encuesta] (
    [ClaveEncuesta] varchar(20)  NOT NULL,
    [Nombre] varchar(150)  NOT NULL,
    [Tipo] smallint  NOT NULL,
    [Estado] bit  NOT NULL,
    [Fecha] datetime  NOT NULL
);
GO

-- Creating table 'EncuestaAplicada'
CREATE TABLE [dbo].[EncuestaAplicada] (
    [IdEncuestaAp] uniqueidentifier  NOT NULL,
    [IdJornada] uniqueidentifier  NULL,
    [ClaveEncuesta] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NULL,
    [ClaveSuscriptor] varchar(20)  NULL,
    [FechaHoraInicio] datetime  NOT NULL,
    [FechaHoraFin] datetime  NULL
);
GO

-- Creating table 'Incidencias'
CREATE TABLE [dbo].[Incidencias] (
    [FolioOrden] varchar(20)  NOT NULL,
    [Incidencia] smallint  NOT NULL,
    [Observacion] varchar(250)  NULL
);
GO

-- Creating table 'Inventario'
CREATE TABLE [dbo].[Inventario] (
    [ClaveMaterial] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [Cantidad] decimal(9,2)  NOT NULL,
    [Fecha] datetime  NOT NULL
);
GO

-- Creating table 'InventarioActivosFijos'
CREATE TABLE [dbo].[InventarioActivosFijos] (
    [IdJornada] uniqueidentifier  NOT NULL,
    [ClaveActivo] varchar(20)  NOT NULL,
    [CodigoBarras] varchar(50)  NOT NULL
);
GO

-- Creating table 'Jornada'
CREATE TABLE [dbo].[Jornada] (
    [IdJornada] uniqueidentifier  NOT NULL,
    [ClaveUsuario] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [ClaveTerminal] varchar(20)  NOT NULL,
    [NumeroEconomicoVh] varchar(100)  NOT NULL,
    [FechaHoraInicial] datetime  NOT NULL,
    [FechaHoraFinal] datetime  NULL,
    [KmInicial] decimal(9,2)  NOT NULL,
    [KmFinal] decimal(9,2)  NULL,
    [PuntosAcumulados] decimal(9,4)  NOT NULL
);
GO

-- Creating table 'Material'
CREATE TABLE [dbo].[Material] (
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Descripcion] varchar(150)  NOT NULL,
    [Clasificacion] smallint  NOT NULL,
    [Tipo] smallint  NOT NULL,
    [Unidad] smallint  NOT NULL,
    [Requerido] bit  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'MaterialDigital'
CREATE TABLE [dbo].[MaterialDigital] (
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Antena] bit  NOT NULL,
    [Control] bit  NOT NULL,
    [Fuente] bit  NOT NULL
);
GO

-- Creating table 'Mensaje'
CREATE TABLE [dbo].[Mensaje] (
    [ClaveMensaje] varchar(20)  NOT NULL,
    [Descripcion] varchar(250)  NULL,
    [Ambiente] smallint  NULL
);
GO

-- Creating table 'Modulo'
CREATE TABLE [dbo].[Modulo] (
    [ClaveModulo] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'NivelesSenial'
CREATE TABLE [dbo].[NivelesSenial] (
    [FolioOrden] varchar(20)  NOT NULL,
    [NumeroSerieEquipoDigital] varchar(150)  NOT NULL,
    [SubidaCanalAlto] decimal(18,5)  NOT NULL,
    [SubidaCanalBajo] decimal(18,5)  NOT NULL,
    [Bajada] decimal(18,5)  NOT NULL,
    [Ruido] decimal(18,5)  NOT NULL,
    [IdImagen] uniqueidentifier  NULL
);
GO

-- Creating table 'NumeroSerieEquipoDigital'
CREATE TABLE [dbo].[NumeroSerieEquipoDigital] (
    [NumeroSerieEquipoDigital1] varchar(150)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Estado] smallint  NOT NULL
);
GO

-- Creating table 'OrdenTrabajo'
CREATE TABLE [dbo].[OrdenTrabajo] (
    [FolioOrden] varchar(20)  NOT NULL,
    [ClaveSuscriptor] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [IdVisita] uniqueidentifier  NULL,
    [ClaveTrabajo] varchar(20)  NOT NULL,
    [TipoTrabajo] smallint  NOT NULL,
    [Prioridad] smallint  NOT NULL,
    [Estado] smallint  NOT NULL,
    [Motivo] smallint  NULL,
    [Observacion] varchar(250)  NULL,
    [FechaHoraProgramada] datetime  NOT NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [ClavePerfil] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Pregunta'
CREATE TABLE [dbo].[Pregunta] (
    [IdPregunta] uniqueidentifier  NOT NULL,
    [ClaveEncuesta] varchar(20)  NOT NULL,
    [Orden] smallint  NOT NULL,
    [TipoPregunta] smallint  NOT NULL,
    [Descripcion] varchar(250)  NOT NULL
);
GO

-- Creating table 'PreguntaOpcion'
CREATE TABLE [dbo].[PreguntaOpcion] (
    [IdPreguntaOpcion] uniqueidentifier  NOT NULL,
    [IdPregunta] uniqueidentifier  NOT NULL,
    [Descripcion] varchar(150)  NOT NULL
);
GO

-- Creating table 'RecuperacionEquipo'
CREATE TABLE [dbo].[RecuperacionEquipo] (
    [NumeroSerie] varchar(150)  NOT NULL,
    [FolioOrden] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [BuenasCondiciones] bit  NOT NULL,
    [ControlRemoto] bit  NOT NULL,
    [Fuente] bit  NOT NULL,
    [Antena] bit  NOT NULL
);
GO

-- Creating table 'Region'
CREATE TABLE [dbo].[Region] (
    [ClaveRegion] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Requisicion'
CREATE TABLE [dbo].[Requisicion] (
    [FolioRequisicion] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NOT NULL,
    [IdJornada] uniqueidentifier  NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [CantRequerida] decimal(9,2)  NOT NULL,
    [CantEntregada] decimal(9,2)  NOT NULL,
    [Tipo] smallint  NOT NULL,
    [IdImagen] uniqueidentifier  NULL
);
GO

-- Creating table 'RespuestaEncuesta'
CREATE TABLE [dbo].[RespuestaEncuesta] (
    [IdRespuesta] uniqueidentifier  NOT NULL,
    [IdEncuestaAp] uniqueidentifier  NOT NULL,
    [IdPregunta] uniqueidentifier  NOT NULL,
    [Respuesta] varchar(250)  NULL,
    [IdImagen] uniqueidentifier  NULL
);
GO

-- Creating table 'Sucursal'
CREATE TABLE [dbo].[Sucursal] (
    [ClaveSucursal] varchar(20)  NOT NULL,
    [ClaveCiudad] varchar(20)  NOT NULL,
    [ClaveRegion] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [CodigoBarrasSalida] varchar(50)  NOT NULL,
    [CodigoBarrasLlegada] varchar(50)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Suscriptor'
CREATE TABLE [dbo].[Suscriptor] (
    [ClaveSuscriptor] varchar(20)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Calle] varchar(100)  NOT NULL,
    [NumeroExt] varchar(10)  NOT NULL,
    [NumeroInt] varchar(10)  NULL,
    [Colonia] varchar(50)  NOT NULL,
    [Sector] varchar(50)  NOT NULL,
    [CalleRef1] varchar(100)  NULL,
    [CalleRef2] varchar(100)  NULL,
    [Comentario] varchar(250)  NULL,
    [Lat] real  NULL,
    [Lng] real  NULL
);
GO

-- Creating table 'SuscriptorVisitado'
CREATE TABLE [dbo].[SuscriptorVisitado] (
    [ClaveSuscriptor] varchar(20)  NOT NULL,
    [IdVisita] uniqueidentifier  NOT NULL,
    [Observacion] varchar(250)  NULL,
    [IdImagen] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Terminal'
CREATE TABLE [dbo].[Terminal] (
    [ClaveTerminal] varchar(20)  NOT NULL,
    [ClaveSucursal] varchar(20)  NOT NULL,
    [NumeroSerie] varchar(150)  NOT NULL,
    [Modelo] varchar(50)  NOT NULL,
    [Fase] smallint  NOT NULL,
    [GPS] bit  NOT NULL,
    [Comentario] varchar(150)  NULL
);
GO

-- Creating table 'TiempoMuerto'
CREATE TABLE [dbo].[TiempoMuerto] (
    [IdTiempoMuerto] uniqueidentifier  NOT NULL,
    [IdJornada] uniqueidentifier  NULL,
    [Motivo] smallint  NOT NULL,
    [FechaHoraInicial] datetime  NOT NULL,
    [FechaHoraFinal] datetime  NULL
);
GO

-- Creating table 'Trabajo'
CREATE TABLE [dbo].[Trabajo] (
    [ClaveTrabajo] varchar(20)  NOT NULL,
    [Descripcion] varchar(255)  NOT NULL,
    [OpcionMenu] tinyint  NOT NULL,
    [CantidadPuntos] decimal(9,4)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'TrabajoMaterial'
CREATE TABLE [dbo].[TrabajoMaterial] (
    [ClaveTrabajo] varchar(20)  NOT NULL,
    [ClaveMaterial] varchar(20)  NOT NULL,
    [CantidadMinima] decimal(9,2)  NOT NULL,
    [CantidadMaxima] decimal(9,2)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [ClaveUsuario] varchar(20)  NOT NULL,
    [ClavePerfil] varchar(20)  NOT NULL,
    [ClaveCuadrilla] varchar(20)  NULL,
    [ClaveSucursal] varchar(20)  NOT NULL,
    [Tipo] smallint  NOT NULL,
    [Contrasenia] varchar(50)  NOT NULL,
    [Nombre] varchar(100)  NOT NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'ValorConfiguracion'
CREATE TABLE [dbo].[ValorConfiguracion] (
    [Parametro] varchar(20)  NOT NULL,
    [Clave] varchar(20)  NULL,
    [Descripcion] varchar(255)  NOT NULL
);
GO

-- Creating table 'ValorReferencia'
CREATE TABLE [dbo].[ValorReferencia] (
    [Valor] smallint  NOT NULL,
    [Clave] varchar(20)  NOT NULL,
    [Descripcion] varchar(150)  NOT NULL,
    [Grupo] smallint  NULL,
    [ValorCliente] varchar(20)  NULL,
    [Estado] bit  NOT NULL
);
GO

-- Creating table 'Vehiculo'
CREATE TABLE [dbo].[Vehiculo] (
    [NumeroEconomicoVh] varchar(100)  NOT NULL,
    [ClaveSucursal] varchar(20)  NOT NULL,
    [Placas] varchar(20)  NOT NULL,
    [Marca] varchar(50)  NOT NULL,
    [SubMarca] varchar(50)  NOT NULL,
    [Modelo] smallint  NOT NULL,
    [CodigoBarras] varchar(50)  NOT NULL,
    [KmInicial] decimal(18,0)  NULL,
    [KmFinal] decimal(18,0)  NULL
);
GO

-- Creating table 'Visita'
CREATE TABLE [dbo].[Visita] (
    [IdVisita] uniqueidentifier  NOT NULL,
    [IdJornada] uniqueidentifier  NOT NULL,
    [ClaveSuscriptor] varchar(20)  NOT NULL,
    [Lat] real  NULL,
    [Lng] real  NULL,
    [FechaHoraInicio] datetime  NOT NULL,
    [FechaHoraFin] datetime  NULL
);
GO

-- Creating table 'ActividadPerfil'
CREATE TABLE [dbo].[ActividadPerfil] (
    [Actividad_ClaveActividad] varchar(50)  NOT NULL,
    [Perfil_ClavePerfil] varchar(20)  NOT NULL
);
GO

-- Creating table 'OrdenTrabajoEquipoDigital'
CREATE TABLE [dbo].[OrdenTrabajoEquipoDigital] (
    [NumeroSerieEquipoDigital_NumeroSerieEquipoDigital1] varchar(150)  NOT NULL,
    [OrdenTrabajo_FolioOrden] varchar(20)  NOT NULL
);
GO

-- Creating table 'ServiciosAdicionales'
CREATE TABLE [dbo].[ServiciosAdicionales] (
    [OrdenTrabajo1_FolioOrden] varchar(20)  NOT NULL,
    [Trabajo1_ClaveTrabajo] varchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClaveActividad] in table 'Actividad'
ALTER TABLE [dbo].[Actividad]
ADD CONSTRAINT [PK_Actividad]
    PRIMARY KEY CLUSTERED ([ClaveActividad] ASC);
GO

-- Creating primary key on [ClaveActivo] in table 'ActivoFijo'
ALTER TABLE [dbo].[ActivoFijo]
ADD CONSTRAINT [PK_ActivoFijo]
    PRIMARY KEY CLUSTERED ([ClaveActivo] ASC);
GO

-- Creating primary key on [ClaveMaterial] in table 'Arqueo'
ALTER TABLE [dbo].[Arqueo]
ADD CONSTRAINT [PK_Arqueo]
    PRIMARY KEY CLUSTERED ([ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveSucursal], [ClaveCuadrilla], [HoraAgenda] in table 'AuditoriaRecepcion'
ALTER TABLE [dbo].[AuditoriaRecepcion]
ADD CONSTRAINT [PK_AuditoriaRecepcion]
    PRIMARY KEY CLUSTERED ([ClaveSucursal], [ClaveCuadrilla], [HoraAgenda] ASC);
GO

-- Creating primary key on [ClaveUsuario], [OrdenBitacora] in table 'BitacoraActividad'
ALTER TABLE [dbo].[BitacoraActividad]
ADD CONSTRAINT [PK_BitacoraActividad]
    PRIMARY KEY CLUSTERED ([ClaveUsuario], [OrdenBitacora] ASC);
GO

-- Creating primary key on [ClaveCuadrilla], [ClaveMaterial], [SerieCarreteInicio], [SerieCarreteFin] in table 'CarreteCable'
ALTER TABLE [dbo].[CarreteCable]
ADD CONSTRAINT [PK_CarreteCable]
    PRIMARY KEY CLUSTERED ([ClaveCuadrilla], [ClaveMaterial], [SerieCarreteInicio], [SerieCarreteFin] ASC);
GO

-- Creating primary key on [ClaveCiudad] in table 'Ciudad'
ALTER TABLE [dbo].[Ciudad]
ADD CONSTRAINT [PK_Ciudad]
    PRIMARY KEY CLUSTERED ([ClaveCiudad] ASC);
GO

-- Creating primary key on [ClaveSuscriptor], [IdVisita] in table 'ClienteServicio'
ALTER TABLE [dbo].[ClienteServicio]
ADD CONSTRAINT [PK_ClienteServicio]
    PRIMARY KEY CLUSTERED ([ClaveSuscriptor], [IdVisita] ASC);
GO

-- Creating primary key on [ClaveSucursal], [Parametro] in table 'Configuracion'
ALTER TABLE [dbo].[Configuracion]
ADD CONSTRAINT [PK_Configuracion]
    PRIMARY KEY CLUSTERED ([ClaveSucursal], [Parametro] ASC);
GO

-- Creating primary key on [FolioOrden], [ClaveMaterial], [SerieCarreteInicio], [SerieCarreteFin] in table 'ConsumoCableTrabajo'
ALTER TABLE [dbo].[ConsumoCableTrabajo]
ADD CONSTRAINT [PK_ConsumoCableTrabajo]
    PRIMARY KEY CLUSTERED ([FolioOrden], [ClaveMaterial], [SerieCarreteInicio], [SerieCarreteFin] ASC);
GO

-- Creating primary key on [FolioOrden], [ClaveMaterial] in table 'ConsumoTrabajo'
ALTER TABLE [dbo].[ConsumoTrabajo]
ADD CONSTRAINT [PK_ConsumoTrabajo]
    PRIMARY KEY CLUSTERED ([FolioOrden], [ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveCuadrilla] in table 'Cuadrilla'
ALTER TABLE [dbo].[Cuadrilla]
ADD CONSTRAINT [PK_Cuadrilla]
    PRIMARY KEY CLUSTERED ([ClaveCuadrilla] ASC);
GO

-- Creating primary key on [IdJornada], [ClaveMaterial] in table 'DiferenciaInventario'
ALTER TABLE [dbo].[DiferenciaInventario]
ADD CONSTRAINT [PK_DiferenciaInventario]
    PRIMARY KEY CLUSTERED ([IdJornada], [ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveEncuesta] in table 'Encuesta'
ALTER TABLE [dbo].[Encuesta]
ADD CONSTRAINT [PK_Encuesta]
    PRIMARY KEY CLUSTERED ([ClaveEncuesta] ASC);
GO

-- Creating primary key on [IdEncuestaAp] in table 'EncuestaAplicada'
ALTER TABLE [dbo].[EncuestaAplicada]
ADD CONSTRAINT [PK_EncuestaAplicada]
    PRIMARY KEY CLUSTERED ([IdEncuestaAp] ASC);
GO

-- Creating primary key on [FolioOrden], [Incidencia] in table 'Incidencias'
ALTER TABLE [dbo].[Incidencias]
ADD CONSTRAINT [PK_Incidencias]
    PRIMARY KEY CLUSTERED ([FolioOrden], [Incidencia] ASC);
GO

-- Creating primary key on [ClaveMaterial], [ClaveCuadrilla] in table 'Inventario'
ALTER TABLE [dbo].[Inventario]
ADD CONSTRAINT [PK_Inventario]
    PRIMARY KEY CLUSTERED ([ClaveMaterial], [ClaveCuadrilla] ASC);
GO

-- Creating primary key on [IdJornada], [ClaveActivo] in table 'InventarioActivosFijos'
ALTER TABLE [dbo].[InventarioActivosFijos]
ADD CONSTRAINT [PK_InventarioActivosFijos]
    PRIMARY KEY CLUSTERED ([IdJornada], [ClaveActivo] ASC);
GO

-- Creating primary key on [IdJornada] in table 'Jornada'
ALTER TABLE [dbo].[Jornada]
ADD CONSTRAINT [PK_Jornada]
    PRIMARY KEY CLUSTERED ([IdJornada] ASC);
GO

-- Creating primary key on [ClaveMaterial] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [PK_Material]
    PRIMARY KEY CLUSTERED ([ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveMaterial] in table 'MaterialDigital'
ALTER TABLE [dbo].[MaterialDigital]
ADD CONSTRAINT [PK_MaterialDigital]
    PRIMARY KEY CLUSTERED ([ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveMensaje] in table 'Mensaje'
ALTER TABLE [dbo].[Mensaje]
ADD CONSTRAINT [PK_Mensaje]
    PRIMARY KEY CLUSTERED ([ClaveMensaje] ASC);
GO

-- Creating primary key on [ClaveModulo] in table 'Modulo'
ALTER TABLE [dbo].[Modulo]
ADD CONSTRAINT [PK_Modulo]
    PRIMARY KEY CLUSTERED ([ClaveModulo] ASC);
GO

-- Creating primary key on [FolioOrden], [NumeroSerieEquipoDigital] in table 'NivelesSenial'
ALTER TABLE [dbo].[NivelesSenial]
ADD CONSTRAINT [PK_NivelesSenial]
    PRIMARY KEY CLUSTERED ([FolioOrden], [NumeroSerieEquipoDigital] ASC);
GO

-- Creating primary key on [NumeroSerieEquipoDigital1] in table 'NumeroSerieEquipoDigital'
ALTER TABLE [dbo].[NumeroSerieEquipoDigital]
ADD CONSTRAINT [PK_NumeroSerieEquipoDigital]
    PRIMARY KEY CLUSTERED ([NumeroSerieEquipoDigital1] ASC);
GO

-- Creating primary key on [FolioOrden] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [PK_OrdenTrabajo]
    PRIMARY KEY CLUSTERED ([FolioOrden] ASC);
GO

-- Creating primary key on [ClavePerfil] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([ClavePerfil] ASC);
GO

-- Creating primary key on [IdPregunta] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [PK_Pregunta]
    PRIMARY KEY CLUSTERED ([IdPregunta] ASC);
GO

-- Creating primary key on [IdPreguntaOpcion] in table 'PreguntaOpcion'
ALTER TABLE [dbo].[PreguntaOpcion]
ADD CONSTRAINT [PK_PreguntaOpcion]
    PRIMARY KEY CLUSTERED ([IdPreguntaOpcion] ASC);
GO

-- Creating primary key on [NumeroSerie] in table 'RecuperacionEquipo'
ALTER TABLE [dbo].[RecuperacionEquipo]
ADD CONSTRAINT [PK_RecuperacionEquipo]
    PRIMARY KEY CLUSTERED ([NumeroSerie] ASC);
GO

-- Creating primary key on [ClaveRegion] in table 'Region'
ALTER TABLE [dbo].[Region]
ADD CONSTRAINT [PK_Region]
    PRIMARY KEY CLUSTERED ([ClaveRegion] ASC);
GO

-- Creating primary key on [FolioRequisicion], [ClaveCuadrilla], [ClaveMaterial] in table 'Requisicion'
ALTER TABLE [dbo].[Requisicion]
ADD CONSTRAINT [PK_Requisicion]
    PRIMARY KEY CLUSTERED ([FolioRequisicion], [ClaveCuadrilla], [ClaveMaterial] ASC);
GO

-- Creating primary key on [IdRespuesta] in table 'RespuestaEncuesta'
ALTER TABLE [dbo].[RespuestaEncuesta]
ADD CONSTRAINT [PK_RespuestaEncuesta]
    PRIMARY KEY CLUSTERED ([IdRespuesta] ASC);
GO

-- Creating primary key on [ClaveSucursal] in table 'Sucursal'
ALTER TABLE [dbo].[Sucursal]
ADD CONSTRAINT [PK_Sucursal]
    PRIMARY KEY CLUSTERED ([ClaveSucursal] ASC);
GO

-- Creating primary key on [ClaveSuscriptor] in table 'Suscriptor'
ALTER TABLE [dbo].[Suscriptor]
ADD CONSTRAINT [PK_Suscriptor]
    PRIMARY KEY CLUSTERED ([ClaveSuscriptor] ASC);
GO

-- Creating primary key on [ClaveSuscriptor], [IdVisita] in table 'SuscriptorVisitado'
ALTER TABLE [dbo].[SuscriptorVisitado]
ADD CONSTRAINT [PK_SuscriptorVisitado]
    PRIMARY KEY CLUSTERED ([ClaveSuscriptor], [IdVisita] ASC);
GO

-- Creating primary key on [ClaveTerminal] in table 'Terminal'
ALTER TABLE [dbo].[Terminal]
ADD CONSTRAINT [PK_Terminal]
    PRIMARY KEY CLUSTERED ([ClaveTerminal] ASC);
GO

-- Creating primary key on [IdTiempoMuerto] in table 'TiempoMuerto'
ALTER TABLE [dbo].[TiempoMuerto]
ADD CONSTRAINT [PK_TiempoMuerto]
    PRIMARY KEY CLUSTERED ([IdTiempoMuerto] ASC);
GO

-- Creating primary key on [ClaveTrabajo] in table 'Trabajo'
ALTER TABLE [dbo].[Trabajo]
ADD CONSTRAINT [PK_Trabajo]
    PRIMARY KEY CLUSTERED ([ClaveTrabajo] ASC);
GO

-- Creating primary key on [ClaveTrabajo], [ClaveMaterial] in table 'TrabajoMaterial'
ALTER TABLE [dbo].[TrabajoMaterial]
ADD CONSTRAINT [PK_TrabajoMaterial]
    PRIMARY KEY CLUSTERED ([ClaveTrabajo], [ClaveMaterial] ASC);
GO

-- Creating primary key on [ClaveUsuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([ClaveUsuario] ASC);
GO

-- Creating primary key on [Parametro] in table 'ValorConfiguracion'
ALTER TABLE [dbo].[ValorConfiguracion]
ADD CONSTRAINT [PK_ValorConfiguracion]
    PRIMARY KEY CLUSTERED ([Parametro] ASC);
GO

-- Creating primary key on [Valor] in table 'ValorReferencia'
ALTER TABLE [dbo].[ValorReferencia]
ADD CONSTRAINT [PK_ValorReferencia]
    PRIMARY KEY CLUSTERED ([Valor] ASC);
GO

-- Creating primary key on [NumeroEconomicoVh] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [PK_Vehiculo]
    PRIMARY KEY CLUSTERED ([NumeroEconomicoVh] ASC);
GO

-- Creating primary key on [IdVisita] in table 'Visita'
ALTER TABLE [dbo].[Visita]
ADD CONSTRAINT [PK_Visita]
    PRIMARY KEY CLUSTERED ([IdVisita] ASC);
GO

-- Creating primary key on [Actividad_ClaveActividad], [Perfil_ClavePerfil] in table 'ActividadPerfil'
ALTER TABLE [dbo].[ActividadPerfil]
ADD CONSTRAINT [PK_ActividadPerfil]
    PRIMARY KEY NONCLUSTERED ([Actividad_ClaveActividad], [Perfil_ClavePerfil] ASC);
GO

-- Creating primary key on [NumeroSerieEquipoDigital_NumeroSerieEquipoDigital1], [OrdenTrabajo_FolioOrden] in table 'OrdenTrabajoEquipoDigital'
ALTER TABLE [dbo].[OrdenTrabajoEquipoDigital]
ADD CONSTRAINT [PK_OrdenTrabajoEquipoDigital]
    PRIMARY KEY NONCLUSTERED ([NumeroSerieEquipoDigital_NumeroSerieEquipoDigital1], [OrdenTrabajo_FolioOrden] ASC);
GO

-- Creating primary key on [OrdenTrabajo1_FolioOrden], [Trabajo1_ClaveTrabajo] in table 'ServiciosAdicionales'
ALTER TABLE [dbo].[ServiciosAdicionales]
ADD CONSTRAINT [PK_ServiciosAdicionales]
    PRIMARY KEY NONCLUSTERED ([OrdenTrabajo1_FolioOrden], [Trabajo1_ClaveTrabajo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClaveModulo] in table 'Actividad'
ALTER TABLE [dbo].[Actividad]
ADD CONSTRAINT [FK_Actividad_Modulo]
    FOREIGN KEY ([ClaveModulo])
    REFERENCES [dbo].[Modulo]
        ([ClaveModulo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividad_Modulo'
CREATE INDEX [IX_FK_Actividad_Modulo]
ON [dbo].[Actividad]
    ([ClaveModulo]);
GO

-- Creating foreign key on [TipoIndice] in table 'Actividad'
ALTER TABLE [dbo].[Actividad]
ADD CONSTRAINT [FK_Actividad_ValorReferencia]
    FOREIGN KEY ([TipoIndice])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividad_ValorReferencia'
CREATE INDEX [IX_FK_Actividad_ValorReferencia]
ON [dbo].[Actividad]
    ([TipoIndice]);
GO

-- Creating foreign key on [ClaveUsuario] in table 'ActivoFijo'
ALTER TABLE [dbo].[ActivoFijo]
ADD CONSTRAINT [FK_ActivoFijo_Usuario]
    FOREIGN KEY ([ClaveUsuario])
    REFERENCES [dbo].[Usuario]
        ([ClaveUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivoFijo_Usuario'
CREATE INDEX [IX_FK_ActivoFijo_Usuario]
ON [dbo].[ActivoFijo]
    ([ClaveUsuario]);
GO

-- Creating foreign key on [ClaveActivo] in table 'InventarioActivosFijos'
ALTER TABLE [dbo].[InventarioActivosFijos]
ADD CONSTRAINT [FK_InventarioActivosFijos_ActivoFijo]
    FOREIGN KEY ([ClaveActivo])
    REFERENCES [dbo].[ActivoFijo]
        ([ClaveActivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InventarioActivosFijos_ActivoFijo'
CREATE INDEX [IX_FK_InventarioActivosFijos_ActivoFijo]
ON [dbo].[InventarioActivosFijos]
    ([ClaveActivo]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'Arqueo'
ALTER TABLE [dbo].[Arqueo]
ADD CONSTRAINT [FK_Arqueo_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'AuditoriaRecepcion'
ALTER TABLE [dbo].[AuditoriaRecepcion]
ADD CONSTRAINT [FK_AuditoriaRecepcion_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AuditoriaRecepcion_Cuadrilla'
CREATE INDEX [IX_FK_AuditoriaRecepcion_Cuadrilla]
ON [dbo].[AuditoriaRecepcion]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'AuditoriaRecepcion'
ALTER TABLE [dbo].[AuditoriaRecepcion]
ADD CONSTRAINT [FK_AuditoriaRecepcion_Sucursal]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'CarreteCable'
ALTER TABLE [dbo].[CarreteCable]
ADD CONSTRAINT [FK_CarreteCable_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveMaterial] in table 'CarreteCable'
ALTER TABLE [dbo].[CarreteCable]
ADD CONSTRAINT [FK_CarreteCable_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarreteCable_Material'
CREATE INDEX [IX_FK_CarreteCable_Material]
ON [dbo].[CarreteCable]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [ClaveRegion] in table 'Ciudad'
ALTER TABLE [dbo].[Ciudad]
ADD CONSTRAINT [FK_Region_Ciudad]
    FOREIGN KEY ([ClaveRegion])
    REFERENCES [dbo].[Region]
        ([ClaveRegion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Region_Ciudad'
CREATE INDEX [IX_FK_Region_Ciudad]
ON [dbo].[Ciudad]
    ([ClaveRegion]);
GO

-- Creating foreign key on [ClaveCiudad] in table 'Sucursal'
ALTER TABLE [dbo].[Sucursal]
ADD CONSTRAINT [FK_Sucursal_Ciudad]
    FOREIGN KEY ([ClaveCiudad])
    REFERENCES [dbo].[Ciudad]
        ([ClaveCiudad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sucursal_Ciudad'
CREATE INDEX [IX_FK_Sucursal_Ciudad]
ON [dbo].[Sucursal]
    ([ClaveCiudad]);
GO

-- Creating foreign key on [ClaveSuscriptor] in table 'ClienteServicio'
ALTER TABLE [dbo].[ClienteServicio]
ADD CONSTRAINT [FK_ClienteServicio_Suscriptor]
    FOREIGN KEY ([ClaveSuscriptor])
    REFERENCES [dbo].[Suscriptor]
        ([ClaveSuscriptor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Referencia] in table 'ClienteServicio'
ALTER TABLE [dbo].[ClienteServicio]
ADD CONSTRAINT [FK_ClienteServicio_ValorReferencia]
    FOREIGN KEY ([Referencia])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteServicio_ValorReferencia'
CREATE INDEX [IX_FK_ClienteServicio_ValorReferencia]
ON [dbo].[ClienteServicio]
    ([Referencia]);
GO

-- Creating foreign key on [TipoIdentificacion] in table 'ClienteServicio'
ALTER TABLE [dbo].[ClienteServicio]
ADD CONSTRAINT [FK_ClienteServicio_ValorReferencia1]
    FOREIGN KEY ([TipoIdentificacion])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteServicio_ValorReferencia1'
CREATE INDEX [IX_FK_ClienteServicio_ValorReferencia1]
ON [dbo].[ClienteServicio]
    ([TipoIdentificacion]);
GO

-- Creating foreign key on [IdVisita] in table 'ClienteServicio'
ALTER TABLE [dbo].[ClienteServicio]
ADD CONSTRAINT [FK_ClienteServicio_Visita]
    FOREIGN KEY ([IdVisita])
    REFERENCES [dbo].[Visita]
        ([IdVisita])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteServicio_Visita'
CREATE INDEX [IX_FK_ClienteServicio_Visita]
ON [dbo].[ClienteServicio]
    ([IdVisita]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'Configuracion'
ALTER TABLE [dbo].[Configuracion]
ADD CONSTRAINT [FK_Configuracion_Sucursal]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Parametro] in table 'Configuracion'
ALTER TABLE [dbo].[Configuracion]
ADD CONSTRAINT [FK_Configuracion_ValorConfiguracion]
    FOREIGN KEY ([Parametro])
    REFERENCES [dbo].[ValorConfiguracion]
        ([Parametro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Configuracion_ValorConfiguracion'
CREATE INDEX [IX_FK_Configuracion_ValorConfiguracion]
ON [dbo].[Configuracion]
    ([Parametro]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'ConsumoCableTrabajo'
ALTER TABLE [dbo].[ConsumoCableTrabajo]
ADD CONSTRAINT [FK_ConsumoCableTrabajo_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsumoCableTrabajo_Material'
CREATE INDEX [IX_FK_ConsumoCableTrabajo_Material]
ON [dbo].[ConsumoCableTrabajo]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [FolioOrden] in table 'ConsumoCableTrabajo'
ALTER TABLE [dbo].[ConsumoCableTrabajo]
ADD CONSTRAINT [FK_ConsumoCableTrabajo_OrdenTrabajo]
    FOREIGN KEY ([FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Motivo] in table 'ConsumoCableTrabajo'
ALTER TABLE [dbo].[ConsumoCableTrabajo]
ADD CONSTRAINT [FK_ConsumoCableTrabajo_ValorReferencia]
    FOREIGN KEY ([Motivo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsumoCableTrabajo_ValorReferencia'
CREATE INDEX [IX_FK_ConsumoCableTrabajo_ValorReferencia]
ON [dbo].[ConsumoCableTrabajo]
    ([Motivo]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'ConsumoTrabajo'
ALTER TABLE [dbo].[ConsumoTrabajo]
ADD CONSTRAINT [FK_ConsumoTrabajo_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsumoTrabajo_Material'
CREATE INDEX [IX_FK_ConsumoTrabajo_Material]
ON [dbo].[ConsumoTrabajo]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [FolioOrden] in table 'ConsumoTrabajo'
ALTER TABLE [dbo].[ConsumoTrabajo]
ADD CONSTRAINT [FK_ConsumoTrabajo_OrdenTrabajo]
    FOREIGN KEY ([FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Motivo] in table 'ConsumoTrabajo'
ALTER TABLE [dbo].[ConsumoTrabajo]
ADD CONSTRAINT [FK_ConsumoTrabajo_ValorReferencia]
    FOREIGN KEY ([Motivo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsumoTrabajo_ValorReferencia'
CREATE INDEX [IX_FK_ConsumoTrabajo_ValorReferencia]
ON [dbo].[ConsumoTrabajo]
    ([Motivo]);
GO

-- Creating foreign key on [TipoCuadrilla] in table 'Cuadrilla'
ALTER TABLE [dbo].[Cuadrilla]
ADD CONSTRAINT [FK_Cuadrilla_ValorReferencia]
    FOREIGN KEY ([TipoCuadrilla])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuadrilla_ValorReferencia'
CREATE INDEX [IX_FK_Cuadrilla_ValorReferencia]
ON [dbo].[Cuadrilla]
    ([TipoCuadrilla]);
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'Inventario'
ALTER TABLE [dbo].[Inventario]
ADD CONSTRAINT [FK_Inventario_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Inventario_Cuadrilla'
CREATE INDEX [IX_FK_Inventario_Cuadrilla]
ON [dbo].[Inventario]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'Jornada'
ALTER TABLE [dbo].[Jornada]
ADD CONSTRAINT [FK_Jornada_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Jornada_Cuadrilla'
CREATE INDEX [IX_FK_Jornada_Cuadrilla]
ON [dbo].[Jornada]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'NumeroSerieEquipoDigital'
ALTER TABLE [dbo].[NumeroSerieEquipoDigital]
ADD CONSTRAINT [FK_NumeroSerieEquipoDigital_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NumeroSerieEquipoDigital_Cuadrilla'
CREATE INDEX [IX_FK_NumeroSerieEquipoDigital_Cuadrilla]
ON [dbo].[NumeroSerieEquipoDigital]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_Cuadrilla'
CREATE INDEX [IX_FK_OrdenTrabajo_Cuadrilla]
ON [dbo].[OrdenTrabajo]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'Cuadrilla'
ALTER TABLE [dbo].[Cuadrilla]
ADD CONSTRAINT [FK_Sucursal_Cuadrilla]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sucursal_Cuadrilla'
CREATE INDEX [IX_FK_Sucursal_Cuadrilla]
ON [dbo].[Cuadrilla]
    ([ClaveSucursal]);
GO

-- Creating foreign key on [ClaveCuadrilla] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Usuario_Cuadrilla]
    FOREIGN KEY ([ClaveCuadrilla])
    REFERENCES [dbo].[Cuadrilla]
        ([ClaveCuadrilla])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Cuadrilla'
CREATE INDEX [IX_FK_Usuario_Cuadrilla]
ON [dbo].[Usuario]
    ([ClaveCuadrilla]);
GO

-- Creating foreign key on [IdJornada] in table 'DiferenciaInventario'
ALTER TABLE [dbo].[DiferenciaInventario]
ADD CONSTRAINT [FK_DiferenciaInventario_Jornada]
    FOREIGN KEY ([IdJornada])
    REFERENCES [dbo].[Jornada]
        ([IdJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveMaterial] in table 'DiferenciaInventario'
ALTER TABLE [dbo].[DiferenciaInventario]
ADD CONSTRAINT [FK_DiferenciaInventario_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DiferenciaInventario_Material'
CREATE INDEX [IX_FK_DiferenciaInventario_Material]
ON [dbo].[DiferenciaInventario]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [Tipo] in table 'Encuesta'
ALTER TABLE [dbo].[Encuesta]
ADD CONSTRAINT [FK_Encuesta_ValorReferencia]
    FOREIGN KEY ([Tipo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Encuesta_ValorReferencia'
CREATE INDEX [IX_FK_Encuesta_ValorReferencia]
ON [dbo].[Encuesta]
    ([Tipo]);
GO

-- Creating foreign key on [ClaveEncuesta] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [FK_Pregunta_Encuesta]
    FOREIGN KEY ([ClaveEncuesta])
    REFERENCES [dbo].[Encuesta]
        ([ClaveEncuesta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregunta_Encuesta'
CREATE INDEX [IX_FK_Pregunta_Encuesta]
ON [dbo].[Pregunta]
    ([ClaveEncuesta]);
GO

-- Creating foreign key on [ClaveSuscriptor] in table 'EncuestaAplicada'
ALTER TABLE [dbo].[EncuestaAplicada]
ADD CONSTRAINT [FK_EncuestaAplicada_Suscriptor]
    FOREIGN KEY ([ClaveSuscriptor])
    REFERENCES [dbo].[Suscriptor]
        ([ClaveSuscriptor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EncuestaAplicada_Suscriptor'
CREATE INDEX [IX_FK_EncuestaAplicada_Suscriptor]
ON [dbo].[EncuestaAplicada]
    ([ClaveSuscriptor]);
GO

-- Creating foreign key on [IdEncuestaAp] in table 'RespuestaEncuesta'
ALTER TABLE [dbo].[RespuestaEncuesta]
ADD CONSTRAINT [FK_RespuestaEncuesta_EncuestaAplicada]
    FOREIGN KEY ([IdEncuestaAp])
    REFERENCES [dbo].[EncuestaAplicada]
        ([IdEncuestaAp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RespuestaEncuesta_EncuestaAplicada'
CREATE INDEX [IX_FK_RespuestaEncuesta_EncuestaAplicada]
ON [dbo].[RespuestaEncuesta]
    ([IdEncuestaAp]);
GO

-- Creating foreign key on [FolioOrden] in table 'Incidencias'
ALTER TABLE [dbo].[Incidencias]
ADD CONSTRAINT [FK_Incidencias_OrdenTrabajo]
    FOREIGN KEY ([FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveMaterial] in table 'Inventario'
ALTER TABLE [dbo].[Inventario]
ADD CONSTRAINT [FK_Inventario_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdJornada] in table 'InventarioActivosFijos'
ALTER TABLE [dbo].[InventarioActivosFijos]
ADD CONSTRAINT [FK_InventarioActivosFijos_Jornada]
    FOREIGN KEY ([IdJornada])
    REFERENCES [dbo].[Jornada]
        ([IdJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveTerminal] in table 'Jornada'
ALTER TABLE [dbo].[Jornada]
ADD CONSTRAINT [FK_Jornada_Terminal]
    FOREIGN KEY ([ClaveTerminal])
    REFERENCES [dbo].[Terminal]
        ([ClaveTerminal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Jornada_Terminal'
CREATE INDEX [IX_FK_Jornada_Terminal]
ON [dbo].[Jornada]
    ([ClaveTerminal]);
GO

-- Creating foreign key on [ClaveUsuario] in table 'Jornada'
ALTER TABLE [dbo].[Jornada]
ADD CONSTRAINT [FK_Jornada_Usuario]
    FOREIGN KEY ([ClaveUsuario])
    REFERENCES [dbo].[Usuario]
        ([ClaveUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Jornada_Usuario'
CREATE INDEX [IX_FK_Jornada_Usuario]
ON [dbo].[Jornada]
    ([ClaveUsuario]);
GO

-- Creating foreign key on [IdJornada] in table 'Requisicion'
ALTER TABLE [dbo].[Requisicion]
ADD CONSTRAINT [FK_Requisicion_Jornada]
    FOREIGN KEY ([IdJornada])
    REFERENCES [dbo].[Jornada]
        ([IdJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Requisicion_Jornada'
CREATE INDEX [IX_FK_Requisicion_Jornada]
ON [dbo].[Requisicion]
    ([IdJornada]);
GO

-- Creating foreign key on [IdJornada] in table 'TiempoMuerto'
ALTER TABLE [dbo].[TiempoMuerto]
ADD CONSTRAINT [FK_TiempoMuerto_Jornada]
    FOREIGN KEY ([IdJornada])
    REFERENCES [dbo].[Jornada]
        ([IdJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TiempoMuerto_Jornada'
CREATE INDEX [IX_FK_TiempoMuerto_Jornada]
ON [dbo].[TiempoMuerto]
    ([IdJornada]);
GO

-- Creating foreign key on [IdJornada] in table 'Visita'
ALTER TABLE [dbo].[Visita]
ADD CONSTRAINT [FK_Visita_Jornada]
    FOREIGN KEY ([IdJornada])
    REFERENCES [dbo].[Jornada]
        ([IdJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Visita_Jornada'
CREATE INDEX [IX_FK_Visita_Jornada]
ON [dbo].[Visita]
    ([IdJornada]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'MaterialDigital'
ALTER TABLE [dbo].[MaterialDigital]
ADD CONSTRAINT [FK_Material_MaterialDigital]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Clasificacion] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [FK_Material_ValorReferencia]
    FOREIGN KEY ([Clasificacion])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_ValorReferencia'
CREATE INDEX [IX_FK_Material_ValorReferencia]
ON [dbo].[Material]
    ([Clasificacion]);
GO

-- Creating foreign key on [Tipo] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [FK_Material_ValorReferencia1]
    FOREIGN KEY ([Tipo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_ValorReferencia1'
CREATE INDEX [IX_FK_Material_ValorReferencia1]
ON [dbo].[Material]
    ([Tipo]);
GO

-- Creating foreign key on [Unidad] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [FK_Material_ValorReferencia2]
    FOREIGN KEY ([Unidad])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_ValorReferencia2'
CREATE INDEX [IX_FK_Material_ValorReferencia2]
ON [dbo].[Material]
    ([Unidad]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'NumeroSerieEquipoDigital'
ALTER TABLE [dbo].[NumeroSerieEquipoDigital]
ADD CONSTRAINT [FK_NumeroSerieEquipoDigital_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NumeroSerieEquipoDigital_Material'
CREATE INDEX [IX_FK_NumeroSerieEquipoDigital_Material]
ON [dbo].[NumeroSerieEquipoDigital]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'RecuperacionEquipo'
ALTER TABLE [dbo].[RecuperacionEquipo]
ADD CONSTRAINT [FK_RecuperacionEquipo_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecuperacionEquipo_Material'
CREATE INDEX [IX_FK_RecuperacionEquipo_Material]
ON [dbo].[RecuperacionEquipo]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'Requisicion'
ALTER TABLE [dbo].[Requisicion]
ADD CONSTRAINT [FK_Requisicion_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Requisicion_Material'
CREATE INDEX [IX_FK_Requisicion_Material]
ON [dbo].[Requisicion]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [ClaveMaterial] in table 'TrabajoMaterial'
ALTER TABLE [dbo].[TrabajoMaterial]
ADD CONSTRAINT [FK_TrabajoMaterial_Material]
    FOREIGN KEY ([ClaveMaterial])
    REFERENCES [dbo].[Material]
        ([ClaveMaterial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TrabajoMaterial_Material'
CREATE INDEX [IX_FK_TrabajoMaterial_Material]
ON [dbo].[TrabajoMaterial]
    ([ClaveMaterial]);
GO

-- Creating foreign key on [Ambiente] in table 'Mensaje'
ALTER TABLE [dbo].[Mensaje]
ADD CONSTRAINT [FK_Mensaje_ValorReferencia]
    FOREIGN KEY ([Ambiente])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Mensaje_ValorReferencia'
CREATE INDEX [IX_FK_Mensaje_ValorReferencia]
ON [dbo].[Mensaje]
    ([Ambiente]);
GO

-- Creating foreign key on [NumeroSerieEquipoDigital] in table 'NivelesSenial'
ALTER TABLE [dbo].[NivelesSenial]
ADD CONSTRAINT [FK_NivelesSenial_NumeroSerieEquipoDigital]
    FOREIGN KEY ([NumeroSerieEquipoDigital])
    REFERENCES [dbo].[NumeroSerieEquipoDigital]
        ([NumeroSerieEquipoDigital1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NivelesSenial_NumeroSerieEquipoDigital'
CREATE INDEX [IX_FK_NivelesSenial_NumeroSerieEquipoDigital]
ON [dbo].[NivelesSenial]
    ([NumeroSerieEquipoDigital]);
GO

-- Creating foreign key on [FolioOrden] in table 'NivelesSenial'
ALTER TABLE [dbo].[NivelesSenial]
ADD CONSTRAINT [FK_NivelesSenial_OrdenTrabajo]
    FOREIGN KEY ([FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Estado] in table 'NumeroSerieEquipoDigital'
ALTER TABLE [dbo].[NumeroSerieEquipoDigital]
ADD CONSTRAINT [FK_NumeroSerieEquipoDigital_ValorReferencia]
    FOREIGN KEY ([Estado])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NumeroSerieEquipoDigital_ValorReferencia'
CREATE INDEX [IX_FK_NumeroSerieEquipoDigital_ValorReferencia]
ON [dbo].[NumeroSerieEquipoDigital]
    ([Estado]);
GO

-- Creating foreign key on [ClaveSuscriptor] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_Suscriptor]
    FOREIGN KEY ([ClaveSuscriptor])
    REFERENCES [dbo].[Suscriptor]
        ([ClaveSuscriptor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_Suscriptor'
CREATE INDEX [IX_FK_OrdenTrabajo_Suscriptor]
ON [dbo].[OrdenTrabajo]
    ([ClaveSuscriptor]);
GO

-- Creating foreign key on [ClaveTrabajo] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_Trabajo]
    FOREIGN KEY ([ClaveTrabajo])
    REFERENCES [dbo].[Trabajo]
        ([ClaveTrabajo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_Trabajo'
CREATE INDEX [IX_FK_OrdenTrabajo_Trabajo]
ON [dbo].[OrdenTrabajo]
    ([ClaveTrabajo]);
GO

-- Creating foreign key on [TipoTrabajo] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_ValorReferencia]
    FOREIGN KEY ([TipoTrabajo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_ValorReferencia'
CREATE INDEX [IX_FK_OrdenTrabajo_ValorReferencia]
ON [dbo].[OrdenTrabajo]
    ([TipoTrabajo]);
GO

-- Creating foreign key on [Estado] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_ValorReferencia1]
    FOREIGN KEY ([Estado])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_ValorReferencia1'
CREATE INDEX [IX_FK_OrdenTrabajo_ValorReferencia1]
ON [dbo].[OrdenTrabajo]
    ([Estado]);
GO

-- Creating foreign key on [Motivo] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_ValorReferencia2]
    FOREIGN KEY ([Motivo])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_ValorReferencia2'
CREATE INDEX [IX_FK_OrdenTrabajo_ValorReferencia2]
ON [dbo].[OrdenTrabajo]
    ([Motivo]);
GO

-- Creating foreign key on [IdVisita] in table 'OrdenTrabajo'
ALTER TABLE [dbo].[OrdenTrabajo]
ADD CONSTRAINT [FK_OrdenTrabajo_Visita]
    FOREIGN KEY ([IdVisita])
    REFERENCES [dbo].[Visita]
        ([IdVisita])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajo_Visita'
CREATE INDEX [IX_FK_OrdenTrabajo_Visita]
ON [dbo].[OrdenTrabajo]
    ([IdVisita]);
GO

-- Creating foreign key on [ClavePerfil] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Usuario_Perfil]
    FOREIGN KEY ([ClavePerfil])
    REFERENCES [dbo].[Perfil]
        ([ClavePerfil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Perfil'
CREATE INDEX [IX_FK_Usuario_Perfil]
ON [dbo].[Usuario]
    ([ClavePerfil]);
GO

-- Creating foreign key on [TipoPregunta] in table 'Pregunta'
ALTER TABLE [dbo].[Pregunta]
ADD CONSTRAINT [FK_Pregunta_ValorReferencia]
    FOREIGN KEY ([TipoPregunta])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregunta_ValorReferencia'
CREATE INDEX [IX_FK_Pregunta_ValorReferencia]
ON [dbo].[Pregunta]
    ([TipoPregunta]);
GO

-- Creating foreign key on [IdPregunta] in table 'PreguntaOpcion'
ALTER TABLE [dbo].[PreguntaOpcion]
ADD CONSTRAINT [FK_PreguntaOpcion_Pregunta]
    FOREIGN KEY ([IdPregunta])
    REFERENCES [dbo].[Pregunta]
        ([IdPregunta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PreguntaOpcion_Pregunta'
CREATE INDEX [IX_FK_PreguntaOpcion_Pregunta]
ON [dbo].[PreguntaOpcion]
    ([IdPregunta]);
GO

-- Creating foreign key on [IdPregunta] in table 'RespuestaEncuesta'
ALTER TABLE [dbo].[RespuestaEncuesta]
ADD CONSTRAINT [FK_RespuestaEncuesta_Pregunta]
    FOREIGN KEY ([IdPregunta])
    REFERENCES [dbo].[Pregunta]
        ([IdPregunta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RespuestaEncuesta_Pregunta'
CREATE INDEX [IX_FK_RespuestaEncuesta_Pregunta]
ON [dbo].[RespuestaEncuesta]
    ([IdPregunta]);
GO

-- Creating foreign key on [ClaveRegion] in table 'Sucursal'
ALTER TABLE [dbo].[Sucursal]
ADD CONSTRAINT [FK_Sucursal_Region]
    FOREIGN KEY ([ClaveRegion])
    REFERENCES [dbo].[Region]
        ([ClaveRegion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sucursal_Region'
CREATE INDEX [IX_FK_Sucursal_Region]
ON [dbo].[Sucursal]
    ([ClaveRegion]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'Terminal'
ALTER TABLE [dbo].[Terminal]
ADD CONSTRAINT [FK_Terminal_Sucursal]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Terminal_Sucursal'
CREATE INDEX [IX_FK_Terminal_Sucursal]
ON [dbo].[Terminal]
    ([ClaveSucursal]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Usuario_Sucursal]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Usuario_Sucursal'
CREATE INDEX [IX_FK_Usuario_Sucursal]
ON [dbo].[Usuario]
    ([ClaveSucursal]);
GO

-- Creating foreign key on [ClaveSucursal] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [FK_Vehiculo_Sucursal]
    FOREIGN KEY ([ClaveSucursal])
    REFERENCES [dbo].[Sucursal]
        ([ClaveSucursal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_Sucursal'
CREATE INDEX [IX_FK_Vehiculo_Sucursal]
ON [dbo].[Vehiculo]
    ([ClaveSucursal]);
GO

-- Creating foreign key on [ClaveSuscriptor] in table 'SuscriptorVisitado'
ALTER TABLE [dbo].[SuscriptorVisitado]
ADD CONSTRAINT [FK_SuscriptorVisitado_Suscriptor]
    FOREIGN KEY ([ClaveSuscriptor])
    REFERENCES [dbo].[Suscriptor]
        ([ClaveSuscriptor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClaveSuscriptor] in table 'Visita'
ALTER TABLE [dbo].[Visita]
ADD CONSTRAINT [FK_Visita_Suscriptor]
    FOREIGN KEY ([ClaveSuscriptor])
    REFERENCES [dbo].[Suscriptor]
        ([ClaveSuscriptor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Visita_Suscriptor'
CREATE INDEX [IX_FK_Visita_Suscriptor]
ON [dbo].[Visita]
    ([ClaveSuscriptor]);
GO

-- Creating foreign key on [IdVisita] in table 'SuscriptorVisitado'
ALTER TABLE [dbo].[SuscriptorVisitado]
ADD CONSTRAINT [FK_SuscriptorVisitado_Visita]
    FOREIGN KEY ([IdVisita])
    REFERENCES [dbo].[Visita]
        ([IdVisita])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SuscriptorVisitado_Visita'
CREATE INDEX [IX_FK_SuscriptorVisitado_Visita]
ON [dbo].[SuscriptorVisitado]
    ([IdVisita]);
GO

-- Creating foreign key on [Fase] in table 'Terminal'
ALTER TABLE [dbo].[Terminal]
ADD CONSTRAINT [FK_Terminal_ValorReferencia]
    FOREIGN KEY ([Fase])
    REFERENCES [dbo].[ValorReferencia]
        ([Valor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Terminal_ValorReferencia'
CREATE INDEX [IX_FK_Terminal_ValorReferencia]
ON [dbo].[Terminal]
    ([Fase]);
GO

-- Creating foreign key on [ClaveTrabajo] in table 'TrabajoMaterial'
ALTER TABLE [dbo].[TrabajoMaterial]
ADD CONSTRAINT [FK_TrabajoMaterial_Trabajo]
    FOREIGN KEY ([ClaveTrabajo])
    REFERENCES [dbo].[Trabajo]
        ([ClaveTrabajo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actividad_ClaveActividad] in table 'ActividadPerfil'
ALTER TABLE [dbo].[ActividadPerfil]
ADD CONSTRAINT [FK_ActividadPerfil_Actividad]
    FOREIGN KEY ([Actividad_ClaveActividad])
    REFERENCES [dbo].[Actividad]
        ([ClaveActividad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Perfil_ClavePerfil] in table 'ActividadPerfil'
ALTER TABLE [dbo].[ActividadPerfil]
ADD CONSTRAINT [FK_ActividadPerfil_Perfil]
    FOREIGN KEY ([Perfil_ClavePerfil])
    REFERENCES [dbo].[Perfil]
        ([ClavePerfil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadPerfil_Perfil'
CREATE INDEX [IX_FK_ActividadPerfil_Perfil]
ON [dbo].[ActividadPerfil]
    ([Perfil_ClavePerfil]);
GO

-- Creating foreign key on [NumeroSerieEquipoDigital_NumeroSerieEquipoDigital1] in table 'OrdenTrabajoEquipoDigital'
ALTER TABLE [dbo].[OrdenTrabajoEquipoDigital]
ADD CONSTRAINT [FK_OrdenTrabajoEquipoDigital_NumeroSerieEquipoDigital]
    FOREIGN KEY ([NumeroSerieEquipoDigital_NumeroSerieEquipoDigital1])
    REFERENCES [dbo].[NumeroSerieEquipoDigital]
        ([NumeroSerieEquipoDigital1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OrdenTrabajo_FolioOrden] in table 'OrdenTrabajoEquipoDigital'
ALTER TABLE [dbo].[OrdenTrabajoEquipoDigital]
ADD CONSTRAINT [FK_OrdenTrabajoEquipoDigital_OrdenTrabajo]
    FOREIGN KEY ([OrdenTrabajo_FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenTrabajoEquipoDigital_OrdenTrabajo'
CREATE INDEX [IX_FK_OrdenTrabajoEquipoDigital_OrdenTrabajo]
ON [dbo].[OrdenTrabajoEquipoDigital]
    ([OrdenTrabajo_FolioOrden]);
GO

-- Creating foreign key on [OrdenTrabajo1_FolioOrden] in table 'ServiciosAdicionales'
ALTER TABLE [dbo].[ServiciosAdicionales]
ADD CONSTRAINT [FK_ServiciosAdicionales_OrdenTrabajo]
    FOREIGN KEY ([OrdenTrabajo1_FolioOrden])
    REFERENCES [dbo].[OrdenTrabajo]
        ([FolioOrden])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Trabajo1_ClaveTrabajo] in table 'ServiciosAdicionales'
ALTER TABLE [dbo].[ServiciosAdicionales]
ADD CONSTRAINT [FK_ServiciosAdicionales_Trabajo]
    FOREIGN KEY ([Trabajo1_ClaveTrabajo])
    REFERENCES [dbo].[Trabajo]
        ([ClaveTrabajo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiciosAdicionales_Trabajo'
CREATE INDEX [IX_FK_ServiciosAdicionales_Trabajo]
ON [dbo].[ServiciosAdicionales]
    ([Trabajo1_ClaveTrabajo]);
GO

-- Creating foreign key on [ClaveUsuario] in table 'Cuadrilla'
ALTER TABLE [dbo].[Cuadrilla]
ADD CONSTRAINT [FK_CuadrillaUsuario]
    FOREIGN KEY ([ClaveUsuario])
    REFERENCES [dbo].[Usuario]
        ([ClaveUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CuadrillaUsuario'
CREATE INDEX [IX_FK_CuadrillaUsuario]
ON [dbo].[Cuadrilla]
    ([ClaveUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------