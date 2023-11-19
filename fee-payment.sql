USE [master]
GO
/****** Object:  Database [SchoolDB]  ******/
CREATE DATABASE [SchoolDB]

GO
USE [SchoolDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO


IF SCHEMA_ID(N'school') IS NULL EXEC(N'CREATE SCHEMA [school];');
GO

CREATE TABLE [school].[Student] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [StudentNumber] nvarchar(20) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [Phone] nvarchar(20) NOT NULL,
    [Address] nvarchar(200) NOT NULL,
    [DOB] datetime2 NOT NULL,
    [Grade] nvarchar(50) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    [UpdatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [school].[FeePayment] (
    [Id] int NOT NULL IDENTITY,
    [FeeAmount] decimal(16,2) NOT NULL,
    [IsPaid] bit NOT NULL,
    [PaidDate] datetime2 NOT NULL,
    [FeeYear] int NOT NULL,
    [Remarks] nvarchar(200) NOT NULL,
    [StudentId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    [UpdatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_FeePayment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FeePayment_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [school].[Student] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedBy', N'CreatedDate', N'DOB', N'Email', N'FirstName', N'Grade', N'LastName', N'Phone', N'StudentNumber', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[school].[Student]'))
    SET IDENTITY_INSERT [school].[Student] ON;
INSERT INTO [school].[Student] ([Id], [Address], [CreatedBy], [CreatedDate], [DOB], [Email], [FirstName], [Grade], [LastName], [Phone], [StudentNumber], [UpdatedBy], [UpdatedDate])
VALUES (1, N'Islamabad, Pakistan', N'system user', '2023-11-19T18:05:26.3228581+05:00', '0001-01-01T00:00:00.0000000', N'jahanzab@live.com', N'Jahnzab', N'First', N'Ashraf', N'+92 334 6168078', N'00001', N'system user', '2023-11-19T18:05:26.3228592+05:00'),
(2, N'NY, USA', N'system user', '2023-11-19T18:05:26.3228595+05:00', '0001-01-01T00:00:00.0000000', N'john.doe@live.com', N'John', N'Second', N'Doe', N'+1 (555) 555-1234', N'00002', N'system user', '2023-11-19T18:05:26.3228595+05:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'CreatedBy', N'CreatedDate', N'DOB', N'Email', N'FirstName', N'Grade', N'LastName', N'Phone', N'StudentNumber', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[school].[Student]'))
    SET IDENTITY_INSERT [school].[Student] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'FeeAmount', N'FeeYear', N'IsPaid', N'PaidDate', N'Remarks', N'StudentId', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[school].[FeePayment]'))
    SET IDENTITY_INSERT [school].[FeePayment] ON;
INSERT INTO [school].[FeePayment] ([Id], [CreatedBy], [CreatedDate], [FeeAmount], [FeeYear], [IsPaid], [PaidDate], [Remarks], [StudentId], [UpdatedBy], [UpdatedDate])
VALUES (1, N'system user', '2023-11-19T18:05:26.3228632+05:00', 102.21, 2023, CAST(1 AS bit), '2023-11-19T18:05:26.3228631+05:00', N'Fee paid', 1, N'system user', '2023-11-19T18:05:26.3228632+05:00'),
(2, N'system user', '2023-11-19T18:05:26.3228634+05:00', 90.5, 2023, CAST(1 AS bit), '2023-11-19T18:05:26.3228634+05:00', N'Fee paid', 2, N'system user', '2023-11-19T18:05:26.3228635+05:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'FeeAmount', N'FeeYear', N'IsPaid', N'PaidDate', N'Remarks', N'StudentId', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[school].[FeePayment]'))
    SET IDENTITY_INSERT [school].[FeePayment] OFF;
GO

CREATE INDEX [IX_FeePayment_StudentId] ON [school].[FeePayment] ([StudentId]);
GO

CREATE UNIQUE INDEX [IX_Student_StudentNumber] ON [school].[Student] ([StudentNumber]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231119130526_run context migration and seed data', N'7.0.14');
GO

COMMIT;
GO

