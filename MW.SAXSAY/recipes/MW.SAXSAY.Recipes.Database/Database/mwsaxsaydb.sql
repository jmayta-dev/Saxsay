USE [master];
GO

IF DB_ID(N'MWSAXSAYDB') IS NOT NULL
BEGIN
    DROP DATABASE [MWSAXSAYDB];
END
GO

CREATE DATABASE [MWSAXSAYDB]
    COLLATE SQL_Latin1_General_CP1_CI_AI;
GO
