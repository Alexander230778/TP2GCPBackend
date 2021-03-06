USE [master]
GO
/****** Object:  Database [upctp3-db]    Script Date: 21/08/2018 06:10:04 p.m. ******/
CREATE DATABASE [upctp3-db]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [upctp3-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [upctp3-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [upctp3-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [upctp3-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [upctp3-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [upctp3-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [upctp3-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [upctp3-db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [upctp3-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [upctp3-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [upctp3-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [upctp3-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [upctp3-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [upctp3-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [upctp3-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [upctp3-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [upctp3-db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [upctp3-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [upctp3-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [upctp3-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [upctp3-db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [upctp3-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [upctp3-db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [upctp3-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [upctp3-db] SET RECOVERY FULL 
GO
ALTER DATABASE [upctp3-db] SET  MULTI_USER 
GO
ALTER DATABASE [upctp3-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [upctp3-db] SET DB_CHAINING OFF 
GO
USE [upctp3-db]
GO
/****** Object:  StoredProcedure [dbo].[GCP0001_RFC_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0001_RFC_LIST]
	@rfc_Codigo INT,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT
					T1.rfc_Codigo,
					T2.pro_Nombre,
					T1.rfc_Asunto,
					T1.rfc_FechaSolicitud,
					T3.est_Estado,
					T1.rfc_Descripcion
				FROM
					GCP01_RFC T1 INNER JOIN GPP_Proyecto T2
						ON T2.pro_Codigo=T1.pro_Codigo
					INNER JOIN GCP15_EstadoRfc T3
						ON T3.est_Codigo=T1.est_Codigo
				ORDER BY T1.rfc_Codigo DESC
			END
		ELSE IF @acci=2
			BEGIN
				SELECT
					T1.rfc_Codigo,
					T2.pro_Nombre,
					T1.rfc_Asunto,
					T1.rfc_FechaSolicitud,
					CONVERT(NVARCHAR(10),T1.rfc_FechaSolicitud,110) AS rfc_StrFechaSolicitud,
					T3.est_Estado,
					T1.rfc_Descripcion,
					'Portafolio 01' AS por_Nombre,
					T1.per_Codigo,
					T1.GCP13_EncargadosRFC_per_Codigo,
					T4.per_Nombre,
					T4.per_Email,
					T1.pro_Codigo,
					T5.Nombre,
					T5.NumPortafolio
				FROM
					GCP01_RFC T1 INNER JOIN GPP_Proyecto T2
						ON T2.pro_Codigo=T1.pro_Codigo
					INNER JOIN GCP15_EstadoRfc T3
						ON T3.est_Codigo=T1.est_Codigo
					INNER JOIN GCP11_Persona T4
						ON T4.per_Codigo=T1.per_Codigo
					INNER JOIN GPP_Portafolio T5
						ON T5.NumPortafolio=T2.NumPortafolio
				WHERE
					T1.rfc_Codigo=@rfc_Codigo
			END
	END


GO
/****** Object:  StoredProcedure [dbo].[GCP0002_GR_Requerimiento_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0002_GR_Requerimiento_LIST]
	@rfc_Codigo INT,
	@lir_Codigo INT,
	@acci INT
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT
					T1.lir_Codigo,
					T1.lir_Nombre,
					T1.lir_Resumen,
					T1.lir_Fecha,
					T1.lir_NivelDoc,
					T1.lir_TipoPublicacion,
					T1.lir_semanaMax,
					CONVERT(NUMERIC(17,2),T1.lir_PresupuestoMax) AS lir_Presupuesto,
					T1.GPP_Proyecto_pro_Codigo,
					T2.est_Estado,
					T3.pro_Nombre,
					T1.lir_Prioridad
				FROM
					GR_Requerimiento T1 INNER JOIN GCP16_EstadoRequerimiento T2
						ON T2.est_Codigo=T1.est_Codigo
					INNER JOIN GPP_Proyecto T3 
						ON T3.pro_Codigo=T1.GPP_Proyecto_pro_Codigo
				WHERE
					T1.GPP_Proyecto_pro_Codigo=@lir_Codigo
			END
		ELSE IF @acci=2
			BEGIN
				SELECT
					T1.lir_Codigo,
					T1.lir_Nombre,
					T1.lir_Resumen,
					T1.lir_Fecha,
					T1.lir_NivelDoc,
					T1.lir_TipoPublicacion,
					T1.lir_semanaMax,
					CONVERT(NUMERIC(17,2),T1.lir_PresupuestoMax) AS lir_Presupuesto,
					T1.GPP_Proyecto_pro_Codigo,
					T2.est_Estado,
					T3.pro_Nombre,
					T1.lir_Prioridad
				FROM
					GR_Requerimiento T1 INNER JOIN GCP16_EstadoRequerimiento T2
						ON T2.est_Codigo=T1.est_Codigo
					INNER JOIN GPP_Proyecto T3 
						ON T3.pro_Codigo=T1.GPP_Proyecto_pro_Codigo
					INNER JOIN GCP_RequerimientoMod T4
						ON T4.lir_Codigo=T1.lir_Codigo
				WHERE
					T4.rfc_Codigo=@rfc_Codigo
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0003_TipoRecurso_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0003_TipoRecurso_LIST]
	@acci INT
	
AS
	BEGIN
			IF @acci =1
					BEGIN
						select
							tip_Nombre
						from
						 GCP08_TipoRecurso;
					END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0006_RFC]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0006_RFC]
	@rfc_Codigo int OUTPUT,
	@rfc_FechaSolicitud datetime,
	@rfc_NivelImpacto int,
	@rfc_Asunto nvarchar(255),
	@rfc_Descripcion nvarchar(255),
	@pro_Codigo int,
	@per_Codigo int,
	@GCP13_EncargadosRFC_per_Codigo int,
	@est_Codigo int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SET @rfc_Codigo = ISNULL((SELECT MAX(rfc_Codigo) FROM GCP01_RFC),0)+1			
				INSERT INTO GCP01_RFC
						   (rfc_Codigo
						   ,rfc_FechaSolicitud
						   ,rfc_NivelImpacto
						   ,rfc_Asunto
						   ,rfc_Descripcion
						   ,pro_Codigo
						   ,per_Codigo
						   ,GCP13_EncargadosRFC_per_Codigo
						   ,est_Codigo)
					 VALUES
						   (@rfc_Codigo,
							@rfc_FechaSolicitud,
							@rfc_NivelImpacto,
							@rfc_Asunto,
							@rfc_Descripcion,
							@pro_Codigo,
							@per_Codigo,
							@GCP13_EncargadosRFC_per_Codigo,
							1)
			END
		ELSE IF @acci=2
			BEGIN
				DELETE FROM GCP_BeneficioRFC WHERE rfc_Codigo=@rfc_Codigo
				UPDATE 
					GCP01_RFC
				SET

					rfc_FechaSolicitud=@rfc_FechaSolicitud,
					rfc_NivelImpacto=@rfc_NivelImpacto,
					rfc_Asunto=@rfc_Asunto,
					rfc_Descripcion=@rfc_Descripcion,
					GCP13_EncargadosRFC_per_Codigo=@GCP13_EncargadosRFC_per_Codigo
				WHERE
					rfc_Codigo=@rfc_Codigo
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0007_GCP_Persona_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0007_GCP_Persona_LIST]
	@per_Codigo int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					T1.per_Codigo,
					T1.per_Nombre,
					T1.per_Email,
					T1.per_Codigo AS value,
					T1.per_Nombre+' ('+T1.per_Email+')' AS text
				FROM 
					GCP11_Persona T1 INNER JOIN GCP12_InteresadoRFC T2
						ON T2.per_Codigo=T1.per_Codigo
			END
		ELSE IF @acci=2
			BEGIN
				SELECT 
					T1.per_Codigo,
					T1.per_Nombre,
					T1.per_Email,
					T1.per_Codigo AS value,
					T1.per_Nombre+' ('+T1.per_Email+')' AS text
				FROM 
					GCP11_Persona T1 INNER JOIN GCP13_EncargadosRFC T2
						ON T2.per_Codigo=T1.per_Codigo
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0008_Beneficio_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0008_Beneficio_LIST]
	@rfc_Codigo INT,
	@acci INT
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					ben_Codigo,
					ben_Nombre,
					ben_Codigo AS value,
					ben_Nombre AS text
				FROM
					GCP07_Beneficio
			END
		ELSE IF @acci=2
			BEGIN
				SELECT 
					T1.ben_Codigo,
					T2.ben_Nombre
				FROM
					GCP_BeneficioRFC T1 INNER JOIN GCP07_Beneficio T2
						ON T2.ben_Codigo=T1.ben_Codigo
				WHERE
					T1.rfc_Codigo=@rfc_Codigo
			END
	END


GO
/****** Object:  StoredProcedure [dbo].[GCP0009_BeneficioRFC]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0009_BeneficioRFC]
	@rfc_Codigo int,
	@ben_Codigo int,
	@acci int
AS
	BEGIN
		INSERT INTO GCP_BeneficioRFC
				   (rfc_Codigo
				   ,ben_Codigo)
			 VALUES
				   (@rfc_Codigo,
					@ben_Codigo)		
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0010_TipoRecurso_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0010_TipoRecurso_LIST]
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					T1.tip_Codigo,
					T1.tip_Nombre,
					T2.niv_Nivel,
					T1.tip_Codigo AS value,
					T1.tip_Nombre+' ('+T2.niv_Nivel+') '+CONVERT(NVARCHAR(9),T1.tip_Costo) AS text,
					T1.tip_Costo
				FROM
					GCP08_TipoRecurso T1 INNER JOIN GCP17_NivelRecurso T2
						ON T2.niv_Codigo=T1.tip_Nivel
				ORDER BY T1.tip_Nombre,T2.niv_Nivel
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0011_GR_Requerimiento]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0011_GR_Requerimiento]
	@lir_Codigo int output, 
	@lir_Nombre nvarchar(255), 
	@lir_Resumen nvarchar(255), 
	@lir_FechaEntrega nvarchar(10) output,
	@lir_EsFuncional bit,
	@lir_RequiereDocumentar bit,
	@rfc_Codigo int, 
	@lir_Prioridad int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SET @lir_Codigo = ISNULL((SELECT MAX(lir_Codigo) FROM GR_Requerimiento),0)+1
				INSERT INTO GR_Requerimiento
						   (lir_Codigo
						   ,lir_Fecha
						   ,lir_Nombre
						   ,lir_Resumen
						   ,lir_NivelDoc
						   ,lir_TipoPublicacion
						   ,lir_semanaMax
						   ,lir_PresupuestoMax
						   ,GPP_Proyecto_pro_Codigo
						   ,est_Codigo
						   ,lir_Prioridad
						   ,lir_FechaEntrega
						   ,lir_EsFuncional
						   ,lir_RequiereDocumentar)
					 VALUES
						   (@lir_Codigo,
							GETDATE(),
							@lir_Nombre,
							@lir_Resumen,
							NULL,
							NULL,
							NULL,
							NULL,
							(SELECT pro_Codigo FROM GCP01_RFC WHERE rfc_Codigo=@rfc_Codigo),
							2,
							@lir_Prioridad,
							@lir_FechaEntrega,
						    @lir_EsFuncional,
						    @lir_RequiereDocumentar)
				SET @lir_FechaEntrega = CONVERT(NVARCHAR(10),CONVERT(DATETIME,@lir_FechaEntrega),111)
			END
		ELSE IF @acci=2
			BEGIN
				DELETE FROM GCP09_Recurso WHERE lir_Codigo=@lir_Codigo
				UPDATE  
					GR_Requerimiento 
				   SET   
					    lir_Nombre  = @lir_Nombre,
					    lir_Resumen  = @lir_Resumen,
					    GPP_Proyecto_pro_Codigo  = (SELECT pro_Codigo FROM GCP01_RFC WHERE rfc_Codigo=@rfc_Codigo),
					    lir_Prioridad  = @lir_Prioridad
				 WHERE 
					lir_Codigo=@lir_Codigo

				IF (SELECT COUNT(lir_Codigo) FROM GCP_RequerimientoMod WHERE lir_Codigo=@lir_Codigo)=0
					BEGIN
						INSERT INTO GCP_RequerimientoMod VALUES
							(
								GETDATE(),
								@rfc_Codigo,
								(SELECT pro_Codigo FROM GCP01_RFC WHERE rfc_Codigo=@rfc_Codigo),
								@lir_Codigo
							)
					END
			END
	END



GO
/****** Object:  StoredProcedure [dbo].[GCP0012_GCP18GCP19GCP20_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0012_GCP18GCP19GCP20_LIST]
	@acci INT
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					T1.nivd_Codigo AS value,
					T1.nivd_Nivel AS text
				FROM
					GCP18_NivelDocumento T1

				SELECT 
					T1.tipp_Codigo AS value,
					T1.tipp_Tipo AS text
				FROM
					GCP19_TipoRequerimiento T1

				SELECT 
					T1.pri_Codigo AS value,
					T1.pri_Prioridad AS text
				FROM
					GCP20_PriodidadRequerimiento T1
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCP0013_Recurso]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCP0013_Recurso]
	@rec_Cantidad int,
	@rec_Semanas int,
	@GCP09_Recurso_ID int,
	@lir_Codigo int,
	@tip_Codigo int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				INSERT INTO  GCP09_Recurso 
						   ( rec_Cantidad
						   , rec_Semanas 
						   , GCP09_Recurso_ID 
						   , lir_Codigo  
						   , tip_Codigo )
					 VALUES
						   (@rec_Cantidad,
						    @rec_Semanas,
							ISNULL((SELECT MAX(GCP09_Recurso_ID) FROM GCP09_Recurso),0)+1,
						    @lir_Codigo,
						    @tip_Codigo)
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GCPP0006_GCP_ImpactoRiesgo_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCPP0006_GCP_ImpactoRiesgo_LIST]
AS
	BEGIN
		SELECT 
			imp_Codigo,
			imp_Descripcion 
		FROM 
			GCP_ImpactoRiesgo
	END
GO
/****** Object:  StoredProcedure [dbo].[GCPP0007_GCP_EstadoRiesgo_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCPP0007_GCP_EstadoRiesgo_LIST]
AS
	BEGIN
		SELECT 
			esr_Codigo,
			esr_Descripcion 
		FROM 
			GCP_EstadoRiesgo
	END

GO
/****** Object:  StoredProcedure [dbo].[GCPP0014_GCP_EvaluacionRiesgo]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GCPP0014_GCP_EvaluacionRiesgo]
	@evr_Codigo int OUTPUT,
	@evr_Requiere bit,
	@evr_Estado nvarchar(255),
	@rfc_Codigo int,
	@evr_Observacion nvarchar(512),
	@pri_Codigo int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SET @evr_Codigo = ISNULL((SELECT MAX(evr_Codigo) FROM GCP14_EvaluacionRiesgo),0)+1
				INSERT INTO GCP14_EvaluacionRiesgo
						   (evr_Codigo,
							evr_Requiere,
							evr_FechaEnvio,
							evr_Estado,
							evr_FechaRespuesta,
							evr_Informe,
							evr_Impacto,
							evr_Adjunto,
							evr_Observacion,
							pri_Codigo,
							rfc_Codigo)
					 VALUES
						   (@evr_Codigo,
							@evr_Requiere,
							GETDATE(),
							3, --Evaluado
							DATEADD(DAY,2,GETDATE()),
							'Se realizo la revision de la RFC y se determino que es de impacto menor para el proyecto',
							1, -- BAJO
							'',
							@evr_Observacion,
							@pri_Codigo,
							@rfc_Codigo)
			END
	END



GO
/****** Object:  StoredProcedure [dbo].[GCPP0015_GCP_EvaluacionRiesgo_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GCPP0015_GCP_EvaluacionRiesgo_LIST]
	@rfc_Codigo int
AS
	BEGIN
		SELECT
			evr_Codigo,
			evr_Requiere,
			evr_FechaEnvio=convert(date,evr_FechaEnvio),
			evr_Estado,
			evr_FechaRespuesta=convert(date,evr_FechaRespuesta),
			evr_Informe,
			evr_Impacto,
			evr_Adjunto,
			evr_Observacion,
			pri_Codigo,
			rfc_Codigo
		FROM
			GCP14_EvaluacionRiesgo
		WHERE
			rfc_Codigo=@rfc_Codigo
	END


GO
/****** Object:  StoredProcedure [dbo].[GCPP0016_LiderTecnico_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GCPP0016_LiderTecnico_LIST]
AS
	BEGIN
		SELECT 
			T1.lit_Codigo,
			T2.per_Nombre,
			T2.per_Email,
			T2.per_Telefono
		FROM 
			GCP21_LiderTecnico T1 INNER JOIN GCP11_Persona T2
				ON T2.per_Codigo=T1.per_Codigo
	END
GO
/****** Object:  StoredProcedure [dbo].[GPP0004_GPP_Portafolio_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GPP0004_GPP_Portafolio_LIST]
	@NumPortafolio int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					T1.NumPortafolio AS value,
					T1.Nombre AS text,
					T1.NumPortafolio,
					T1.Nombre,
					T1.Descripción
				FROM
					GPP_Portafolio T1
			END
	END

GO
/****** Object:  StoredProcedure [dbo].[GPP0005_GPP_Proyecto_LIST]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GPP0005_GPP_Proyecto_LIST]
	@pro_Codigo int,
	@NumPortafolio int,
	@acci int
AS
	BEGIN
		IF @acci=1
			BEGIN
				SELECT 
					T1.NumPortafolio,
					T1.pro_Codigo AS value,
					T1.pro_Nombre AS text,
					T1.pro_Codigo,
					T1.pro_Nombre
				FROM
					GPP_Proyecto T1
				WHERE
					T1.NumPortafolio=@NumPortafolio
			END
	END

GO
/****** Object:  Table [dbo].[GCP_BeneficioRFC]    Script Date: 21/08/2018 06:10:04 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP_BeneficioRFC](
	[rfc_Codigo] [int] NOT NULL,
	[ben_Codigo] [int] NOT NULL
)

GO
/****** Object:  Table [dbo].[GCP_EstadoRiesgo]    Script Date: 21/08/2018 06:10:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP_EstadoRiesgo](
	[esr_Codigo] [int] NOT NULL,
	[esr_Descripcion] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[esr_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP_ImpactoRiesgo]    Script Date: 21/08/2018 06:10:05 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP_ImpactoRiesgo](
	[imp_Codigo] [int] NOT NULL,
	[imp_Descripcion] [nvarchar](64) NULL,
PRIMARY KEY CLUSTERED 
(
	[imp_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP_PrioridadRiesgo]    Script Date: 21/08/2018 06:10:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP_PrioridadRiesgo](
	[pri_Codigo] [int] NOT NULL,
	[pri_Descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[pri_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP_RequerimientoMod]    Script Date: 21/08/2018 06:10:08 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP_RequerimientoMod](
	[req_FechaCambio] [datetime] NULL,
	[rfc_Codigo] [int] NULL,
	[pro_Codigo] [int] NULL,
	[lir_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP01_RFC]    Script Date: 21/08/2018 06:10:08 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP01_RFC](
	[rfc_Codigo] [int] NOT NULL,
	[rfc_FechaSolicitud] [datetime] NULL,
	[rfc_NivelImpacto] [int] NULL,
	[rfc_Asunto] [nvarchar](225) NULL,
	[rfc_Descripcion] [nvarchar](225) NULL,
	[pro_Codigo] [int] NULL,
	[per_Codigo] [int] NULL,
	[GCP13_EncargadosRFC_per_Codigo] [int] NULL,
	[est_Codigo] [int] NULL,
 CONSTRAINT [PK_GCP01_RFC] PRIMARY KEY CLUSTERED 
(
	[rfc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP02_EvaluaciónTécnica]    Script Date: 21/08/2018 06:10:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP02_EvaluaciónTécnica](
	[evt_Codigo] [nchar](10) NULL,
	[evt_Fecha] [datetime] NULL,
	[evt_Asunto] [nchar](10) NULL,
	[evt_Descripcion] [nchar](10) NULL,
	[evt_Autor] [nchar](10) NULL,
	[evt_Conclusion] [nchar](10) NULL,
	[rfc_Codigo] [int] NULL,
	[pro_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP04_InformeFinal]    Script Date: 21/08/2018 06:10:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP04_InformeFinal](
	[inf_Codigo] [int] NOT NULL,
	[inf_Fecha] [datetime] NULL,
	[inf_Asunto] [nvarchar](255) NULL,
	[inf_Autor] [nvarchar](255) NULL,
	[rfc_Codigo] [int] NULL,
	[pro_Codigo] [int] NULL,
 CONSTRAINT [PK_GCP04_InformeFinal] PRIMARY KEY CLUSTERED 
(
	[inf_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP07_Beneficio]    Script Date: 21/08/2018 06:10:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP07_Beneficio](
	[ben_Codigo] [int] NOT NULL,
	[ben_Nombre] [nvarchar](255) NULL,
 CONSTRAINT [PK_GCP07_Beneficio] PRIMARY KEY CLUSTERED 
(
	[ben_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP08_TipoRecurso]    Script Date: 21/08/2018 06:10:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP08_TipoRecurso](
	[tip_Codigo] [int] NOT NULL,
	[tip_Nombre] [nvarchar](255) NULL,
	[tip_Nivel] [int] NULL,
	[tip_Costo] [numeric](17, 2) NOT NULL,
 CONSTRAINT [PK_GCP08_TipoRecurso] PRIMARY KEY CLUSTERED 
(
	[tip_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP09_Recurso]    Script Date: 21/08/2018 06:10:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP09_Recurso](
	[rec_Cantidad] [int] NULL,
	[rec_Semanas] [int] NULL,
	[GCP09_Recurso_ID] [int] NULL,
	[lir_Codigo] [int] NULL,
	[tip_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP10_Conclusion]    Script Date: 21/08/2018 06:10:12 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP10_Conclusion](
	[con_Descripción] [nvarchar](255) NULL,
	[rfc_Codigo] [int] NULL,
	[inf_Codigo] [int] NULL,
	[pro_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP11_Persona]    Script Date: 21/08/2018 06:10:13 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP11_Persona](
	[per_Codigo] [int] NOT NULL,
	[per_Nombre] [nvarchar](255) NULL,
	[per_Email] [nvarchar](255) NULL,
	[per_Telefono] [int] NULL,
 CONSTRAINT [PK_GCP11_Persona] PRIMARY KEY CLUSTERED 
(
	[per_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP12_InteresadoRFC]    Script Date: 21/08/2018 06:10:14 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP12_InteresadoRFC](
	[int_telefono] [int] NULL,
	[per_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP13_EncargadosRFC]    Script Date: 21/08/2018 06:10:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP13_EncargadosRFC](
	[enc_Cargo] [nvarchar](255) NULL,
	[enc_planilla] [int] NULL,
	[per_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GCP14_EvaluacionRiesgo]    Script Date: 21/08/2018 06:10:15 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP14_EvaluacionRiesgo](
	[evr_Codigo] [int] NOT NULL,
	[evr_Requiere] [bit] NULL,
	[evr_FechaEnvio] [datetime] NULL,
	[evr_Estado] [nvarchar](255) NULL,
	[evr_FechaRespuesta] [datetime] NULL,
	[evr_Informe] [nvarchar](255) NULL,
	[evr_Impacto] [nvarchar](255) NULL,
	[evr_Adjunto] [nvarchar](255) NULL,
	[rfc_Codigo] [int] NULL,
	[pri_Codigo] [int] NULL,
	[evr_Observacion] [nvarchar](100) NULL,
 CONSTRAINT [PK_GCP14_EvaluacionRiesgo] PRIMARY KEY CLUSTERED 
(
	[evr_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GCP15_EstadoRfc]    Script Date: 21/08/2018 06:10:16 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP15_EstadoRfc](
	[est_Codigo] [int] NOT NULL,
	[est_Estado] [nvarchar](64) NULL
)

GO
/****** Object:  Table [dbo].[GCP16_EstadoRequerimiento]    Script Date: 21/08/2018 06:10:16 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP16_EstadoRequerimiento](
	[est_Codigo] [int] NOT NULL,
	[est_Estado] [nvarchar](64) NULL
)

GO
/****** Object:  Table [dbo].[GCP17_NivelRecurso]    Script Date: 21/08/2018 06:10:18 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP17_NivelRecurso](
	[niv_Codigo] [int] NOT NULL,
	[niv_Nivel] [nvarchar](64) NULL
)

GO
/****** Object:  Table [dbo].[GCP18_NivelDocumento]    Script Date: 21/08/2018 06:10:19 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP18_NivelDocumento](
	[nivd_Codigo] [int] NOT NULL,
	[nivd_Nivel] [nvarchar](64) NOT NULL
)

GO
/****** Object:  Table [dbo].[GCP19_TipoRequerimiento]    Script Date: 21/08/2018 06:10:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP19_TipoRequerimiento](
	[tipp_Codigo] [int] NOT NULL,
	[tipp_Tipo] [nvarchar](64) NOT NULL
)

GO
/****** Object:  Table [dbo].[GCP20_PriodidadRequerimiento]    Script Date: 21/08/2018 06:10:20 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP20_PriodidadRequerimiento](
	[pri_Codigo] [int] NOT NULL,
	[pri_Prioridad] [nvarchar](64) NOT NULL
)

GO
/****** Object:  Table [dbo].[GCP21_LiderTecnico]    Script Date: 21/08/2018 06:10:21 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GCP21_LiderTecnico](
	[lit_Codigo] [int] NULL,
	[per_Codigo] [int] NULL
)

GO
/****** Object:  Table [dbo].[GPP_Portafolio]    Script Date: 21/08/2018 06:10:21 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPP_Portafolio](
	[NumPortafolio] [int] NOT NULL,
	[Nombre] [nvarchar](128) NOT NULL,
	[Descripción] [nvarchar](512) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaFinal] [datetime] NOT NULL,
	[Prioridad] [nvarchar](64) NOT NULL,
	[Observaciones] [nvarchar](512) NOT NULL,
	[Estado] [nvarchar](64) NOT NULL
)

GO
/****** Object:  Table [dbo].[GPP_Proyecto]    Script Date: 21/08/2018 06:10:22 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPP_Proyecto](
	[pro_Codigo] [int] NOT NULL,
	[pro_Nombre] [nvarchar](255) NULL,
	[NumPortafolio] [int] NULL,
 CONSTRAINT [PK_GPP_Proyecto] PRIMARY KEY CLUSTERED 
(
	[pro_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GR_Requerimiento]    Script Date: 21/08/2018 06:10:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GR_Requerimiento](
	[lir_Codigo] [int] NOT NULL,
	[lir_Fecha] [datetime] NULL,
	[lir_Nombre] [nvarchar](255) NULL,
	[lir_Resumen] [nvarchar](255) NULL,
	[lir_NivelDoc] [int] NULL,
	[lir_TipoPublicacion] [int] NULL,
	[lir_semanaMax] [nvarchar](255) NULL,
	[lir_PresupuestoMax] [numeric](17, 2) NULL,
	[GPP_Proyecto_pro_Codigo] [int] NULL,
	[est_Codigo] [int] NULL,
	[lir_Prioridad] [int] NULL,
	[lir_FechaEntrega] [datetime] NULL,
	[lir_EsFuncional] [bit] NULL,
	[lir_RequiereDocumentar] [bit] NULL,
 CONSTRAINT [PK_GR_Requerimiento] PRIMARY KEY CLUSTERED 
(
	[lir_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (6, 1)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (6, 5)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (5, 1)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (5, 3)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (4, 5)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (4, 4)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (3, 1)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (3, 4)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (3, 5)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (6, 2)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (7, 1)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (9, 3)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (8, 1)
INSERT [dbo].[GCP_BeneficioRFC] ([rfc_Codigo], [ben_Codigo]) VALUES (8, 3)
INSERT [dbo].[GCP_EstadoRiesgo] ([esr_Codigo], [esr_Descripcion]) VALUES (1, N'Enviado')
INSERT [dbo].[GCP_EstadoRiesgo] ([esr_Codigo], [esr_Descripcion]) VALUES (2, N'En Proceso')
INSERT [dbo].[GCP_EstadoRiesgo] ([esr_Codigo], [esr_Descripcion]) VALUES (3, N'Evaluado')
INSERT [dbo].[GCP_ImpactoRiesgo] ([imp_Codigo], [imp_Descripcion]) VALUES (1, N'Bajo')
INSERT [dbo].[GCP_ImpactoRiesgo] ([imp_Codigo], [imp_Descripcion]) VALUES (2, N'Medio')
INSERT [dbo].[GCP_ImpactoRiesgo] ([imp_Codigo], [imp_Descripcion]) VALUES (3, N'Alto')
INSERT [dbo].[GCP_PrioridadRiesgo] ([pri_Codigo], [pri_Descripcion]) VALUES (1, N'Bajo')
INSERT [dbo].[GCP_PrioridadRiesgo] ([pri_Codigo], [pri_Descripcion]) VALUES (2, N'Medio')
INSERT [dbo].[GCP_PrioridadRiesgo] ([pri_Codigo], [pri_Descripcion]) VALUES (3, N'Alto')
INSERT [dbo].[GCP07_Beneficio] ([ben_Codigo], [ben_Nombre]) VALUES (1, N'Disminución en el presupuesto')
INSERT [dbo].[GCP07_Beneficio] ([ben_Codigo], [ben_Nombre]) VALUES (2, N'Dosminución en tiempo de desarrollo')
INSERT [dbo].[GCP07_Beneficio] ([ben_Codigo], [ben_Nombre]) VALUES (3, N'Mejor aprovechamiento de recursos')
INSERT [dbo].[GCP07_Beneficio] ([ben_Codigo], [ben_Nombre]) VALUES (4, N'Mejora en la tecnología')
INSERT [dbo].[GCP07_Beneficio] ([ben_Codigo], [ben_Nombre]) VALUES (5, N'Mejora en la documentación')
INSERT [dbo].[GCP08_TipoRecurso] ([tip_Codigo], [tip_Nombre], [tip_Nivel], [tip_Costo]) VALUES (1, N'Front End', 2, CAST(3000.00 AS Numeric(17, 2)))
INSERT [dbo].[GCP08_TipoRecurso] ([tip_Codigo], [tip_Nombre], [tip_Nivel], [tip_Costo]) VALUES (3, N'Front End', 1, CAST(2000.00 AS Numeric(17, 2)))
INSERT [dbo].[GCP08_TipoRecurso] ([tip_Codigo], [tip_Nombre], [tip_Nivel], [tip_Costo]) VALUES (4, N'Analista de calidad', 1, CAST(2500.00 AS Numeric(17, 2)))
INSERT [dbo].[GCP08_TipoRecurso] ([tip_Codigo], [tip_Nombre], [tip_Nivel], [tip_Costo]) VALUES (5, N'Analista de calidad', 2, CAST(3500.00 AS Numeric(17, 2)))
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (1, 1, 1, 8, 3)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (1, 4, 4, 9, 4)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (1, 2, 5, 9, 3)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (4, 1, 6, 10, 5)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (1, 1, 2, 8, 1)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (2, 1, 3, 8, 5)
INSERT [dbo].[GCP09_Recurso] ([rec_Cantidad], [rec_Semanas], [GCP09_Recurso_ID], [lir_Codigo], [tip_Codigo]) VALUES (2, 4, 7, 11, 4)
INSERT [dbo].[GCP11_Persona] ([per_Codigo], [per_Nombre], [per_Email], [per_Telefono]) VALUES (1, N'Oscar Lujan Cuadros', N'olujan@corp.com', 992298765)
INSERT [dbo].[GCP11_Persona] ([per_Codigo], [per_Nombre], [per_Email], [per_Telefono]) VALUES (2, N'Pedro Morales Ceijas', N'pmorales@corp.com', 998876545)
INSERT [dbo].[GCP11_Persona] ([per_Codigo], [per_Nombre], [per_Email], [per_Telefono]) VALUES (3, N'Manuel Martinez Orosco', N'mmartinez@corp.com', 908765670)
INSERT [dbo].[GCP12_InteresadoRFC] ([int_telefono], [per_Codigo]) VALUES (997786543, 2)
INSERT [dbo].[GCP13_EncargadosRFC] ([enc_Cargo], [enc_planilla], [per_Codigo]) VALUES (N'Analista de sistemas', 3000, 3)
INSERT [dbo].[GCP13_EncargadosRFC] ([enc_Cargo], [enc_planilla], [per_Codigo]) VALUES (N'Jefe de proyecto', 6000, 1)
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (1, N'Nueva')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (2, N'Evaluada tecnicamente')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (3, N'Evaluada en riesgo')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (4, N'En planificación')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (5, N'Planificada')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (6, N'Cerrada aprobada')
INSERT [dbo].[GCP15_EstadoRfc] ([est_Codigo], [est_Estado]) VALUES (7, N'Cerrada desaprobada')
INSERT [dbo].[GCP16_EstadoRequerimiento] ([est_Codigo], [est_Estado]) VALUES (1, N'Terminado')
INSERT [dbo].[GCP16_EstadoRequerimiento] ([est_Codigo], [est_Estado]) VALUES (2, N'Pendiente')
INSERT [dbo].[GCP16_EstadoRequerimiento] ([est_Codigo], [est_Estado]) VALUES (3, N'Cancelado')
INSERT [dbo].[GCP17_NivelRecurso] ([niv_Codigo], [niv_Nivel]) VALUES (1, N'Junior')
INSERT [dbo].[GCP17_NivelRecurso] ([niv_Codigo], [niv_Nivel]) VALUES (2, N'Senior')
INSERT [dbo].[GCP18_NivelDocumento] ([nivd_Codigo], [nivd_Nivel]) VALUES (1, N'Nivel I')
INSERT [dbo].[GCP18_NivelDocumento] ([nivd_Codigo], [nivd_Nivel]) VALUES (2, N'Nivel II')
INSERT [dbo].[GCP18_NivelDocumento] ([nivd_Codigo], [nivd_Nivel]) VALUES (3, N'Nivel III')
INSERT [dbo].[GCP18_NivelDocumento] ([nivd_Codigo], [nivd_Nivel]) VALUES (4, N'Nivel IV')
INSERT [dbo].[GCP19_TipoRequerimiento] ([tipp_Codigo], [tipp_Tipo]) VALUES (1, N'Funcional')
INSERT [dbo].[GCP19_TipoRequerimiento] ([tipp_Codigo], [tipp_Tipo]) VALUES (2, N'No funcional')
INSERT [dbo].[GCP20_PriodidadRequerimiento] ([pri_Codigo], [pri_Prioridad]) VALUES (1, N'Alta')
INSERT [dbo].[GCP20_PriodidadRequerimiento] ([pri_Codigo], [pri_Prioridad]) VALUES (2, N'Media')
INSERT [dbo].[GCP20_PriodidadRequerimiento] ([pri_Codigo], [pri_Prioridad]) VALUES (3, N'Baja')
INSERT [dbo].[GCP21_LiderTecnico] ([lit_Codigo], [per_Codigo]) VALUES (1, 2)
INSERT [dbo].[GCP21_LiderTecnico] ([lit_Codigo], [per_Codigo]) VALUES (2, 3)
INSERT [dbo].[GPP_Portafolio] ([NumPortafolio], [Nombre], [Descripción], [FechaCreacion], [FechaFinal], [Prioridad], [Observaciones], [Estado]) VALUES (1, N'Automatización institucional', N'Todos los procesos de la empresa', CAST(0x0000A8D000C9837F AS DateTime), CAST(0x0000A95700000000 AS DateTime), N'Alta', N'Ninguna', N'Abierto')
INSERT [dbo].[GPP_Portafolio] ([NumPortafolio], [Nombre], [Descripción], [FechaCreacion], [FechaFinal], [Prioridad], [Observaciones], [Estado]) VALUES (2, N'Propuesta de nueva tecnología', N'Abarca todos los mercados de tecnologia móvil', CAST(0x0000A8D000C9837F AS DateTime), CAST(0x0000A9C800000000 AS DateTime), N'Alta', N'ok', N'Abierto')
INSERT [dbo].[GPP_Proyecto] ([pro_Codigo], [pro_Nombre], [NumPortafolio]) VALUES (1, N'Automatización del proceso de alumnado en CEP Witman', 1)
INSERT [dbo].[GPP_Proyecto] ([pro_Codigo], [pro_Nombre], [NumPortafolio]) VALUES (2, N'Automatización del proceso de importaciones Neptunia', 2)
USE [master]
GO
ALTER DATABASE [upctp3-db] SET  READ_WRITE 
GO
