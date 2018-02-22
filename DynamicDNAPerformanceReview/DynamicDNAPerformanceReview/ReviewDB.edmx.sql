
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2018 15:45:17
-- Generated from EDMX file: C:\Users\admin\Documents\Lucky\DynamicDNAPerformanceReview\DynamicDNAPerformanceReview\Reviewdb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMRS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ReviewTable_Management]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewTables] DROP CONSTRAINT [FK_ReviewTable_Management];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewTable_UserAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewTables] DROP CONSTRAINT [FK_ReviewTable_UserAccounts];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Managements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managements];
GO
IF OBJECT_ID(N'[dbo].[ReviewTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReviewTables];
GO
IF OBJECT_ID(N'[dbo].[UserAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAccounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Managements'
CREATE TABLE [dbo].[Managements] (
    [ManagementID] int IDENTITY(1,1) NOT NULL,
    [Lastname] nvarchar(150)  NOT NULL,
    [Firstname] nvarchar(150)  NOT NULL,
    [Username] nvarchar(150)  NOT NULL,
    [Password] nvarchar(150)  NOT NULL,
    [ComfirmPassword] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'ReviewTables'
CREATE TABLE [dbo].[ReviewTables] (
    [ReviewID] int IDENTITY(1,1) NOT NULL,
    [fkManagementID] int  NULL,
    [fkEmployeeId] int  NULL,
    [RoleOnProject] nvarchar(150)  NULL,
    [ProjectEngagement] nvarchar(250)  NULL,
    [LineManager] nvarchar(150)  NULL,
    [DateOfReview] datetime  NULL,
    [PeriodOfReview] nvarchar(max)  NULL,
    [proPeer] nvarchar(max)  NULL,
    [ProManagement] nvarchar(max)  NULL,
    [proAgreed] nvarchar(max)  NULL,
    [ExPeer] nvarchar(max)  NULL,
    [ExMan] nvarchar(max)  NULL,
    [ExAgreed] nvarchar(max)  NULL,
    [JudPeer] nvarchar(max)  NULL,
    [JudMan] nvarchar(max)  NULL,
    [JudAgreed] nvarchar(max)  NULL,
    [IntPeer] nvarchar(max)  NULL,
    [IntMan] nvarchar(max)  NULL,
    [IntAgreed] nvarchar(max)  NULL,
    [JobPeer] nvarchar(max)  NULL,
    [JobMan] nvarchar(max)  NULL,
    [JobAgreed] nvarchar(max)  NULL,
    [PassPeer] nvarchar(max)  NULL,
    [PassMan] nvarchar(max)  NULL,
    [PassAgreed] nvarchar(max)  NULL,
    [TeaPeer] nvarchar(max)  NULL,
    [TeaMan] nvarchar(max)  NULL,
    [TeaAgreed] nvarchar(max)  NULL,
    [GroPeer] nvarchar(max)  NULL,
    [GroMan] nvarchar(max)  NULL,
    [GroAgreed] nvarchar(max)  NULL,
    [OverallAverage] nvarchar(max)  NULL,
    [GeneralComments] nvarchar(max)  NULL,
    [prComments] nvarchar(max)  NULL,
    [ExComments] nvarchar(max)  NULL,
    [JuComments] nvarchar(max)  NULL,
    [intComments] nvarchar(max)  NULL,
    [JobComments] nvarchar(max)  NULL,
    [PassComments] nvarchar(max)  NULL,
    [TeaComments] nvarchar(max)  NULL,
    [GroComments] nvarchar(max)  NULL,
    [CareerPlans] nvarchar(max)  NULL,
    [ObjectivesNextPeriod] nvarchar(max)  NULL,
    [DueDate] datetime  NULL,
    [OverallAVGman] nvarchar(50)  NULL,
    [OverallAVGAgreed] nvarchar(50)  NULL,
    [GrandAverage] nvarchar(50)  NULL
);
GO

-- Creating table 'UserAccounts'
CREATE TABLE [dbo].[UserAccounts] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] varchar(150)  NOT NULL,
    [EmployeeSurname] varchar(150)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(150)  NOT NULL,
    [ComfirmPassword] nvarchar(150)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ManagementID] in table 'Managements'
ALTER TABLE [dbo].[Managements]
ADD CONSTRAINT [PK_Managements]
    PRIMARY KEY CLUSTERED ([ManagementID] ASC);
GO

-- Creating primary key on [ReviewID] in table 'ReviewTables'
ALTER TABLE [dbo].[ReviewTables]
ADD CONSTRAINT [PK_ReviewTables]
    PRIMARY KEY CLUSTERED ([ReviewID] ASC);
GO

-- Creating primary key on [UserID] in table 'UserAccounts'
ALTER TABLE [dbo].[UserAccounts]
ADD CONSTRAINT [PK_UserAccounts]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fkManagementID] in table 'ReviewTables'
ALTER TABLE [dbo].[ReviewTables]
ADD CONSTRAINT [FK_ReviewTable_Management]
    FOREIGN KEY ([fkManagementID])
    REFERENCES [dbo].[Managements]
        ([ManagementID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewTable_Management'
CREATE INDEX [IX_FK_ReviewTable_Management]
ON [dbo].[ReviewTables]
    ([fkManagementID]);
GO

-- Creating foreign key on [fkEmployeeId] in table 'ReviewTables'
ALTER TABLE [dbo].[ReviewTables]
ADD CONSTRAINT [FK_ReviewTable_UserAccounts]
    FOREIGN KEY ([fkEmployeeId])
    REFERENCES [dbo].[UserAccounts]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewTable_UserAccounts'
CREATE INDEX [IX_FK_ReviewTable_UserAccounts]
ON [dbo].[ReviewTables]
    ([fkEmployeeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------